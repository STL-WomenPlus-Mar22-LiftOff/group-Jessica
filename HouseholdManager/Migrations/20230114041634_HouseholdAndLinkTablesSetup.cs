using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class HouseholdAndLinkTablesSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Rooms_RoomId",
                table: "Missions");

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Missions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Households",
                columns: table => new
                {
                    HouseholdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Households", x => x.HouseholdId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_HouseholdId",
                table: "User",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HouseholdId",
                table: "Rooms",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_HouseholdId",
                table: "Missions",
                column: "HouseholdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Households_HouseholdId",
                table: "Missions",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "HouseholdId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Rooms_RoomId",
                table: "Missions",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Households_HouseholdId",
                table: "Rooms",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "HouseholdId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Households_HouseholdId",
                table: "User",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "HouseholdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Households_HouseholdId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Rooms_RoomId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Households_HouseholdId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Households_HouseholdId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Households");

            migrationBuilder.DropIndex(
                name: "IX_User_HouseholdId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HouseholdId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Missions_HouseholdId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Missions");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Rooms_RoomId",
                table: "Missions",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
