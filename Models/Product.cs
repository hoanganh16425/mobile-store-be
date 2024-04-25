namespace MBBE.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public string? ProductImage { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Brand { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
