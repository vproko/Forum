using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApp.ViewComponents
{
    public class MessagesCountViewComponent : ViewComponent
    {
        private readonly IMessageService _messageService;

        public MessagesCountViewComponent(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<string> InvokeAsync()
        {
            IEnumerable<MessageViewModel> count = await _messageService.GetMessagesByUsernameAsync(User.Identity.Name);

            return $"{count.Count()}";
        }
    }
}
