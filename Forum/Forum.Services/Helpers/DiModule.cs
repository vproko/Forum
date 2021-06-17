using AutoMapper;
using Forum.DataAccess;
using Forum.DataAccess.Interfaces;
using Forum.DataAccess.Repositories;
using Forum.DomainClasses.Models;
using Forum.Services.Helpers.MapperProfiles;
using Forum.Services.Interfaces;
using Forum.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Forum.Services.Helpers
{
    public class DiModule
    {
        public static IServiceCollection RegisterModules(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ForumDbContext>(ob => ob.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole<Guid>>(options => 
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 7;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            }).AddRoleManager<RoleManager<IdentityRole<Guid>>>()
              .AddEntityFrameworkStores<ForumDbContext>()
              .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => 
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
                options.Lockout.MaxFailedAccessAttempts = 3;
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IThreadRepository, ThreadRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IReplyRepository, ReplyRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.ConfigureApplicationCookie(options => 
            {
                options.Cookie.Name = "ForumCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Users/LogIn";
                options.AccessDeniedPath = "/Users/LogIn";
                options.SlidingExpiration = true;
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IThreadService, ThreadService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IReplyService, ReplyService>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new CategoryProfile());
                cfg.AddProfile(new ThreadProfile());
                cfg.AddProfile(new PostProfile());
                cfg.AddProfile(new MessageProfile());
                cfg.AddProfile(new ReplyProfile());
            });

            return services;
        }
    }
}