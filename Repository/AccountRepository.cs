using MBBE.Data;
using MBBE.Dtos.Account;
using MBBE.Interfaces;
using MBBE.Mappers;
using MBBE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> UpdateUserAsync(User user, string? newPassword, List<string> roleNames)
{
    using (var transaction = await _dataContext.Database.BeginTransactionAsync())
    {
        try
        {
            // Update roles
            var existingRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, existingRoles);

            var roleResult = await _userManager.AddToRolesAsync(user, roleNames);
            if (!roleResult.Succeeded)
                return false;

            // Update password if provided
            if (!string.IsNullOrEmpty(newPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, token, newPassword);
                if (!passwordResult.Succeeded)
                    return false;
            }

            // Save user updates
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return false;

            await transaction.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}
    }
}
