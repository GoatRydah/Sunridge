using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class removedNotMappedAU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressValue",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApartmentValue",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityValue",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateValue",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipValue",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressValue",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApartmentValue",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityValue",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StateValue",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipValue",
                table: "AspNetUsers");
        }
    }
}
