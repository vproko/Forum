using AutoMapper;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class ThreadController : Controller
    {
        private readonly IThreadService _threadService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ThreadController(IThreadService threadService, IUserService userService, IMapper mapper)
        {
            _threadService = threadService;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ViewThreadAsync(Guid threadId, int pageIndex = 1, int pageSize = 5)
        {
            ViewData["PageIndex"] = pageIndex;
            ViewData["PageSize"] = pageSize;
            if (threadId != Guid.Empty)
            {
                if (User.Identity.IsAuthenticated == true)
                    ViewData["User"] = _mapper.Map<UserViewModel>(await _userService.FindUserAsync(User.Identity.Name));
                return View(_mapper.Map<ThreadViewModel>(await _threadService.FindThreadWithRelatedDataAsync(threadId, pageIndex, pageSize)));
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateThreadAsync(ThreadViewModel thread, Guid categoryId, int pageIndex, int pageSize)
        {
            if (ModelState.IsValid && categoryId != Guid.Empty)
                await _threadService.CreateAsync(thread);
            return RedirectToAction("ViewCategory", "Category", new { categoryId, pageIndex, pageSize });
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateThreadAsync(ThreadViewModel thread, int pageIndex)
        {
            if (ModelState.IsValid)
                await _threadService.UpdateAsync(_mapper.Map<ThreadDto>(thread));
            return RedirectToAction("ViewCategory", "Category", new { categoryId = thread.CategoryId, pageIndex });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteThreadAsync(Guid threadId, Guid categoryId, int pageIndex, int pageSize)
        {
            if (threadId != Guid.Empty && categoryId != Guid.Empty)
                await _threadService.RemoveAsync(threadId);
            return RedirectToAction("ViewCategory", "Category", new { categoryId, pageIndex, pageSize });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> MakeThreadStickyAsync(Guid threadId, Guid categoryId, int pageIndex)
        {
            if (threadId != Guid.Empty && categoryId != Guid.Empty)
                await _threadService.StickThreadAsync(threadId);
            return RedirectToAction("ViewCategory", "Category", new { categoryId, pageIndex });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> MakeThreadNonStickyAsync(Guid threadId, Guid categoryId, int pageIndex)
        {
            if (threadId != Guid.Empty && categoryId != Guid.Empty)
                await _threadService.UnStickThreadAsync(threadId);
            return RedirectToAction("ViewCategory", "Category", new { categoryId, pageIndex });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> SetThreadLockedAsync(Guid threadId, Guid categoryId, int pageIndex)
        {
            if (threadId != Guid.Empty && categoryId != Guid.Empty)
                await _threadService.LockThreadAsync(threadId);
            return RedirectToAction("ViewCategory", "Category", new { categoryId, pageIndex });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> SetThreadUnlockedAsync(Guid threadId, Guid categoryId, int pageIndex)
        {
            if (threadId != Guid.Empty && categoryId != Guid.Empty)
                await _threadService.UnlockThreadAsync(threadId);
            return RedirectToAction("ViewCategory", "Category", new { categoryId, pageIndex });
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> ChangeCategoryAsync(Guid threadId, Guid categoryId)
        {
            if (threadId != Guid.Empty && categoryId != Guid.Empty)
            {
                await _threadService.MoveThreadAsync(threadId, categoryId);
                return Json(new { message = "Thread was successfully moved." });
            }
            return Json(new { message = "Something went wrong, thread wasn't move in the new category" });
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> SearchThreadsAsync(string term)
        {
            if (string.IsNullOrEmpty(term) is false)
            {
                var data = await _threadService.GetThreadsBySearchAsync(term);
                if (data.Count() != 0)
                {
                    return Json(_mapper.Map<IEnumerable<ThreadViewModel>>(data));
                }
                return Json(new { error = "Sorry there's no match" });
            }
            return Json(new { error = "Sorry there's no match" });
        }
    }
}
