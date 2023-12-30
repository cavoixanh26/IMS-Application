using AutoMapper;
using IMS.BusinessService.Constants;
using IMS.BusinessService.Service;
using IMS.Contract.Common.Sorting;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Classes;
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
    public class ClassService : ServiceBase<Class>, IClassService
    {
        private readonly UserManager<AppUser> userManager;
        public ClassService(
            IMSDbContext context, 
            IMapper mapper,
            IUnitOfWork unitOfWork,
            UserManager<AppUser> userManager) 
            : base(context, mapper, unitOfWork)
        {
            this.userManager = userManager;
        }

        public async Task<ClassReponse> GetClasses(ClassRequest request, AppUser currentUser)
        {
            var classes = await context.Classes
                .Include(x => x.Subject)
                .Include(x => x.Setting)
                .Include(x => x.Assignee)
             .Where(u => (string.IsNullOrWhiteSpace(request.KeyWords)
             || u.Name.Contains(request.KeyWords)
             || u.Description.Contains(request.KeyWords)
             || u.Assignee.UserName.Contains(request.KeyWords))
             && (!request.SubjectId.HasValue || u.SubjectId == request.SubjectId)
             && (!request.SettingId.HasValue || u.SettingId == request.SettingId))
             .ToListAsync();

            if (await userManager.IsInRoleAsync(currentUser, RoleDefault.Manager))
            {
                classes = classes.Where(x => x.CreatedBy.Equals(currentUser.Id.ToString())).ToList();
            }
            else if (await userManager.IsInRoleAsync(currentUser, RoleDefault.Teacher))
            {
                classes = classes.Where(x => x.AssigneeId == currentUser.Id).ToList(); 
            }

            var classDtos = mapper.Map<List<ClassDto>>(classes.Paginate(request));

            var response = new ClassReponse
            {
                Classes = classDtos,
                Page = GetPagingResponse(request, classes.Count()),
            };

            return response;
        }

        public async Task<ClassDto> GetClassById(int classId)
        {
            var classes = await context.Classes
           .Include(x => x.ClassStudents)
                 .Include(x => x.Milestones)
                 .Include(x => x.Projects)
                 .Include(x => x.IssueSettings)
            .FirstOrDefaultAsync(u => u.Id == classId);

            var classDto = mapper.Map<ClassDto>(classes);
            return classDto;
        }

        public async Task<ClassDto> CreateClass(CreateAndUpdateClassDto request)
        {
            var checkClassExistedInSemester =
            await context.Classes.AnyAsync(x => x.Name.Trim() == request.Name.Trim()
                                            && x.SettingId == request.SettingId
                                            && x.SubjectId == request.SubjectId);
            if (checkClassExistedInSemester)
                throw HttpException.BadRequestException("Class existed in semester");

            var classEntity = mapper.Map<Class>(request);
            context.Classes.Add(classEntity);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<ClassDto>(classEntity);
        }

        public async Task<ClassDto> UpdateClass(int id, CreateAndUpdateClassDto request)
        {
            var checkClassExistedInSemester =
            await context.Classes.AnyAsync(x => x.Id != id 
                                            && x.Name.Trim() == request.Name.Trim()
                                            && x.SettingId == request.SettingId
                                            && x.SubjectId == request.SubjectId);
            if (checkClassExistedInSemester)
                throw HttpException.BadRequestException("Class existed in semester");

            var classEntity = await context.Classes.FindAsync(id);
            if (classEntity == null)
            {
                throw HttpException.NotFoundException("Not found");
            }
            mapper.Map(request, classEntity);

            context.Entry(classEntity).State = EntityState.Modified;
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<ClassDto>(classEntity);
        }
    }
}
