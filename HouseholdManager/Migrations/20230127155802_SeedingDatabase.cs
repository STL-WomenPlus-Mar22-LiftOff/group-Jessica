using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "User", "User" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Administrator", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1addd14-6340-4840-95c2-db12554843e5", 0, "099d6d7b-8a7e-43a5-8cf1-0da39c99628d", "defaultAdmin@yahoo.com", false, true, null, "DEFAULTADMIN@YAHOO.COM", "DEFAULTADMIN@YAHOO.COM", "AQAAAAEAACcQAAAAELeKW1R6ys0U4t3pqRsMZgzlBxnW7EN+2WzzFPq1k6GsGbqicTqDQlYjWFqd3Tx1rw==", "111-222-3333", false, "7fe6d526-fe7c-4e7c-894b-9ae6ac77202a", false, "defaultAdmin@yahoo.com" },
                    { "u1ua87c6-b718-4f48-90a2-458e0a2443e6", 0, "c1b8df6d-d480-45ea-b8f7-93eae78f06d6", "defaultUser@yahoo.com", false, true, null, "DEFAULTUSER@YAHOO.COM", "DEFAULTUSER@YAHOO.COM", "AQAAAAEAACcQAAAAEBA1wJ+EHpEa/w4lNA9wuJWrVnF7NNhmFtrwI1xOi75EXVzdoL5ZVXeewZhEG6/3yw==", "111-222-3333", false, "8a89dec9-741b-4fa9-a940-f191e8848c20", false, "defaultUser@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "Households",
                columns: new[] { "HouseholdId", "HouseholdName", "Icon" },
                values: new object[] { 1, "DefaultHousehold", "" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "🥄", "Kitchen" },
                    { 2, "🧻", "Bathroom" },
                    { 3, "🛏", "Master Bedroom" },
                    { 4, "🛋", "Living Room" },
                    { 5, "🛏", "Bedroom" },
                    { 6, "🛏", "Guest Bedroom" },
                    { 7, "🧻", "Master Bathroom" },
                    { 8, "🍽", "Dining Room" },
                    { 9, "🌳", "Yard" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "a1addd14-6340-4840-95c2-db12554843e5" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "a1addd14-6340-4840-95c2-db12554843e5" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "u1ua87c6-b718-4f48-90a2-458e0a2443e6" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "HouseholdId", "Icon", "MemberType", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "👩‍🔧", "Admin", null, "defaultAdmin@yahoo.com" },
                    { 2, 1, "👩‍💼", "Member", null, "defaultUser@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "MissionId", "DueDate", "MemberId", "MissionName", "Point", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(554), 2, "Wash dishes", 2, 1 },
                    { 2, new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(667), 1, "Make bed", 1, 5 },
                    { 3, new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(679), 2, "Make bed", 1, 3 },
                    { 4, new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(689), 1, "Mow lawn", 5, 9 },
                    { 5, new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(697), 1, "Make dinner", 4, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "a1addd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "a1addd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "u1ua87c6-b718-4f48-90a2-458e0a2443e6" });

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1addd14-6340-4840-95c2-db12554843e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1ua87c6-b718-4f48-90a2-458e0a2443e6");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Households",
                keyColumn: "HouseholdId",
                keyValue: 1);
        }
    }
}
