using Data.Contracts.Catalogs.CatalogItems;
using Data.Contracts.UriComposer;
using Data.DTOs.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Catalogs
{
    public class GetCatalogItemPDPRepository : IGetCatalogItemPDPRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IUriComposerRepository uriComposerRepository;

        public GetCatalogItemPDPRepository(ApplicationDbContext context, IUriComposerRepository uriComposerRepository = null)
        {
            this.context = context;
            this.uriComposerRepository = uriComposerRepository;
        }

        public CatalogItemPDPDto Execute(string Slug)
        {
            var catalogitem = context.CatalogItems
                 .Include(p => p.CatalogItemFeatures)
                 .Include(p => p.CatalogItemImages)
                 .Include(p => p.CatalogType)
                 .Include(p => p.CatalogBrand)
                 .Include(p => p.Discounts)
                 .SingleOrDefault(p => p.Slug == Slug);
            catalogitem.VisitCount += 1;
            context.SaveChanges();

            var feature = catalogitem.CatalogItemFeatures
                .Select(p => new PDPFeaturesDto
                {
                    Group = p.Group,
                    Key = p.Key,
                    Value = p.Value
                }).ToList()
                .GroupBy(p => p.Group);

            var similarCatalogItems = context
               .CatalogItems
               .Include(p => p.CatalogItemImages)
               .Where(p => p.CatalogTypeId == catalogitem.CatalogTypeId)
               .Take(10)
               .Select(p => new SimilarCatalogItemDto
               {
                   Id = p.Id,
                   Images = uriComposerRepository.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                   Price = p.Price,
                   Name = p.Name
               }).ToList();

            return new CatalogItemPDPDto
            {
                Features = feature,
                SimilarCatalogs = similarCatalogItems,
                Id = catalogitem.Id,
                Name = catalogitem.Name,
                Brand = catalogitem.CatalogBrand.Brand,
                Type = catalogitem.CatalogType.Type,
                Price = catalogitem.Price,
                Description = catalogitem.Description,
                Images = catalogitem.CatalogItemImages.Select(p => uriComposerRepository.ComposeImageUri(p.Src)).ToList(),
                OldPrice = catalogitem.OldPrice,
                PercentDiscount = catalogitem.PercentDiscount,
            };
        }
    }
}
