using Data.DTOs;
using Data.DTOs.Catalogs.CatalogTypes;

namespace Data.Contracts.Catalogs.CatalogTypes
{
    public interface ICatalogTypeRepository
    {
        BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType);
        BaseDto Remove(int Id);
        BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType);
        BaseDto<CatalogTypeDto> FindById(int Id);
        PaginatedItemsDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize);
    }
}
