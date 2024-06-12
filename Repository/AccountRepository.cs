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

        public List<User> GetUsers(AccountQueryObject query)
        {
            var account =  _dataContext.Users.AsQueryable();
            if(!string.IsNullOrEmpty(query.UserName))
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
    }
}
