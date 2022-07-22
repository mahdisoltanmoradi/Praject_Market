using Data.DTOs.Catalogs;

namespace Data.Contracts.Catalogs.CatalogItems
{
    public interface IGetCatalogItemPDPRepository
    {
        CatalogItemPDPDto Execute(string Slug);
    }
}
