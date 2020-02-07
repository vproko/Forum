using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IHostingEnvironment _hosting;

        public UserController(IUserService userService, IPostService postService, IHostingEnvironment hosting)
        {
            _userService = userService;
            _postService = postService;
            _hosting = hosting;
        }

        [AllowAnonymous]
        public IActionResult Registration() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegistrationAsync(RegisterViewModel registration)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterAsync(registration, "user");
                return RedirectToAction("ShowAllCategoriesAsync", "Category");
            }

            return RedirectToAction("registration", "user");
        }

        [Authorize(Roles = "admin")]
        public IActionResult RegisterAdmin() => View();

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdminAsync(RegisterViewModel registration)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterAsync(registration, "admin");
                return RedirectToAction("ShowAllCategoriesAsync", "Category");
            }

            return RedirectToAction("RegisterAdmin", "User");
        }

        [AllowAnonymous]
        public IActionResult LogIn() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogInAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _userService.LoginAsync(model);

                if (result)
                {
                    await _userService.UserOnlineStatusAsync(model.Username, true);
                    return RedirectToAction("ShowAllCategoriesAsync", "Category");
                }
            }

            return RedirectToAction("LogIn", "user");
        }

        public async Task<IActionResult> LogOutAsync()
        {
            await _userService.UserOnlineStatusAsync(User.Identity.Name, false);
            await _userService.LogoutAsync();

            return RedirectToAction("ShowAllCategoriesAsync", "Category");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> MembersAsync(int page = 0)
        {
            IEnumerable<UserViewModel> members = await _userService.GetAllUsersAsync();
            IEnumerable<UserViewModel> users = members.Where(u => u.Administrator == false);
            PaginationInfo(members, page);

            return View(users.Skip(page * 5).Take(5));
        }

        public async Task<IActionResult> ProfileAsync(string tab, int page)
        {
            UserViewModel user = await _userService.GetCurrentUserAsync(User.Identity.Name);
            ViewBag.Tab = tab;
            ViewBag.Page = page;

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhotoAsync(IFormFile photo)
        {
            if (photo != null)
            {
                var path = Path.Combine(_hosting.WebRootPath, @"avatars", Path.GetFileName(photo.FileName));
                photo.CopyTo(new FileStream(path, FileMode.Create));
                string image = "/avatars/" + Path.GetFileName(photo.FileName);
                var user = await _userService.GetCurrentUserAsync(User.Identity.Name);
                user.Avatar = image;
                await _userService.UpdateAvatarAsync(user);
            }
            return RedirectToAction("ProfileAsync");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserViewModel update)
        {
            if (ModelState.IsValid)
            {
                if (update.NewPassword != null)
                    await _userService.PasswordCheckAsync(update.OldPassword, update.UserID);

                await _userService.UpdateUserInfoAsync(update);

                return RedirectToAction("ProfileAsync", new { tab = "#vtab2" });
            }

            return View("CustomErrorPage");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUserAsync(string userId, string view, int totalUsers, int currentPage)
        {
            await _userService.DeleteUserAsync(userId);

            if (view == "ReportedPostsAsync")
                return RedirectToAction("ReportedPostsAsync", "Post");

            int page = ReturnToPage(totalUsers, currentPage);

            return RedirectToAction("MembersAsync", new { page });
        }

        public async Task<IActionResult> DeleteAccountAsync(string userId)
        {
            await _userService.DeleteUserAsync(userId);
            await _userService.LogoutAsync();

            return RedirectToAction("ShowAllCategoriesAsync", "Category");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SuspendUnsuspendAsync(string username, string userId, int page)
        {
            await _userService.SuspensionStatusAsync(username);

            if(userId != null)
            {
                await _postService.DeleteReportedPostsByUserIdAsync(userId);
                return RedirectToAction("ReportedPostsAsync", "Post");
            }

            return RedirectToAction("MembersAsync", new { page });
        }

        private void PaginationInfo(IEnumerable<UserViewModel> users, int page)
        {
            ViewBag.Page = page;
            ViewBag.TotalUSers = users.Count();
            ViewBag.TotalPages = decimal.ToInt32(Math.Round(Math.Ceiling((decimal)users.Count() / 5), 0));
        }

        private int ReturnToPage(int totalUsers, int currentPage)
        {
            int totalPages = decimal.ToInt32(Math.Round(Math.Ceiling(((decimal)totalUsers - 1) / 5), 0)) - 1;
            int page = totalPages <= currentPage ? totalPages : currentPage;

            return page;
        }
    }
}