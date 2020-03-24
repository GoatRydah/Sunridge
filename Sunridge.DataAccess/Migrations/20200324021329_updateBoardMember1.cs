using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class updateBoardMember1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMember_Lot_LotId",
                table: "BoardMember");

            migrationBuilder.DropIndex(
                name: "IX_BoardMember_LotId",
                table: "BoardMember");

            migrationBuilder.DropColumn(
                name: "LotId",
                table: "BoardMember");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LotId",
                table: "BoardMember",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BoardMember_LotId",
                table: "BoardMember",
                column: "LotId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMember_Lot_LotId",
                table: "BoardMember",
                column: "LotId",
                principalTable: "Lot",
                principalColumn: "LotId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
