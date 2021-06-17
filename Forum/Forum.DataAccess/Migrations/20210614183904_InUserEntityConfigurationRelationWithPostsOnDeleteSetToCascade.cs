using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DataAccess.Migrations
{
    public partial class InUserEntityConfigurationRelationWithPostsOnDeleteSetToCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("395284c7-b632-475a-b09d-aa82cc3fee37"), "96eae66b-0fc1-40f9-ad56-fbdac910b441", "admin", "ADMIN" },
                    { new Guid("f0bcb522-53cc-43ce-acfd-730e1e66d4a3"), "fae127e1-7401-4dd5-866b-4691ba00484f", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsItAdministrator", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"), 0, "not set", "4b5cc72e-8d20-40b3-8234-52bbed988b71", "jdoe@email.com", true, "John", true, new DateTime(2021, 6, 14, 18, 39, 3, 444, DateTimeKind.Utc).AddTicks(3427), "Doe", false, null, "JDOE@EMAIL.COM", "JDOE", "AQAAAAEAACcQAAAAEI1bELNxFHTR9PYUjsruo/UbUC+/e9dPtCc2U1YtrGdrLOA0YGf9UX7TDOUfyG/Jqg==", null, false, "", false, "jdoe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("64b8a5ff-a606-4722-960c-81056d081226"), 0, "not set", "ec5ded53-b17a-4340-9223-6daff3f179e2", "bbsky@email.com", true, "Bob", new DateTime(2021, 6, 14, 18, 39, 3, 455, DateTimeKind.Utc).AddTicks(1146), "Bobsky", false, null, "BBSKY@EMAIL.COM", "BBSKY", "AQAAAAEAACcQAAAAEK15OpBKNRY2/VX+s+o0JG92MVa9ajsQUNGqwE9mFoJ70bG4eOmMJIUrfmOQmM6gGg==", null, false, "", false, "bbsky" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("8c7c1d3f-3328-406b-89e1-63d89dc0a35e"), "Software" },
                    { new Guid("dbd1a7aa-05fa-454c-b970-fc16c78f39da"), "Games" },
                    { new Guid("220fb38d-2dad-4df7-bea0-c4c571b2969c"), "News" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"), new Guid("395284c7-b632-475a-b09d-aa82cc3fee37") },
                    { new Guid("64b8a5ff-a606-4722-960c-81056d081226"), new Guid("f0bcb522-53cc-43ce-acfd-730e1e66d4a3") }
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "CategoryId", "DateCreated", "Title" },
                values: new object[,]
                {
                    { new Guid("b5b3bf64-6b08-45bd-828d-e8e3d16b280d"), new Guid("8c7c1d3f-3328-406b-89e1-63d89dc0a35e"), new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(2692), "Best free antivirus" },
                    { new Guid("c142d3d5-604c-420e-9576-cdb10ad95d45"), new Guid("dbd1a7aa-05fa-454c-b970-fc16c78f39da"), new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(4108), "The Best FPS for 2020" },
                    { new Guid("c16e41bf-de73-4b81-86a3-c76b77b3d2cd"), new Guid("220fb38d-2dad-4df7-bea0-c4c571b2969c"), new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(4140), "New Version of Firefox has been released" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "DatePosted", "EditedBy", "ThreadId", "UserId", "Username" },
                values: new object[,]
                {
                    { new Guid("07c57aef-3ce0-406c-b59d-a02bb5f39a9c"), "Kaspersky Cloud Free is the best free option.", new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(8897), null, new Guid("b5b3bf64-6b08-45bd-828d-e8e3d16b280d"), new Guid("64b8a5ff-a606-4722-960c-81056d081226"), "bbsky" },
                    { new Guid("16733bff-02e1-48ad-919f-c676d52d8ba9"), "Call of Duty: Modern Warfare is the best one so far.", new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(9481), null, new Guid("c142d3d5-604c-420e-9576-cdb10ad95d45"), new Guid("64b8a5ff-a606-4722-960c-81056d081226"), "bbsky" },
                    { new Guid("29380704-484a-41c7-9b49-5df6bbb0522d"), "Firefox 81.0 has been released.", new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(9498), null, new Guid("c16e41bf-de73-4b81-86a3-c76b77b3d2cd"), new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"), "jdoe" },
                    { new Guid("aa0b7fbf-e496-40ee-8470-3f63907e7065"), "I hope they've patched some of the security holes.", new DateTime(2021, 6, 14, 18, 39, 3, 456, DateTimeKind.Utc).AddTicks(9502), null, new Guid("c16e41bf-de73-4b81-86a3-c76b77b3d2cd"), new Guid("64b8a5ff-a606-4722-960c-81056d081226"), "bbsky" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("19615e1f-69ee-4980-82df-dea41b28e7a0"), "I don't agree entirely, Kaspersky it's little bit heavy on resources.", new DateTime(2021, 6, 14, 18, 39, 3, 457, DateTimeKind.Utc).AddTicks(3558), false, null, new Guid("07c57aef-3ce0-406c-b59d-a02bb5f39a9c"), new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("74c37c65-b1f9-470b-bbdc-c5011fbcd2dc"), "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone.", new DateTime(2021, 6, 14, 18, 39, 3, 457, DateTimeKind.Utc).AddTicks(4556), false, null, new Guid("16733bff-02e1-48ad-919f-c676d52d8ba9"), new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "Edited", "EditedBy", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("4b5baedb-5c1c-44d3-8056-23bc3cd5da48"), "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized.", new DateTime(2021, 6, 14, 18, 39, 3, 457, DateTimeKind.Utc).AddTicks(4581), false, null, new Guid("29380704-484a-41c7-9b49-5df6bbb0522d"), new Guid("64b8a5ff-a606-4722-960c-81056d081226"), "bbsky" });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"), new Guid("395284c7-b632-475a-b09d-aa82cc3fee37") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("64b8a5ff-a606-4722-960c-81056d081226"), new Guid("f0bcb522-53cc-43ce-acfd-730e1e66d4a3") });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("aa0b7fbf-e496-40ee-8470-3f63907e7065"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("19615e1f-69ee-4980-82df-dea41b28e7a0"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("4b5baedb-5c1c-44d3-8056-23bc3cd5da48"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("74c37c65-b1f9-470b-bbdc-c5011fbcd2dc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("395284c7-b632-475a-b09d-aa82cc3fee37"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0bcb522-53cc-43ce-acfd-730e1e66d4a3"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("07c57aef-3ce0-406c-b59d-a02bb5f39a9c"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("16733bff-02e1-48ad-919f-c676d52d8ba9"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("29380704-484a-41c7-9b49-5df6bbb0522d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("07a7aa29-46cb-4b1c-95e0-a015004b1ef2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("64b8a5ff-a606-4722-960c-81056d081226"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("b5b3bf64-6b08-45bd-828d-e8e3d16b280d"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("c142d3d5-604c-420e-9576-cdb10ad95d45"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("c16e41bf-de73-4b81-86a3-c76b77b3d2cd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("220fb38d-2dad-4df7-bea0-c4c571b2969c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("8c7c1d3f-3328-406b-89e1-63d89dc0a35e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("dbd1a7aa-05fa-454c-b970-fc16c78f39da"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
