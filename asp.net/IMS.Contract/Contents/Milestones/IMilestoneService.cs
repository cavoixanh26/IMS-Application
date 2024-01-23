using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Assignments;
using IMS.Domain.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Milestones
{
    public interface IMilestoneService : IGenericRepository<Milestone>
    {
        Task<MilestoneResponse> GetMilestones(MilestoneRequest request);
        Task<MilestoneDto> GetMilestoneById(int id);
        Task CreateMilestone(CreateMilestoneDto request);
    }
}
