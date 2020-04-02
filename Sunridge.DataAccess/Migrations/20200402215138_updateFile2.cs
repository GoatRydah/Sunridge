using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class updateFile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LotId",
                table: "File",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_File_LotId",
                table: "File",
                column: "LotId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Lot_LotId",
                table: "File",
                column: "LotId",
                principalTable: "Lot",
                principalColumn: "LotId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Lot_LotId",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_LotId",
                table: "File");

            migrationBuilder.DropColumn(
                name: "LotId",
                table: "File");
        }
    }
}
