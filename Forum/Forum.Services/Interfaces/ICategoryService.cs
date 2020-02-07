using Forum.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task<CategoryViewModel> GetCategoryByIdAsync(string categoryId);
        Task CreateCategoryAsync(CategoryViewModel category);
        Task UpdateCategoryAsync(CategoryViewModel update);
        Task DeleteCategoryAsync(string categoryId);
    }
}
