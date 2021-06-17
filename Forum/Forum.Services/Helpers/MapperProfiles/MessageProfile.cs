using AutoMapper;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;
using System;

namespace Forum.Services.Helpers.MapperProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>()
                .ReverseMap()
                .ForMember(m => m.MessageId, src => src.MapFrom(src => Guid.NewGuid()))
                .ForMember(m => m.DateSent, src => src.MapFrom(src => DateTime.UtcNow));

            CreateMap<MessageDto, MessageViewModel>()
                .ReverseMap();
        }
    }
}
