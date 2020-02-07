using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.DataAccess.Repositories
{
    public class ThreadRepository : BaseRepository, IRepository<Thread>
    {
        public ThreadRepository(ForumDbContext context) : base(context) { }

        public IEnumerable<Thread> GetAll()
        {
            return _context.Threads.Include(t => t.Category);
        }

        public Thread GetById(string id)
        {
            return _context.Threads.Include(t => t.Category).Include(t => t.Posts).ThenInclude(p => p.User).FirstOrDefault(t => t.ThreadID == id);
        }

        public int Insert(Thread entity)
        {
            _context.Threads.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Thread entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(string id)
        {
            Thread thread = _context.Threads.FirstOrDefault(t => t.ThreadID == id);

            if (thread != null)
            {
                _context.Threads.Remove(thread);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
