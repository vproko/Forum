using Forum.Dto.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IReplyService
    {
        Task<IEnumerable<ReplyDto>> GetReportedRepliesPerPageAsync(int pageIndex, int pageSize, CancellationToken ct);
        Task<int> GetReportedRepliesCountAsync();
        Task DeleteUsersRepliesAsync(Guid userId);
        Task CreateAsync(ReplyDto reply);
        Task UpdateAsync(ReplyDto reply);
        Task ReportAsync(Guid replyId);
        Task UnReportAsync(Guid replyId);
        Task RemoveAsync(Guid id);
    }
}
