using Entities.Common;

namespace Entities.Catalogs
{
    public class CatalogItemFavourite : BaseEntity<int>
    {
        public string UserId { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatalogItemId { get; set; }
    }
}
