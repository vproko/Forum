using Forum.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.WebApp.ViewComponents
{
    public class MessageCountViewComponent : ViewComponent
    {
        private readonly IMessageService _messageService;

        public MessageCountViewComponent(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int count = await _messageService.GetMessagesCountAsync(User.Identity.Name);
            return Content(count.ToString());
        }
    }
}
