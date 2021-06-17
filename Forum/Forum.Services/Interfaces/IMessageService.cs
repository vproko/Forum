using Forum.Dto.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetUsersMessagesPerPageAsync(string username, int pageIndex, int pageSize);
        Task<int> GetMessagesCountAsync(string username);
        Task CreateAsync(MessageDto message);
        Task RemoveAsync(Guid id);
    }
}
