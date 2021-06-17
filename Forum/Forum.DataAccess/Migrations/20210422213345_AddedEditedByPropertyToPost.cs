using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DataAccess.Migrations
{
    public partial class AddedEditedByPropertyToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("7380e9b8-3712-4b0f-a834-5ca1f91e2795"), new Guid("11bc3a4d-ef79-4049-b8bf-54f1522ec013") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("f48718b4-4a0b-4f5a-92e1-869b4c255079"), new Guid("13e32762-b7d5-4aec-a2c8-30b844f45342") });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("65e751ae-9788-442b-8795-f1c5ff16179b"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("115ba9d8-cbef-4a26-a479-889a27c10b45"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("cfc800dc-b5df-4b1f-b5b5-378607ce3046"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("f0809604-b642-4a95-a3e4-d9c0c0c4e58e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11bc3a4d-ef79-4049-b8bf-54f1522ec013"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("13e32762-b7d5-4aec-a2c8-30b844f45342"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("4b11047b-0380-4804-acdf-e4f8ceb60203"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("897e1a19-e6c0-48a1-8850-7fe7159067f6"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("d48a5d1e-49fa-4672-bd96-57f7bfda520a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7380e9b8-3712-4b0f-a834-5ca1f91e2795"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f48718b4-4a0b-4f5a-92e1-869b4c255079"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("15b6193f-601d-4a94-bba3-850a4ed2703e"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("60b34fe4-8582-443f-8e51-e497ea46d715"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("9f88b16f-9e3c-424e-952f-e799ddb2aab5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("792edefb-938f-4b67-b8f5-a79cc70f3fb8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("86bd6057-ea22-4f4f-83b0-ee1f97b1b718"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("fd5bdcf7-a5f8-4958-9af1-ac1db8db1098"));

            migrationBuilder.AddColumn<string>(
                name: "EditedBy",
                table: "Posts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("89f33c28-362f-40f9-9079-c47ee5d4d8b1"), "ee2c92a5-38ee-40b2-96de-a1c351837eaf", "admin", "ADMIN" },
                    { new Guid("e97c2742-7f10-478e-a30c-b2f8f25d1907"), "40df99ee-5cc8-463d-af7e-601bff2e67a0", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsItAdministrator", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"), 0, "not set", "f9c4f053-9022-447b-94e2-ce41dc3c9629", "jdoe@email.com", true, "John", true, new DateTime(2021, 4, 22, 21, 33, 44, 436, DateTimeKind.Utc).AddTicks(2015), "Doe", false, null, "JDOE@EMAIL.COM", "JDOE", "AQAAAAEAACcQAAAAED5V4i7Pl0Now/eD/fQ8q1hkg9OEa3j9NGrO7Z+PzBixdlfZIyPtmfON3t3dcuO0cg==", null, false, "", false, "jdoe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"), 0, "not set", "c215c7e8-846f-4c8c-9332-ae3c7a803a41", "bbsky@email.com", true, "Bob", new DateTime(2021, 4, 22, 21, 33, 44, 444, DateTimeKind.Utc).AddTicks(5892), "Bobsky", false, null, "BBSKY@EMAIL.COM", "BBSKY", "AQAAAAEAACcQAAAAEFdDud5EpLlubXqJ4Z7PfzcsbBPvEWUxqPDHiewNaEfOxrXjTwgjb7AbrBH6/YbIWA==", null, false, "", false, "bbsky" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("17f067af-2898-429e-aa35-e2fee1a35957"), "Software" },
                    { new Guid("c6dfb416-37ea-4213-bf98-46e5ef95b81c"), "Games" },
                    { new Guid("33ac5e29-9ada-48f3-b6f3-1f5b9d78780c"), "News" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"), new Guid("89f33c28-362f-40f9-9079-c47ee5d4d8b1") },
                    { new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"), new Guid("e97c2742-7f10-478e-a30c-b2f8f25d1907") }
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "CategoryId", "DateCreated", "Title" },
                values: new object[,]
                {
                    { new Guid("ad2ce429-00d9-4164-9b8c-a3b52a9c37c7"), new Guid("17f067af-2898-429e-aa35-e2fee1a35957"), new DateTime(2021, 4, 22, 21, 33, 44, 445, DateTimeKind.Utc).AddTicks(7873), "Best free antivirus" },
                    { new Guid("b5644bfd-c5c5-4b0b-b644-dfac147205db"), new Guid("c6dfb416-37ea-4213-bf98-46e5ef95b81c"), new DateTime(2021, 4, 22, 21, 33, 44, 445, DateTimeKind.Utc).AddTicks(8692), "The Best FPS for 2020" },
                    { new Guid("2051b91a-3108-4cb1-92fb-f35d54119032"), new Guid("33ac5e29-9ada-48f3-b6f3-1f5b9d78780c"), new DateTime(2021, 4, 22, 21, 33, 44, 445, DateTimeKind.Utc).AddTicks(8709), "New Version of Firefox has been released" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "DatePosted", "EditedBy", "ThreadId", "UserId", "Username" },
                values: new object[,]
                {
                    { new Guid("e1573c82-8282-406d-bac6-093131b014b3"), "Kaspersky Cloud Free is the best free option.", new DateTime(2021, 4, 22, 21, 33, 44, 446, DateTimeKind.Utc).AddTicks(5523), null, new Guid("ad2ce429-00d9-4164-9b8c-a3b52a9c37c7"), new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"), "bbsky" },
                    { new Guid("b89da3bc-65e1-40bc-a82e-10b647bd8aaa"), "Call of Duty: Modern Warfare is the best one so far.", new DateTime(2021, 4, 22, 21, 33, 44, 446, DateTimeKind.Utc).AddTicks(6316), null, new Guid("b5644bfd-c5c5-4b0b-b644-dfac147205db"), new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"), "bbsky" },
                    { new Guid("ff86d947-2428-434a-a2d1-06a531970238"), "Firefox 81.0 has been released.", new DateTime(2021, 4, 22, 21, 33, 44, 446, DateTimeKind.Utc).AddTicks(6333), null, new Guid("2051b91a-3108-4cb1-92fb-f35d54119032"), new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"), "jdoe" },
                    { new Guid("7176be8d-f9d5-4ca3-a16c-f221fd090748"), "I hope they've patched some of the security holes.", new DateTime(2021, 4, 22, 21, 33, 44, 446, DateTimeKind.Utc).AddTicks(6337), null, new Guid("2051b91a-3108-4cb1-92fb-f35d54119032"), new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"), "bbsky" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("2234fa56-3182-4941-ba58-e68e53354de3"), "I don't agree entirely, Kaspersky it's little bit heavy on resources.", new DateTime(2021, 4, 22, 21, 33, 44, 447, DateTimeKind.Utc).AddTicks(797), new Guid("e1573c82-8282-406d-bac6-093131b014b3"), new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("9c6ba06b-030d-4181-9b97-8341c978d299"), "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.", new DateTime(2021, 4, 22, 21, 33, 44, 447, DateTimeKind.Utc).AddTicks(1561), new Guid("b89da3bc-65e1-40bc-a82e-10b647bd8aaa"), new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("13dfb00e-69b3-4c9c-b277-cc4198a7badc"), "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.", new DateTime(2021, 4, 22, 21, 33, 44, 447, DateTimeKind.Utc).AddTicks(1581), new Guid("ff86d947-2428-434a-a2d1-06a531970238"), new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"), "bbsky" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"), new Guid("e97c2742-7f10-478e-a30c-b2f8f25d1907") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"), new Guid("89f33c28-362f-40f9-9079-c47ee5d4d8b1") });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("7176be8d-f9d5-4ca3-a16c-f221fd090748"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("13dfb00e-69b3-4c9c-b277-cc4198a7badc"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("2234fa56-3182-4941-ba58-e68e53354de3"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("9c6ba06b-030d-4181-9b97-8341c978d299"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("89f33c28-362f-40f9-9079-c47ee5d4d8b1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e97c2742-7f10-478e-a30c-b2f8f25d1907"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("b89da3bc-65e1-40bc-a82e-10b647bd8aaa"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("e1573c82-8282-406d-bac6-093131b014b3"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("ff86d947-2428-434a-a2d1-06a531970238"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d364bb30-998d-451a-bc87-27ec8aafca5a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7997c59-a227-4ecb-96a1-c710ad81f48d"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("2051b91a-3108-4cb1-92fb-f35d54119032"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("ad2ce429-00d9-4164-9b8c-a3b52a9c37c7"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("b5644bfd-c5c5-4b0b-b644-dfac147205db"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("17f067af-2898-429e-aa35-e2fee1a35957"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("33ac5e29-9ada-48f3-b6f3-1f5b9d78780c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c6dfb416-37ea-4213-bf98-46e5ef95b81c"));

            migrationBuilder.DropColumn(
                name: "EditedBy",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("13e32762-b7d5-4aec-a2c8-30b844f45342"), "6d5d5c44-3d21-42f2-be8a-cd8a2b4030d8", "admin", "ADMIN" },
                    { new Guid("11bc3a4d-ef79-4049-b8bf-54f1522ec013"), "1a73ca4f-6502-40bb-87b0-c7eba54c6e04", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsItAdministrator", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f48718b4-4a0b-4f5a-92e1-869b4c255079"), 0, "not set", "e9447117-30ff-4efa-9389-73b07a87f30e", "jdoe@email.com", true, "John", true, new DateTime(2021, 4, 22, 20, 21, 54, 102, DateTimeKind.Utc).AddTicks(9370), "Doe", false, null, "JDOE@EMAIL.COM", "JDOE", "AQAAAAEAACcQAAAAEDYss8UbJGECaFfzLXzky6g0LFUvNYD9ZdXQ5HT+hLXZV1DbIMSzCoIS4capbuNH7Q==", null, false, "", false, "jdoe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7380e9b8-3712-4b0f-a834-5ca1f91e2795"), 0, "not set", "db0450c6-ef4f-4fa5-8018-19eaac37595c", "bbsky@email.com", true, "Bob", new DateTime(2021, 4, 22, 20, 21, 54, 111, DateTimeKind.Utc).AddTicks(6482), "Bobsky", false, null, "BBSKY@EMAIL.COM", "BBSKY", "AQAAAAEAACcQAAAAECSPSr8ds7vNJMf/56gVy3IxZS6R5xSg/C9g1d6kgRF2O2gMkwZTQ2hEPaSV7F1OTA==", null, false, "", false, "bbsky" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("fd5bdcf7-a5f8-4958-9af1-ac1db8db1098"), "Software" },
                    { new Guid("86bd6057-ea22-4f4f-83b0-ee1f97b1b718"), "Games" },
                    { new Guid("792edefb-938f-4b67-b8f5-a79cc70f3fb8"), "News" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("f48718b4-4a0b-4f5a-92e1-869b4c255079"), new Guid("13e32762-b7d5-4aec-a2c8-30b844f45342") },
                    { new Guid("7380e9b8-3712-4b0f-a834-5ca1f91e2795"), new Guid("11bc3a4d-ef79-4049-b8bf-54f1522ec013") }
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "CategoryId", "DateCreated", "Title" },
                values: new object[,]
                {
                    { new Guid("9f88b16f-9e3c-424e-952f-e799ddb2aab5"), new Guid("fd5bdcf7-a5f8-4958-9af1-ac1db8db1098"), new DateTime(2021, 4, 22, 20, 21, 54, 112, DateTimeKind.Utc).AddTicks(8466), "Best free antivirus" },
                    { new Guid("60b34fe4-8582-443f-8e51-e497ea46d715"), new Guid("86bd6057-ea22-4f4f-83b0-ee1f97b1b718"), new DateTime(2021, 4, 22, 20, 21, 54, 112, DateTimeKind.Utc).AddTicks(9269), "The Best FPS for 2020" },
                    { new Guid("15b6193f-601d-4a94-bba3-850a4ed2703e"), new Guid("792edefb-938f-4b67-b8f5-a79cc70f3fb8"), new DateTime(2021, 4, 22, 20, 21, 54, 112, DateTimeKind.Utc).AddTicks(9287), "New Version of Firefox has been released" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "DatePosted", "ThreadId", "UserId", "Username" },
                values: new object[,]
                {
                    { new Guid("d48a5d1e-49fa-4672-bd96-57f7bfda520a"), "Kaspersky Cloud Free is the best free option.", new DateTime(2021, 4, 22, 20, 21, 54, 113, DateTimeKind.Utc).AddTicks(6214), new Guid("9f88b16f-9e3c-424e-952f-e799ddb2aab5"), new Guid("7380e9b8-3712-4b0f-a834-5ca1f91e2795"), "bbsky" },
                    { new Guid("4b11047b-0380-4804-acdf-e4f8ceb60203"), "Call of Duty: Modern Warfare is the best one so far.", new DateTime(2021, 4, 22, 20, 21, 54, 113, DateTimeKind.Utc).AddTicks(7010), new Guid("60b34fe4-8582-443f-8e51-e497ea46d715"), new Guid("7380e9b8-3712-4b0f-a834-5ca1f91e2795"), "bbsky" },
                    { new Guid("897e1a19-e6c0-48a1-8850-7fe7159067f6"), "Firefox 81.0 has been released.", new DateTime(2021, 4, 22, 20, 21, 54, 113, DateTimeKind.Utc).AddTicks(7030), new Guid("15b6193f-601d-4a94-bba3-850a4ed2703e"), new Guid("f48718b4-4a0b-4f5a-92e1-869b4c255079"), "jdoe" },
                    { new Guid("65e751ae-9788-442b-8795-f1c5ff16179b"), "I hope they've patched some of the security holes.", new DateTime(2021, 4, 22, 20, 21, 54, 113, DateTimeKind.Utc).AddTicks(7033), new Guid("15b6193f-601d-4a94-bba3-850a4ed2703e"), new Guid("7380e9b8-3712-4b0f-a834-5ca1f91e2795"), "bbsky" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("115ba9d8-cbef-4a26-a479-889a27c10b45"), "I don't agree entirely, Kaspersky it's little bit heavy on resources.", new DateTime(2021, 4, 22, 20, 21, 54, 114, DateTimeKind.Utc).AddTicks(1510), new Guid("d48a5d1e-49fa-4672-bd96-57f7bfda520a"), new Guid("f48718b4-4a0b-4f5a-92e1-869b4c255079"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("cfc800dc-b5df-4b1f-b5b5-378607ce3046"), "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.", new DateTime(2021, 4, 22, 20, 21, 54, 114, DateTimeKind.Utc).AddTicks(2270), new Guid("4b11047b-0380-4804-acdf-e4f8ceb60203"), new Guid("f48718b4-4a0b-4f5a-92e1-869b4c255079"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("f0809604-b642-4a95-a3e4-d9c0c0c4e58e"), "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.", new DateTime(2021, 4, 22, 20, 21, 54, 114, DateTimeKind.Utc).AddTicks(2288), new Guid("897e1a19-e6c0-48a1-8850-7fe7159067f6"), new Guid("7380e9b8-3712-4b0f-a834-5ca1f91e2795"), "bbsky" });
        }
    }
}
