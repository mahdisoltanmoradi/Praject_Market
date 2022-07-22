using AutoMapper;
using Common;
using Data.Contracts.CatalogItems;
using Data.Contracts.Catalogs.CatalogItems;
using Data.Contracts.UriComposer;
using Data.DTOs;
using Data.DTOs.Brands;
using Data.DTOs.Catalogs;
using Data.DTOs.Catalogs.CatalogTypes;
using Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Catalogs
{
    public class CatalogItemRepository : ICatalogItemRepository,IScopedDependency
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly IUriComposerRepository _uriComposerRepository;

        public CatalogItemRepository(ApplicationDbContext dbContext, IUriComposerRepository uriComposerRepository = null, IMapper mapper = null)
        {
            _context = dbContext;
            _uriComposerRepository = uriComposerRepository;
            this.mapper = mapper;
        }



        public void AddToMyFavourite(string UserId, int CatalogItemId)
        {
            var catalogItem = _context.CatalogItems.Find(CatalogItemId);
            CatalogItemFavourite catalogItemFavourite = new CatalogItemFavourite
            {
                CatalogItem = catalogItem,
                UserId = UserId,
            };
            _context.CatalogItemFavourites.Add(catalogItemFavourite);
            _context.SaveChanges();
        }

        public List<CatalogBrandDto> GetBrand()
        {
            var brands = _context.CatalogBrands
           .OrderBy(p => p.Brand).Take(500).ToList();

            var data = mapper.Map<List<CatalogBrandDto>>(brands);
            return data;
        }

        public PaginatedItemsDto<CatalogItemListItemDto> GetCatalogList(int page, int pageSize)
        {
            int rowCount = 0;
            var data = _context.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .ToPaged(page, pageSize, out rowCount)
                .OrderByDescending(p => p.Id)
                .Select(p => new CatalogItemListItemDto
                {
                    Id = p.Id,
                    Brand = p.CatalogBrand.Brand,
                    Type = p.CatalogType.Type,
                    AvailableStock = p.AvailableStock,
                    MaxStockThreshold = p.MaxStockThreshold,
                    RestockThreshold = p.RestockThreshold,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

            return new PaginatedItemsDto<CatalogItemListItemDto>(page, page, rowCount, data);
        }

        public List<ListCatalogTypeDto> GetCatalogType()
        {
            var types = _context.CatalogTypes
               .Include(p => p.ParentCatalogType)
               .Include(p => p.ParentCatalogType)
               .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
                .Include(p => p.SubType)
                .Where(p => p.ParentCatalogTypeId != null)
                .Where(p => p.SubType.Count == 0)
                 .Select(p => new { p.Id, p.Type, p.ParentCatalogType, p.SubType })
                                .ToList()
                .Select(p => new ListCatalogTypeDto
                {
                    Id = p.Id,
                    Type = $"{p?.Type ?? ""} - {p?.ParentCatalogType?.Type ?? ""} - {p?.ParentCatalogType?.ParentCatalogType?.Type ?? ""}"
                }).ToList();
            return types;
        }

        public BaseDto<int> Execute(AddNewCatalogItemDto request)
        {
            var catalogItem = mapper.Map<CatalogItem>(request);
            _context.CatalogItems.Add(catalogItem);
            _context.SaveChanges();
            return new BaseDto<int>(true, new List<string> { "با موفقیت ثبت شد" }, catalogItem.Id);
        }

        public PaginatedItemsDto<FavouriteCatalogItemDto> GetMyFavourite(string UserId, int page = 1, int pageSize = 20)
        {
            var model = _context.CatalogItems
             .Include(p => p.CatalogItemImages)
             .Include(p => p.Discounts)
             .Include(p => p.CatalogItemFavourites)
             .Where(p => p.CatalogItemFavourites.Any(f => f.UserId == UserId))
             .OrderByDescending(p => p.Id)
             .AsQueryable();
            int rowCount = 0;

            var data = model.PagedResult(page, pageSize, out rowCount)
            .ToList()
            .Select(p => new FavouriteCatalogItemDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Rate = 4,
                AvailableStock = p.AvailableStock,
                Image = _uriComposerRepository
                .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
            }).ToList();
            return new PaginatedItemsDto<FavouriteCatalogItemDto>(page, pageSize, rowCount, data);
        }
    }
}
