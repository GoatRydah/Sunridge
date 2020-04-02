using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class updateFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_LotHistory_LotHistoryId",
                table: "File");

            migrationBuilder.AlterColumn<int>(
                name: "LotHistoryId",
                table: "File",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_File_LotHistory_LotHistoryId",
                table: "File",
                column: "LotHistoryId",
                principalTable: "LotHistory",
                principalColumn: "LotHistoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_LotHistory_LotHistoryId",
                table: "File");

            migrationBuilder.AlterColumn<int>(
                name: "LotHistoryId",
                table: "File",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_File_LotHistory_LotHistoryId",
                table: "File",
                column: "LotHistoryId",
                principalTable: "LotHistory",
                principalColumn: "LotHistoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
