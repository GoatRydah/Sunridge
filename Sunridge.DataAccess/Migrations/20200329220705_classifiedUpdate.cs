using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class classifiedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassifiedListing_ClassifiedCategory_ClassifiedCategoryId",
                table: "ClassifiedListing");

            migrationBuilder.DropIndex(
                name: "IX_ClassifiedListing_ClassifiedCategoryId",
                table: "ClassifiedListing");

            migrationBuilder.DropColumn(
                name: "ClassifiedCategoryId",
                table: "ClassifiedListing");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "ClassifiedListing");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ClassifiedListing");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ClassifiedListing");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ClassifiedCategory");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "ClassifiedCategory");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ClassifiedCategory");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ClassifiedCategory");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ClassifiedListing",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "ClassifiedCategory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ClassifiedListing");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "ClassifiedCategory");

            migrationBuilder.AddColumn<int>(
                name: "ClassifiedCategoryId",
                table: "ClassifiedListing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "ClassifiedListing",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ClassifiedListing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ClassifiedListing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ClassifiedCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "ClassifiedCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ClassifiedCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ClassifiedCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListing_ClassifiedCategoryId",
                table: "ClassifiedListing",
                column: "ClassifiedCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifiedListing_ClassifiedCategory_ClassifiedCategoryId",
                table: "ClassifiedListing",
                column: "ClassifiedCategoryId",
                principalTable: "ClassifiedCategory",
                principalColumn: "ClassifiedCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
