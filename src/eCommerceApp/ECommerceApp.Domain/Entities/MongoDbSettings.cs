namespace ECommerceApp.Domain.Entities
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CategoriesCollectionName { get; set; } = null!;
        public string ProductsCollectionName { get; set; }
    }
}
