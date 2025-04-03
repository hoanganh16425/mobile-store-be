using MBBE.Data;
using MBBE.Dtos.Account;
using MBBE.Interfaces;
using MBBE.Mappers;
using MBBE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static MBBE.Common.Constant.Enum;

namespace MBBE.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;

        public AccountRepository(DataContext dataContext, UserManager<User> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public List<User> GetUsers(AccountQueryObject query)
        {
            var account = _dataContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(query.UserName))
            {
                account = account.Where(a => a.UserName.Contains(query.UserName));
            }
            if (!string.IsNullOrEmpty(query.Email))
            {
                account = account.Where(a => a.Email.Contains(query.Email));
            }
            if (!string.IsNullOrEmpty(query.ShippingAddress))
            {
                account = account.Where(a => a.ShippingAddress.Contains(query.ShippingAddress));
            }
            if (!string.IsNullOrEmpty(query.PhoneNumber))
            {
                account = account.Where(a => a.PhoneNumber.Contains(query.PhoneNumber));
            }
            if (!string.IsNullOrEmpty(query.Citizenship))
            {
                account = account.Where(a => a.Citizenship.Contains(query.Citizenship));
            }

            return account.ToList();
        }

        public async Task<User?> GetUserDetail(string userId)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<(bool Success, string ErrorMessage, AccountDto? user)> UpdateUserAsync(User user, UpdateAccountDto? updateDto, List<string> roles)
        {
            using (var transaction = await _dataContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Update basic user information
                    user.UserName = updateDto.Username;
                    user.Email = updateDto.Email;
                    user.ShippingAddress = updateDto.ShippingAddress;
                    user.Citizenship = updateDto.Citizenship;
                    user.Dob = updateDto.Dob;
                    user.EmergencyContact = updateDto.EmergencyContact;
                    user.BankName = updateDto.BankName;
                    user.BankAccount = updateDto.BankAccount;
                    user.AnnualLeave = updateDto.AnnualLeave;
                    user.MedicalLeave = updateDto.MedicalLeave;
                    user.UrgentLeave = updateDto.UrgentLeave;
                    user.SpecialLeave = updateDto.SpecialLeave;
                    user.Marriage = updateDto.Marriage;
                    user.Hospitalisation = updateDto.Hospitalisation;
                    user.Maternity = updateDto.Maternity;
                    user.UnpaidLeave = updateDto.UnpaidLeave;
                    user.PhoneNumber = updateDto.PhoneNumber;
                    // Update roles
                    var existingRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, existingRoles);

                    var roleResult = await _userManager.AddToRolesAsync(user, roles);
                    if (!roleResult.Succeeded)
                    {
                        return (false, "Failed to update roles", null);
                    }

                    // Update password if provided
                    if (!string.IsNullOrEmpty(updateDto.Password))
                    {
                        // Ensure the user manager does not require 2FA for password reset
                        _userManager.Options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;

                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                        var passwordResult = await _userManager.ResetPasswordAsync(user, token, updateDto.Password);

                        if (!passwordResult.Succeeded)
                        {
                            return (false, "Failed to update password", null);
                        }
                    }

                    // Update the user entity manually, this is important if you're modifying other fields
                    _dataContext.Users.Update(user);

                    // Save user updates to the database
                    await _dataContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    var userDto = await AccountMapper.ToAccountDto(user, _userManager);

                    return (true, "User updated successfully", userDto);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return (false, $"Exception: {ex.Message}", null);
                }
            }
        }

    }
}
