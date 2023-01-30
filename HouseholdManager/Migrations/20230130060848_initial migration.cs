using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1addd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb530eff-455f-44e3-9638-417fabed9396", "AQAAAAEAACcQAAAAEBKnqH+BAr4IcbpX+N6pory4ZU+rT8gw0oBuz45HExY7tNBXyXgBUx+Ak/s/sTpJkg==", "302cfd58-5d57-4678-8707-db303afde2d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1ua87c6-b718-4f48-90a2-458e0a2443e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a96405ab-e5fb-4b1d-a0bb-07b69baf5797", "AQAAAAEAACcQAAAAEL3S3DMJPCWXUHdnhmYWhSHqEQzQGPOO8rUOgiVEKhDKHW60pGYAE0eUI+KuEVe/+w==", "8434e09a-a050-4f42-ad41-032e11ea3e39" });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 1, 30, 0, 8, 47, 723, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 1, 30, 0, 8, 47, 723, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 1, 30, 0, 8, 47, 723, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2023, 1, 30, 0, 8, 47, 723, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2023, 1, 30, 0, 8, 47, 723, DateTimeKind.Local).AddTicks(9939));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1addd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "099d6d7b-8a7e-43a5-8cf1-0da39c99628d", "AQAAAAEAACcQAAAAELeKW1R6ys0U4t3pqRsMZgzlBxnW7EN+2WzzFPq1k6GsGbqicTqDQlYjWFqd3Tx1rw==", "7fe6d526-fe7c-4e7c-894b-9ae6ac77202a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1ua87c6-b718-4f48-90a2-458e0a2443e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1b8df6d-d480-45ea-b8f7-93eae78f06d6", "AQAAAAEAACcQAAAAEBA1wJ+EHpEa/w4lNA9wuJWrVnF7NNhmFtrwI1xOi75EXVzdoL5ZVXeewZhEG6/3yw==", "8a89dec9-741b-4fa9-a940-f191e8848c20" });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2023, 1, 27, 9, 58, 2, 199, DateTimeKind.Local).AddTicks(697));
        }
    }
}
