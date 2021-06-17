using AutoMapper;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;
using System;
using System.Linq;

namespace Forum.Services.Helpers.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationViewModel, User>()
                .ForMember(u => u.EmailConfirmed, src => src.MapFrom(src => true))
                .ForMember(u => u.Joined, src => src.MapFrom(src => DateTime.UtcNow))
                .ForMember(u => u.IsItAdministrator, src => src.Condition(src => src.Role == "admin"))
                .ForMember(u => u.Online, src => src.MapFrom(src => false))
                .ForMember(u => u.Suspended, src => src.MapFrom(src => false));

            CreateMap<User, UserDto>()
                .ForMember(udto => udto.UserId, src => src.MapFrom(src => src.Id))
                .ForMember(udto => udto.Posts, src => src.MapFrom(src => src.Posts.OrderByDescending(p => p.DatePosted.Date).ThenByDescending(p => p.DatePosted.TimeOfDay)))
                .ForMember(udto => udto.Replies, src => src.MapFrom(src => src.Replies.OrderByDescending(r => r.DateReplied.Date).ThenByDescending(p => p.DateReplied.TimeOfDay)))
                .ForMember(udto => udto.Messages, src => src.MapFrom(src => src.Messages.OrderByDescending(m => m.DateSent.Date).ThenByDescending(m => m.DateSent.TimeOfDay)))
                .ForSourceMember(u => u.PasswordHash, opt => opt.DoNotValidate());

            CreateMap<UserDto, UserViewModel>()
                .ReverseMap();
        }
    }
}
