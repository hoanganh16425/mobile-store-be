namespace MBBE.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
