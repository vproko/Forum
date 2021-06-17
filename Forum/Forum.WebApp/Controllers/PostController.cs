using AutoMapper;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Forum.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IUserService userService, IMapper mapper)
        {
            _postService = postService;
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePostAsync(int pageIndex, PostViewModel post)
        {
            if (ModelState.IsValid)
                await _postService.CreateAsync(_mapper.Map<PostDto>(post), User.Identity.Name);
            return RedirectToAction("ViewThread", "Thread", new { threadId = post.ThreadId, pageIndex });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> FindUsersPostsAsync(Guid userId, string username, CancellationToken ct, int pageIndex = 1, int pageSize = 5)
        {
            if (userId != Guid.Empty)
            {
                ViewData["UserID"] = userId;
                ViewData["Username"] = username;
                PageInfoViewData(pageIndex, pageSize);
                if (User.Identity.IsAuthenticated is true)
                    ViewData["User"] = _mapper.Map<UserViewModel>(await _userService.FindUserAsync(User.Identity.Name));
                return View(_mapper.Map<IEnumerable<PostViewModel>>(await _postService.GetPostsByUsersIdAsync(userId, pageIndex, pageSize, ct)));
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RecentPostsAsync(CancellationToken ct, int pageIndex = 1, int pageSize = 5)
        {
            PageInfoViewData(pageIndex, pageSize);
            if (User.Identity.IsAuthenticated == true)
                ViewData["User"] = _mapper.Map<UserViewModel>(await _userService.FindUserAsync(User.Identity.Name));
            return View(_mapper.Map<IEnumerable<PostViewModel>>(await _postService.GetRecentPostsPerPageAsync(pageIndex, pageSize, ct)));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPostAsync(PostViewModel post, Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            if (ModelState.IsValid)
            {
                await _postService.UpdateAsync(_mapper.Map<PostDto>(post), User.Identity.Name);
                return ToWhichPageToReturn(threadId, userId, username, term, pageIndex, pageSize);
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPostAdminAsync(PostViewModel post, int postIdx, int replyIdx, int postPgSize, int replyPgSize)
        {
            if (ModelState.IsValid)
                await _postService.UpdateAsync(_mapper.Map<PostDto>(post), User.Identity.Name);
            return RedirectToAction("ReportedPosts", new { postIdx, replyIdx, postPgSize, replyPgSize });
        }

        [Authorize]
        public async Task<IActionResult> ReportPostAsync(Guid postId, Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            if (postId != Guid.Empty)
            {
                await _postService.ReportAsync(postId);
                return ToWhichPageToReturn(threadId, userId, username, term, pageIndex, pageSize);
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UnReportPostAsync(Guid postId, int postIdx, int replyIdx, int postPgSize, int replyPgSize)
        {
            if (postId != Guid.Empty)
                await _postService.UnReportAsync(postId);
            return RedirectToAction("ReportedPosts", new { postIdx, replyIdx, postPgSize, replyPgSize });
        }

        [Authorize]
        public async Task<IActionResult> DeletePostAsync(Guid postId, Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            if (postId != Guid.Empty)
            {
                await _postService.RemoveAsync(postId);
                return ToWhichPageToReturn(threadId, userId, username, term, pageIndex, pageSize);
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletePostAdminAsync(Guid postId, int postIdx, int replyIdx, int postPgSize, int replyPgSize)
        {
            if (postId != Guid.Empty)
                await _postService.RemoveAsync(postId);
            return RedirectToAction("ReportedPosts", new { postIdx, replyIdx, postPgSize, replyPgSize });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> ReportedPostsAsync(CancellationToken ct, int postIdx = 1, int replyIdx = 1, int postPgSize = 5, int replyPgSize = 5)
        {
            ReportsViewModel reports = new ReportsViewModel
            {
                ReportedPosts = _mapper.Map<IEnumerable<PostViewModel>>(await _postService.GetReportedPostsPerPageAsync(postIdx, postPgSize, ct)),
                ReportedReplies = Enumerable.Empty<ReplyViewModel>()
            };
            ViewData["PageInfo"] = new ReportsPageInfoModel()
            {
                Admin = _mapper.Map<UserViewModel>(await _userService.FindUserAsync(User.Identity.Name)),
                PostIdx = postIdx,
                ReplyIdx = replyIdx,
                PostPgSize = postPgSize,
                ReplyPgSize = replyPgSize,
                WhichTab = "posts"
            };
            return View(reports);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> ChangePostsThreadAsync(Guid postId, Guid threadId)
        {
            if (postId != Guid.Empty && threadId != Guid.Empty)
            {
                await _postService.MovePostAsync(postId, threadId);
                return Json(new { response = "The post was successfully moved" });
            }
            return Json(new { response = "The post wasn't moved" });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchPostsAsync(string term, CancellationToken ct, int pageIndex = 1, int pageSize = 5)
        {
            if (string.IsNullOrEmpty(term) is false)
            {
                await SearchViewDataAsync(term, pageIndex, pageSize);
                return View(_mapper.Map<IEnumerable<PostViewModel>>(await _postService.FindPostsAsync(term, pageIndex, pageSize, ct)));
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RedirectToSearchPostsAsync(string term, int pageIndex, int pageSize, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(term) is false)
            {
                await SearchViewDataAsync(term, pageIndex, pageSize);
                return View("Views/Post/SearchPosts.cshtml", _mapper.Map<IEnumerable<PostViewModel>>(await _postService.FindPostsAsync(term, pageIndex, pageSize, ct)));
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        private async Task SearchViewDataAsync(string term, int pageIndex, int pageSize)
        {
            PageInfoViewData(pageIndex, pageSize);
            ViewData["SearchTerm"] = term;
            if (User.Identity.IsAuthenticated is true)
                ViewData["User"] = _mapper.Map<UserViewModel>(await _userService.FindUserAsync(User.Identity.Name));
        }

        private void PageInfoViewData(int pageIndex, int pageSize)
        {
            ViewData["PageIndex"] = pageIndex;
            ViewData["PageSize"] = pageSize;
        }

        private IActionResult ToWhichPageToReturn(Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            return true switch
            {
                bool _ when userId != Guid.Empty && string.IsNullOrEmpty(username) is false => RedirectToAction("FindUsersPosts", new { userId, username, pageIndex, pageSize }),
                bool _ when threadId != Guid.Empty => RedirectToAction("ViewThread", "Thread", new { threadId, pageIndex, pageSize }),
                bool _ when string.IsNullOrEmpty(term) is false => RedirectToAction("RedirectToSearchPosts", new { term, pageIndex, pageSize }),
                _ => RedirectToAction("RecentPosts", new { pageIndex, pageSize }),
            };
        }
    }
}
