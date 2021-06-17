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
    [Migration("20210426133734_EditedAndEditedByAddedToReply")]
    partial class EditedAndEditedByAddedToReply
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
                            CategoryId = new Guid("fee89ac0-5cb9-4df7-a658-079384f83511"),
                            Name = "Software"
                        },
                        new
                        {
                            CategoryId = new Guid("4a2895b5-f4c9-4d71-bf2a-96c6c54da07d"),
                            Name = "Games"
                        },
                        new
                        {
                            CategoryId = new Guid("8f50d186-f6ed-463a-bac4-bbada253ed66"),
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
                            PostId = new Guid("b098e09a-b36d-464c-8794-83ab03f707a0"),
                            Content = "Kaspersky Cloud Free is the best free option.",
                            DatePosted = new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(3855),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("2fda77c9-4b49-48f4-93e3-9fe1dae81b54"),
                            UserId = new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"),
                            Username = "bbsky"
                        },
                        new
                        {
                            PostId = new Guid("a534fdb9-2309-49b3-8b61-7d24acf6d797"),
                            Content = "Call of Duty: Modern Warfare is the best one so far.",
                            DatePosted = new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(4676),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("8947e958-ad5a-45a9-9bf7-2076b89a6fa2"),
                            UserId = new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"),
                            Username = "bbsky"
                        },
                        new
                        {
                            PostId = new Guid("fb432ca6-3eb7-4619-8a8e-b9c8c3313420"),
                            Content = "Firefox 81.0 has been released.",
                            DatePosted = new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(4694),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("c173b6b1-a9b6-4679-ab0a-955e40ff1f8c"),
                            UserId = new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"),
                            Username = "jdoe"
                        },
                        new
                        {
                            PostId = new Guid("6094849b-94fa-4b35-90ec-f016bb2c11c1"),
                            Content = "I hope they've patched some of the security holes.",
                            DatePosted = new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(4697),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("c173b6b1-a9b6-4679-ab0a-955e40ff1f8c"),
                            UserId = new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"),
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

                    b.Property<bool>("Edited")
                        .HasColumnType("bit");

                    b.Property<string>("EditedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

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
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ReplyId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Replies");

                    b.HasData(
                        new
                        {
                            ReplyId = new Guid("c7859686-7469-4f39-ad65-0d088409a60a"),
                            Content = "I don't agree entirely, Kaspersky it's little bit heavy on resources.",
                            DateReplied = new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(9232),
                            Edited = false,
                            PostId = new Guid("b098e09a-b36d-464c-8794-83ab03f707a0"),
                            Reported = false,
                            UserId = new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"),
                            Username = "jdoe"
                        },
                        new
                        {
                            ReplyId = new Guid("8553372c-ecdb-45d8-ac8b-b097f219f466"),
                            Content = "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.",
                            DateReplied = new DateTime(2021, 4, 26, 13, 37, 33, 963, DateTimeKind.Utc).AddTicks(717),
                            Edited = false,
                            PostId = new Guid("a534fdb9-2309-49b3-8b61-7d24acf6d797"),
                            Reported = false,
                            UserId = new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"),
                            Username = "jdoe"
                        },
                        new
                        {
                            ReplyId = new Guid("976a2ad7-fe01-41e8-bc90-885093168fe5"),
                            Content = "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.",
                            DateReplied = new DateTime(2021, 4, 26, 13, 37, 33, 963, DateTimeKind.Utc).AddTicks(741),
                            Edited = false,
                            PostId = new Guid("fb432ca6-3eb7-4619-8a8e-b9c8c3313420"),
                            Reported = false,
                            UserId = new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"),
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
                            ThreadId = new Guid("2fda77c9-4b49-48f4-93e3-9fe1dae81b54"),
                            CategoryId = new Guid("fee89ac0-5cb9-4df7-a658-079384f83511"),
                            DateCreated = new DateTime(2021, 4, 26, 13, 37, 33, 961, DateTimeKind.Utc).AddTicks(6004),
                            Title = "Best free antivirus"
                        },
                        new
                        {
                            ThreadId = new Guid("8947e958-ad5a-45a9-9bf7-2076b89a6fa2"),
                            CategoryId = new Guid("4a2895b5-f4c9-4d71-bf2a-96c6c54da07d"),
                            DateCreated = new DateTime(2021, 4, 26, 13, 37, 33, 961, DateTimeKind.Utc).AddTicks(6840),
                            Title = "The Best FPS for 2020"
                        },
                        new
                        {
                            ThreadId = new Guid("c173b6b1-a9b6-4679-ab0a-955e40ff1f8c"),
                            CategoryId = new Guid("8f50d186-f6ed-463a-bac4-bbada253ed66"),
                            DateCreated = new DateTime(2021, 4, 26, 13, 37, 33, 961, DateTimeKind.Utc).AddTicks(6857),
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
                            Id = new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"),
                            AccessFailedCount = 0,
                            Avatar = "not set",
                            ConcurrencyStamp = "67cc1136-c6fc-44d3-a259-c942a270ed9b",
                            Email = "jdoe@email.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            IsItAdministrator = true,
                            Joined = new DateTime(2021, 4, 26, 13, 37, 33, 951, DateTimeKind.Utc).AddTicks(5332),
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "JDOE@EMAIL.COM",
                            NormalizedUserName = "JDOE",
                            Online = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEE6yCVNVa8s627v0CpttLeQuPEs1RO6lEPWZSAs5tN+SB6M9/tG3Lzm+iftk4Kf0Gg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            Suspended = false,
                            TwoFactorEnabled = false,
                            UserName = "jdoe"
                        },
                        new
                        {
                            Id = new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"),
                            AccessFailedCount = 0,
                            Avatar = "not set",
                            ConcurrencyStamp = "1929deba-7268-48e7-ae04-31f84bba3f32",
                            Email = "bbsky@email.com",
                            EmailConfirmed = true,
                            FirstName = "Bob",
                            IsItAdministrator = false,
                            Joined = new DateTime(2021, 4, 26, 13, 37, 33, 960, DateTimeKind.Utc).AddTicks(3233),
                            LastName = "Bobsky",
                            LockoutEnabled = false,
                            NormalizedEmail = "BBSKY@EMAIL.COM",
                            NormalizedUserName = "BBSKY",
                            Online = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEDPgq+bXGxT00Ci4fsonUHgTxTqYZCtPkRpH5H0zDTZ4KLPAtR7oFBj0Kl2TgNSpKg==",
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
                            Id = new Guid("98ade400-f9ae-488d-b519-9b1f428f2b09"),
                            ConcurrencyStamp = "852f323e-9701-49c0-acbe-623180f2e0ec",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("7e37de0d-0651-4997-b4fc-919a0e27481e"),
                            ConcurrencyStamp = "af49aa12-886d-4b15-a8c9-0cfe934b00c1",
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
                            UserId = new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"),
                            RoleId = new Guid("98ade400-f9ae-488d-b519-9b1f428f2b09")
                        },
                        new
                        {
                            UserId = new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"),
                            RoleId = new Guid("7e37de0d-0651-4997-b4fc-919a0e27481e")
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