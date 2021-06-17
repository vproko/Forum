using Forum.DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.DataAccess.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetUsersPostsAsync(Guid userId, int pageIndex, int pageSize, CancellationToken ct);
        Task<IEnumerable<Post>> SearchPostsAsync(string term, int pageIndex, int pageSize, CancellationToken ct);
        Task<IEnumerable<Post>> GetRecentPostsAsync(int pageIndex, int pageSize, CancellationToken ct);
        Task<IEnumerable<Post>> GetReportedPostsAsync(int pageIndex, int pageSize, CancellationToken ct);
        Task<int> GetReportedPostsCountAsync();
    }
}