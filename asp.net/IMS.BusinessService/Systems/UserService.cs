using AutoMapper;
using IMS.BusinessService.Service;
using IMS.Contract.Common.Sorting;
using IMS.Contract.Systems.Firebase;
using IMS.Contract.Systems.Users;
using IMS.Domain.Systems;
using IMS.Infrastructure.EnityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq.Dynamic.Core;
using IMS.Contract.Common.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace IMS.BusinessService.Systems;

public class UserService : ServiceBase<AppUser>, IUserService
{
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<AppRole> roleManager;
    private readonly IFirebaseService firebaseService;
    public UserService(
    UserManager<AppUser> userManager,
    RoleManager<AppRole> roleManager,
    IFirebaseService firebaseService,
        IMSDbContext context,
    IMapper mapper,
        IUnitOfWork unitOfWork)
    : base(context, mapper, unitOfWork)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.firebaseService = firebaseService;
    }

    public async Task AssignRolesAsync(Guid userId, string[] roleNames)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            throw new Exception("User doesn't exist");
        }
        var currentRoles = await userManager.GetRolesAsync(user);
        var removedResult = await userManager.RemoveFromRolesAsync(user, currentRoles);
        var addedResult = await userManager.AddToRolesAsync(user, roleNames);
        if (!addedResult.Succeeded || !removedResult.Succeeded)
        {
            List<IdentityError> addedErrorList = addedResult.Errors.ToList();
            List<IdentityError> removedErrorList = removedResult.Errors.ToList();
            var errorList = new List<IdentityError>();
            errorList.AddRange(addedErrorList);
            errorList.AddRange(removedErrorList);
            string errors = "";

            foreach (var error in errorList)
            {
                errors = errors + error.Description.ToString();
            }
            throw new Exception(errors);
        }
    }

    public async Task CreateUser(CreateUserDto userDto)
    {
        var existingUser = await userManager.FindByNameAsync(userDto.UserName);
        if (existingUser != null)
        {
            // Tên người dùng đã tồn tại
            throw new Exception("Username is already exist");
        }

        existingUser = await userManager.FindByEmailAsync(userDto.Email);
        if (existingUser != null)
        {
            // Email đã tồn tại
            throw new Exception("Email is already exist");
        }

        var user = mapper.Map<CreateUserDto, AppUser>(userDto);
        var result = await userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
        {
            // Xử lý lỗi khi tạo người dùng thất bại
            throw new Exception("Failed to create user. Please check the provided data.");
        }
        await userManager.AddToRoleAsync(user, "User");
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            throw new Exception("User doesn't exist");
        }
        await userManager.DeleteAsync(user);
    }

    public async Task<UserResponse> GetListAllAsync(UserRequest request)
    {
        var usersQuery = new List<AppUser>();   
        if (!string.IsNullOrEmpty(request.RoleName))
        {
            var role = await roleManager.FindByNameAsync(request.RoleName);
            if (role != null)
            {
                usersQuery = (List<AppUser>)await userManager.GetUsersInRoleAsync(role.Name);
            }
        }else
        {
            usersQuery = userManager.Users.ToList();
        }

        usersQuery = usersQuery
            .Where(u => string.IsNullOrWhiteSpace(request.KeyWords)
                        || u.FullName.Contains(request.KeyWords)
                        || u.UserName.Contains(request.KeyWords))
            .ToList();

        var users = await usersQuery.Paginate(request).ToDynamicListAsync();

        var userDtos = new List<UserDto>();

        foreach (var user in users)
        {
            // Retrieve the roles for each user
            var roles = await userManager.GetRolesAsync(user);

            var userDto = mapper.Map<UserDto>(user);

            // Set the Roles property in UserDto
            userDto.Roles = roles;

            userDtos.Add(userDto);
        }

        var response = new UserResponse
        {
            Users = userDtos,
            Page = GetPagingResponse(request, usersQuery.Count()),
        };

        return response;
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            throw new Exception("Not found");
        }
        var userDto = mapper.Map<AppUser, UserDto>(user);
        var roles = await userManager.GetRolesAsync(user);
        userDto.Roles = roles;
        return userDto;
    }

    public async Task<List<UserDto>> GetUserByRoleName(string roleName)
    {
        var usersInRoleName = await userManager.GetUsersInRoleAsync(roleName);
        var userDtos = mapper.Map<List<UserDto>>(usersInRoleName);
        return userDtos;
    }

    public async Task UpdateUser(Guid id, UpdateUserDto userDto)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            throw new Exception("Not found");
        }
        mapper.Map(userDto, user);
        if (userDto.FileImage != null)
        {
            var fileName = await firebaseService.UpLoadFileOnFirebaseAsync(userDto.FileImage);
            user.Avatar = fileName;
        }
        var result = await userManager.UpdateAsync(user);
    }

}
