using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class AllTheRemainingTablesForModels4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InKindWorkHours_FormResponse_FormResponseId",
                table: "InKindWorkHours");

            migrationBuilder.DropIndex(
                name: "IX_InKindWorkHours_FormResponseId",
                table: "InKindWorkHours");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "InKindWorkHours",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InKindWorkHours_OwnerId",
                table: "InKindWorkHours",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_InKindWorkHours_FormResponse_OwnerId",
                table: "InKindWorkHours",
                column: "OwnerId",
                principalTable: "FormResponse",
                principalColumn: "FormResponseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InKindWorkHours_FormResponse_OwnerId",
                table: "InKindWorkHours");

            migrationBuilder.DropIndex(
                name: "IX_InKindWorkHours_OwnerId",
                table: "InKindWorkHours");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "InKindWorkHours");

            migrationBuilder.CreateIndex(
                name: "IX_InKindWorkHours_FormResponseId",
                table: "InKindWorkHours",
                column: "FormResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_InKindWorkHours_FormResponse_FormResponseId",
                table: "InKindWorkHours",
                column: "FormResponseId",
                principalTable: "FormResponse",
                principalColumn: "FormResponseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
