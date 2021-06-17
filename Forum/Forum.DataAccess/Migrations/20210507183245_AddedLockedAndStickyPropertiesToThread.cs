using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DataAccess.Migrations
{
    public partial class AddedLockedAndStickyPropertiesToThread : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "Threads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sticky",
                table: "Threads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("803735fe-075e-4a1b-867a-6690d1368193"), "5792793f-aae0-4046-8a6b-d600db412d66", "admin", "ADMIN" },
                    { new Guid("9f670e0c-b025-4f46-8c46-d8dda4cb81b1"), "995cf5c8-d5f0-4d57-95d8-c941c474497b", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsItAdministrator", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("758e9b7c-adda-4a70-8caf-adb80b384c97"), 0, "not set", "7a3a9d87-2ae3-4381-8c93-7b0a7cb2e415", "jdoe@email.com", true, "John", true, new DateTime(2021, 5, 7, 18, 32, 44, 226, DateTimeKind.Utc).AddTicks(5412), "Doe", false, null, "JDOE@EMAIL.COM", "JDOE", "AQAAAAEAACcQAAAAEGqkzG1HC9umolefy7aNQ2eqy/Xv82VRUaenInHqGm0qFQo6axPDDPWEMj2Yx2guIA==", null, false, "", false, "jdoe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c3e7c300-0862-410d-8532-16e0f89fe8ec"), 0, "not set", "f92d468c-268f-4f34-bc24-bd11212ed240", "bbsky@email.com", true, "Bob", new DateTime(2021, 5, 7, 18, 32, 44, 235, DateTimeKind.Utc).AddTicks(4352), "Bobsky", false, null, "BBSKY@EMAIL.COM", "BBSKY", "AQAAAAEAACcQAAAAEBd+WOePvyy+RfiyUM/AitN/7YK2ICgIfHRtCd/B8qos/GX1XtiRrUatRvYyNyopfQ==", null, false, "", false, "bbsky" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("5d65bbf0-e88d-4c1a-9141-c2ae28f6ec67"), "Software" },
                    { new Guid("66577e65-99be-4b99-84ad-964331207f6d"), "Games" },
                    { new Guid("bdc24be1-399f-4c76-81ee-7c55b30dee0b"), "News" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("758e9b7c-adda-4a70-8caf-adb80b384c97"), new Guid("803735fe-075e-4a1b-867a-6690d1368193") },
                    { new Guid("c3e7c300-0862-410d-8532-16e0f89fe8ec"), new Guid("9f670e0c-b025-4f46-8c46-d8dda4cb81b1") }
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "CategoryId", "DateCreated", "Title" },
                values: new object[,]
                {
                    { new Guid("43a680eb-6777-4909-a1a8-e67993b85db3"), new Guid("5d65bbf0-e88d-4c1a-9141-c2ae28f6ec67"), new DateTime(2021, 5, 7, 18, 32, 44, 236, DateTimeKind.Utc).AddTicks(7143), "Best free antivirus" },
                    { new Guid("fb765719-5817-4fb6-afee-345b82d4ae8e"), new Guid("66577e65-99be-4b99-84ad-964331207f6d"), new DateTime(2021, 5, 7, 18, 32, 44, 236, DateTimeKind.Utc).AddTicks(9560), "The Best FPS for 2020" },
                    { new Guid("a43c1b4a-60a5-4074-9eb5-425ceb8f7ffc"), new Guid("bdc24be1-399f-4c76-81ee-7c55b30dee0b"), new DateTime(2021, 5, 7, 18, 32, 44, 236, DateTimeKind.Utc).AddTicks(9597), "New Version of Firefox has been released" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "DatePosted", "EditedBy", "ThreadId", "UserId", "Username" },
                values: new object[,]
                {
                    { new Guid("6e01990d-e6ca-4c14-816e-82a0139b1d5e"), "Kaspersky Cloud Free is the best free option.", new DateTime(2021, 5, 7, 18, 32, 44, 237, DateTimeKind.Utc).AddTicks(7194), null, new Guid("43a680eb-6777-4909-a1a8-e67993b85db3"), new Guid("c3e7c300-0862-410d-8532-16e0f89fe8ec"), "bbsky" },
                    { new Guid("b0e1b1e3-d572-4332-917d-db78905351d6"), "Call of Duty: Modern Warfare is the best one so far.", new DateTime(2021, 5, 7, 18, 32, 44, 237, DateTimeKind.Utc).AddTicks(8069), null, new Guid("fb765719-5817-4fb6-afee-345b82d4ae8e"), new Guid("c3e7c300-0862-410d-8532-16e0f89fe8ec"), "bbsky" },
                    { new Guid("70dc0fa4-8c4c-417c-a7e9-322d3557d9ea"), "Firefox 81.0 has been released.", new DateTime(2021, 5, 7, 18, 32, 44, 237, DateTimeKind.Utc).AddTicks(8085), null, new Guid("a43c1b4a-60a5-4074-9eb5-425ceb8f7ffc"), new Guid("758e9b7c-adda-4a70-8caf-adb80b384c97"), "jdoe" },
                    { new Guid("4686815c-3802-4170-be76-8b64f6de8784"), "I hope they've patched some of the security holes.", new DateTime(2021, 5, 7, 18, 32, 44, 237, DateTimeKind.Utc).AddTicks(8088), null, new Guid("a43c1b4a-60a5-4074-9eb5-425ceb8f7ffc"), new Guid("c3e7c300-0862-410d-8532-16e0f89fe8ec"), "bbsky" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("4d46b7dd-2645-4de8-b5de-5004a915edf7"), "I don't agree entirely, Kaspersky it's little bit heavy on resources.", new DateTime(2021, 5, 7, 18, 32, 44, 238, DateTimeKind.Utc).AddTicks(2380), false, null, new Guid("6e01990d-e6ca-4c14-816e-82a0139b1d5e"), new Guid("758e9b7c-adda-4a70-8caf-adb80b384c97"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("83385a2b-9ff7-42cb-95ce-508a40878310"), "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.", new DateTime(2021, 5, 7, 18, 32, 44, 238, DateTimeKind.Utc).AddTicks(3774), false, null, new Guid("b0e1b1e3-d572-4332-917d-db78905351d6"), new Guid("758e9b7c-adda-4a70-8caf-adb80b384c97"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("66c42fe4-3fe3-4c85-b7d7-ce5ac446d5e8"), "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.", new DateTime(2021, 5, 7, 18, 32, 44, 238, DateTimeKind.Utc).AddTicks(3799), false, null, new Guid("70dc0fa4-8c4c-417c-a7e9-322d3557d9ea"), new Guid("c3e7c300-0862-410d-8532-16e0f89fe8ec"), "bbsky" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("758e9b7c-adda-4a70-8caf-adb80b384c97"), new Guid("803735fe-075e-4a1b-867a-6690d1368193") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("c3e7c300-0862-410d-8532-16e0f89fe8ec"), new Guid("9f670e0c-b025-4f46-8c46-d8dda4cb81b1") });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("4686815c-3802-4170-be76-8b64f6de8784"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("4d46b7dd-2645-4de8-b5de-5004a915edf7"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("66c42fe4-3fe3-4c85-b7d7-ce5ac446d5e8"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("83385a2b-9ff7-42cb-95ce-508a40878310"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("803735fe-075e-4a1b-867a-6690d1368193"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f670e0c-b025-4f46-8c46-d8dda4cb81b1"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("6e01990d-e6ca-4c14-816e-82a0139b1d5e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("70dc0fa4-8c4c-417c-a7e9-322d3557d9ea"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("b0e1b1e3-d572-4332-917d-db78905351d6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("758e9b7c-adda-4a70-8caf-adb80b384c97"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3e7c300-0862-410d-8532-16e0f89fe8ec"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("43a680eb-6777-4909-a1a8-e67993b85db3"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("a43c1b4a-60a5-4074-9eb5-425ceb8f7ffc"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("fb765719-5817-4fb6-afee-345b82d4ae8e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("5d65bbf0-e88d-4c1a-9141-c2ae28f6ec67"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("66577e65-99be-4b99-84ad-964331207f6d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("bdc24be1-399f-4c76-81ee-7c55b30dee0b"));

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "Threads");

            migrationBuilder.DropColumn(
                name: "Sticky",
                table: "Threads");

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
    }
}
