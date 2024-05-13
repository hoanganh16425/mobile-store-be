namespace MBBE.Models
{
    public class Cart
    {
        public Guid CartID { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
