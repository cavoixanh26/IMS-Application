using AutoMapper;
using IMS.BusinessService.Service;
using IMS.Contract.Common.Sorting;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Subjects;
using IMS.Domain.Contents;
using IMS.Infrastructure.EnityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IMS.Contract.ExceptionHandling;
using Microsoft.AspNetCore.Identity;
using IMS.Domain.Systems;
using IMS.BusinessService.Constants;

namespace IMS.BusinessService.Systems;

public class SubjectService : ServiceBase<Subject>, ISubjectService
{
    private readonly UserManager<AppUser> userManager;
    public SubjectService(
        IMSDbContext context,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        UserManager<AppUser> userManager) 
        : base(context, mapper, unitOfWork)
    {
        this.userManager = userManager;
    }

    public async Task<SubjectDto> CreateSubject(CreateUpdateSubjectDto request)
    {
        var checkExistSubject = await context.Subjects
            .FirstOrDefaultAsync(x => x.Name.Equals(request.Name));
        if (checkExistSubject != null)
        {
            throw HttpException.BadRequestException("Subject's name exist");
        }

        var subject = mapper.Map<Subject>(request);
        await context.Subjects.AddAsync(subject);
        await unitOfWork.SaveChangesAsync();
        var subjectDto = mapper.Map<SubjectDto>(subject);
        return subjectDto;
    }

    public async Task<SubjectDto> GetBySubjectByIdAsync(int id)
    {
        var subject = await context.Subjects
            .FirstOrDefaultAsync(x => x.Id == id && x.IsActive != false);
        var subjectDto = mapper.Map<SubjectDto>(subject);
        return subjectDto;
    }

    public async Task<SubjectReponse> GetSubjectAllAsync(SubjectRequest request, string userId)
    {
        var subjects = await context.Subjects
            .Include(x => x.Manager)
            .Where(x => (string.IsNullOrEmpty(userId) || x.ManagerId.ToString() == userId) 
                    && string.IsNullOrWhiteSpace(request.KeyWords)
                    || x.Name.Contains(request.KeyWords)
                    || x.Description.Contains(request.KeyWords)
                    && x.IsActive != false)
            .ToListAsync();

        var subjectDtos = mapper.Map<List<SubjectDto>>(subjects.Paginate(request));

        var response = new SubjectReponse
        {
            Subjects = subjectDtos,
            Page = GetPagingResponse(request, subjects.Count()),
        };

        return response;
    }

    public async Task<SubjectDto> UpdateAssignManager(AssignSubject request)
    {
        var subject = await context.Subjects.FirstOrDefaultAsync(x => x.Id == request.SubjectId);
        if (subject == null)
        {
            throw HttpException.BadRequestException("The subject does not exist yet!");
        }

        var manager = await userManager.FindByIdAsync(request.ManagerId);
        if (!await userManager.IsInRoleAsync(manager, RoleDefault.Manager))
        {
            throw HttpException.BadRequestException("The assignee hasn't permission");
        }

        subject.ManagerId = manager.Id;
        context.Subjects.Update(subject);
        await unitOfWork.SaveChangesAsync();

        var subjectDto = mapper.Map<SubjectDto>(subject);
        return subjectDto;
    }

    public async Task UpdateSubject(int id, CreateUpdateSubjectDto request, AppUser currentUser)
    {
        var subject = await context.Subjects.FindAsync(id);
        if (subject == null)
        {
            throw HttpException.NotFoundException("Subject doest not exist yet");
        }

        var checkRoleAdmin = await userManager.IsInRoleAsync(currentUser, RoleDefault.Admin);
        if (subject.ManagerId != currentUser.Id && !checkRoleAdmin)
        {
            throw HttpException.NoPermissionException("Not Permission!");
        }
        
        mapper.Map(request, subject);
        context.Update(subject);
        await unitOfWork.SaveChangesAsync();
    }
}
