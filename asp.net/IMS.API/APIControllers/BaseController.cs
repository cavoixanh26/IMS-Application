using IMS.Domain.Systems;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IMS.Api.APIControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
        protected readonly UserManager<AppUser> userManager;

        public BaseController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        protected async Task<string> GetCurrentUserIdAsync()
        {
            var currentUser = this.User;
            var id = userManager.GetUserId(currentUser);
            var user = await userManager.GetUserAsync(currentUser);
            return id;
        }
    }
}
