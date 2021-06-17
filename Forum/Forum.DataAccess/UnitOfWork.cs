using Forum.DataAccess.Interfaces;
using Forum.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace Forum.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ForumDbContext _context;
        private Lazy<ICategoryRepository> _categories;
        private Lazy<IThreadRepository> _threads;
        private Lazy<IPostRepository> _posts;
        private Lazy<IMessageRepository> _messages;
        private Lazy<IUserRepository> _users;
        private Lazy<IReplyRepository> _replies;

        public UnitOfWork(ForumDbContext context)
        {
            _context = context;
            _categories = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _threads = new Lazy<IThreadRepository>(() => new ThreadRepository(_context));
            _posts = new Lazy<IPostRepository>(() => new PostRepository(_context));
            _messages = new Lazy<IMessageRepository>(() => new MessageRepository(_context));
            _users = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _replies = new Lazy<IReplyRepository>(() => new ReplyRepository(_context));
        }

        public ICategoryRepository Categories
        {
            get { return _categories.Value; }
        }


        public IThreadRepository Threads 
        { 
            get { return _threads.Value; } 
        }

        public IPostRepository Posts
        {
            get { return _posts.Value; }
        }

        public IMessageRepository Messages
        {
            get { return _messages.Value; }
        }

        public IUserRepository Users
        {
            get { return _users.Value; }
        }

        public IReplyRepository Replies 
        {
            get { return _replies.Value; }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
