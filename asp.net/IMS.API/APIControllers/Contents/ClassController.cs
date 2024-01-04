using AutoMapper;
using IMS.BusinessService.Constants;
using IMS.Contract.Dtos.Students;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Classes;
using IMS.Contract.Contents.Projects;
using IMS.Contract.Systems.Users;
using IMS.Domain.Contents;
using IMS.Domain.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.APIControllers.Contents;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClassController : BaseController<IClassService>
{
    public ClassController(
        IClassService service,
        UserManager<AppUser> userManager)
        : base(service, userManager)
    {
    }


    [HttpGet]
    public async Task<ActionResult<ClassReponse>> GetClasses([FromQuery] ClassRequest request)
    {
        var currentUser = await GetCurrentUserAsync();
        var data = await service.GetClasses(request, currentUser);
        return Ok(data);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ClassDto>> GetClassByid(int id)
    {
        var data = await service.GetClassById(id);
        return Ok(data);
    }

    [HttpPost]
    [Authorize(Roles = $"{RoleDefault.Admin}, {RoleDefault.Manager}")]
    public async Task<IActionResult> CreateNewClass([FromBody] CreateAndUpdateClassDto request)
    {
        var response = await service.CreateClass(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClass(int id, [FromBody] CreateAndUpdateClassDto input)
    {
        var response = await service.UpdateClass(id, input);
        return Ok(response);
    }

    [HttpGet("{id}/students-list")]
    public async Task<ActionResult<StudentResponse>> GetStudentsInClass(int id, [FromQuery] StudentRequest request)
    {
        var response = await service.GetStudentsInClass(id, request);
        return Ok(response);
    }

    [HttpPost("add-student")]
    public async Task<ActionResult> CreateStudent([FromBody] AddStudentInClassRequest request)
    {
        await service.AddedStudentoClass(request);
        return Ok("Student added to class successfully");
    }

}
