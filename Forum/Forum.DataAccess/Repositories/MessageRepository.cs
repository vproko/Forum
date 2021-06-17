using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ForumDbContext context) : base(context) { }
              
        public async Task<IEnumerable<Message>> GetMessagesAsync(Guid userId, int pageIndex, int pageSize)
        {
            return await _context.Messages
                .Where(m => m.ReceiverId == userId)
                .Select(m => new Message
                {
                    MessageId = m.MessageId,
                    ReceiverId = m.ReceiverId,
                    SenderId = m.SenderId,
                    SenderUsername = m.SenderUsername,
                    Content = m.Content,
                    DateSent = m.DateSent,
                    User = new User
                    {
                        Id = m.User.Id,
                        UserName = m.User.UserName,
                        Joined = m.User.Joined,
                        PostsCount = m.User.Posts.Count(),
                        RepliesCount = m.User.Replies.Count(),
                        Avatar = m.User.Avatar
                    }
                })
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(m => m.DateSent)
                .ToListAsync();
        }
        
        public async Task<int> GetMessagesCountAsync (Guid userId)
        {
            return await _context.Messages
                .AsNoTracking()
                .Where(m => m.User.Id == userId)
                .Select(m => m.MessageId)
                .CountAsync();
        }
    }
}
