using AutoMapper;
using Forum.DomainClasses.Models;
using Forum.ViewModels.ViewModels;
using System;
using System.Linq;

namespace Forum.Services.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(u => u.FullName, src => src.ResolveUsing(rm => $"{rm.FirstName} {rm.LastName}"))
                .ForMember(u => u.EmailConfirmed, src => src.UseValue(true))
                .ForMember(u => u.Joined, src => src.ResolveUsing(rm => DateTime.UtcNow))
                .ForMember(u => u.Administrator, src => src.UseValue(false))
                .ForMember(u => u.Online, src => src.UseValue(false))
                .ForMember(u => u.Suspended, src => src.UseValue(false))
                .ReverseMap();

            CreateMap<User, UserViewModel>()
                .ForMember(um => um.Messages, src => src.MapFrom(u => u.Messages.OrderByDescending(m => m.Created.Date).ThenByDescending(m => m.Created.TimeOfDay)))
                .ForMember(um => um.PasswordHash, src => src.Ignore())
                .ReverseMap();

            CreateMap<Thread, ThreadViewModel>()
                .ForMember(tm => tm.Posts, src => src.MapFrom(t => t.Posts.OrderBy(p => p.DateCreated.Date).ThenBy(p => p.DateCreated.TimeOfDay)))
                .ReverseMap()
                .ForMember(t => t.ThreadID, src => src.ResolveUsing(tm => Guid.NewGuid().ToString()))
                .ForMember(t => t.DateCreated, src => src.ResolveUsing(tm => DateTime.UtcNow));

            CreateMap<Post, PostViewModel>()
                .ForMember(pm => pm.PostID, src => src.MapFrom(p => p.PostID))
                .ReverseMap()
                .ForMember(p => p.PostID, src => src.ResolveUsing(pm => Guid.NewGuid().ToString()))
                .ForMember(p => p.DateCreated, src => src.ResolveUsing(pm => DateTime.UtcNow))
                .ForMember(p => p.Reported, src => src.UseValue(false));

            CreateMap<Category, CategoryViewModel>()
                .ForMember(cv => cv.Threads, src => src.MapFrom(c => c.Threads.OrderByDescending(t => t.DateCreated.Date).ThenByDescending(t => t.DateCreated.TimeOfDay)))
                .ReverseMap()
                .ForMember(c => c.CategoryID, src => src.ResolveUsing(cm => Guid.NewGuid().ToString()));

            CreateMap<Message, MessageViewModel>()
                .ReverseMap()
                .ForMember(m => m.MessageID, src => src.ResolveUsing(mm => Guid.NewGuid().ToString()))
                .ForMember(m => m.Created, src => src.ResolveUsing(mm => DateTime.UtcNow));

        }
    }
}
