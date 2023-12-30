using IMS.Contract.Common.UnitOfWorks;
using IMS.Domain.Contents;
using IMS.Domain.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Classes
{
    public interface IClassService : IGenericRepository<Class>
    {
        Task<ClassReponse> GetClasses(ClassRequest request, AppUser currentUser);
        Task<ClassDto> GetClassById(int classId);
        Task<ClassDto> CreateClass(CreateAndUpdateClassDto request);
        Task<ClassDto> UpdateClass(int id, CreateAndUpdateClassDto request);
    }
}
