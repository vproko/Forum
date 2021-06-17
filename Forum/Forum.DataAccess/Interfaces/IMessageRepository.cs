using Forum.DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.DataAccess.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessagesAsync(Guid userId, int pageIndex, int pageSize);
        Task<int> GetMessagesCountAsync(Guid userId);
    }
}