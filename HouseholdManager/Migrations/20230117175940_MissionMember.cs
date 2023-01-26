using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class MissionMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MemberId",
                table: "Missions",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Members_MemberId",
                table: "Missions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Members_MemberId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_MemberId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Missions");
        }
    }
}
