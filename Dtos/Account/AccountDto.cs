using MBBE.Models;
using System.ComponentModel.DataAnnotations;
using static MBBE.Common.Constant.Enum;

namespace MBBE.Dtos.Account
{
    public class AccountDto
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string Dob { get; set; } = string.Empty;
        public int EmergencyContact { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string BankAccount { get; set; } = string.Empty;
        public DateTime Dateregister { get; set; }
        public IList<UserRoles> Roles { get; set; }
        public string Citizenship { get; set; } = string.Empty;
        public int AnnualLeave { get; set; }
        public int MedicalLeave { get; set; }
        public int UrgentLeave { get; set; }
        public int SpecialLeave { get; set; }
        public int Marriage { get; set; }
        public int Hospitalisation { get; set; }
        public int Maternity { get; set; }
        public int UnpaidLeave { get; set; }
    }

    public class AccountQueryObject
    {
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ShippingAddress { get; set; }
        public string? Citizenship { get; set; }
        public IList<UserRoles>? Roles { get; set; }
    }

    public class UpdateAccountDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string ShippingAddress { get; set; } = string.Empty;
        [Required]
        public string Citizenship { get; set; } = string.Empty;
        [Required]
        public string Dob { get; set; } = string.Empty;
        [Required]
        public int EmergencyContact { get; set; }
        [Required]
        public string BankName { get; set; } = string.Empty;
        [Required]
        public string BankAccount { get; set; } = string.Empty;
        [Required]
        public int AnnualLeave { get; set; }
        [Required]
        public int MedicalLeave { get; set; }
        [Required]
        public int UrgentLeave { get; set; }
        [Required]
        public int SpecialLeave { get; set; }
        [Required]
        public int Marriage { get; set; }
        [Required]
        public int Hospitalisation { get; set; }
        [Required]
        public int Maternity { get; set; }
        [Required]
        public int UnpaidLeave { get; set; }
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public List<UserRoles> Role { get; set; }
    }
}
