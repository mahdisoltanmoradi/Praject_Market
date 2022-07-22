namespace Data.Contracts.Catalogs.CatalogItems
{
    public class FavouriteCatalogItemDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public int AvailableStock { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
