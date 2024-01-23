using AutoMapper;
using IMS.BusinessService.Service;
using IMS.Contract.Common.Sorting;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Assignments;
using IMS.Contract.Contents.Classes;
using IMS.Contract.Contents.Milestones;
using IMS.Contract.Contents.Projects;
using IMS.Contract.ExceptionHandling;
using IMS.Domain.Contents;
using IMS.Infrastructure.EnityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BusinessService.Systems;

public class MilestoneService : ServiceBase<Milestone>, IMilestoneService
{
    private readonly IClassService classService;
    private readonly IProjectService projectService;

    public MilestoneService(
        IMSDbContext context, 
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IClassService classService,
        IProjectService projectService) 
        : base(context, mapper, unitOfWork)
    {
        this.classService = classService;
        this.projectService = projectService;
    }

    public async Task CreateMilestone(CreateMilestoneDto request)
    {
        if (request.ClassId.HasValue)
        {
            var existClass = await classService.GetClassById(request.ClassId.Value);
            if (existClass == null) 
                throw HttpException.NotFoundException("Not found class");
        }
        else if (request.ProjectId.HasValue)
        {
            var existProject = await classService.GetClassById(request.ProjectId.Value);
            if (existProject == null)
                throw HttpException.NotFoundException("Not found project");
        }else
        {
            throw HttpException.BadRequestException("have to exist either class or project");
        }

        if (string.IsNullOrEmpty(request.Title))
            throw HttpException.BadRequestException("Title Not Empty");

        if (request.StartDate.HasValue
            && request.DueDate.HasValue
            && request.StartDate.Value > request.DueDate.Value)
            throw HttpException.BadRequestException("Start date less than Due date");

        var milestone = mapper.Map<Milestone>(request);
        context.Milestones.Add(milestone);
        await unitOfWork.SaveChangesAsync();
    }

    public Task<MilestoneDto> GetMilestoneById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<MilestoneResponse> GetMilestones(MilestoneRequest request)
    {
        var milestones = await context.Milestones
            .AsNoTracking()
            .Include(x => x.Project)
            .Include(x => x.Class)
            .Include(x => x.Issues)
            .Where(u => (string.IsNullOrWhiteSpace(request.KeyWords)
                    || u.Description.Contains(request.KeyWords)
                    || u.Title.Contains(request.KeyWords))
                    && (!request.ClassId.HasValue || request.ClassId.Value == u.ClassId)
                    && (!request.ProjectId.HasValue || request.ProjectId.Value == u.ProjectId)
                    && (!request.Status.HasValue || request.Status.Value == u.Status)
                    && (!request.StartDate.HasValue || u.StartDate >= request.StartDate)
                    && (!request.DueDate.HasValue || u.DueDate <= request.DueDate)
                    && (!request.IsActive.HasValue || u.IsActive == request.IsActive))
            .ToListAsync();

        var milestoneDtos = mapper.Map<List<MilestoneDto>>(milestones.Paginate(request));

        var response = new MilestoneResponse
        {
            Milestones = milestoneDtos,
            Page = GetPagingResponse(request, milestones.Count()),
        };

        return response;
    }

}
