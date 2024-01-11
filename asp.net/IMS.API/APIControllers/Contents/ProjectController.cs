using AutoMapper;
using IMS.BusinessService.Systems;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Projects;
using IMS.Contract.Contents.Subjects;
using IMS.Contract.Dtos.Members;
using IMS.Contract.ExceptionHandling;
using IMS.Contract.Systems.Users;
using IMS.Domain.Contents;
using IMS.Domain.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.APIControllers.Contents
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : BaseController<IProjectService>
    {

        public ProjectController(
            IProjectService service,
            UserManager<AppUser> userManager)
            : base(service, userManager)
        {
        }

        [HttpGet]
        public async Task<ActionResult<ProjectReponse>> GetAllProject([FromQuery] ProjectRequest request)
        {
            try
            {
                var data = await service.GetProjectsInClass(request);
                return Ok(data);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            try
            {
                var data = await service.GetProjectById(id);
                return Ok(data);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto request)
        {
            try
            {
                await service.CreateProject(request);
                return Ok("Add successfully ");
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectDto request)
        {
            try
            {
                await service.UpdateProject(id, request);
                return Ok("Update Successfully");
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }

        [HttpPost("add-members-to-project")]
        public async Task<IActionResult> AddMembersToProject(MemberInProjectRequest request)
        {
            try
            {
                var response = await service.AddMembersToProject(request);
                return Ok(response);
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.Status, ex.Message);
            }
        }
    }
}
