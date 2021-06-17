using Microsoft.AspNetCore.Mvc;
using Forum.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;

namespace Forum.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public HomeController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryDto> data = await _categoryService.GetAllCategoriesAsync(1, 5);
            IEnumerable<CategoryViewModel> categories = _mapper.Map<IEnumerable<CategoryViewModel>>(data);
            return View(categories);
        }
    }
}