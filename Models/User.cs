using static MBBE.Common.Constant.Enum;

namespace MBBE.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public int Phone { get; set; }
        public UserRoles UserRole { get; set; }
        public DateTime Dateregister { get; set; } = DateTime.Now;

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public required Role Role { get; set; }
        public Cart? Cart { get; set; }
    }
}
