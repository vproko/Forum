using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DataAccess.Migrations
{
    public partial class AddedEditedPropertyToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("7723ac91-5d1a-4f94-ae01-a0ab6b45db4f"), new Guid("415a3ffd-f34f-43b2-ac94-2bb0a351b77d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("df07adf2-d1b1-46e8-89a0-7ad42d6ade53"), new Guid("90f45d03-e309-42ab-82ef-b9f71ca3d138") });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("34df0d97-a06d-4089-ac20-5987b0090357"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("415e7732-dc05-476f-a7b0-e1fa0d3a576f"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("56b62391-774e-4e8e-b860-6d750e58b74c"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "ReplyId",
                keyValue: new Guid("ca855024-65b6-4ce3-9239-d78059573849"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("415a3ffd-f34f-43b2-ac94-2bb0a351b77d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("90f45d03-e309-42ab-82ef-b9f71ca3d138"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("7a8eb558-6ba1-4a9b-aaa0-f5d30afedbac"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("d02bc654-24ef-426e-86ad-ce3160bbf7e0"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("e38b2327-3c5d-4a01-9a51-39b441adad8e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7723ac91-5d1a-4f94-ae01-a0ab6b45db4f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df07adf2-d1b1-46e8-89a0-7ad42d6ade53"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("4dc1f058-4bab-4d2e-879f-8496ef338d10"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("e170d035-857b-4a70-865b-87bef7051cbb"));

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "ThreadId",
                keyValue: new Guid("e2a4ed51-c840-445d-a3eb-f3f91dab6441"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("01e122dc-a2d1-4dd0-84d8-ac67b9b8a706"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("0b396523-b393-4b7f-aeaf-0bb8d71fda20"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("71a55080-aff8-4934-9daf-0aec280fe183"));

            migrationBuilder.AddColumn<bool>(
                name: "Edited",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Edited",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("90f45d03-e309-42ab-82ef-b9f71ca3d138"), "e034c462-44df-4909-b2b5-b283c55e80da", "admin", "ADMIN" },
                    { new Guid("415a3ffd-f34f-43b2-ac94-2bb0a351b77d"), "46748b78-e7db-411a-b31e-d81a9f7fcbf6", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsItAdministrator", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("df07adf2-d1b1-46e8-89a0-7ad42d6ade53"), 0, "not set", "2873d1f9-d28c-44cc-b9a5-dfe50dbb6283", "jdoe@email.com", true, "John", true, new DateTime(2021, 4, 14, 10, 39, 3, 953, DateTimeKind.Utc).AddTicks(2860), "Doe", false, null, "JDOE@EMAIL.COM", "JDOE", "AQAAAAEAACcQAAAAEHbTq3PqwswBg5ONHOxTzbyytofNm+DNy7p1fsJC0Jm0wM+XPiQU+Qrr92NKziHaEA==", null, false, "", false, "jdoe" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Joined", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7723ac91-5d1a-4f94-ae01-a0ab6b45db4f"), 0, "not set", "7b991f8a-35fe-4886-9f29-92c42e808804", "bbsky@email.com", true, "Bob", new DateTime(2021, 4, 14, 10, 39, 3, 961, DateTimeKind.Utc).AddTicks(8509), "Bobsky", false, null, "BBSKY@EMAIL.COM", "BBSKY", "AQAAAAEAACcQAAAAEPnb5dnEyxXmBixFfHsC7sEKR7DJ5sO0Kyx5KHxBsSKchOHiJ+cNL6BeQoA6FfX8zA==", null, false, "", false, "bbsky" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("0b396523-b393-4b7f-aeaf-0bb8d71fda20"), "Software" },
                    { new Guid("01e122dc-a2d1-4dd0-84d8-ac67b9b8a706"), "Games" },
                    { new Guid("71a55080-aff8-4934-9daf-0aec280fe183"), "News" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("df07adf2-d1b1-46e8-89a0-7ad42d6ade53"), new Guid("90f45d03-e309-42ab-82ef-b9f71ca3d138") },
                    { new Guid("7723ac91-5d1a-4f94-ae01-a0ab6b45db4f"), new Guid("415a3ffd-f34f-43b2-ac94-2bb0a351b77d") }
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "CategoryId", "DateCreated", "Title" },
                values: new object[,]
                {
                    { new Guid("4dc1f058-4bab-4d2e-879f-8496ef338d10"), new Guid("0b396523-b393-4b7f-aeaf-0bb8d71fda20"), new DateTime(2021, 4, 14, 10, 39, 3, 963, DateTimeKind.Utc).AddTicks(873), "Best free antivirus" },
                    { new Guid("e2a4ed51-c840-445d-a3eb-f3f91dab6441"), new Guid("01e122dc-a2d1-4dd0-84d8-ac67b9b8a706"), new DateTime(2021, 4, 14, 10, 39, 3, 963, DateTimeKind.Utc).AddTicks(1688), "The Best FPS for 2020" },
                    { new Guid("e170d035-857b-4a70-865b-87bef7051cbb"), new Guid("71a55080-aff8-4934-9daf-0aec280fe183"), new DateTime(2021, 4, 14, 10, 39, 3, 963, DateTimeKind.Utc).AddTicks(1706), "New Version of Firefox has been released" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "DatePosted", "ThreadId", "UserId", "Username" },
                values: new object[,]
                {
                    { new Guid("7a8eb558-6ba1-4a9b-aaa0-f5d30afedbac"), "Kaspersky Cloud Free is the best free option.", new DateTime(2021, 4, 14, 10, 39, 3, 963, DateTimeKind.Utc).AddTicks(8541), new Guid("4dc1f058-4bab-4d2e-879f-8496ef338d10"), new Guid("7723ac91-5d1a-4f94-ae01-a0ab6b45db4f"), "bbsky" },
                    { new Guid("d02bc654-24ef-426e-86ad-ce3160bbf7e0"), "Call of Duty: Modern Warfare is the best one so far.", new DateTime(2021, 4, 14, 10, 39, 3, 963, DateTimeKind.Utc).AddTicks(9410), new Guid("e2a4ed51-c840-445d-a3eb-f3f91dab6441"), new Guid("7723ac91-5d1a-4f94-ae01-a0ab6b45db4f"), "bbsky" },
                    { new Guid("e38b2327-3c5d-4a01-9a51-39b441adad8e"), "Firefox 81.0 has been released.", new DateTime(2021, 4, 14, 10, 39, 3, 963, DateTimeKind.Utc).AddTicks(9429), new Guid("e170d035-857b-4a70-865b-87bef7051cbb"), new Guid("df07adf2-d1b1-46e8-89a0-7ad42d6ade53"), "jdoe" },
                    { new Guid("34df0d97-a06d-4089-ac20-5987b0090357"), "I hope they've patched some of the security holes.", new DateTime(2021, 4, 14, 10, 39, 3, 963, DateTimeKind.Utc).AddTicks(9432), new Guid("e170d035-857b-4a70-865b-87bef7051cbb"), new Guid("7723ac91-5d1a-4f94-ae01-a0ab6b45db4f"), "bbsky" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("ca855024-65b6-4ce3-9239-d78059573849"), "I don't agree entirely, Kaspersky it's little bit heavy on resources", new DateTime(2021, 4, 14, 10, 39, 3, 964, DateTimeKind.Utc).AddTicks(4225), new Guid("7a8eb558-6ba1-4a9b-aaa0-f5d30afedbac"), new Guid("df07adf2-d1b1-46e8-89a0-7ad42d6ade53"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("415e7732-dc05-476f-a7b0-e1fa0d3a576f"), "Amazing graphics, maybe too dynamic for my taste, and the one other thing I don't like, it's the obviouse taking \"sides\". It's game, it should be fun for everyone", new DateTime(2021, 4, 14, 10, 39, 3, 964, DateTimeKind.Utc).AddTicks(5058), new Guid("d02bc654-24ef-426e-86ad-ce3160bbf7e0"), new Guid("df07adf2-d1b1-46e8-89a0-7ad42d6ade53"), "jdoe" });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "DateReplied", "PostId", "UserId", "Username" },
                values: new object[] { new Guid("56b62391-774e-4e8e-b860-6d750e58b74c"), "Firefox used to be my first choice, with Brave Browser on the market, I think his position is seriously jeopardized", new DateTime(2021, 4, 14, 10, 39, 3, 964, DateTimeKind.Utc).AddTicks(5077), new Guid("e38b2327-3c5d-4a01-9a51-39b441adad8e"), new Guid("7723ac91-5d1a-4f94-ae01-a0ab6b45db4f"), "bbsky" });
        }
    }
}
