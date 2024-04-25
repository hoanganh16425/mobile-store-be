namespace MBBE.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; } = new Order();
        public Product Product { get; set; }
    }
}
