using AutoMapper;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;
using System;

namespace Forum.Services.Helpers.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ReverseMap()
                .ForMember(c => c.CategoryId, src => src.MapFrom(src => Guid.NewGuid()));

            CreateMap<CategoryDto, CategoryViewModel>()
                .ReverseMap();
        }
    }
}