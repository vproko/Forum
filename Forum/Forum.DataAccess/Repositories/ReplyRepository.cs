using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        public ReplyRepository(ForumDbContext context) : base(context) { }

        public async Task<IEnumerable<Reply>> GetUsersRepliesAsync(Guid userId)
        {
            return await _context.Replies
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reply>> GetReportedRepliesAsync(int pageIndex, int pageSize, CancellationToken ct)
        {
            return await _context.Replies
                .Include(r => r.User)
                .Where(r => r.Reported == true)
                .Select(r => new Reply
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

                })
                .OrderByDescending(r => r.DateReplied)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<int> GetReportedRepliesCountAsync()
        {
            return await _context.Replies
                .AsNoTracking()
                .Where(r => r.Reported == true)
                .Select(r => r.ReplyId)
                .CountAsync();
        }
    }
}