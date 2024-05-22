using System.ComponentModel.DataAnnotations;
using static MBBE.Common.Constant.Enum;

namespace MBBE.Dtos.Account
{
    public class RegisterDto
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
        public string Role { get; set; }
    }
}
