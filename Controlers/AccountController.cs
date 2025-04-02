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
        private readonly IAccountRepository _accountRepository;
        public AccountController(UserManager<User> userManager, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAllUser([FromQuery] AccountQueryObject query)
        {
            var userList = _accountRepository.GetUsers(query);
            var userDtos = new List<AccountDto>();

            foreach (var user in userList)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userDto = new AccountDto
                {
                    UserName = user.UserName,
                    Id = user.Id,
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

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserDetail([FromRoute] string id)
        {
            var user = await _accountRepository.GetUserDetail(id);
            if (user == null)
            {
                return NotFound(user);
            }
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
                Id = user.Id,
                Roles = roles.Select(r => Enum.Parse<UserRoles>(r)).ToList(),
            };

            if (!ModelState.IsValid)
                return NotFound(ModelState);
            return Ok(userDto);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromRoute] string id, [FromBody] UpdateAccountDto dto)
        {
            var userDetail = await _accountRepository.GetUserDetail(id);
            if (userDetail == null) return NotFound(new { error = "User not found" });

            var roleNames = dto.Role.Select(role => Enum.GetName(typeof(UserRoles), role)).ToList();

            var result = await _accountRepository.UpdateUserAsync(userDetail, dto, roleNames);

            if (!result.Success) return BadRequest(new { error = result.ErrorMessage });

            return Ok(new { message = result.ErrorMessage, user = result.user });
        }
    }
}
