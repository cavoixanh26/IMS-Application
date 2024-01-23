using AutoMapper;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Assignments;
using IMS.Contract.Contents.Milestones;
using IMS.Domain.Contents;
using IMS.Domain.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IMS.Api.APIControllers.Contents
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MilestoneController : BaseController<IMilestoneService>
    {
        public MilestoneController(
            IMilestoneService service, 
            UserManager<AppUser> userManager
            )
            :base(service, userManager)
        {
        }

        [HttpGet()]
        public async Task<ActionResult<MilestoneResponse>> GetAllMilestone([FromQuery] MilestoneRequest request)
        {
            var response = await service.GetMilestones(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MilestoneDto>> GetMilestoneId(int id)
        {
            var response = await service.GetMilestoneById(id);
            return Ok(response);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMilestone(int id)
        //{

        //}

        [HttpPost]
        public async Task<IActionResult> CreateMilestone([FromBody] CreateMilestoneDto request)
        {
            await service.CreateMilestone(request);
            return Ok("Successfully");
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateMilestone(int id, [FromBody] UpdateMilestoneDto data)
        //{

        //}
    }
}
