using AutoMapper;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IUserService userService, IMapper mapper)
        {
            _messageService = messageService;
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(MessageViewModel message, Guid threadId, Guid userId, string username, string term, int pageIndex, int pageSize)
        {
            if (ModelState.IsValid && threadId != Guid.Empty)
            {
                await _messageService.CreateAsync(_mapper.Map<MessageDto>(message));
                return ToWhichPageToReturn(threadId, userId, username, term, pageIndex, pageSize);
            }
            return RedirectToAction("ViewThread", "Thread", new { threadId });
        }

        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateMessageAdminAsync(MessageViewModel message, int postIdx, int replyIdx, int postPgSize, int replyPgSize, string whichTab)
        {
            if (ModelState.IsValid)
                await _messageService.CreateAsync(_mapper.Map<MessageDto>(message));
            if (whichTab == "posts")
                return RedirectToAction("ReportedPosts", "Post", new { postIdx, replyIdx, postPgSize, replyPgSize });
            return RedirectToAction("ReportedReplies", "Reply", new { postIdx, replyIdx, postPgSize, replyPgSize });
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateMessageReplyAsync(MessageViewModel message)
        {
            if (ModelState.IsValid)
                await _messageService.CreateAsync(_mapper.Map<MessageDto>(message));
            return RedirectToAction("ViewMessages");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteMessageAsync(Guid messageId, int pageIndex)
        {
            if (messageId != Guid.Empty)
                await _messageService.RemoveAsync(messageId);
            return RedirectToAction("ViewMessages", new { pageIndex });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ViewMessagesAsync(int pageIndex = 1, int pageSize = 5)
        {
            UserDto user = await _userService.GetUsersMessagesAsync(User.Identity.Name, pageIndex, pageSize);
            ViewData["IndexPage"] = pageIndex;
            ViewData["TotalPages"] = (int)Math.Ceiling((decimal)user.MessagesCount / pageSize);
            return View(_mapper.Map<IEnumerable<MessageViewModel>>(user.Messages));
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
