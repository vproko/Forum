﻿// <auto-generated />
using System;
using Forum.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forum.DataAccess.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20210422213345_AddedEditedByPropertyToPost")]
    partial class AddedEditedByPropertyToPost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forum.DomainClasses.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("17f067af-2898-429e-aa35-e2fee1a35957"),
                            Name = "Software"
                        },
                        new
                        {
                            CategoryId = new Guid("c6dfb416-37ea-4213-bf98-46e5ef95b81c"),
                            Name = "Games"
                        },
                        new
                        {
                            CategoryId = new Guid("33ac5e29-9ada-48f3-b6f3-1f5b9d78780c"),
                            Name = "News"
                        });
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2(7)");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SenderUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2(7)");

                    b.Property<bool>("Edited")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("EditedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Reported")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("ThreadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("PostId");

                    b.HasIndex("ThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = new Guid("e1573c82-8282-406d-bac6-093131b014b3"),
                            Content = "Kaspersky Cloud Free is the best free option.",
                            DatePosted = new DateTime(2021, 4, 22, 21, 33, 44, 446, DateTimeKind.Utc).AddTicks(5523),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("ad2ce429-00d9-4164-9b8c-a3b52a9c37c7"),
                            UserId = new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"),
                            Username = "bbsky"
                        },
                        new
                        {
                            PostId = new Guid("b89da3bc-65e1-40bc-a82e-10b647bd8aaa"),
                            Content = "Call of Duty: Modern Warfare is the best one so far.",
                            DatePosted = new DateTime(2021, 4, 22, 21, 33, 44, 446, DateTimeKind.Utc).AddTicks(6316),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("b5644bfd-c5c5-4b0b-b644-dfac147205db"),
                            UserId = new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"),
                            Username = "bbsky"
                        },
                        new
                        {
                            PostId = new Guid("ff86d947-2428-434a-a2d1-06a531970238"),
                            Content = "Firefox 81.0 has been released.",
                            DatePosted = new DateTime(2021, 4, 22, 21, 33, 44, 446, DateTimeKind.Utc).AddTicks(6333),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("2051b91a-3108-4cb1-92fb-f35d54119032"),
                            UserId = new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"),
                            Username = "jdoe"
                        },
                        new
                        {
                            PostId = new Guid("7176be8d-f9d5-4ca3-a16c-f221fd090748"),
                            Content = "I hope they've patched some of the security holes.",
                            DatePosted = new DateTime(2021, 4, 22, 21, 33, 44, 446, DateTimeKind.Utc).AddTicks(6337),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("2051b91a-3108-4cb1-92fb-f35d54119032"),
                            UserId = new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"),
                            Username = "bbsky"
                        });
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.Reply", b =>
                {
                    b.Property<Guid>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateReplied")
                        .HasColumnType("datetime2(7)");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Reported")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ReplyId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Replies");

                    b.HasData(
                        new
                        {
                            ReplyId = new Guid("2234fa56-3182-4941-ba58-e68e53354de3"),
                            Content = "I don't agree entirely, Kaspersky it's little bit heavy on resources.",
                            DateReplied = new DateTime(2021, 4, 22, 21, 33, 44, 447, DateTimeKind.Utc).AddTicks(797),
                            PostId = new Guid("e1573c82-8282-406d-bac6-093131b014b3"),
                            Reported = false,
                            UserId = new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"),
                            Username = "jdoe"
                        },
                        new
                        {
                            ReplyId = new Guid("9c6ba06b-030d-4181-9b97-8341c978d299"),
                            Content = "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.",
                            DateReplied = new DateTime(2021, 4, 22, 21, 33, 44, 447, DateTimeKind.Utc).AddTicks(1561),
                            PostId = new Guid("b89da3bc-65e1-40bc-a82e-10b647bd8aaa"),
                            Reported = false,
                            UserId = new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"),
                            Username = "jdoe"
                        },
                        new
                        {
                            ReplyId = new Guid("13dfb00e-69b3-4c9c-b277-cc4198a7badc"),
                            Content = "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.",
                            DateReplied = new DateTime(2021, 4, 22, 21, 33, 44, 447, DateTimeKind.Utc).AddTicks(1581),
                            PostId = new Guid("ff86d947-2428-434a-a2d1-06a531970238"),
                            Reported = false,
                            UserId = new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"),
                            Username = "bbsky"
                        });
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.Thread", b =>
                {
                    b.Property<Guid>("ThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("ThreadId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Threads");

                    b.HasData(
                        new
                        {
                            ThreadId = new Guid("ad2ce429-00d9-4164-9b8c-a3b52a9c37c7"),
                            CategoryId = new Guid("17f067af-2898-429e-aa35-e2fee1a35957"),
                            DateCreated = new DateTime(2021, 4, 22, 21, 33, 44, 445, DateTimeKind.Utc).AddTicks(7873),
                            Title = "Best free antivirus"
                        },
                        new
                        {
                            ThreadId = new Guid("b5644bfd-c5c5-4b0b-b644-dfac147205db"),
                            CategoryId = new Guid("c6dfb416-37ea-4213-bf98-46e5ef95b81c"),
                            DateCreated = new DateTime(2021, 4, 22, 21, 33, 44, 445, DateTimeKind.Utc).AddTicks(8692),
                            Title = "The Best FPS for 2020"
                        },
                        new
                        {
                            ThreadId = new Guid("2051b91a-3108-4cb1-92fb-f35d54119032"),
                            CategoryId = new Guid("33ac5e29-9ada-48f3-b6f3-1f5b9d78780c"),
                            DateCreated = new DateTime(2021, 4, 22, 21, 33, 44, 445, DateTimeKind.Utc).AddTicks(8709),
                            Title = "New Version of Firefox has been released"
                        });
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsItAdministrator")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("Joined")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("Online")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Suspended")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"),
                            AccessFailedCount = 0,
                            Avatar = "not set",
                            ConcurrencyStamp = "f9c4f053-9022-447b-94e2-ce41dc3c9629",
                            Email = "jdoe@email.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            IsItAdministrator = true,
                            Joined = new DateTime(2021, 4, 22, 21, 33, 44, 436, DateTimeKind.Utc).AddTicks(2015),
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "JDOE@EMAIL.COM",
                            NormalizedUserName = "JDOE",
                            Online = false,
                            PasswordHash = "AQAAAAEAACcQAAAAED5V4i7Pl0Now/eD/fQ8q1hkg9OEa3j9NGrO7Z+PzBixdlfZIyPtmfON3t3dcuO0cg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            Suspended = false,
                            TwoFactorEnabled = false,
                            UserName = "jdoe"
                        },
                        new
                        {
                            Id = new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"),
                            AccessFailedCount = 0,
                            Avatar = "not set",
                            ConcurrencyStamp = "c215c7e8-846f-4c8c-9332-ae3c7a803a41",
                            Email = "bbsky@email.com",
                            EmailConfirmed = true,
                            FirstName = "Bob",
                            IsItAdministrator = false,
                            Joined = new DateTime(2021, 4, 22, 21, 33, 44, 444, DateTimeKind.Utc).AddTicks(5892),
                            LastName = "Bobsky",
                            LockoutEnabled = false,
                            NormalizedEmail = "BBSKY@EMAIL.COM",
                            NormalizedUserName = "BBSKY",
                            Online = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEFdDud5EpLlubXqJ4Z7PfzcsbBPvEWUxqPDHiewNaEfOxrXjTwgjb7AbrBH6/YbIWA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            Suspended = false,
                            TwoFactorEnabled = false,
                            UserName = "bbsky"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("89f33c28-362f-40f9-9079-c47ee5d4d8b1"),
                            ConcurrencyStamp = "ee2c92a5-38ee-40b2-96de-a1c351837eaf",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("e97c2742-7f10-478e-a30c-b2f8f25d1907"),
                            ConcurrencyStamp = "40df99ee-5cc8-463d-af7e-601bff2e67a0",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"),
                            RoleId = new Guid("89f33c28-362f-40f9-9079-c47ee5d4d8b1")
                        },
                        new
                        {
                            UserId = new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"),
                            RoleId = new Guid("e97c2742-7f10-478e-a30c-b2f8f25d1907")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.Message", b =>
                {
                    b.HasOne("Forum.DomainClasses.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.Post", b =>
                {
                    b.HasOne("Forum.DomainClasses.Models.Thread", "Thread")
                        .WithMany("Posts")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forum.DomainClasses.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.Reply", b =>
                {
                    b.HasOne("Forum.DomainClasses.Models.Post", "Post")
                        .WithMany("Replies")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forum.DomainClasses.Models.User", "User")
                        .WithMany("Replies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Forum.DomainClasses.Models.Thread", b =>
                {
                    b.HasOne("Forum.DomainClasses.Models.Category", "Category")
                        .WithMany("Threads")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Forum.DomainClasses.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Forum.DomainClasses.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forum.DomainClasses.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Forum.DomainClasses.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}