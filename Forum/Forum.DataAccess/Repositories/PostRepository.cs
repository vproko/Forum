using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models; // added to all Thread models, to avoid conflict with threading tasks
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ForumDbContext context) : base(context) { }

        public async Task<IEnumerable<Post>> GetReportedPostsAsync(int pageIndex, int pageSize, CancellationToken ct)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Where(p => p.Reported == true)
                .Select(p => new Post
                {
                    PostId = p.PostId,
                    ThreadId = p.ThreadId,
                    UserId = p.UserId,
                    Content = p.Content,
                    Reported = p.Reported,
                    Edited = p.Edited,
                    EditedBy = p.EditedBy,
                    DatePosted = p.DatePosted,
                    RepliesCount = p.Replies.Count(),
                    User = new User
                    {
                        Id = p.User.Id,
                        UserName = p.User.UserName,
                        Joined = p.User.Joined,
                        PostsCount = p.User.Posts.Select(p => p.PostId).Count(),
                        RepliesCount = p.User.Replies.Select(r => r.ReplyId).Count(),
                    },
                })
                .OrderByDescending(p => p.DatePosted)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<int> GetReportedPostsCountAsync()
        {
            return await _context.Posts
                .AsNoTracking()
                .Where(p => p.Reported == true)
                .Select(p => p.PostId)
                .CountAsync();
        }

        public async Task<IEnumerable<Post>> GetRecentPostsAsync(int pageIndex, int pageSize, CancellationToken ct)
        {
            return await _context.Posts
                .Select(p => new Post
                {
                    PostId = p.PostId,
                    ThreadId = p.ThreadId,
                    UserId = p.UserId,
                    Content = p.Content,
                    Reported = p.Reported,
                    Edited = p.Edited,
                    EditedBy = p.EditedBy,
                    DatePosted = p.DatePosted,
                    Replies = p.Replies.Select(r => new Reply
                    {
                        ReplyId = r.ReplyId,
                        PostId = r.PostId,
                        UserId = r.UserId,
                        Username = r.Username,
                        Content = r.Content,
                        Reported = r.Reported,
                        DateReplied = r.DateReplied,
                        Edited = r.Edited,
                        EditedBy = r.EditedBy,
                        User = new User
                        {
                            Id = r.User.Id,
                            UserName = r.User.UserName,
                            Joined = r.User.Joined,
                            PostsCount = r.User.Posts.Select(p => p.PostId).Count(),
                            RepliesCount = r.User.Replies.Select(r => r.ReplyId).Count(),
                        }
                    }).OrderBy(r => r.DateReplied)
                      .ToList(),
                    RepliesCount = p.Replies.Count(),
                    User = new User
                    {
                        Id = p.User.Id,
                        UserName = p.User.UserName,
                        Joined = p.User.Joined,
                        PostsCount = p.User.Posts.Select(p => p.PostId).Count(),
                        RepliesCount = p.User.Replies.Select(r => r.ReplyId).Count(),
                    },
                    Thread = new DomainClasses.Models.Thread //
                    {
                        Title = p.Thread.Title
                    }
                })
                .OrderByDescending(p => p.DatePosted)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Post>> GetUsersPostsAsync(Guid userId, int pageIndex, int pageSize, CancellationToken ct)
        {
            return await _context.Posts
                .Where(p => p.UserId == userId)
                .Select(p => new Post
                {
                    PostId = p.PostId,
                    Username = p.Username,
                    ThreadId = p.ThreadId,
                    UserId = p.UserId,
                    Content = p.Content,
                    Reported = p.Reported,
                    Edited = p.Edited,
                    EditedBy = p.EditedBy,
                    DatePosted = p.DatePosted,
                    Replies = p.Replies.Select(r => new Reply
                    {
                        ReplyId = r.ReplyId,
                        PostId = r.PostId,
                        UserId = r.UserId,
                        Username = r.Username,
                        Content = r.Content,
                        Reported = r.Reported,
                        DateReplied = r.DateReplied,
                        Edited = r.Edited,
                        EditedBy = r.EditedBy,
                        User = new User
                        {
                            Id = r.User.Id,
                            UserName = r.User.UserName,
                            Joined = r.User.Joined,
                            PostsCount = r.User.Posts.Select(p => p.PostId).Count(),
                            RepliesCount = r.User.Replies.Select(r => r.ReplyId).Count(),
                        }
                    }).OrderBy(r => r.DateReplied)
                      .ToList(),
                    RepliesCount = p.Replies.Count(),
                    User = new User
                    {
                        Id = p.User.Id,
                        UserName = p.User.UserName,
                        Joined = p.User.Joined,
                        PostsCount = p.User.Posts.Select(p => p.PostId).Count(),
                        RepliesCount = p.User.Replies.Select(r => r.ReplyId).Count(),
                    },
                    Thread = new DomainClasses.Models.Thread
                    {
                        Title = p.Thread.Title
                    }
                })
                .OrderByDescending(p => p.DatePosted)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<IEnumerable<Post>> SearchPostsAsync(string term, int pageIndex, int pageSize, CancellationToken ct)
        {
            return await _context.Posts
                .Where(p =>p.Thread.Title.Contains(term) || p.Content.Contains(term) || p.Replies.Any(r => r.Content.Contains(term)))
                .Select(p => new Post
                {
                    PostId = p.PostId,
                    Username = p.Username,
                    ThreadId = p.ThreadId,
                    UserId = p.UserId,
                    Content = p.Content,
                    Reported = p.Reported,
                    Edited = p.Edited,
                    EditedBy = p.EditedBy,
                    DatePosted = p.DatePosted,
                    Replies = p.Replies.Select(r => new Reply
                    {
                        ReplyId = r.ReplyId,
                        PostId = r.PostId,
                        UserId = r.UserId,
                        Username = r.Username,
                        Content = r.Content,
                        Reported = r.Reported,
                        DateReplied = r.DateReplied,
                        Edited = r.Edited,
                        EditedBy = r.EditedBy,
                        User = new User
                        {
                            Id = r.User.Id,
                            UserName = r.User.UserName,
                            Joined = r.User.Joined,
                            PostsCount = r.User.Posts.Select(p => p.PostId).Count(),
                            RepliesCount = r.User.Replies.Select(r => r.ReplyId).Count(),
                        }
                    }).OrderBy(r => r.DateReplied)
                      .ToList(),
                    RepliesCount = p.Replies.Count(),
                    User = new User
                    {
                        Id = p.User.Id,
                        UserName = p.User.UserName,
                        Joined = p.User.Joined,
                        PostsCount = p.User.Posts.Select(p => p.PostId).Count(),
                        RepliesCount = p.User.Replies.Select(r => r.ReplyId).Count(),
                    },
                    Thread = new DomainClasses.Models.Thread
                    {
                        Title = p.Thread.Title
                    }
                })
                .OrderByDescending(p => p.DatePosted)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }
    }
}
