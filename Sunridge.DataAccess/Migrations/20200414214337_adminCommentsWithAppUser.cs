using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class adminCommentsWithAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AdminComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminComments_ApplicationUserId",
                table: "AdminComments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminComments_AspNetUsers_ApplicationUserId",
                table: "AdminComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminComments_AspNetUsers_ApplicationUserId",
                table: "AdminComments");

            migrationBuilder.DropIndex(
                name: "IX_AdminComments_ApplicationUserId",
                table: "AdminComments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AdminComments");
        }
    }
}
