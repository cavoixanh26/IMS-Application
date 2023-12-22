using AutoMapper;
using IMS.BusinessService.Service;
using IMS.Contract.Common.Sorting;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Contract.Contents.Subjects;
using IMS.Domain.Contents;
using IMS.Infrastructure.EnityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IMS.Contract.ExceptionHandling;

namespace IMS.BusinessService.Systems
{
    public class SubjectService : ServiceBase<Subject>, ISubjectService
    {
        public SubjectService(
            IMSDbContext context,
            IMapper mapper,
            IUnitOfWork unitOfWork) 
            : base(context, mapper, unitOfWork)
        {
        }

        public async Task<SubjectDto> CreateSubject(CreateUpdateSubjectDto request)
        {
            var checkExistSubject = await context.Subjects
                .AnyAsync(x => x.Name.Equals(request.Name));
            if (checkExistSubject)
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

        public async Task<SubjectReponse> GetSubjectAllAsync(SubjectRequest request)
        {
            var subjects = await context.Subjects
                .Where(x => string.IsNullOrWhiteSpace(request.KeyWords)
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
    }
}
