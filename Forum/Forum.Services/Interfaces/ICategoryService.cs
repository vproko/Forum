using Forum.Dto.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(int pageIndex, int pageSize);
        Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId, int pageIndex, int pageSize);
        Task CreateAsync(CategoryDto category);
        Task UpdateAsync(CategoryDto category);
        Task RemoveAsync(Guid id);
    }
}
