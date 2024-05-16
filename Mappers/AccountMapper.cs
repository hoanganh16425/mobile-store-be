using MBBE.Dtos.Account;
using MBBE.Models;

namespace MBBE.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToAccountDto(this User userModel)
        {
            return new AccountDto
            {
                UserName = userModel.UserName,
                PhoneNumber = userModel.Phone,
                Email = userModel.Email,
                Dateregister = userModel.Dateregister,
                ShippingAddress = userModel.ShippingAddress,
            };
        }
    }
}
