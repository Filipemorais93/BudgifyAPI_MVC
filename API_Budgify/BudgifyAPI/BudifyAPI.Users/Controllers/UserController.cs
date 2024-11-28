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
        public async Task<IActionResult> AddUserGroup([FromBody] UserGroup userGroup)
        {
            var result = await _usersService.AddUserGroup(userGroup);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("UpdateUserGroup/{id_user_group}")]
        public async Task<IActionResult> UpdateUserGroup([FromBody] UserGroup userGroup)
        {
            var result = await _usersService.UpdateUserGroup(userGroup);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteUserGroup")]
        public async Task<IActionResult> DeleteUserGroup([FromBody] UserGroup userGroup)
        {
            var result = await _usersService.DeleteUserGroup(userGroup);
            if (result != null)
                return Ok(result);
            return BadRequest();

        }

        [HttpGet("GetAllUserGroup/id_user_group")]
        public async Task<IActionResult> GetAllUserGroup([FromBody] Guid userGroupId)
        {
            var result = await _usersService.GetAllUserGroup(userGroupId);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AddUserToUserGroup")]
        public async Task<IActionResult> AddUserToUserGroup([FromBody] User user)
        {
            var result = await _usersService.AddUserToUserGroup(user);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteUserFromUserGroup")]
        public async Task<IActionResult> DeleteUserFromUserGroup([FromBody]User user)
        {
            var result = await _usersService.DeleteUserFromUserGroup(user);  
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AddManagerToUserGroup")]
        public async Task<IActionResult> AddManagerToUserGroup([FromBody] User user)
        {
            var result = await _usersService.AddManagerToUserGroup(user);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteManagerToUserGroup")]
        public async Task<IActionResult> DeleteManagerToUserGroup([FromBody] User user)
        {
            var result = await _usersService.DeleteManagerToUserGroup(user);
            if(result != null) 
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var result = await _usersService.AddUser(user);
            if(result != null) 
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("UpdateUser/id_user")]
        public async Task<IActionResult> UpdateUser([FromBody] User userId)
        {
            var result = await _usersService.UpdateUser(userId);
            if(result != null)  
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteUser/id_user")]
        public async Task<IActionResult> DeleteUser([FromBody] Guid userId)
        {
            var result = await _usersService.DeleteUser(userId);
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _usersService.GetUsers();
            if(result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("GetUserById/id_user")]
        public async Task<IActionResult> GetUserById([FromBody] Guid userId)
        {
            var result = await _usersService.GetUserById(userId);
            if(result != null)  
                return Ok(result);
            return BadRequest();
        }

    }
}
