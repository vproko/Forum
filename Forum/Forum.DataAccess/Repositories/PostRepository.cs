using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.DataAccess.Repositories
{
    public class PostRepository : BaseRepository, IRepository<Post>
    {
        public PostRepository(ForumDbContext context) : base(context) { }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.Include(p => p.Thread).Include(p => p.User);
        }

        public Post GetById(string id)
        {
            return _context.Posts.FirstOrDefault(p => p.PostID == id);
        }

        public int Insert(Post entity)
        {
            _context.Posts.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Post entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(string id)
        {
            Post post = _context.Posts.FirstOrDefault(p => p.PostID == id);

            if (post != null)
            {
                _context.Posts.Remove(post);
                return _context.SaveChanges();
            }
            
            return -1;
        }
    }
}
