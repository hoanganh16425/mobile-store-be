namespace MBBE.Models
{
    public class Promotions
    {
        public Guid PromotionId { get; set; }
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DiscountPercent { get; set; }
        public int MinOrderAmount { get; set; }
    }
}
