using AutoMapper;
using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task CreateAsync(CategoryDto category)
        {
            _unitOfWork.Categories.Add(_mapper.Map<Category>(category));
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(int pageIndex, int pageSize)
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _unitOfWork.Categories.GetCategoriesAsync(pageIndex, pageSize));
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId, int pageIndex, int pageSize)
        {
            return _mapper.Map<CategoryDto>(await _unitOfWork.Categories.GetCategoryAsync(categoryId, pageIndex, pageSize));
        }

        public async Task RemoveAsync(Guid id)
        {
            _unitOfWork.Categories.Remove(await _unitOfWork.Categories.FindAsync(id));
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(CategoryDto category)
        {
            Category match = await _unitOfWork.Categories.FindAsync(category.CategoryId);
            match.Name = category.Name ?? match.Name;
            await _unitOfWork.CompleteAsync();
        }
    }
}