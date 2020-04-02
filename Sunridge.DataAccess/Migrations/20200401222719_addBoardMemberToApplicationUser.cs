using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class addBoardMemberToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "BoardMember",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardMember_ApplicationUserId",
                table: "BoardMember",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMember_AspNetUsers_ApplicationUserId",
                table: "BoardMember",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMember_AspNetUsers_ApplicationUserId",
                table: "BoardMember");

            migrationBuilder.DropIndex(
                name: "IX_BoardMember_ApplicationUserId",
                table: "BoardMember");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "BoardMember",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
