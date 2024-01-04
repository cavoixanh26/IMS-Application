using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Dtos.Students;
using IMS.Domain.Contents;
using IMS.Domain.Systems;
namespace IMS.Contract.Contents.Classes;

public interface IClassService : IGenericRepository<Class>
{
    Task<ClassReponse> GetClasses(ClassRequest request, AppUser currentUser);
    Task<ClassDto> GetClassById(int classId);
    Task<ClassDto> CreateClass(CreateAndUpdateClassDto request);
    Task<ClassDto> UpdateClass(int id, CreateAndUpdateClassDto request);
    Task<StudentResponse> GetStudentsInClass(int id, StudentRequest request);
    Task AddedStudentoClass(AddStudentInClassRequest request);
}
