using IMS.BusinessService.Common.UnitOfWorks;
using IMS.Contract.Common.UnitOfWorks;
using IMS.Domain.Systems;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.APIControllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TService> : ControllerBase
{
    protected readonly UserManager<AppUser> userManager;
    protected readonly TService service;

    public BaseController(
        TService service, 
        UserManager<AppUser> userManager)
    {
        this.userManager = userManager;
        this.service = service;
    }

    protected async Task<AppUser> GetCurrentUserAsync()
    {
        var currentUser = this.User;
        var id = userManager.GetUserId(currentUser);
        var user = await userManager.GetUserAsync(currentUser);
        return user;
    }
}
