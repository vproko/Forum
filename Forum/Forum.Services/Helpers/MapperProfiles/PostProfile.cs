using AutoMapper;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;
using System;

namespace Forum.Services.Helpers.MapperProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ReverseMap()
                .ForMember(p => p.PostId, src => src.MapFrom(src => Guid.NewGuid()))
                .ForMember(p => p.DatePosted, src => src.MapFrom(src => DateTime.UtcNow))
                .ForMember(p => p.Reported, src => src.MapFrom(src => false))
                .ForMember(p => p.Edited, src => src.MapFrom(src => false));

            CreateMap<PostDto, PostViewModel>()
                .ReverseMap();
        }
    }
}
