using AutoMapper;
using IMS.BusinessService.Constants;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Subjects;
using IMS.Domain.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.APIControllers.Contents;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = $"{RoleDefault.Admin},{RoleDefault.Manager}")]
public class SubjectController : BaseController<ISubjectService>
{
    private readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;

    public SubjectController(
        UserManager<AppUser> userManager,
        ISubjectService service,
        IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(service, userManager)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubjectDto>> GetSubjectById(int id)
    {
        try
        {
            var subject = await service.GetBySubjectByIdAsync(id);
            return Ok(subject);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<SubjectReponse>> GetSubjects([FromQuery] SubjectRequest request)
    {
        string managerId = "";
        if (await CheckRole(RoleDefault.Manager))
        {
            managerId = userManager.GetUserId(User);
        }

        var subjectList = await service.GetSubjectAllAsync(request, managerId);
        return Ok(subjectList);
    }

    [HttpPost]
    [Authorize(Roles = RoleDefault.Admin)]
    public async Task<IActionResult> Create([FromBody] CreateUpdateSubjectDto request)
    {
        try
        {
            var response = await service.CreateSubject(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubject(int id, [FromBody] CreateUpdateSubjectDto input)
    {
        await service.UpdateSubject(id, input);
        return Ok("successfully");
    }

    [HttpPut("assign-subject")]
    [Authorize(Roles = RoleDefault.Admin)]
    public async Task<IActionResult> AssignSubjectForManager(AssignSubject request)
    {
        try
        {
            var subjectDto = await service.UpdateAssignManager(request);
            return Ok(subjectDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
