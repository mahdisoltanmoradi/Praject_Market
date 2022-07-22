using Common;
using Common.Enums;
using Data.Contracts.Catalogs.CatalogItems;
using Data.Contracts.UriComposer;
using Data.DTOs;
using Data.DTOs.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Repositories.Catalogs
{
    public class GetCatalogIItemPLPRepository : IGetCatalogIItemPLPRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IUriComposerRepository uriComposerRepository;

        public GetCatalogIItemPLPRepository(ApplicationDbContext context, IUriComposerRepository uriComposerRepository = null)
        {
            this.context = context;
            this.uriComposerRepository = uriComposerRepository;
        }

        public PaginatedItemsDto<CatalogPLPDto> Execute(CatlogPLPRequestDto request)
        {
            int rowCount = 0;
            var query = context.CatalogItems
                .Include(p => p.Discounts)
                .Include(p => p.CatalogItemImages)
                .OrderByDescending(p => p.Id)
                .AsQueryable();

            if (request.brandId != null)
            {
                query = query.Where(p => request.brandId.Any(b => b == p.CatalogBrandId));
            }

            if (request.CatalogTypeId != null)
            {
                query = query.Where(p => p.CatalogTypeId == request.CatalogTypeId);
            }

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                query = query.Where(p => p.Name.Contains(request.SearchKey)
                || p.Description.Contains(request.SearchKey));
            }

            if (request.AvailableStock == true)
            {
                query = query.Where(p => p.AvailableStock > 0);
            }


            if (request.SortType == SortType.Bestselling)
            {
                query = query.Include(p => p.OrderDetails)
                    .OrderByDescending(p => p.OrderDetails.Count());
            }

            if (request.SortType == SortType.MostPopular)
            {
                query = query.Include(p => p.CatalogItemFavourites)
                    .OrderByDescending(p => p.CatalogItemFavourites.Count());
            }
            if (request.SortType == SortType.MostVisited)
            {
                query = query
                    .OrderByDescending(p => p.VisitCount);
            }

            if (request.SortType == SortType.newest)
            {
                query = query
                    .OrderByDescending(p => p.Id);
            }

            if (request.SortType == SortType.cheapest)
            {
                query = query
                    .Include(p => p.Discounts)
                    .OrderBy(p => p.Price);
            }

            if (request.SortType == SortType.mostExpensive)
            {
                query = query
                    .Include(p => p.Discounts)
                    .OrderByDescending(p => p.Price);
            }

            var data = query.PagedResult(request.page, request.pageSize, out rowCount)
                .ToList()
                .Select(p => new CatalogPLPDto
                {
                    Id = p.Id,
                    Slug = p.Slug,
                    Name = p.Name,
                    Price = p.Price,
                    Rate = 4,
                    Image = uriComposerRepository
                    .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                    AvailableStock = p.AvailableStock,
                }).ToList();
            return new PaginatedItemsDto<CatalogPLPDto>(request.page, request.pageSize, rowCount, data);
        }
    }
}
