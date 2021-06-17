using Forum.DomainClasses.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Forum.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            //USERS
            //User Roles Id's
            Guid adminRoleId = Guid.NewGuid();
            Guid userRoleId = Guid.NewGuid();

            //Roles
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> { Id = adminRoleId, Name = "admin", NormalizedName = "ADMIN" },
                new IdentityRole<Guid> { Id = userRoleId, Name = "user", NormalizedName = "USER" }
            );

            //User Id's
            Guid jdId = Guid.NewGuid();
            Guid bbId = Guid.NewGuid();

            //Hasher
            PasswordHasher<User> hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = jdId,
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "jdoe",
                    NormalizedUserName = "JDOE",
                    Email = "jdoe@email.com",
                    NormalizedEmail = "JDOE@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Jdoe123#"),
                    SecurityStamp = string.Empty,
                    IsItAdministrator = true,
                    Online = false,
                    Suspended = false,
                    Avatar = "not set",
                    Joined = DateTime.UtcNow
                },
                new User
                {
                    Id = bbId,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    UserName = "bbsky",
                    NormalizedUserName = "BBSKY",
                    Email = "bbsky@email.com",
                    NormalizedEmail = "BBSKY@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Bbsky123#"),
                    SecurityStamp = string.Empty,
                    IsItAdministrator = false,
                    Online = false,
                    Suspended = false,
                    Avatar = "not set",
                    Joined = DateTime.UtcNow
                }
            );

            //Seeding/Assinging Roles
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { RoleId = adminRoleId, UserId = jdId },
                new IdentityUserRole<Guid> { RoleId = userRoleId, UserId = bbId }
            );

            //CATEGORIES
            //Category Id's
            Guid softwareId = Guid.NewGuid();
            Guid gamesId = Guid.NewGuid();
            Guid newsId = Guid.NewGuid();

            builder.Entity<Category>().HasData(
                new Category { CategoryId = softwareId, Name = "Software" },
                new Category { CategoryId = gamesId, Name = "Games" },
                new Category { CategoryId = newsId, Name = "News" }
            );

            //THREADS
            //Threads Id's
            Guid threadOne = Guid.NewGuid();
            Guid threadTwo = Guid.NewGuid();
            Guid threadThree = Guid.NewGuid();

            builder.Entity<Thread>().HasData(
                new Thread
                {
                    ThreadId = threadOne,
                    CategoryId = softwareId,
                    Title = "Best free antivirus",
                    DateCreated = DateTime.UtcNow,
                    Locked = false,
                    Sticky = false
                },
                new Thread
                {
                    ThreadId = threadTwo,
                    CategoryId = gamesId,
                    Title = "The Best FPS for 2020",
                    DateCreated = DateTime.UtcNow,
                    Locked = false,
                    Sticky = false
                },
                new Thread
                {
                    ThreadId = threadThree,
                    CategoryId = newsId,
                    Title = "New Version of Firefox has been released",
                    DateCreated = DateTime.UtcNow,
                    Locked = false,
                    Sticky = false
                }
            );

            //POSTS
            //Post Id's
            Guid postOne = Guid.NewGuid();
            Guid postTwo = Guid.NewGuid();
            Guid postThree = Guid.NewGuid();
            Guid postFour = Guid.NewGuid();

            builder.Entity<Post>().HasData(
                new Post
                {
                    PostId = postOne,
                    ThreadId = threadOne,
                    UserId = bbId,
                    Username = "bbsky",
                    Content = "Kaspersky Cloud Free is the best free option.",
                    Reported = false,
                    Edited = false,
                    DatePosted = DateTime.UtcNow
                },
                new Post
                {
                    PostId = postTwo,
                    ThreadId = threadTwo,
                    UserId = bbId,
                    Username = "bbsky",
                    Content = "Call of Duty: Modern Warfare is the best one so far.",
                    Reported = false,
                    Edited = false,
                    DatePosted = DateTime.UtcNow
                },
                new Post
                {
                    PostId = postThree,
                    ThreadId = threadThree,
                    UserId = jdId,
                    Username = "jdoe",
                    Content = "Firefox 81.0 has been released.",
                    Reported = false,
                    Edited = false,
                    DatePosted = DateTime.UtcNow
                },
                new Post
                {
                    PostId = postFour,
                    ThreadId = threadThree,
                    UserId = bbId,
                    Username = "bbsky",
                    Content = "I hope they've patched some of the security holes.",
                    Reported = false,
                    Edited = false,
                    DatePosted = DateTime.UtcNow
                }
            );

            // REPLIES
            // Reply id's
            Guid replyOne = Guid.NewGuid();
            Guid replyTwo = Guid.NewGuid();
            Guid replyThree = Guid.NewGuid();

            builder.Entity<Reply>().HasData(
                new Reply
                {
                    ReplyId = replyOne,
                    PostId = postOne,
                    UserId = jdId,
                    Username = "jdoe",
                    Content = "I don't agree entirely, Kaspersky it's little bit heavy on resources.",
                    DateReplied = DateTime.UtcNow,
                    Edited = false
                },
                new Reply
                {
                    ReplyId = replyTwo,
                    PostId = postTwo,
                    UserId = jdId,
                    Username = "jdoe",
                    Content = "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.",
                    DateReplied = DateTime.UtcNow,
                    Edited = false
                },
                new Reply
                {
                    ReplyId = replyThree,
                    PostId = postThree,
                    UserId = bbId,
                    Username = "bbsky",
                    Content = "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.",
                    DateReplied = DateTime.UtcNow,
                    Edited = false
                }
            );
        }
    }
}