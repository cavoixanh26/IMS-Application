﻿using IMS.BusinessService.Constants;
using IMS.Contract.Systems.Roles;
using IMS.Domain.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.APIControllers.Systems;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = RoleDefault.Admin)]
public class RoleController : BaseController<IRoleService>
{
        public RoleController(
		IRoleService service,
		UserManager<AppUser> userManager)
		: base(service, userManager)
	{
        }

	[HttpGet]
	public async Task<ActionResult<RoleResponse>> GetAllRoles([FromQuery]RoleRequest request)
	{
		var data = await service.GetListAllAsync(request);
		return Ok(data);
	}

	[HttpPost]
	public async Task<IActionResult> CreateRole([FromBody] CreateUpdateRoleDto input)
	{
		await service.AddRole(input);
		return Ok("Add role succesfully");
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateRole(Guid id, [FromBody] CreateUpdateRoleDto input)
	{
		 await service.UpdateRole(id, input);
		return Ok("Update role succesfully");
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteRoles([FromQuery] Guid[] ids)
	{	
		await service.DeleteManyRole(ids);
		return Ok("Delete roles succesfully");
	}


	[HttpGet("{id}")]
	public async Task<ActionResult<RoleDto>> GetRoleById(Guid id)
	{
		var data = await service.GetRoleById(id);
		return Ok(data);
	}

	[HttpGet("{roleId}/permissions")]
	public async Task<ActionResult<PermissionDto>> GetAllRolePermissions(string roleId)
	{	
		var data = await service.GetAllRolePermission(roleId);
		return Ok(data);
	}

	[HttpPut("permissions")]
	public async Task<IActionResult> SavePermission([FromBody] PermissionDto model)
	{
		await service.SavePermission(model);
		return Ok("Update permission succesfully");
	}
}
