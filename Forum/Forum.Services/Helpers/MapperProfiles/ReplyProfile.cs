using AutoMapper;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;
using System;

namespace Forum.Services.Helpers.MapperProfiles
{
    public class ReplyProfile : Profile
    {
        public ReplyProfile()
        {
            CreateMap<Reply, ReplyDto>()
                .ReverseMap()
                .ForMember(r => r.ReplyId, src => src.MapFrom(src => Guid.NewGuid()))
                .ForMember(r => r.DateReplied, src => src.MapFrom(src => DateTime.UtcNow))
                .ForMember(r => r.Edited, src => src.MapFrom(src => false));

            CreateMap<ReplyDto, ReplyViewModel>()
                .ReverseMap();
        }
    }
}