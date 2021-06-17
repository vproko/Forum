using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DataAccess.Migrations
{
    public partial class EditedAndEditedByAddedToReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Replies",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "Edited",
                table: "Replies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EditedBy",
                table: "Replies",
                maxLength: 100,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("98ade400-f9ae-488d-b519-9b1f428f2b09"), "852f323e-9701-49c0-acbe-623180f2e0ec", "admin", "ADMIN" },
                    { new Guid("7e37de0d-0651-4997-b4fc-919a0e27481e"), "af49aa12-886d-4b15-a8c9-0cfe934b00c1", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsItAdministrator", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"), 0, "not set", "67cc1136-c6fc-44d3-a259-c942a270ed9b", "jdoe@email.com", true, "John", true, new DateTime(2021, 4, 26, 13, 37, 33, 951, DateTimeKind.Utc).AddTicks(5332), "Doe", false, null, "JDOE@EMAIL.COM", "JDOE", "AQAAAAEAACcQAAAAEE6yCVNVa8s627v0CpttLeQuPEs1RO6lEPWZSAs5tN+SB6M9/tG3Lzm+iftk4Kf0Gg==", null, false, "", false, "jdoe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"), 0, "not set", "1929deba-7268-48e7-ae04-31f84bba3f32", "bbsky@email.com", true, "Bob", new DateTime(2021, 4, 26, 13, 37, 33, 960, DateTimeKind.Utc).AddTicks(3233), "Bobsky", false, null, "BBSKY@EMAIL.COM", "BBSKY", "AQAAAAEAACcQAAAAEDPgq+bXGxT00Ci4fsonUHgTxTqYZCtPkRpH5H0zDTZ4KLPAtR7oFBj0Kl2TgNSpKg==", null, false, "", false, "bbsky" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("fee89ac0-5cb9-4df7-a658-079384f83511"), "Software" },
                    { new Guid("4a2895b5-f4c9-4d71-bf2a-96c6c54da07d"), "Games" },
                    { new Guid("8f50d186-f6ed-463a-bac4-bbada253ed66"), "News" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"), new Guid("98ade400-f9ae-488d-b519-9b1f428f2b09") },
                    { new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"), new Guid("7e37de0d-0651-4997-b4fc-919a0e27481e") }
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "CategoryId", "DateCreated", "Title" },
                values: new object[,]
                {
                    { new Guid("2fda77c9-4b49-48f4-93e3-9fe1dae81b54"), new Guid("fee89ac0-5cb9-4df7-a658-079384f83511"), new DateTime(2021, 4, 26, 13, 37, 33, 961, DateTimeKind.Utc).AddTicks(6004), "Best free antivirus" },
                    { new Guid("8947e958-ad5a-45a9-9bf7-2076b89a6fa2"), new Guid("4a2895b5-f4c9-4d71-bf2a-96c6c54da07d"), new DateTime(2021, 4, 26, 13, 37, 33, 961, DateTimeKind.Utc).AddTicks(6840), "The Best FPS for 2020" },
                    { new Guid("c173b6b1-a9b6-4679-ab0a-955e40ff1f8c"), new Guid("8f50d186-f6ed-463a-bac4-bbada253ed66"), new DateTime(2021, 4, 26, 13, 37, 33, 961, DateTimeKind.Utc).AddTicks(6857), "New Version of Firefox has been released" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "DatePosted", "EditedBy", "ThreadId", "UserId", "Username" },
                values: new object[,]
                {
                    { new Guid("b098e09a-b36d-464c-8794-83ab03f707a0"), "Kaspersky Cloud Free is the best free option.", new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(3855), null, new Guid("2fda77c9-4b49-48f4-93e3-9fe1dae81b54"), new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"), "bbsky" },
                    { new Guid("a534fdb9-2309-49b3-8b61-7d24acf6d797"), "Call of Duty: Modern Warfare is the best one so far.", new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(4676), null, new Guid("8947e958-ad5a-45a9-9bf7-2076b89a6fa2"), new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"), "bbsky" },
                    { new Guid("fb432ca6-3eb7-4619-8a8e-b9c8c3313420"), "Firefox 81.0 has been released.", new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(4694), null, new Guid("c173b6b1-a9b6-4679-ab0a-955e40ff1f8c"), new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"), "jdoe" },
                    { new Guid("6094849b-94fa-4b35-90ec-f016bb2c11c1"), "I hope they've patched some of the security holes.", new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(4697), null, new Guid("c173b6b1-a9b6-4679-ab0a-955e40ff1f8c"), new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"), "bbsky" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("c7859686-7469-4f39-ad65-0d088409a60a"), "I don't agree entirely, Kaspersky it's little bit heavy on resources.", new DateTime(2021, 4, 26, 13, 37, 33, 962, DateTimeKind.Utc).AddTicks(9232), false, null, new Guid("b098e09a-b36d-464c-8794-83ab03f707a0"), new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("8553372c-ecdb-45d8-ac8b-b097f219f466"), "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.", new DateTime(2021, 4, 26, 13, 37, 33, 963, DateTimeKind.Utc).AddTicks(717), false, null, new Guid("a534fdb9-2309-49b3-8b61-7d24acf6d797"), new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("976a2ad7-fe01-41e8-bc90-885093168fe5"), "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.", new DateTime(2021, 4, 26, 13, 37, 33, 963, DateTimeKind.Utc).AddTicks(741), false, null, new Guid("fb432ca6-3eb7-4619-8a8e-b9c8c3313420"), new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"), "bbsky" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"), new Guid("7e37de0d-0651-4997-b4fc-919a0e27481e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"), new Guid("98ade400-f9ae-488d-b519-9b1f428f2b09") });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("6094849b-94fa-4b35-90ec-f016bb2c11c1"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("8553372c-ecdb-45d8-ac8b-b097f219f466"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("976a2ad7-fe01-41e8-bc90-885093168fe5"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("c7859686-7469-4f39-ad65-0d088409a60a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e37de0d-0651-4997-b4fc-919a0e27481e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98ade400-f9ae-488d-b519-9b1f428f2b09"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("a534fdb9-2309-49b3-8b61-7d24acf6d797"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("b098e09a-b36d-464c-8794-83ab03f707a0"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("fb432ca6-3eb7-4619-8a8e-b9c8c3313420"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a26abf1-a6b3-42d7-a42b-e327c962fa6e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97c9b0b9-a303-427c-85a3-0504ee05fd6f"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("2fda77c9-4b49-48f4-93e3-9fe1dae81b54"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("8947e958-ad5a-45a9-9bf7-2076b89a6fa2"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("c173b6b1-a9b6-4679-ab0a-955e40ff1f8c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("4a2895b5-f4c9-4d71-bf2a-96c6c54da07d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("8f50d186-f6ed-463a-bac4-bbada253ed66"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("fee89ac0-5cb9-4df7-a658-079384f83511"));

            migrationBuilder.DropColumn(
                name: "Edited",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "EditedBy",
                table: "Replies");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Replies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

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
    }
}
