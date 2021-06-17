using AutoMapper;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IUserService userService, IMapper mapper)
        {
            _categoryService = categoryService;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> ViewCategoriesAsync(int pageIndex = 1, int pageSize = 5)
        {
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetAllCategoriesAsync(pageIndex, pageSize)));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ViewCategoryAsync(Guid categoryId, int pageIndex = 1, int pageSize = 5)
        {
            if (User.Identity.IsAuthenticated == true)
                ViewData["User"] = _mapper.Map<UserViewModel>(await _userService.FindUserAsync(User.Identity.Name));
            CategoryDto data = await _categoryService.GetCategoryByIdAsync(categoryId, pageIndex, pageSize);
            ViewData["PageIndex"] = pageIndex;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = (int)Math.Ceiling((decimal)data.ThreadsCount / pageSize);
            return View(_mapper.Map<CategoryViewModel>(data));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoryAsync(CategoryViewModel category)
        {
            if (ModelState.IsValid)
                await _categoryService.CreateAsync(_mapper.Map<CategoryDto>(category));
            return RedirectToAction("ViewCategories");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryViewModel category, int pageIndex, int pageSize)
        {
            if (ModelState.IsValid)
                await _categoryService.UpdateAsync(_mapper.Map<CategoryDto>(category));
            return RedirectToAction("ViewCategory", new { categoryId = category.CategoryId, pageIndex, pageSize });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteCategoryAsync(Guid categoryId)
        {
            await _categoryService.RemoveAsync(categoryId);
            return RedirectToAction("ViewCategories");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> GetCategoryies()
        {
            return Json(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetAllCategoriesAsync(1, 5)));
        }
    }
}
