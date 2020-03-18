using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class AllTheRemainingTablesForModels3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Owner_OwnerId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Owner_OwnerId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_DashboardViewModel_Owner_OwnerId",
                table: "DashboardViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Owner_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_AspNetUsers_KeyHistory_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Owner_KeyHistory_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Owner_OwnerId1",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_AspNetUsers_Transaction_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Owner_Transaction_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FormResponse_AspNetUsers_ApplicationUserId",
                table: "FormResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_FormResponse_Owner_OwnerId",
                table: "FormResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Owner_OwnerId",
                table: "Photo");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_FormResponse_ApplicationUserId",
                table: "FormResponse");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_KeyHistory_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_KeyHistory_OwnerId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_OwnerId1",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_Transaction_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OwnerId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "FormResponse");

            migrationBuilder.DropColumn(
                name: "KeyHistory_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "KeyHistory_OwnerId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Transaction_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Photo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "FormResponse",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Transaction_OwnerId",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "DashboardViewModel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AdminPhotoViewModelsId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassifiedListingViewModelId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminPhotoViewModelsId",
                table: "AspNetUsers",
                column: "AdminPhotoViewModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClassifiedListingViewModelId",
                table: "AspNetUsers",
                column: "ClassifiedListingViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AdminPhotoViewModels_AdminPhotoViewModelsId",
                table: "AspNetUsers",
                column: "AdminPhotoViewModelsId",
                principalTable: "AdminPhotoViewModels",
                principalColumn: "AdminPhotoViewModelsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "AspNetUsers",
                column: "ClassifiedListingViewModelId",
                principalTable: "ClassifiedListingViewModel",
                principalColumn: "ClassifiedListingViewModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_OwnerId",
                table: "Comment",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DashboardViewModel_AspNetUsers_OwnerId",
                table: "DashboardViewModel",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_AspNetUsers_OwnerId",
                table: "DbItem",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_AspNetUsers_Transaction_OwnerId",
                table: "DbItem",
                column: "Transaction_OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormResponse_AspNetUsers_OwnerId",
                table: "FormResponse",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_AspNetUsers_OwnerId",
                table: "Photo",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AdminPhotoViewModels_AdminPhotoViewModelsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_OwnerId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_DashboardViewModel_AspNetUsers_OwnerId",
                table: "DashboardViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_AspNetUsers_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_AspNetUsers_Transaction_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FormResponse_AspNetUsers_OwnerId",
                table: "FormResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_AspNetUsers_OwnerId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdminPhotoViewModelsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClassifiedListingViewModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminPhotoViewModelsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClassifiedListingViewModelId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Photo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "FormResponse",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "FormResponse",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Transaction_OwnerId",
                table: "DbItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "DbItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyHistory_ApplicationUserId",
                table: "DbItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeyHistory_OwnerId",
                table: "DbItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId1",
                table: "DbItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transaction_ApplicationUserId",
                table: "DbItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "DashboardViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    AdminPhotoViewModelsId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClassifiedListingViewModelId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiveEmails = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owner_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Owner_AdminPhotoViewModels_AdminPhotoViewModelsId",
                        column: x => x.AdminPhotoViewModelsId,
                        principalTable: "AdminPhotoViewModels",
                        principalColumn: "AdminPhotoViewModelsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Owner_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                        column: x => x.ClassifiedListingViewModelId,
                        principalTable: "ClassifiedListingViewModel",
                        principalColumn: "ClassifiedListingViewModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_ApplicationUserId",
                table: "FormResponse",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_KeyHistory_ApplicationUserId",
                table: "DbItem",
                column: "KeyHistory_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_KeyHistory_OwnerId",
                table: "DbItem",
                column: "KeyHistory_OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_OwnerId1",
                table: "DbItem",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_Transaction_ApplicationUserId",
                table: "DbItem",
                column: "Transaction_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OwnerId1",
                table: "AspNetUsers",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_AddressId",
                table: "Owner",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_AdminPhotoViewModelsId",
                table: "Owner",
                column: "AdminPhotoViewModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_ClassifiedListingViewModelId",
                table: "Owner",
                column: "ClassifiedListingViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Owner_OwnerId1",
                table: "AspNetUsers",
                column: "OwnerId1",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Owner_OwnerId",
                table: "Comment",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DashboardViewModel_Owner_OwnerId",
                table: "DashboardViewModel",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Owner_OwnerId",
                table: "DbItem",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_AspNetUsers_KeyHistory_ApplicationUserId",
                table: "DbItem",
                column: "KeyHistory_ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Owner_KeyHistory_OwnerId",
                table: "DbItem",
                column: "KeyHistory_OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Owner_OwnerId1",
                table: "DbItem",
                column: "OwnerId1",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_AspNetUsers_Transaction_ApplicationUserId",
                table: "DbItem",
                column: "Transaction_ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Owner_Transaction_OwnerId",
                table: "DbItem",
                column: "Transaction_OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormResponse_AspNetUsers_ApplicationUserId",
                table: "FormResponse",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormResponse_Owner_OwnerId",
                table: "FormResponse",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Owner_OwnerId",
                table: "Photo",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
