using BudifyAPI.Users.Models.DB;
using BudifyAPI.Users.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudifyAPI.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("AddUserGroup")]
        public async Task<IActionResult> AddUserGroup(UserGroup userGroup)
        {
            var result = await _usersService.AddUserGroup(userGroup);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("UpdateUserGroup")]
        public async Task<IActionResult> UpdateUserGroup(UserGroup userGroup)
        {
            var result = await _usersService.UpdateUserGroup(userGroup);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteUserGroup")]
        public async Task<IActionResult> DeleteUserGroup(UserGroup userGroup)
        {
            var result = await _usersService.DeleteUserGroup(userGroup);
            if (result != null)
                return Ok(result);
            return BadRequest();

        }

        [HttpGet("GetAllUserGroup/id_user_group")]
        public async Task<IActionResult> GetAllUserGroup(Guid userGroupId)
        {
            var result = await _usersService.GetAllUserGroup(userGroupId);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AddUserToUserGroup")]
        public async Task<IActionResult> AddUserToUserGroup(User user, UserGroup userGroup)
        {
            var result = await _usersService.AddUserToUserGroup(user, userGroup);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("DeleteUserFromUserGroup")]
        public async Task<IActionResult> DeleteUserFromUserGroup(User user, UserGroup userGroup)
        {
            var result = await _usersService.DeleteUserFromUserGroup(user, userGroup);  
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("AddManagerToUserGroup")]
        public async Task<IActionResult> AddManagerToUserGroup(User user, UserGroup userGroup)
        {
            var result = await _usersService.AddManagerToUserGroup(user, userGroup);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("DeleteManagerToUserGroup")]
        public async Task<IActionResult> DeleteManagerToUserGroup(User user, UserGroup userGroup)
        {
            var result = _usersService.DeleteManagerToUserGroup(user, userGroup);
            if(result != null) 
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            var result = _usersService.AddUser(user);
            if(result != null) 
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("UpdateUser/id_user")]
        public async Task<IActionResult> UpdateUser(User userId)
        {
            var result = _usersService.UpdateUser(userId);
            if(result != null)  
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("DeleteUser/id_user")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = (_usersService.DeleteUser(userId));
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(User user)
        {
            var result = _usersService.GetUsers(user);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("GetUserById/id_user")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var result = _usersService.GetUserById(userId);
            if(result != null)  
                return Ok(result);
            return BadRequest();
        }

    }
}
