using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ForumDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int pageIndex, int pageSize)
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Threads = c.Threads.Select(t => new Thread
                    {
                        ThreadId = t.ThreadId,
                        CategoryId = t.CategoryId,
                        Title = t.Title,
                        PostsCount = t.Posts.Select(p => p.PostId).Count(),
                        DateCreated = t.DateCreated,
                        Locked = t.Locked,
                        Sticky = t.Sticky
                    }).OrderByDescending(t => t.Sticky == true)
                      .ThenByDescending(t => t.DateCreated.Date)
                      .ThenByDescending(t => t.DateCreated.TimeOfDay)
                      .Take(pageSize)
                      .ToList(),
                    ThreadsCount = c.Threads.Select(t => t.ThreadId).Count()
                })
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(Guid categoryId, int pageIndex, int pageSize)
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(c => c.CategoryId == categoryId)
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Threads = c.Threads.Select(t => new Thread
                    {
                        ThreadId = t.ThreadId,
                        CategoryId = t.CategoryId,
                        Title = t.Title,
                        PostsCount = t.Posts.Select(p => p.PostId).Count(),
                        DateCreated = t.DateCreated,
                        Locked = t.Locked,
                        Sticky = t.Sticky,
                        Posts = t.Posts.Select(p => new Post
                        {
                            RepliesCount = p.Replies.Select(r => r.ReplyId).Count(),
                        }).Take(5).ToList(),
                    }).OrderByDescending(t => t.Sticky)
                      .ThenByDescending(t => t.DateCreated.Date)
                      .ThenByDescending(t => t.DateCreated.TimeOfDay)
                      .Skip((pageIndex - 1) * pageSize)
                      .Take(pageSize)
                      .ToList(),
                    ThreadsCount = c.Threads.Select(t => t.ThreadId).Count(),

                })
                .FirstAsync();
        }
    }
}
