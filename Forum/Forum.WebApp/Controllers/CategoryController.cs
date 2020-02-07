using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApp.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        [AllowAnonymous]
        public async Task<IActionResult> ShowAllCategoriesAsync()
        {
            IEnumerable<CategoryViewModel> categories = await _categoryService.GetAllCategoriesAsync();

            return View(categories);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateCategoryAsync(CategoryViewModel category)
        {
            if(ModelState.IsValid)
                await _categoryService.CreateCategoryAsync(category);

            return RedirectToAction("ShowAllCategoriesAsync");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategoryAsync(string categoryId)
        {
            await _categoryService.DeleteCategoryAsync(categoryId);

            return RedirectToAction("ShowAllCategoriesAsync");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditCategoryAsync(CategoryViewModel update)
        {
            await _categoryService.UpdateCategoryAsync(update);

            return RedirectToAction("ShowAllCategoriesAsync");
        }
    }
}