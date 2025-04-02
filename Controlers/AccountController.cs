using MBBE.Dtos.Account;
using MBBE.Interfaces;
using MBBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MBBE.Mappers;
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
            var userDtos = await AccountMapper.MapAccountDtos(userList, _userManager);
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
            var userDto = await AccountMapper.ToAccountDto(user, _userManager);

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

            return Ok(result.user);
        }
    }
}
