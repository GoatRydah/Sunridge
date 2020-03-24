using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class ChangePhotoToHaveOwnerName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_AspNetUsers_OwnerId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_OwnerId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Photo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Photo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_OwnerId",
                table: "Photo",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_AspNetUsers_OwnerId",
                table: "Photo",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
