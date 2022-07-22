using Common.Enums;

namespace Data.DTOs.Catalogs
{
    public class CatlogPLPRequestDto
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public int? CatalogTypeId { get; set; }
        public int[] brandId { get; set; }
        public bool AvailableStock { get; set; }
        public string SearchKey { get; set; }
        public SortType SortType { get; set; }
    }

    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
        public int AvailableStock { get; set; }
    }
}
