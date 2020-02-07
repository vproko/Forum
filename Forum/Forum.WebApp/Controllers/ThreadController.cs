using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class ThreadController : Controller
    {
        private readonly IThreadService _threadService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public ThreadController(IThreadService threadService, ICategoryService categoryService, IUserService userService)
        {
            _threadService = threadService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> ShowAllThreadsAsync(string categoryId, int page = 0)
        {
            CategoryViewModel category = await _categoryService.GetCategoryByIdAsync(categoryId);
            IEnumerable<ThreadViewModel> sorted = await PagesInfoAuthCheckSortPostsAsync(category.Threads, page);
            ViewBag.Category = category;

            return View(sorted);
        }

        public async Task<IActionResult> AddThreadAsync(ThreadViewModel thread)
        {
            if(ModelState.IsValid)
                await _threadService.CreateThreadAsync(thread);

            return RedirectToAction("ShowAllThreadsAsync",new { categoryId = thread.CategoryID });
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditThreadAsync(ThreadViewModel thread, string categoryId, int page)
        {
            await _threadService.UpdateThreadAsync(thread);

            return RedirectToAction("ShowAllThreadsAsync", new { categoryId, page });
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveThreadAsync(string threadId, string categoryId, int currentPage)
        {
            await _threadService.DeleteThreadAsync(threadId);
            CategoryViewModel category = await _categoryService.GetCategoryByIdAsync(categoryId);
            int totalPages = decimal.ToInt32(Math.Round(Math.Ceiling(((decimal)category.Threads.Count()) / 5), 0)) - 1;
            int page = totalPages <= currentPage ? totalPages : currentPage;

            return RedirectToAction("ShowAllThreadsAsync", new { categoryId, page });
        }
        
        #region PrivateMethods
        private async Task<IEnumerable<ThreadViewModel>> PagesInfoAuthCheckSortPostsAsync(IEnumerable<ThreadViewModel> threads, int page)
        {
            await IsItAuthenticatedSuspendedAsync();
            PaginationInfo(threads, page);

            return threads.Skip(page * 5).Take(5);
        }

        private async Task IsItAuthenticatedSuspendedAsync()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                ViewBag.CurrentUser = await _userService.GetCurrentUserAsync(User.Identity.Name);
        }

        private void PaginationInfo(IEnumerable<ThreadViewModel> threads, int page)
        {
            ViewBag.Page = page;
            ViewBag.TotalThreads = threads.Count();
            ViewBag.TotalPages = decimal.ToInt32(Math.Round(Math.Ceiling((decimal)threads.Count() / 5), 0));
        }
        #endregion
    }
}