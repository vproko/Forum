using AutoMapper;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Forum.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class ReplyController : Controller
    {
        private readonly IReplyService _replyService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ReplyController(IReplyService replyService, IUserService userService, IMapper mapper)
        {
            _replyService = replyService;
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReplyAsync([FromForm] ReplyViewModel newReply, [FromQuery] Guid threadId, [FromQuery] Guid userId, [FromQuery] string username, string term, int pageIndex, int pageSize)
        {
            if (ModelState.IsValid)
            {
                await _replyService.CreateAsync(_mapper.Map<ReplyDto>(newReply));
                return ToWhichPageToReturn(threadId, userId, username, term, pageIndex, pageSize);
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReplyAsync(ReplyViewModel newReply, Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            if (ModelState.IsValid)
            {
                await _replyService.UpdateAsync(_mapper.Map<ReplyDto>(newReply));
                return ToWhichPageToReturn(threadId, userId, username, term, pageIndex, pageSize);
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReplyAdminAsync(ReplyViewModel newReply, int postIdx, int replyIdx, int postPgSize, int replyPgSize)
        {
            if (ModelState.IsValid)
                await _replyService.UpdateAsync(_mapper.Map<ReplyDto>(newReply));
            return RedirectToAction("ReportedReplies", new { postIdx, replyIdx, postPgSize, replyPgSize });
        }

        [Authorize]
        public async Task<IActionResult> ReportReplyAsync(Guid replyId, Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            if (replyId != Guid.Empty)
            {
                await _replyService.ReportAsync(replyId);
                return ToWhichPageToReturn(threadId, userId, username, term, pageIndex, pageSize);
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UnReportReplyAsync(Guid replyId, int postIdx, int replyIdx, int postPgSize, int replyPgSize)
        {
            if (replyId != Guid.Empty)
                await _replyService.UnReportAsync(replyId);
            return RedirectToAction("ReportedPosts", "Post", new { postIdx, replyIdx, postPgSize, replyPgSize });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> ReportedRepliesAsync(CancellationToken ct, int postIdx = 1, int replyIdx = 1, int postPgSize = 5, int replyPgSize = 5)
        {
            ReportsViewModel reports = new ReportsViewModel
            {
                ReportedReplies = _mapper.Map<IEnumerable<ReplyViewModel>>(await _replyService.GetReportedRepliesPerPageAsync(replyIdx, replyPgSize, ct))
            };
            ViewData["PageInfo"] = new ReportsPageInfoModel()
            {
                Admin = _mapper.Map<UserViewModel>(await _userService.FindUserAsync(User.Identity.Name)),
                PostIdx = postIdx,
                ReplyIdx = replyIdx,
                PostPgSize = postPgSize,
                ReplyPgSize = replyPgSize,
                WhichTab = "replies"
            };
            return View("Views/Post/ReportedPosts.cshtml", reports);
        }

        [Authorize]
        public async Task<IActionResult> DeleteReplyAsync(Guid replyId, Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            if (replyId != Guid.Empty)
            {
                await _replyService.RemoveAsync(replyId);
                return ToWhichPageToReturn(threadId, userId, username, term, pageIndex, pageSize);
            }
            return RedirectToAction("ViewCategories", "Category");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteReplyAdminAsync(Guid replyId, int postIdx, int replyIdx, int postPgSize, int replyPgSize)
        {
            if (replyId != Guid.Empty)
                await _replyService.RemoveAsync(replyId);
            return RedirectToAction("ReportedPosts", "Post", new { postIdx, replyIdx, postPgSize, replyPgSize });
        }

        private IActionResult ToWhichPageToReturn(Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            return true switch
            {
                bool _ when userId != Guid.Empty && string.IsNullOrEmpty(username) is false => RedirectToAction("FindUsersPosts", "Post", new { userId, username, pageIndex, pageSize }),
                bool _ when threadId != Guid.Empty => RedirectToAction("ViewThread", "Thread", new { threadId, pageIndex, pageSize }),
                bool _ when string.IsNullOrEmpty(term) is false => RedirectToAction("RedirectToSearchPosts", "Post", new { term, pageIndex, pageSize }),
                _ => RedirectToAction("RecentPosts", "Post", new { pageIndex, pageSize }),
            };
        }
    }
}
