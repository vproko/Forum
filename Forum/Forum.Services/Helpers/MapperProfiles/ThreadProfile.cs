using AutoMapper;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;
using System;

namespace Forum.Services.Helpers.MapperProfiles
{
    public class ThreadProfile : Profile
    {
        public ThreadProfile()
        {
            CreateMap<Thread, ThreadDto>()
                .ReverseMap()
                .ForMember(t => t.ThreadId, src => src.MapFrom(src => Guid.NewGuid()))
                .ForMember(t => t.DateCreated, src => src.MapFrom(src => DateTime.UtcNow))
                .ForMember(t => t.Locked, src => src.MapFrom(src => false))
                .ForMember(t => t.Sticky, src => src.MapFrom(src => false));

            CreateMap<ThreadDto, ThreadViewModel>()
                .ReverseMap();
        }
    }
}
