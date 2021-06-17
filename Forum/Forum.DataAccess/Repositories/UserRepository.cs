using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ForumDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetUsersInfoAsync(int pageIndex, int pageSize)
        {
            return await _context.Users.AsNoTracking()
                .Where(u => u.IsItAdministrator != true)
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsItAdministrator = u.IsItAdministrator,
                    Online = u.Online,
                    Suspended = u.Suspended,
                    Avatar = u.Avatar,
                    Joined = u.Joined,
                    PostsCount = u.Posts.Select(p => p.PostId).Count(),
                    RepliesCount = u.Replies.Select(r => r.ReplyId).Count(),
                    MessagesCount = u.Messages.Select(m => m.MessageId).Count(),
                })
                .OrderBy(u => u.UserName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<IEnumerable<User>> GetUsersInfoBySearchAsync(string searchTerm, int pageIndex, int pageSize)
        {
            return await _context.Users.AsNoTracking()
                .Where(u => u.IsItAdministrator != true && u.UserName.ToLower().StartsWith(searchTerm.ToLower()))
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsItAdministrator = u.IsItAdministrator,
                    Online = u.Online,
                    Suspended = u.Suspended,
                    Avatar = u.Avatar,
                    Joined = u.Joined,
                    PostsCount = u.Posts.Select(p => p.PostId).Count(),
                    RepliesCount = u.Replies.Select(r => r.ReplyId).Count(),
                    MessagesCount = u.Messages.Select(m => m.MessageId).Count(),
                })
                .OrderBy(u => u.UserName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<User> FindUserInfoAsync(Guid userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new User
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    Email = u.Email,
                    IsItAdministrator = u.IsItAdministrator,
                    Online = u.Online,
                    Suspended = u.Suspended,
                    Avatar = u.Avatar,
                    Joined = u.Joined,
                    PostsCount = u.Posts.Select(p => p.PostId).Count(),
                    RepliesCount = u.Replies.Select(r => r.ReplyId).Count(),
                    MessagesCount = u.Messages.Select(m => m.MessageId).Count(),

                })
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUsersMessagesAsync(string username, int pageIndex, int pageSize)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .Select(u => new User
                {
                    Id = u.Id,
                    Messages = u.Messages.OrderByDescending(m => m.DateSent.Date)
                                         .ThenByDescending(m => m.DateSent.TimeOfDay)
                                         .Skip((pageIndex - 1) * pageSize)
                                         .Take(pageSize)
                                         .ToList(),
                    MessagesCount = u.Messages.Count()
                })
                .FirstOrDefaultAsync();
        }
    }
}