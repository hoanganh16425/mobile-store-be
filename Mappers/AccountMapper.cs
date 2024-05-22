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
        public static User ToRegisterDto(this RegisterDto registerDto)
        {
            return new User
            {
                UserName = registerDto.Username,
                PhoneNumber = registerDto.Phone,
                Email = registerDto.Email,
                ShippingAddress = registerDto.ShippingAddress,
                Citizenship = registerDto.Citizenship,
                Dob = registerDto.Dob,
                EmergencyContact = registerDto.EmergencyContact,
                BankName = registerDto.BankName,
                BankAccount = registerDto.BankAccount,
                AnnualLeave = registerDto.AnnualLeave,
                MedicalLeave = registerDto.MedicalLeave,
                UrgentLeave = registerDto.UrgentLeave,
                SpecialLeave = registerDto.SpecialLeave,
                Marriage = registerDto.Marriage,
                Hospitalisation = registerDto.Hospitalisation,
                Maternity = registerDto.Maternity,
                UnpaidLeave = registerDto.UnpaidLeave,
    };
        }

    }
}
