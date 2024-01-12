using AutoMapper;
using IMS.BusinessService.Service;
using IMS.Contract.Common.Sorting;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Projects;
using IMS.Contract.Contents.Subjects;
using IMS.Contract.Dtos.Members;
using IMS.Contract.ExceptionHandling;
using IMS.Domain.Contents;
using IMS.Domain.Systems;
using IMS.Infrastructure.EnityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BusinessService.Systems
{
    public class ProjectService : ServiceBase<Project>, IProjectService
    {

        public ProjectService(
            IMSDbContext context, 
            IMapper mapper,
            IUnitOfWork unitOfWork) 
            : base(context, mapper, unitOfWork)
        {
        }

        public async Task<ProjectResponse> GetProjectsInClass(ProjectRequest request)
        {
            var projects = await context.Projects
                .Include(x => x.ProjectMembers)
                .ThenInclude(y => y.User)
                .Where(u => u.ClassId == request.ClassId 
                && (string.IsNullOrWhiteSpace(request.KeyWords)
                || u.Name.Contains(request.KeyWords)
                || u.Description.Contains(request.KeyWords))
                && (!request.ProjectStatus.HasValue || u.Status == request.ProjectStatus))
                .ToListAsync();

            var projectDtos = mapper.Map<List<ProjectDto>>(projects.Paginate(request));

            var response = new ProjectResponse
            {
                Projects = projectDtos,
                Page = GetPagingResponse(request, projects.Count()),
            };

            return response;
        }

        public async Task<ProjectDto> GetProjectById(int Id)
        {
            var subject = await context.Projects
               .Include(x => x.ProjectMembers)
               .ThenInclude(y => y.User)
               .FirstOrDefaultAsync(u => u.Id == Id);

            if (subject == null)
            {
                throw HttpException.NotFoundException("Not found");
            }

            var subjectDto = mapper.Map<ProjectDto>(subject);
            return subjectDto;
        }

        public async Task CreateProject(CreateProjectDto request)
        {
            var checkExistClass = await context.Classes.AnyAsync(x => x.Id == request.ClassId);
            if (!checkExistClass)
                throw HttpException.BadRequestException("Class doesn't existed yet");

            var projectEntity = mapper.Map<Project>(request);
            await context.Projects.AddAsync(projectEntity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProject(int id, UpdateProjectDto request)
        {
            var project = await context.Projects.FindAsync(id);
            if (project == null)
                throw HttpException.BadRequestException("Not found project");

            mapper.Map(request, project);
            context.Entry(project).State = EntityState.Modified;
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<ProjectDto> AddMembersToProject(MemberInProjectRequest request)
        {
            var project = await context.Projects
                .Include(x => x.ProjectMembers)
                .FirstOrDefaultAsync(x => x.Id == request.ProjectId);
            if (project == null)
                throw HttpException.NotFoundException("Not found project");

            var hasTeamLeader = await context.ProjectMembers
                .AnyAsync(x => x.ProjectId == request.ProjectId
                            && x.IsTeamleader);
            // check exist member
            foreach (var memberRequest in request.Members)
            {
                var isExistStudentInClass = await context.ClassStudents
                                                .AnyAsync(x => x.ClassId == project.ClassId
                                                            && x.StudentId == memberRequest.MemberId);
                if (isExistStudentInClass)
                {
                    var projectMember = new ProjectMember
                    {
                        ProjectId = request.ProjectId,
                        UserId = memberRequest.MemberId,
                        IsTeamleader = memberRequest.IsTeamleader && !hasTeamLeader,
                    };
                    if (memberRequest.IsTeamleader)
                        hasTeamLeader = true;
                    await context.ProjectMembers.AddAsync(projectMember);
                }
            }
            await unitOfWork.SaveChangesAsync();
            var projectDto = mapper.Map<ProjectDto>(project);

            return projectDto;
        }
    }
}
