using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class Dirtometer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirtLevel",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1addd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67a56391-1316-40fd-8a7e-23ca049c5e38", "AQAAAAEAACcQAAAAEArCiebaI1hPxRPxOVBEz+0oK0j+1P5p3/iv0f1u5GyZifqd+i3OfzOc19inYNc7sw==", "b2121470-4b44-4e68-9a5c-b0edbeb08821" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1ua87c6-b718-4f48-90a2-458e0a2443e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e959b39d-d9dc-41b4-8032-d1b09a2963d6", "AQAAAAEAACcQAAAAEL/4ha50nFSciIestRudWfniC2wE+bEWxXrUN2hf3Hit2+28dTFiE6mSoL33zmQZQA==", "8c79ff39-783f-47a9-ad4c-5ccb099e84a5" });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 2, 7, 15, 16, 16, 40, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 2, 7, 15, 16, 16, 40, DateTimeKind.Local).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 2, 7, 15, 16, 16, 40, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2023, 2, 7, 15, 16, 16, 40, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2023, 2, 7, 15, 16, 16, 40, DateTimeKind.Local).AddTicks(2439));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirtLevel",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1addd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab3eeed0-defd-41e9-b1bd-36661b62829d", "AQAAAAEAACcQAAAAENFo9vgxEGXoObDLtNeg1E4EAhglostSfvFOkO49dwmG408JAN2qbOfAk4yM/8pG+A==", "8bbd6713-9a6a-4572-a0a2-7f159540fba0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1ua87c6-b718-4f48-90a2-458e0a2443e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87e350eb-1d91-4711-96d9-f9c46cf314fe", "AQAAAAEAACcQAAAAEK5S9m0kGIvt8YgHuLX9cGIRE8T2ZlaAZJL8V3rcHEh+EHGunYODzGG/LClIuugq6w==", "33ca19e6-a47d-4a14-b372-519aa161a80d" });

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 1, 31, 21, 45, 23, 545, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 1, 31, 21, 45, 23, 545, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 1, 31, 21, 45, 23, 545, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2023, 1, 31, 21, 45, 23, 545, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "MissionId",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2023, 1, 31, 21, 45, 23, 545, DateTimeKind.Local).AddTicks(9889));
        }
    }
}
