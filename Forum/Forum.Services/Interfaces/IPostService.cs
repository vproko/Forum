using Forum.Dto.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetPostsByUsersIdAsync(Guid userId, int pageIndex, int pageSize, CancellationToken ct);
        Task<IEnumerable<PostDto>> FindPostsAsync(string term, int pageIndex, int pageSize, CancellationToken ct);
        Task<IEnumerable<PostDto>> GetRecentPostsPerPageAsync(int pageIndex, int pageSize, CancellationToken ct);
        Task<IEnumerable<PostDto>> GetReportedPostsPerPageAsync(int pageIndex, int pageSize, CancellationToken ct);
        Task<int> GetReportedPostsCountAsync();
        Task CreateAsync(PostDto post, string username);
        Task UpdateAsync(PostDto post, string username);
        Task MovePostAsync(Guid postId, Guid threadId);
        Task ReportAsync(Guid id);
        Task UnReportAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}