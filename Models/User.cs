using Microsoft.AspNetCore.Identity;

namespace MBBE.Models
{
    public class User : IdentityUser
    {
        public string ShippingAddress { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string Dob { get; set; } = string.Empty;
        public int EmergencyContact { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string BankAccount { get; set; } = string.Empty;
        public int AnnualLeave { get; set; }
        public int MedicalLeave { get; set; }
        public int UrgentLeave { get; set; }
        public int SpecialLeave { get; set; }
        public int Marriage { get; set; }
        public int Hospitalisation { get; set; }
        public int Maternity { get; set; }
        public int UnpaidLeave { get; set; }
        public DateTime Dateregister { get; set; } = DateTime.Now;

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<UserRoleMap> UserRoleMaps { get; set; }
    }
}
