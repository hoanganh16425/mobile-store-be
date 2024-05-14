using Microsoft.AspNetCore.Identity;

namespace MBBE.Models
{
    public class User : IdentityUser
    {
        public string ShippingAddress { get; set; } = string.Empty;
        public int Phone { get; set; }
        public DateTime Dateregister { get; set; } = DateTime.Now;

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
