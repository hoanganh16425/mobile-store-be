namespace MBBE.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }
        public User User { get; set; }
    }
}
