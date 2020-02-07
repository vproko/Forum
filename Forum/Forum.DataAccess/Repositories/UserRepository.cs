using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository<User>
    {
        public UserRepository(ForumDbContext context) : base(context) { }

        public IEnumerable<User> GetAll() => _context.Users;

        public User GetById(string id)
        {
            return _context.Users.Include(u => u.Posts).Include(u => u.Messages).FirstOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.Include(u => u.Messages).Include(u => u.Posts).FirstOrDefault(u => u.UserName == username);
        }

        public int Insert(User entity)
        {
            _context.Users.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(User entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(string id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
