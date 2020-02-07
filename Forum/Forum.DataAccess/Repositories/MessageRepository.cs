using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using System.Collections.Generic;
using System.Linq;

namespace Forum.DataAccess.Repositories
{
    public class MessageRepository : BaseRepository, IRepository<Message>
    {
        public MessageRepository(ForumDbContext context) : base(context) { }

        public IEnumerable<Message> GetAll() => _context.Messages;

        public Message GetById(string id)
        {
            return _context.Messages.FirstOrDefault(m => m.MessageID == id);
        }

        public int Insert(Message entity)
        {
            _context.Messages.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Message entity)
        {
            Message privateMessage = _context.Messages.FirstOrDefault(pm => pm.MessageID == entity.MessageID);

            if (privateMessage != null)
            {
                privateMessage.MessageID = entity.MessageID;
                privateMessage.ReceiverID = entity.ReceiverID;
                privateMessage.ReceiverUsername = entity.ReceiverUsername;
                privateMessage.SenderID = entity.SenderID;
                privateMessage.SenderUsername = entity.SenderUsername;
                privateMessage.Content = entity.Content;
                privateMessage.Created = entity.Created;

                return _context.SaveChanges();
            }

            return -1;
        }

        public int Delete(string id)
        {
            Message privateMessage = _context.Messages.FirstOrDefault(pm => pm.MessageID == id);

            if (privateMessage != null)
            {
                _context.Remove(privateMessage);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
