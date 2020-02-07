using AutoMapper;
using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await Task.Run(() => _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryRepository.GetAll()));
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(string categoryId)
        {
            Category category = await Task.Run(() => _mapper.Map<Category>(_categoryRepository.GetById(categoryId)));

            if (category != null)
                return _mapper.Map<CategoryViewModel>(category);
            else
                throw new Exception("There's no category with that id");
        }

        public async Task CreateCategoryAsync(CategoryViewModel category)
        {
            await Task.Run(() => _categoryRepository.Insert(_mapper.Map<Category>(category)));
        }

        public async Task UpdateCategoryAsync(CategoryViewModel update)
        {
            Category category = await Task.Run(() => _mapper.Map<Category>(_categoryRepository.GetById(update.CategoryID)));

            if (category != null)
            {
                category.CategoryID = update.CategoryID;
                category.Title = update.Title;

                int result = await Task.Run(() => _categoryRepository.Update(category));
                CheckForError(result);
            }
            else
                throw new Exception("There's no category with that id");
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            Category category = await Task.Run(() => _categoryRepository.GetById(categoryId));

            if (category != null)
            {
                int result = _categoryRepository.Delete(categoryId);
                CheckForError(result);
            }
            else
                throw new Exception("There's no category with that id");
        }

        private void CheckForError(int result)
        {
            if (result == -1)
                throw new Exception("Something went wrong");
        }
    }
}
