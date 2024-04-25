namespace MBBE.Models
{
    public class ProductCategory
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
