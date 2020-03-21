using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class changedNameInPhotViewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AdminPhotoViewModels_AdminPhotoViewModelsId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AdminPhotoViewModels");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdminPhotoViewModelsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminPhotoViewModelsId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminPhotoViewModelsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminPhotoViewModels",
                columns: table => new
                {
                    AdminPhotoViewModelsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPhotoViewModels", x => x.AdminPhotoViewModelsId);
                    table.ForeignKey(
                        name: "FK_AdminPhotoViewModels_Photo_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photo",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminPhotoViewModelsId",
                table: "AspNetUsers",
                column: "AdminPhotoViewModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminPhotoViewModels_PhotoId",
                table: "AdminPhotoViewModels",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AdminPhotoViewModels_AdminPhotoViewModelsId",
                table: "AspNetUsers",
                column: "AdminPhotoViewModelsId",
                principalTable: "AdminPhotoViewModels",
                principalColumn: "AdminPhotoViewModelsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
