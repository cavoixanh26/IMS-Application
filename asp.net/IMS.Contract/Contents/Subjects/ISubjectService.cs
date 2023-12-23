using IMS.Contract.Common.UnitOfWorks;
using IMS.Domain.Contents;
using IMS.Domain.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Subjects
{
    public interface ISubjectService : IGenericRepository<Subject>
    {
        Task<SubjectReponse> GetSubjectAllAsync(SubjectRequest request, string userId);
        Task<SubjectDto> GetBySubjectByIdAsync(int subjectId);
        Task<SubjectDto> CreateSubject(CreateUpdateSubjectDto request);
        Task<SubjectDto> UpdateAssignManager(AssignSubject request);
        Task UpdateSubject(int id, CreateUpdateSubjectDto request, AppUser currentUser);
    }
}
