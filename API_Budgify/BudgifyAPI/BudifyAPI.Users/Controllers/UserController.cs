﻿using BudifyAPI.Users.Models.USers.DBUsers;
using BudifyAPI.Users.Models.USers.DBUsers.CreateUSerHelper;
using BudifyAPI.Users.Models.USers.Helpers;
using BudifyAPI.Users.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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
        public async Task<IActionResult> AddUserGroup([FromBody] CreateUserGroup name)
        {
            var result = await _usersService.AddUserGroup(name);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("UpdateUserGroup/{userGroupId}")]
        public async Task<IActionResult> UpdateUserGroup(Guid userGroupId, CreateUserGroup name)
        {
            var result = await _usersService.UpdateUserGroup(userGroupId, name);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteUserGroup/{userGroupId}")]
        public async Task<IActionResult> DeleteUserGroup([FromRoute] Guid userGroupId)
        {
            var result = await _usersService.DeleteUserGroup(userGroupId);
            if (result != null)
                return Ok(result);
            return BadRequest();

        }

        [HttpGet("GetUserGroup/{userGroupId}")]
        public async Task<IActionResult> GetAllUserGroup(Guid userGroupId)
        {
            var result = await _usersService.GetUserGroup(userGroupId);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AddUserToUserGroup/{userId}")]
        public async Task<IActionResult> AddUserToUserGroup([FromBody] CreateUser createUser, Guid userId)
        {
            var result = await _usersService.AddUserToUserGroup(createUser, userId);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteUserFromUserGroup/{userId}")]
        public async Task<IActionResult> DeleteUserFromUserGroup(Guid userId)
        {
            var result = await _usersService.DeleteUserFromUserGroup(userId);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AddManagerToUserGroup")]
        public async Task<IActionResult> AddManagerToUserGroup([FromBody] User user)
        {
            var result = await _usersService.AddManagerToUserGroup(user);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteManagerToUserGroup")]
        public async Task<IActionResult> DeleteManagerToUserGroup([FromBody] User user)
        {
            var result = await _usersService.DeleteManagerToUserGroup(user);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] CreateUser createUser)
        {
            var result = await _usersService.AddUser(createUser);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("UpdateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, CreateUser createUser )
        {
            var result = await _usersService.UpdateUser(userId, createUser);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await _usersService.DeleteUser(userId);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _usersService.GetUsers();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var result = await _usersService.GetUserById(userId);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

    }
}
