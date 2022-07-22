using Data.DTOs;
using Data.DTOs.Catalogs;

namespace Data.Contracts.Catalogs.CatalogItems
{
    public interface IGetCatalogIItemPLPRepository
    {
        PaginatedItemsDto<CatalogPLPDto> Execute(CatlogPLPRequestDto request);
    }
}
