using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class iconSupportAdditional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberIcon",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HouseholdIcon",
                table: "Households");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Members",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Households",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Households");

            migrationBuilder.AddColumn<string>(
                name: "MemberIcon",
                table: "Members",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseholdIcon",
                table: "Households",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
