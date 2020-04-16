using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class removeClassifieds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ClassifiedCategory");

            migrationBuilder.DropTable(
                name: "ClassifiedImage");

            migrationBuilder.DropTable(
                name: "ClassifiedService");

            migrationBuilder.DropTable(
                name: "ClassifiedListingViewModel");

            migrationBuilder.DropTable(
                name: "ClassifiedListing");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClassifiedListingViewModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClassifiedListingViewModelId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassifiedListingViewModelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassifiedListing",
                columns: table => new
                {
                    ClassifiedListingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ListingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedListing", x => x.ClassifiedListingId);
                    table.ForeignKey(
                        name: "FK_ClassifiedListing_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedImage",
                columns: table => new
                {
                    ClassifiedImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassifiedListingId = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedListingViewModel",
                columns: table => new
                {
                    ClassifiedListingViewModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassifiedListingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedListingViewModel", x => x.ClassifiedListingViewModelId);
                    table.ForeignKey(
                        name: "FK_ClassifiedListingViewModel_ClassifiedListing_ClassifiedListingId",
                        column: x => x.ClassifiedListingId,
                        principalTable: "ClassifiedListing",
                        principalColumn: "ClassifiedListingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedCategory",
                columns: table => new
                {
                    ClassifiedCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassifiedListingViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedCategory", x => x.ClassifiedCategoryId);
                    table.ForeignKey(
                        name: "FK_ClassifiedCategory_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                        column: x => x.ClassifiedListingViewModelId,
                        principalTable: "ClassifiedListingViewModel",
                        principalColumn: "ClassifiedListingViewModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClassifiedListingViewModelId",
                table: "AspNetUsers",
                column: "ClassifiedListingViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedCategory_ClassifiedListingViewModelId",
                table: "ClassifiedCategory",
                column: "ClassifiedListingViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedImage_ClassifiedListingId",
                table: "ClassifiedImage",
                column: "ClassifiedListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListing_OwnerId",
                table: "ClassifiedListing",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListingViewModel_ClassifiedListingId",
                table: "ClassifiedListingViewModel",
                column: "ClassifiedListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "AspNetUsers",
                column: "ClassifiedListingViewModelId",
                principalTable: "ClassifiedListingViewModel",
                principalColumn: "ClassifiedListingViewModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
