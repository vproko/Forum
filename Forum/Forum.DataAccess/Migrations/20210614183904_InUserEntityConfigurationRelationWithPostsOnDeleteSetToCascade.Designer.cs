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
    [Migration("20210614183904_InUserEntityConfigurationRelationWithPostsOnDeleteSetToCascade")]
    partial class InUserEntityConfigurationRelationWithPostsOnDeleteSetToCascade
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
                            CategoryId = new Guid("8c7c1d3f-3328-406b-89e1-63d89dc0a35e"),
                            Name = "Software"
                        },
                        new
                        {
                            CategoryId = new Guid("dbd1a7aa-05fa-454c-b970-fc16c78f39da"),
                            Name = "Games"
                        },
                        new
                        {
                            CategoryId = new Guid("220fb38d-2dad-4df7-bea0-c4c571b2969c"),
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
                            PostId = new Guid("07c57aef-3ce0-406c-b59d-a02bb5f39a9c"),
                            Content = "Kaspersky Cloud Free is the best free option.",
                            DatePosted = new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(8897),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("b5b3bf64-6b08-45bd-828d-e8e3d16b280d"),
                            UserId = new Guid("64b8a5ff-a606-4722-960c-81056d081226"),
                            Username = "bbsky"
                        },
                        new
                        {
                            PostId = new Guid("16733bff-02e1-48ad-919f-c676d52d8ba9"),
                            Content = "Call of Duty: Modern Warfare is the best one so far.",
                            DatePosted = new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(9481),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("c142d3d5-604c-420e-9576-cdb10ad95d45"),
                            UserId = new Guid("64b8a5ff-a606-4722-960c-81056d081226"),
                            Username = "bbsky"
                        },
                        new
                        {
                            PostId = new Guid("29380704-484a-41c7-9b49-5df6bbb0522d"),
                            Content = "Firefox 81.0 has been released.",
                            DatePosted = new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(9498),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("c16e41bf-de73-4b81-86a3-c76b77b3d2cd"),
                            UserId = new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"),
                            Username = "jdoe"
                        },
                        new
                        {
                            PostId = new Guid("aa0b7fbf-e496-40ee-8470-3f63907e7065"),
                            Content = "I hope they've patched some of the security holes.",
                            DatePosted = new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(9502),
                            Edited = false,
                            Reported = false,
                            ThreadId = new Guid("c16e41bf-de73-4b81-86a3-c76b77b3d2cd"),
                            UserId = new Guid("64b8a5ff-a606-4722-960c-81056d081226"),
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
                            ReplyId = new Guid("19615e1f-69ee-4980-82df-dea41b28e7a0"),
                            Content = "I don't agree entirely, Kaspersky it's little bit heavy on resources.",
                            DateReplied = new DateTime(2021, 6, 14, 18, 39, 3, 457, DateTimeKind.Utc).AddTicks(3558),
                            Edited = false,
                            PostId = new Guid("07c57aef-3ce0-406c-b59d-a02bb5f39a9c"),
                            Reported = false,
                            UserId = new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"),
                            Username = "jdoe"
                        },
                        new
                        {
                            ReplyId = new Guid("74c37c65-b1f9-470b-bbdc-c5011fbcd2dc"),
                            Content = "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.",
                            DateReplied = new DateTime(2021, 6, 14, 18, 39, 3, 457, DateTimeKind.Utc).AddTicks(4556),
                            Edited = false,
                            PostId = new Guid("16733bff-02e1-48ad-919f-c676d52d8ba9"),
                            Reported = false,
                            UserId = new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"),
                            Username = "jdoe"
                        },
                        new
                        {
                            ReplyId = new Guid("4b5baedb-5c1c-44d3-8056-23bc3cd5da48"),
                            Content = "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.",
                            DateReplied = new DateTime(2021, 6, 14, 18, 39, 3, 457, DateTimeKind.Utc).AddTicks(4581),
                            Edited = false,
                            PostId = new Guid("29380704-484a-41c7-9b49-5df6bbb0522d"),
                            Reported = false,
                            UserId = new Guid("64b8a5ff-a606-4722-960c-81056d081226"),
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

                    b.Property<bool>("Locked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("Sticky")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

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
                            ThreadId = new Guid("b5b3bf64-6b08-45bd-828d-e8e3d16b280d"),
                            CategoryId = new Guid("8c7c1d3f-3328-406b-89e1-63d89dc0a35e"),
                            DateCreated = new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(2692),
                            Locked = false,
                            Sticky = false,
                            Title = "Best free antivirus"
                        },
                        new
                        {
                            ThreadId = new Guid("c142d3d5-604c-420e-9576-cdb10ad95d45"),
                            CategoryId = new Guid("dbd1a7aa-05fa-454c-b970-fc16c78f39da"),
                            DateCreated = new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(4108),
                            Locked = false,
                            Sticky = false,
                            Title = "The Best FPS for 2020"
                        },
                        new
                        {
                            ThreadId = new Guid("c16e41bf-de73-4b81-86a3-c76b77b3d2cd"),
                            CategoryId = new Guid("220fb38d-2dad-4df7-bea0-c4c571b2969c"),
                            DateCreated = new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(4140),
                            Locked = false,
                            Sticky = false,
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
                            Id = new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"),
                            AccessFailedCount = 0,
                            Avatar = "not set",
                            ConcurrencyStamp = "4b5cc72e-8d20-40b3-8234-52bbed988b71",
                            Email = "jdoe@email.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            IsItAdministrator = true,
                            Joined = new DateTime(2021, 6, 14, 18, 39, 3, 444, DateTimeKind.Utc).AddTicks(3427),
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "JDOE@EMAIL.COM",
                            NormalizedUserName = "JDOE",
                            Online = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEI1bELNxFHTR9PYUjsruo/UbUC+/e9dPtCc2U1YtrGdrLOA0YGf9UX7TDOUfyG/Jqg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            Suspended = false,
                            TwoFactorEnabled = false,
                            UserName = "jdoe"
                        },
                        new
                        {
                            Id = new Guid("64b8a5ff-a606-4722-960c-81056d081226"),
                            AccessFailedCount = 0,
                            Avatar = "not set",
                            ConcurrencyStamp = "ec5ded53-b17a-4340-9223-6daff3f179e2",
                            Email = "bbsky@email.com",
                            EmailConfirmed = true,
                            FirstName = "Bob",
                            IsItAdministrator = false,
                            Joined = new DateTime(2021, 6, 14, 18, 39, 3, 455, DateTimeKind.Utc).AddTicks(1146),
                            LastName = "Bobsky",
                            LockoutEnabled = false,
                            NormalizedEmail = "BBSKY@EMAIL.COM",
                            NormalizedUserName = "BBSKY",
                            Online = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEK15OpBKNRY2/VX+s+o0JG92MVa9ajsQUNGqwE9mFoJ70bG4eOmMJIUrfmOQmM6gGg==",
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
                            Id = new Guid("395284c7-b632-475a-b09d-aa82cc3fee37"),
                            ConcurrencyStamp = "96eae66b-0fc1-40f9-ad56-fbdac910b441",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("f0bcb522-53cc-43ce-acfd-730e1e66d4a3"),
                            ConcurrencyStamp = "fae127e1-7401-4dd5-866b-4691ba00484f",
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
                            UserId = new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"),
                            RoleId = new Guid("395284c7-b632-475a-b09d-aa82cc3fee37")
                        },
                        new
                        {
                            UserId = new Guid("64b8a5ff-a606-4722-960c-81056d081226"),
                            RoleId = new Guid("f0bcb522-53cc-43ce-acfd-730e1e66d4a3")
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
                        .OnDelete(DeleteBehavior.Cascade)
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
