using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class addUserNameReportLostAndFound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "ReportItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "LostAndFoundItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "ReportItem");

            migrationBuilder.DropColumn(
                name: "username",
                table: "LostAndFoundItem");
        }
    }
}
