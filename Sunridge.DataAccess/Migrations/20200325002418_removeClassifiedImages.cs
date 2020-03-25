using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class removeClassifiedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassifiedImage");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "ClassifiedListing",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "ClassifiedListing");

            migrationBuilder.CreateTable(
                name: "ClassifiedImage",
                columns: table => new
                {
                    ClassifiedImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassifiedListingId = table.Column<int>(type: "int", nullable: false),
                    ClassifiedListingViewModelId = table.Column<int>(type: "int", nullable: true),
                    ImageExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMainImage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedImage", x => x.ClassifiedImageId);
                    table.ForeignKey(
                        name: "FK_ClassifiedImage_ClassifiedListing_ClassifiedListingId",
                        column: x => x.ClassifiedListingId,
                        principalTable: "ClassifiedListing",
                        principalColumn: "ClassifiedListingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassifiedImage_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                        column: x => x.ClassifiedListingViewModelId,
                        principalTable: "ClassifiedListingViewModel",
                        principalColumn: "ClassifiedListingViewModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedImage_ClassifiedListingId",
                table: "ClassifiedImage",
                column: "ClassifiedListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedImage_ClassifiedListingViewModelId",
                table: "ClassifiedImage",
                column: "ClassifiedListingViewModelId");
        }
    }
}
