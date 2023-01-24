using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class InitialMigrationSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Households",
                columns: table => new
                {
                    HouseholdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseholdName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HouseholdIcon = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Households", x => x.HouseholdId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MemberIcon = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HouseholdId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "HouseholdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionId);
                    table.ForeignKey(
                        name: "FK_Missions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1addd14-6340-4840-95c2-db12554843e5", 0, null, "d90d998d-d0ca-4e99-91c0-fa7548fcc38e", "defaultAdmin@yahoo.com", false, null, null, true, null, "DEFAULTADMIN@YAHOO.COM", "DEFAULTADMIN@YAHOO.COM", "AQAAAAEAACcQAAAAENoZsrMrhcRNITEGP/sMadaRNoCyMT7Qr2fDA895bL2iddEvpXmUcKaLsMvNgcMpDw==", "111-222-3333", false, "79229fb4-7d51-43c1-bc5e-4e7450742612", false, "defaultAdmin@yahoo.com" },
                    { "u1ua87c6-b718-4f48-90a2-458e0a2443e6", 0, null, "6ff19fc2-4ffc-47b3-914d-50c31ee72741", "defaultUser@yahoo.com", false, null, null, true, null, "DEFAULTUSER@YAHOO.COM", "DEFAULTUSER@YAHOO.COM", "AQAAAAEAACcQAAAAEKf/HW3gdw4EG8HYJPC7C574EOQ/rTO6tSabZHFLikylvN2ysZs3BzjBmkzIna8heg==", "111-222-3333", false, "0dcb03e2-440b-4ad4-94d9-0b6ec6a933c7", false, "defaultUser@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "Households",
                columns: new[] { "HouseholdId", "HouseholdIcon", "HouseholdName" },
                values: new object[] { 1, "", "DefaultHousehold" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "", "Kitchen" },
                    { 2, "", "Bathroom" },
                    { 3, "", "Master Bedroom" },
                    { 4, "", "Living Room" },
                    { 5, "", "Bedroom" },
                    { 6, "", "Guest Bedroom" },
                    { 7, "", "Master Bathroom" },
                    { 8, "", "Dining Room" },
                    { 9, "", "Yard" }
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
                columns: new[] { "MemberId", "HouseholdId", "MemberIcon", "MemberType", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "", "Admin", null, "defaultAdmin@yahoo.com" },
                    { 2, 1, "", "Member", null, "defaultUser@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "MissionId", "DueDate", "MemberId", "MissionName", "Point", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 23, 13, 14, 59, 575, DateTimeKind.Local).AddTicks(7031), 2, "Wash dishes", 2, 1 },
                    { 2, new DateTime(2023, 1, 23, 13, 14, 59, 575, DateTimeKind.Local).AddTicks(7076), 1, "Make bed", 1, 5 },
                    { 3, new DateTime(2023, 1, 23, 13, 14, 59, 575, DateTimeKind.Local).AddTicks(7084), 2, "Make bed", 1, 3 },
                    { 4, new DateTime(2023, 1, 23, 13, 14, 59, 575, DateTimeKind.Local).AddTicks(7091), 1, "Mow lawn", 5, 9 },
                    { 5, new DateTime(2023, 1, 23, 13, 14, 59, 575, DateTimeKind.Local).AddTicks(7098), 1, "Make dinner", 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Members_HouseholdId",
                table: "Members",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MemberId",
                table: "Missions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_RoomId",
                table: "Missions",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Households");
        }
    }
}
