using static MBBE.Common.Constant.Enum;

namespace MBBE.Dtos.Account
{
    public class AccountDto
    {
        public string? UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string Dob { get; set; } = string.Empty;
        public int EmergencyContact { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string BankAccount { get; set; } = string.Empty;
        public DateTime Dateregister { get; set; }
        public IList<UserRoles> Roles { get; set; }
    }
}
