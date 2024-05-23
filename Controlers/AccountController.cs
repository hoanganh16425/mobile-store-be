using MBBE.Dtos.Account;
using MBBE.Interfaces;
using MBBE.Mappers;
using MBBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                    PhoneNumber = user.Phone,
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName.ToLower());
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Username not found or password incorrect");
            return Ok(
                    new NewUserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    }
                );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = registerDto.ToRegisterDto();
                var createUser = await _userManager.CreateAsync(user, registerDto.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, registerDto.Role.ToString());
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user)
                            }
                       );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }

                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        ///[HttpGet]
    }
}
