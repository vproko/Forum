using System;
using System.Threading.Tasks;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService) => _messageService = messageService;

        public async Task<IActionResult> CreateMessageAsync(MessageViewModel message, string threadId, string search, string view, int page)
        {
            await _messageService.CreateMessageAsync(message);

            return ToWhichViewToReturn(threadId, search, view, page);
        }

        public async Task<IActionResult> DeleteMessage(string messageId,int totalMessages, int currentPage)
        {
            await _messageService.DeleteMessageAsync(messageId);
            int lastPage = decimal.ToInt32(Math.Round(Math.Ceiling(((decimal)totalMessages - 1) / 5), 0)) - 1;
            int page = lastPage < currentPage ? lastPage : currentPage;

            return RedirectToAction("ProfileAsync", "User", new { tab = "#vtab3", page });
        }

        public async Task<IActionResult> DeleteAllMessageAsync(string userId)
        {
            await _messageService.DeleteAllUsersMessagesAsync(userId);

            return RedirectToAction("ProfileAsync", "User", new { tab = "#vtab3" });
        }

        private IActionResult ToWhichViewToReturn( string threadId, string search, string view, int page)
        {
            if (search != null)
                return RedirectToAction("SearchAsync", "Post", new { search, page });

            if (threadId != null && view == null)
                return RedirectToAction("ShowPostsAsync", "Post", new { threadId, page });

            if(view != null)
                return RedirectToAction("RecentPostsAsync", "Post", new { page });

            return RedirectToAction("ProfileAsync", "User", new { tab = "#vtab3", page });
        }
    }
}