using MBBE.Dtos.Account;
using MBBE.Interfaces;
using MBBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static MBBE.Common.Constant.Enum;

namespace MBBE.Controlers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly IAccountRepository _accountRepository;
        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAllUser()
        {
            var userList = _accountRepository.GetUsers();
            var userDtos = new List<AccountDto>();

            foreach (var user in userList)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userDto = new AccountDto
                {
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Dateregister = user.Dateregister,
                    ShippingAddress = user.ShippingAddress,
                    EmergencyContact = user.EmergencyContact,
                    BankAccount = user.BankAccount,
                    BankName = user.BankName,
                    Dob = user.Dob,
                    Roles = roles.Select(r => Enum.Parse<UserRoles>(r)).ToList(),
                };

                userDtos.Add(userDto);
            }
            if (!ModelState.IsValid)
                return NotFound(ModelState);
            return Ok(userDtos);
        }
    }
}
