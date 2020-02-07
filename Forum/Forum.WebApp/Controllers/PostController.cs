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
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IThreadService _threadService;
        private readonly IUserService _userService;

        public PostController(IPostService postService, IThreadService threadService, IUserService userService)
        {
            _postService = postService;
            _threadService = threadService;
            _userService = userService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> ShowPostsAsync(string threadId, int page = 0)
        {
            ThreadViewModel thread = await _threadService.GetThreadByIdAsync(threadId);
            IEnumerable<PostViewModel> sorted = await PagesInfoAuthCheckSortPostsAsync(thread.Posts, page);
            ViewBag.Thread = thread;

            return View(sorted);
        }

        [AllowAnonymous]
        public async Task<IActionResult> RecentPostsAsync(int page = 0)
        {
            IEnumerable<PostViewModel> posts = await _postService.GetAllRecentPostsAsync();
            ViewBag.View = "RecentPostsAsync";

            return View(await PagesInfoAuthCheckSortPostsAsync(posts, page));
        }

        [AllowAnonymous]
        public async Task<IActionResult> SearchAsync(string search, int page = 0)
        {
            if (search != null)
            {
                IEnumerable<PostViewModel> result = await _postService.SearchPostsAsync(search);
                ViewBag.SearchTerm = search;

                return View(await PagesInfoAuthCheckSortPostsAsync(result, page));
            }

            return RedirectToAction("ShowAllCategoriesAsync", "Category");
        }

        [HttpPost]
        public async Task<IActionResult> AddPostAsync(PostViewModel post, int totalCount)
        {
            if (ModelState.IsValid)
                await _postService.CreatePostAsync(post);

            int lastPage = decimal.ToInt32(Math.Round(Math.Ceiling(((decimal)totalCount + 1) / 5), 0)) - 1;

            return RedirectToAction("ShowPostsAsync", new { threadId = post.ThreadID, page = lastPage });
        }

        [HttpPost]
        public async Task<IActionResult> EditPostAsync(PostViewModel post, string view, string search, int page)
        {
            await _postService.ChangePostAsync(post);

            return ToWhichViewToReturn(post.ThreadID, view, search, page);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReplyAsync(string originalPoster, string originalPost, PostViewModel reply)
        {
            await _postService.CreatePostReplyAsync(originalPoster, originalPost, reply);
            IEnumerable<PostViewModel> totalPosts = await _postService.GetPostsByThreadAsync(reply.ThreadID);
            int lastPage = decimal.ToInt32(Math.Round(Math.Ceiling((decimal)totalPosts.Count() / 5), 0)) - 1;

            return RedirectToAction("ShowPostsAsync", new { threadId = reply.ThreadID, page = lastPage });
        }

        public async Task<IActionResult> ReportPostAsync(string postId, string threadId, string view, string search, int page)
        {
            await _postService.ReportUnreportPostAsync(postId);

            return ToWhichViewToReturn(threadId, view, search, page);
        }

        public async Task<IActionResult> ClearAllReportsAsync(string userId)
        {
            await _postService.UnreportAllPostsByUserIdAsync(userId);

            return RedirectToAction("ReportedPostsAsync");
        }

        public async Task<IActionResult> UnreportPostAsync(string postId)
        {
            await _postService.ReportUnreportPostAsync(postId);

            return RedirectToAction("ReportedPostsAsync");
        }

        public async Task<IActionResult> ReportedPostsAsync()
        {
            IEnumerable<PostViewModel> reported = await _postService.GetAllReportedPostsAsync();

            if(reported.Count() > 0) return View(reported);

            return View("NoReports");
        }

        public async Task<IActionResult> DeletePostAsync(string postId, string threadId, string view, string search, int currentPage)
        {
            await _postService.DeletePostAsync(postId);
            int totalPostsCount = await TotalPostsCountAsync(threadId, view, search);
            int totalPages = decimal.ToInt32(Math.Round(Math.Ceiling(((decimal)totalPostsCount) / 5), 0)) - 1;
            int page = totalPages <= currentPage ? totalPages : currentPage;

            return ToWhichViewToReturn(threadId, view, search, page);
        }

        #region PrivateMethods
        private async Task<IEnumerable<PostViewModel>> PagesInfoAuthCheckSortPostsAsync(IEnumerable<PostViewModel> posts, int page)
        {
            PaginationInfo(posts, page);
            await IsItAuthenticatedAsync();

            return posts.Skip(page * 5).Take(5);
        }

        private async Task IsItAuthenticatedAsync()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                ViewBag.CurrentUser = await _userService.GetCurrentUserAsync(User.Identity.Name);
        }

        private IActionResult ToWhichViewToReturn(string threadId, string view, string search, int page)
        {
            if (view == "ReportedPostsAsync" && User.IsInRole("admin"))
                return RedirectToAction("ReportedPostsAsync");

            if (threadId != null && view != "RecentPostsAsync" && search == null)
                return RedirectToAction("ShowPostsAsync", new { threadId, page });

            if(search != null)
                return RedirectToAction("SearchAsync", new { search, page });

            return RedirectToAction("RecentPostsAsync", new { page });
        }

        private void PaginationInfo(IEnumerable<PostViewModel> posts, int page)
        {
            ViewBag.Page = page;
            ViewBag.TotalPosts = posts.Count();
            ViewBag.TotalPages = decimal.ToInt32(Math.Round(Math.Ceiling((decimal)posts.Count() / 5), 0));
        }

        private async Task<int> TotalPostsCountAsync (string threadId, string view, string search)
        {
            IEnumerable<PostViewModel> result;

            if (search != null)
                result =  await _postService.SearchPostsAsync(search);
            else if(view == "RecentPostsAsync")
                result = await _postService.GetAllRecentPostsAsync();
            else
                result = await _postService.GetPostsByThreadAsync(threadId);

            return result.Count();
        }
        #endregion
    }
}