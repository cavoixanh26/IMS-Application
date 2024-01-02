using AutoMapper;
using IMS.Contract.Contents.Assignments;
using IMS.Contract.Contents.Classes;
using IMS.Contract.Contents.Milestones;
using IMS.Contract.Contents.Projects;
using IMS.Contract.Contents.Settings;
using IMS.Contract.Contents.Subjects;
using IMS.Contract.Systems.Roles;
using IMS.Contract.Systems.Users;
using IMS.Domain.Contents;
using IMS.Domain.Systems;

namespace IMS.BusinessService.ProfilesAutoMap;

public class MappingProfile : Profile 
{
	public MappingProfile()
	{	
		//User
		CreateMap<AppRole, RoleDto>().ReverseMap();
		CreateMap<AppUser, UserDto>().ReverseMap();


		//User
		CreateMap<CreateUserDto, AppUser>().ReverseMap();
		CreateMap<UpdateUserDto, AppUser>().ReverseMap()
			.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

		//Assignment
		CreateMap<CreateUpdateAssignmentDTO ,Assignment>().ReverseMap();
		CreateMap<AssignmentDTO , Assignment>().ReverseMap();
		

        //Subject 
        CreateMap<CreateUpdateSubjectDto, Subject>().ReverseMap();
        CreateMap<Subject, SubjectDto>()
			.ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.Email : null))
			.ReverseMap();

		// setting
		CreateMap<SettingDto, Setting>().ReverseMap();
		CreateMap<CreateUpdateSetting, Setting>().ReverseMap();

		// milestone
		CreateMap<MilestoneDto , Milestone>().ReverseMap();	
		CreateMap<CreateMilestoneDto , Milestone>().ReverseMap();
		CreateMap<UpdateMilestoneDto , Milestone>().ReverseMap();

        //Project 
        CreateMap<CreateAndUpdateProjectDto, Project>().ReverseMap();
        CreateMap<ProjectDto, Project>().ReverseMap();

        //Class
        CreateMap<CreateAndUpdateClassDto, Class>().ReverseMap();
		CreateMap<Class, ClassDto>()
			.ForMember(dest => dest.Semester, opt => opt.MapFrom(src => src.Setting != null ? src.Setting.Name : null))
			.ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject != null ? src.Subject.Name : null))
			.ForMember(dest => dest.TeacherName, opt => opt.MapFrom(scr => scr.Assignee != null ? scr.Assignee.Email : null))
			.ForMember(dest => dest.NumberOfStudent, opt => opt.MapFrom(src => src.ClassStudents != null ? src.ClassStudents.Count : 0))
			.ReverseMap();

    }
}
