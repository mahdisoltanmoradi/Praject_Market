using Entities.Common;
using System.Collections.Generic;

namespace Entities.Catalogs
{
    public class CatalogType : BaseEntity<int>
    {
        public string Type { get; set; }

        public int? ParentCatalogTypeId { get; set; }
        public CatalogType ParentCatalogType { get; set; }

        public ICollection<CatalogType> SubType { get; set; }
    }
}
