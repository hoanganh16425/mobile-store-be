﻿using MBBE.Dtos.Account;
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
                PhoneNumber = userModel.PhoneNumber = string.Empty,
                Email = userModel.Email,
                Dateregister = userModel.Dateregister,
                ShippingAddress = userModel.ShippingAddress,
                EmergencyContact = userModel.EmergencyContact,
                BankAccount = userModel.BankAccount,
                BankName = userModel.BankName,
                Dob = userModel.Dob
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
