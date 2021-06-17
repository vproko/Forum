using Forum.DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.DataAccess.Interfaces
{
    public interface IThreadRepository : IRepository<Thread>
    {
        Task<IEnumerable<Thread>> GetThreadsAsync(int pageIndex, int pageSize);
        Task<Thread> GetThreadByIdAsync(Guid threadId, int pageIndex, int pageSize);

        Task<IEnumerable<Thread>> GetThreadsByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Thread>> SearchThreadsAsync(string term);
    }
}
