using MBBE.Dtos.Account;
using MBBE.Models;

namespace MBBE.Interfaces
{
    public interface IAccountRepository
    {
        List<User> GetUsers(AccountQueryObject query);
        Task<User> GetUserDetail(string userId);

        Task<User> UpdateUser(string userId, UpdateAccountDto updateAccount);
    }
}
