using Data.Contracts.Catalogs.CatalogItems;
using Data.DTOs;
using Data.DTOs.Brands;
using Data.DTOs.Catalogs;
using Data.DTOs.Catalogs.CatalogTypes;
using System.Collections.Generic;

namespace Data.Contracts.CatalogItems
{
    public interface ICatalogItemRepository
    {
        List<CatalogBrandDto> GetBrand();
        List<ListCatalogTypeDto> GetCatalogType();
        PaginatedItemsDto<CatalogItemListItemDto> GetCatalogList(int page, int pageSize);
        void AddToMyFavourite(string UserId, int CatalogItemId);
        PaginatedItemsDto<FavouriteCatalogItemDto> GetMyFavourite(string UserId, int page = 1, int pageSize = 20);
        BaseDto<int> Execute(AddNewCatalogItemDto request);
        //PaginatedItemsDto<FavouriteCatalogItemDto> GetMyFavourite(string UserId, int page = 1, int pageSize = 20);
    }
}
