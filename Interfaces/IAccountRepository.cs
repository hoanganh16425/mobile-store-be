using MBBE.Dtos.Account;
using MBBE.Models;

namespace MBBE.Interfaces
{
    public interface IAccountRepository
    {
        List<User> GetUsers();
    }
}
