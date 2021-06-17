using System;
using System.Threading.Tasks;

namespace Forum.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IThreadRepository Threads { get; }
        IPostRepository Posts { get; }
        IMessageRepository Messages { get; }
        IUserRepository Users { get; }
        IReplyRepository Replies { get; }
        Task<int> CompleteAsync();
    }
}
