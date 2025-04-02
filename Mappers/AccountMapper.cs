using MBBE.Dtos.Account;
using MBBE.Models;
using Microsoft.AspNetCore.Identity;
using static MBBE.Common.Constant.Enum;

namespace MBBE.Mappers
{
    public static class AccountMapper
    {
        public static async Task<AccountDto> ToAccountDto(User userModel, UserManager<User> userManager)
        {
            var roles = await userManager.GetRolesAsync(userModel);
            return new AccountDto
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                Email = userModel.Email,
                ShippingAddress = userModel.ShippingAddress,
                PhoneNumber = userModel.PhoneNumber,
                Dateregister = userModel.Dateregister,
                Citizenship = userModel.Citizenship,
                EmergencyContact = userModel.EmergencyContact,
                BankAccount = userModel.BankAccount,
                BankName = userModel.BankName,
                Dob = userModel.Dob,
                Roles = roles.Select(r => Enum.Parse<UserRoles>(r)).ToList(),
                AnnualLeave = userModel.AnnualLeave,
                MedicalLeave = userModel.MedicalLeave,
                UrgentLeave = userModel.UrgentLeave,
                SpecialLeave = userModel.SpecialLeave,
                Marriage = userModel.Marriage,
                Hospitalisation = userModel.Hospitalisation,
                Maternity = userModel.Maternity,
                UnpaidLeave = userModel.UnpaidLeave,
        };
        }

        public static async Task<List<AccountDto>> MapAccountDtos(List<User> users, UserManager<User> userManager)
        {
            var userDtos = new List<AccountDto>();
            foreach (var user in users)
            {
                userDtos.Add(await ToAccountDto(user, userManager));
            }

            return userDtos;
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
