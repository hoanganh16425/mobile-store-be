using MBBE.Dtos.Account;
using MBBE.Models;

namespace MBBE.Interfaces
{
    public interface IAccountRepository
    {
        List<User> GetUsers(AccountQueryObject query);
        Task<User> GetUserDetail(string userId);
        Task<User?> GetUserByIdAsync(string userId);
        Task<(bool Success, string ErrorMessage, AccountDto? user)> UpdateUserAsync(User user, UpdateAccountDto? dto, List<string> roleNames);
    }
}
