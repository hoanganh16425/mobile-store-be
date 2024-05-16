namespace MBBE.Dtos.Account
{
    public class AccountDto
    {
        public string? UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public DateTime Dateregister { get; set; }
    }
}
