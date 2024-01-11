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
using System.Text;
using System.Data;
using ClosedXML.Excel;
using IMS.Contract.ExceptionHandling;

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
        try
        {
            var data = await service.GetClassById(id);
            return Ok(data);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.Status, ex.Message);
        }
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

    [HttpPost("down-template-add-students")]
    public ActionResult GetTemplateExcelAddStudent()
    {
        var dt = new DataTable("Template");
        dt.Columns.AddRange(new DataColumn[2]
        {
            new DataColumn("Full Name"),
            new DataColumn("Email")
        });

        using (var wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dt);
            using (var stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                Response.Headers.Add("Content-Disposition", "attachment; filename=template-add-student.xlsx");
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }
    }

    [HttpPost("import-students")]
    public async Task<IActionResult> ImportStudentToClassAsync(int classId, IFormFile formFile)
    {
        formFile = Request.Form.Files[0];
        if (formFile == null || formFile.Length <= 0)
        {
            return BadRequest("Empty File");
        }

        await service.ImportStudentToClass(classId, formFile);
        return Ok("Import successfully");
    }
}
