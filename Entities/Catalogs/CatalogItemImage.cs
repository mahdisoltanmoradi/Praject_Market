using Entities.Common;

namespace Entities.Catalogs
{
    public class CatalogItemImage : BaseEntity<int>
    {
        public string Src { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatlogItemId { get; set; }
    }
}
