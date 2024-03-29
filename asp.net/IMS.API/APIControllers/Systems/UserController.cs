﻿using AutoMapper;
using IMS.BusinessService.Systems;
using IMS.Contract.ExceptionHandling;
using IMS.Contract.Systems.Roles;
using IMS.Contract.Systems.Users;
using IMS.Domain.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static IMS.BusinessService.Constants.Permissions;

namespace IMS.Api.APIControllers.Systems
{

	[Route("api/[controller]")]
	[ApiController]
	public class UserController : BaseController<IUserService>
	{
		private readonly IMapper _mapper;
        public UserController(
			IUserService service, 
			UserManager<AppUser> userManager,
			IMapper mapper) 
			: base(service, userManager)
        {
			_mapper = mapper;
        }

		[HttpGet("users")]
		public async Task<ActionResult<UserResponse>> GetAllUsers([FromQuery]UserRequest request)
		{
			var data = await service.GetListAllAsync(request);
			return Ok(data);
		}

		[HttpPost("assign-roles")]
		public async Task<IActionResult> AssignRoles(Guid userId, string[] roleNames)
		{
			await service.AssignRolesAsync(userId, roleNames);
			return Ok();
		}

		[HttpDelete("delete-user/{id}")]
		public async Task<IActionResult> DeleteUser(Guid id)
		{
			try
			{
				await service.DeleteAsync(id);
				return Ok("User deleted successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserDto>> GetUserById(Guid id)
		{
			try
			{
				var data = await service.GetUserByIdAsync(id);
				return Ok(data);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody]CreateUserDto input)
		{
			await service.CreateUser(input);
			return Ok("User create successfully.");
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(Guid id,[FromForm] UpdateUserDto input)
		{
			await service.UpdateUser(id, input);
			return Ok("User updated successfully.");
		}

		[HttpGet("user-by-role")]
		public async Task<ActionResult<List<UserDto>>> GetUsersByRole(string roleName)
		{
			try
			{
				var response = await service.GetUserByRoleName(roleName);
				return Ok(response);
			}
			catch (HttpException ex)
			{
				return StatusCode((int)ex.Status, ex.Message);
			}
		}
	}

	
}
