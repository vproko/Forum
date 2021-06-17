using AutoMapper;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviroment;
        public UserController(IUserService userService, IMapper mapper, IWebHostEnvironment enviroment)
        {
            _userService = userService;
            _mapper = mapper;
            _enviroment = enviroment;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Registration() => View();

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationAsync(RegistrationViewModel registration)
        {
            if (ModelState.IsValid)
            {
                if (registration.UserImage != null && registration.UserImage.Length < 2097152)
                    registration.Avatar = await UploadFileAsync(registration.UserImage);

                registration.Role = "user";
                if (await _userService.CreateAsync(registration) is true)
                    return RedirectToAction("ViewCategories", "Category");
            }
            ViewData["ErrorMessage"] = "Your registration was unsuccessful, try again";
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> FindUserAsync(Guid userId)
        {
            UserDto user = await _userService.FindUserAsync(userId);
            if (user is null)
                return BadRequest(new { message = "Something went wrong." });
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login() => View();

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel login)
        {
            if (ModelState.IsValid)
                if (await _userService.LogInAsync(login))
                    return RedirectToAction("ViewCategories", "Category");
            ViewData["ErrorMessage"] = "Your login was unsuccessful, try again";
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _userService.LogOutAsync(User.Identity.Name);
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateUserInfoAsync(UpdateInfoViewModel update)
        {
            if (ModelState.IsValid)
            {
                if (update.UserImage != null)
                {
                    UserDto user = await _userService.FindUserAsync(User.Identity.Name);
                    await DeleteFileAsync(user.Avatar);
                    update.Avatar = await UploadFileAsync(update.UserImage);
                }
                UserDto result = await _userService.UpdateUserAsync(update, User.Identity.Name);
                if (result != null)
                    return Json(new { message = "Your info was updated successfully", user = result });
            }

            return Json(new { message = "Update wasn't successful" });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordViewModel password)
        {
            if (ModelState.IsValid)
                if (await _userService.ChangeUsersPasswordAsync(password, User.Identity.Name))
                    return Json(new { message = "Your password was changed successfully" });
            return Json(new { message = "Your password wasn't updated" });
        }

        [Authorize]
        public async Task<IActionResult> DeleteAccountAsync()
        {
            UserDto user = await _userService.FindUserAsync(User.Identity.Name);
            if (user.Avatar != "not set")
                await DeleteFileAsync(user.Avatar);
            if (await _userService.RemoveAsync(User.Identity.Name))
                return RedirectToAction("Registration");
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAccountAdminAsync(string username)
        {
            UserDto user = await _userService.FindUserAsync(username);
            if (user.Avatar != "not set")
                await DeleteFileAsync(user.Avatar);
            await _userService.RemovedByAdminAsync(username);
            return RedirectToAction("UsersList");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> UsersListAsync(int pageIndex = 1, int pageSize = 5)
        {
            PageInfoData(pageIndex, pageSize);
            return View(_mapper.Map<IEnumerable<UserViewModel>>(await _userService.GetUsersPerPageAsync(pageIndex, pageSize)));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> SearchUsersListAsync(string searchTerm, int pageIndex = 1, int pageSize = 5)
        {
            PageInfoData(pageIndex, pageSize);
            if (string.IsNullOrEmpty(searchTerm) is false)
            {
                ViewData["SearchTerm"] = searchTerm;
                return View("Views/User/UsersList.cshtml", _mapper.Map<IEnumerable<UserViewModel>>(await _userService.SearchUsersPerPageAsync(searchTerm, pageIndex, pageSize)));
            }
            return RedirectToAction("UsersList", new { pageIndex, pageSize });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> UsersListManagerAsync(string searchTerm, int pageIndex = 1, int pageSize = 5)
        {
            PageInfoData(pageIndex, pageSize);
            if (string.IsNullOrEmpty(searchTerm))
                return RedirectToAction("UsersList", new { pageIndex, pageSize });
            ViewData["SearchTerm"] = searchTerm;
            return View("Views/User/UsersList.cshtml", _mapper.Map<IEnumerable<UserViewModel>>(await _userService.SearchUsersPerPageAsync(searchTerm, pageIndex, pageSize)));
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> SuspendUserAsync(Guid userId, int pageIndex)
        {
            await _userService.ChangeUsersSuspensionAsync(userId);
            return RedirectToAction("UsersList", new { pageIndex });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CheckSenderAsync(Guid userId)
        {
            if (userId != Guid.Empty)
                return Json(_mapper.Map<UserViewModel>(await _userService.FindUserAsync(userId)));
            return Json(new { message = "Something went wrong." });
        }

        private async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file != null)
            {
                var fileName = $"{Guid.NewGuid()}-{DateTime.UtcNow.Millisecond}{new FileInfo(file.FileName).Extension}";
                var folderPath = Path.Combine(_enviroment.WebRootPath, @"uploads", fileName);
                using var fileStream = new FileStream(folderPath, FileMode.Create, FileAccess.Write);
                await file.CopyToAsync(fileStream);
                return $"/uploads/{fileName}";
            }
            return "not set";
        }

        private Task DeleteFileAsync(string path)
        {
            if (System.IO.File.Exists(_enviroment.WebRootPath + $"/uploads/{Path.GetFileName(path)}"))
                System.IO.File.Delete(_enviroment.WebRootPath + $"/uploads/{Path.GetFileName(path)}");
            return Task.CompletedTask;
        }

        private void PageInfoData(int pageIndex, int pageSize)
        {
            ViewData["PageIndex"] = pageIndex;
            ViewData["PageSize"] = pageSize;
        }
    }
}
