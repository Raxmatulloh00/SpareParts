namespace DataStore.SQL.Models
{
    public class SparePartsInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string CatalogNumber { get; set; }
    }
}
