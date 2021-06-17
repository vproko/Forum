using Forum.DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(int pageIndex, int pageSize);
        Task<Category> GetCategoryAsync(Guid categoryId, int pageIndex, int pageSize);
    }
}