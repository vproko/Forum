using Forum.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageViewModel>> GetAllMessagesAsync();
        Task<IEnumerable<MessageViewModel>> GetMessagesByUsernameAsync(string username);
        Task CreateMessageAsync(MessageViewModel message);
        Task DeleteMessageAsync(string messageId);
        Task DeleteAllUsersMessagesAsync(string userId);
    }
}
