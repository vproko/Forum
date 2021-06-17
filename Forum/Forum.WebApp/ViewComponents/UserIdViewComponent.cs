using Forum.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.WebApp.ViewComponents
{
    public class UserIdViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        public UserIdViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.FindUserAsync(User.Identity.Name);

            return Content(user.UserId.ToString());
        }
    }
}
