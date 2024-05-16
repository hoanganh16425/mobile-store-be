using MBBE.Data;
using MBBE.Dtos.Account;
using MBBE.Interfaces;
using MBBE.Mappers;
using MBBE.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MBBE.Repository
{
    public class AccountRepository: IAccountRepository
    {
        private readonly DataContext _dataContext;
        public AccountRepository(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public List<User> GetUsers()
        {
            return _dataContext.Users.OrderBy(u => u.Id).ToList();
        }
    }
}
