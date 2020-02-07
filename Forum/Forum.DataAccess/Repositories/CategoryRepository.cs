using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public CategoryRepository(ForumDbContext context) : base(context) { }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Include(c => c.Threads).ThenInclude(t => t.Posts);
        }

        public Category GetById(string id)
        {
            return _context.Categories.Include(c => c.Threads).ThenInclude(t => t.Posts).FirstOrDefault(c => c.CategoryID == id);
        }

        public int Insert(Category entity)
        {
            _context.Categories.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Category entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(string id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);

            if (category != null)
            {
                _context.Remove(category);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
