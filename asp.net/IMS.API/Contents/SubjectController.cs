using AutoMapper;
using IMS.Api.APIControllers;
using IMS.BusinessService.Constants;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Subjects;
using IMS.Domain.Contents;
using IMS.Domain.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Contents;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = RoleDefault.Admin)]
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
        var subjectList = await service.GetSubjectAllAsync(request);
        return Ok(subjectList);
    }

    [HttpPost]
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
        var data = await service.GetById(id);
        if (data == null)
        {
            return NotFound("Not found subject");
        }
        else
        {
            var map = _mapper.Map(input, data);
            var result = await service.UpdateAsync(map);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Update Successfully");
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubject(int id)
    {
        var data = await service.GetById(id);
        if (data != null)
        {
            await service.DeleteAsync(data);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Delete Successfully !!!");
        }
        else
        {
            return NotFound("Not found subject");
        }
    }
}
