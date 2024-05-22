using MBBE.Dtos.Account;
using MBBE.Interfaces;
using MBBE.Mappers;
using MBBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly RoleManager<Role> _roleManager;
        public AccountController(UserManager<User> userManager, RoleManager<Role> roleManager, ITokenService tokenService, SignInManager<User> signInManager, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _accountRepository = accountRepository;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Authorize]

        public IActionResult GetAllUser()
        {
            var userList = _accountRepository.GetUsers();
            var userDto = userList.Select(s => s.ToAccountDto()).ToList();
            if (!ModelState.IsValid)
                return NotFound(ModelState);
            return Ok(userDto);
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
                    var roleResult = await _userManager.AddToRoleAsync(user, registerDto.Role);
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
