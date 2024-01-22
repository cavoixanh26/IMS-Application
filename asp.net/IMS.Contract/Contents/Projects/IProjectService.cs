using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Dtos.Members;
using IMS.Domain.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Projects
{
    public interface IProjectService : IGenericRepository<Project>
    {
        Task<ProjectResponse> GetProjectsInClass(ProjectRequest request);
        Task<ProjectDto> GetProjectById(int Id);
        Task CreateProject(CreateProjectDto request);
        Task UpdateProject(int id, UpdateProjectDto request);
        Task<ProjectDto> AddMembersToProject(MemberInProjectRequest request);
        Task DeleteMembersFromProject(int projectId, Guid memberId);
        Task UpdateTeamleader(int projectId, Guid memberId);
    }
}
