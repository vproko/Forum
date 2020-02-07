using Forum.DomainClasses.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Forum.DataAccess
{
    public class ForumDbContext : IdentityDbContext<User>
    {
        public ForumDbContext(DbContextOptions options) : base(options){}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //USER

            //User's primary key
            builder.Entity<User>()
                .HasKey(u => u.Id);

            //User's Id Identity
            builder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            //User's required properties
            builder.Entity<User>()
                .Property(u => u.FullName)
                .IsRequired();
            
            builder.Entity<User>()
                .Property(u => u.Joined)
                .IsRequired();
            
            builder.Entity<User>()
                .Property(u => u.Online)
                .IsRequired();
            
            builder.Entity<User>()
                .Property(u => u.Suspended)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Administrator)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Avatar)
                .IsRequired();

            //User's relations
            builder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.ReceiverID)
                .OnDelete(DeleteBehavior.Cascade);


            //CATEGORY

            //Category's primary key
            builder.Entity<Category>()
                .HasKey(c => c.CategoryID);

            //Category's Id Identity
            builder.Entity<Category>()
                .Property(c => c.CategoryID)
                .ValueGeneratedOnAdd();

            //Category's required properties
            builder.Entity<Category>()
                .Property(c => c.Title)
                .IsRequired();

            //Category's relation
            builder.Entity<Category>()
                .HasMany(c => c.Threads)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);


            //THREAD

            //Thread's primary key
            builder.Entity<Thread>()
                .HasKey(t => t.ThreadID);

            //Thread's Id Identity
            builder.Entity<Thread>()
                .Property(t => t.ThreadID)
                .ValueGeneratedOnAdd();

            //Thread's required properties
            builder.Entity<Thread>()
                .Property(t => t.Title)
                .IsRequired();

            builder.Entity<Thread>()
                .Property(t => t.CategoryID)
                .IsRequired();

            builder.Entity<Thread>()
                .Property(t => t.DateCreated)
                .IsRequired();

            //Thread's relation
            builder.Entity<Thread>()
                .HasMany(t => t.Posts)
                .WithOne(p => p.Thread)
                .HasForeignKey(p => p.ThreadID)
                .OnDelete(DeleteBehavior.Cascade);


            //POST
            
            //Post's primary key
            builder.Entity<Post>()
                .HasKey(p => p.PostID);

            //Post's Id Identity
            builder.Entity<Post>()
                .Property(p => p.PostID)
                .ValueGeneratedOnAdd();

            //Post's required properties
            builder.Entity<Post>()
                .Property(p => p.Content)
                .IsRequired();

            builder.Entity<Post>()
                .Property(p => p.DateCreated)
                .IsRequired();

            builder.Entity<Post>()
                .Property(p => p.UserID)
                .IsRequired();

            builder.Entity<Post>()
                .Property(p => p.ThreadID)
                .IsRequired();

            builder.Entity<Post>()
                .Property(p => p.Reported)
                .IsRequired();

            //Message

            //Message's primary key
            builder.Entity<Message>()
                .HasKey(m => m.MessageID);

            //Message's Id Identity
            builder.Entity<Message>()
                .Property(m => m.MessageID)
                .ValueGeneratedOnAdd();

            //Message's required properties
            builder.Entity<Message>()
                .Property(m => m.ReceiverID)
                .IsRequired();

            builder.Entity<Message>()
                .Property(m => m.ReceiverUsername)
                .IsRequired();

            builder.Entity<Message>()
                .Property(m => m.SenderID)
                .IsRequired();

            builder.Entity<Message>()
                .Property(m => m.SenderUsername)
                .IsRequired();

            builder.Entity<Message>()
                .Property(m => m.Content)
                .IsRequired();

            builder.Entity<Message>()
                .Property(m => m.Created)
                .IsRequired();

            //Data Seed

            //Id's for roles
            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();

            //Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole{Id = adminRoleId, Name = "admin", NormalizedName = "ADMIN" },
                new IdentityRole{Id = userRoleId, Name = "user", NormalizedName = "USER" }
            );

            //User id's
            string jdUserId = Guid.NewGuid().ToString();
            string bbUserId = Guid.NewGuid().ToString();
            string jpUserId = Guid.NewGuid().ToString();

            //Hasher
            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                    new User
                    {
                        Id = jdUserId,
                        Administrator = false,
                        Avatar = "/avatars/no-image.jpg",
                        FullName = "John Doe",
                        UserName = "jdoe",
                        NormalizedUserName = "JDOE",
                        Email = "jd@forum.com",
                        NormalizedEmail = "JD@FORUM.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "John123#"),
                        SecurityStamp = string.Empty,
                        Joined = DateTime.UtcNow
                    },
                    new User
                    {
                        Id = bbUserId,
                        Administrator = false,
                        Avatar = "/avatars/no-image.jpg",
                        FullName = "Bob Bobsky",
                        UserName = "bbsky",
                        NormalizedUserName = "BBSKY",
                        Email = "bb@forum.com",
                        NormalizedEmail = "BB@FORUM.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Bbsky123#"),
                        SecurityStamp = string.Empty,
                        Joined = DateTime.UtcNow
                    },
                    new User
                    {
                        Id = jpUserId,
                        Administrator = true,
                        Avatar = "/avatars/no-image.jpg",
                        FullName = "James Parker",
                        UserName = "James",
                        NormalizedUserName = "JAMES",
                        Email = "jp@forum.com",
                        NormalizedEmail = "JP@FORUM.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Admin123#"),
                        SecurityStamp = string.Empty,
                        Joined = DateTime.UtcNow
                    }
                );

            //Seeding/Assigning role
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>{ RoleId = adminRoleId, UserId = jpUserId},
                new IdentityUserRole<string>{ RoleId = userRoleId, UserId = jdUserId},
                new IdentityUserRole<string>{ RoleId = userRoleId, UserId = bbUserId}
            );

            //Category id's
            string softwareId = Guid.NewGuid().ToString();
            string gamesId = Guid.NewGuid().ToString();
            string newsId = Guid.NewGuid().ToString();

            builder.Entity<Category>().HasData(
                    new Category
                    {
                        CategoryID = softwareId,
                        Title = "Software"
                    },
                    new Category
                    {
                        CategoryID = gamesId,
                        Title = "Games"
                    },
                    new Category
                    {
                        CategoryID = newsId,
                        Title = "News"
                    }
                );

            string threadOneId = Guid.NewGuid().ToString();
            string threadTwoId = Guid.NewGuid().ToString();
            string threadThreeId = Guid.NewGuid().ToString();

            builder.Entity<Thread>().HasData(
                    new Thread
                    {
                        ThreadID = threadOneId,
                        Title = "Best Free AV",
                        CategoryID = softwareId,
                        DateCreated = DateTime.UtcNow
                    },
                    new Thread
                    {
                        ThreadID = threadTwoId,
                        Title = "New version of Firefox is released",
                        CategoryID = newsId,
                        DateCreated = DateTime.UtcNow
                    },
                    new Thread
                    {
                        ThreadID = threadThreeId,
                        Title = "The best FPS game in 2019",
                        CategoryID = gamesId,
                        DateCreated = DateTime.UtcNow
                    }
                );

            //Posts Id's

            string postOne = Guid.NewGuid().ToString();
            string postTwo = Guid.NewGuid().ToString();
            string postThree = Guid.NewGuid().ToString();
            string postFour = Guid.NewGuid().ToString();

            builder.Entity<Post>().HasData(
                    new Post
                    {
                        PostID = postOne,
                        ThreadID = threadOneId,
                        Content = "The best free antivirus is Kaspersky Cloud Free",
                        DateCreated = DateTime.UtcNow,
                        UserID = jpUserId
                    },
                    new Post
                    {
                        PostID = postTwo,
                        ThreadID = threadOneId,
                        Content = "Avast is another good free antivirus",
                        DateCreated = DateTime.UtcNow,
                        UserID = jdUserId
                    },
                    new Post
                    {
                        PostID = postThree,
                        ThreadID = threadTwoId,
                        Content = "I hope they've patched some of the security holes",
                        DateCreated = DateTime.UtcNow,
                        UserID = jdUserId
                    },
                    new Post
                    {
                        PostID = postFour,
                        ThreadID = threadThreeId,
                        Content = "Call of Duty: Modern Warfare is the best one so far.",
                        DateCreated = DateTime.UtcNow,
                        UserID = bbUserId
                    }
                );
        }
    }
}
