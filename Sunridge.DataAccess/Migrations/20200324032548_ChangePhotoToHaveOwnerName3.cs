using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class ChangePhotoToHaveOwnerName3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Photo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
