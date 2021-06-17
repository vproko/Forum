using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class ThreadRepository : Repository<Thread>, IThreadRepository
    {
        public ThreadRepository(ForumDbContext context) : base(context) { }

        public async Task<IEnumerable<Thread>> GetThreadsByCategoryAsync(Guid categoryId)
        {
            return await _context.Threads
                .AsNoTracking()
                .Where(t => t.CategoryId == categoryId)
                .Select(t => new Thread
                {
                    ThreadId = t.ThreadId,
                    Title = t.Title,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Thread>> SearchThreadsAsync(string term)
        {
            return await _context.Threads
                .AsNoTracking()
                .Where(t => t.Title.ToLower().Contains(term.ToLower()))
                .Select(t => new Thread
                {
                    ThreadId = t.ThreadId,
                    Title = t.Title,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Thread>> GetThreadsAsync(int pageIndex, int pageSize)
        {
            return await _context.Threads
                .AsNoTracking()
                .Select(t => new Thread
                {
                    ThreadId = t.ThreadId,
                    CategoryId = t.CategoryId,
                    Title = t.Title,
                    DateCreated = t.DateCreated,
                    Locked = t.Locked,
                    Sticky = t.Sticky,
                    PostsCount = t.Posts.Select(p => p.PostId).Count(),
                })
                .OrderByDescending(t => t.DateCreated)
                .Skip(pageIndex - 1 * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Thread> GetThreadByIdAsync(Guid threadId, int pageIndex, int pageSize)
        {
            return await _context.Threads
                .AsNoTracking()
                .Where(t => t.ThreadId == threadId)
                .Select(t => new Thread
                {
                    ThreadId = t.ThreadId,
                    CategoryId = t.CategoryId,
                    Title = t.Title,
                    DateCreated = t.DateCreated,
                    Locked = t.Locked,
                    Sticky = t.Sticky,
                    Category = new Category
                    {
                        CategoryId = t.Category.CategoryId,
                        Name = t.Category.Name,
                    },
                    PostsCount = t.Posts.Select(p => p.PostId).Count(),
                    Posts = t.Posts.Select(p => new Post
                    {
                        PostId = p.PostId,
                        ThreadId = p.ThreadId,
                        UserId = p.UserId,
                        Username = p.Username,
                        Content = p.Content,
                        Reported = p.Reported,
                        Edited = p.Edited,
                        EditedBy = p.EditedBy,
                        DatePosted = p.DatePosted,
                        RepliesCount = p.Replies.Select(r => r.ReplyId).Count(),
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
                                IsItAdministrator = r.User.IsItAdministrator,
                            }
                        }).OrderBy(r => r.DateReplied.Date).ThenBy(r => r.DateReplied.TimeOfDay).ToList(),
                        User = new User
                        {
                            Id = p.User.Id,
                            UserName = p.User.UserName,
                            Avatar = p.User.Avatar,
                            Joined = p.User.Joined,
                            PostsCount = p.User.Posts.Select(p => p.PostId).Count(),
                            RepliesCount = p.User.Replies.Select(r => r.ReplyId).Count(),
                            IsItAdministrator = p.User.IsItAdministrator,
                            Suspended = p.User.Suspended,
                        },
                    }).OrderBy(p => p.DatePosted.Date).ThenBy(p => p.DatePosted.TimeOfDay).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                })
                .FirstAsync();
        }
    }
}