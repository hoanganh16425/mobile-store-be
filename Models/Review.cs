namespace MBBE.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public int Ratint { get; set; }
        public string Comment { get; set; } = string.Empty;
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
