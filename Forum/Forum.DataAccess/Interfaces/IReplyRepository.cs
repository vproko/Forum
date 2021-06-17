using Forum.DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.DataAccess.Interfaces
{
    public interface IReplyRepository : IRepository<Reply>
    {
        Task<IEnumerable<Reply>> GetUsersRepliesAsync(Guid userId);
        Task<IEnumerable<Reply>> GetReportedRepliesAsync(int pageIndex, int pageSize, CancellationToken ct);
        Task<int> GetReportedRepliesCountAsync();
    }
}