using Entities.Common;

namespace Entities.Catalogs
{
    public class CatalogItemFeature : BaseEntity<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatlogItemId { get; set; }
    }
}
