using AutoMapper;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Classes;
using IMS.Contract.Contents.Projects;
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
    private readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;

    public ClassController(
        IClassService service, 
        IMapper mapper, 
        IUnitOfWork unitOfWork,
        UserManager<AppUser> userManager)
        : base(service, userManager)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    public async Task<ActionResult<ClassReponse>> GetClasses([FromQuery] ClassRequest request)
    {
        var currentUser = await GetCurrentUserAsync();
        var data = await service.GetClasses(request, currentUser);
        return Ok(data);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectReponse>> GetClassByid(int id)
    {
        var data = await service.GetClassById(id);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewClass([FromBody] CreateAndUpdateClassDto data)
    {
        var map = _mapper.Map<Class>(data);
        var result = await service.InsertAsync(map);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Add successfully ");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClass(int id, [FromBody] CreateAndUpdateClassDto input)
    {
        var data = await service.GetById(id);
        if (data == null)
        {
            return BadRequest();
        }
        else
        {
            var map = _mapper.Map(input, data);
            var result = await service.UpdateAsync(map);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Update Successfully ");
        }
    }

}
