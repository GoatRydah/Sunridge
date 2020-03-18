using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class AllTheRemainingTablesForModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassifiedImage_ClassifiedListing_ClassifiedListingId",
                table: "ClassifiedImage");

            migrationBuilder.DropTable(
                name: "ClassifiedListing");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "KeyHistory");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "OwnerLot");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "ClassifiedCategory");

            migrationBuilder.DropTable(
                name: "Key");

            migrationBuilder.DropTable(
                name: "CommonAreaAsset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType");

            migrationBuilder.RenameTable(
                name: "TransactionType",
                newName: "DbItem");

            migrationBuilder.AddColumn<int>(
                name: "AdminPhotoViewModelsId",
                table: "Owner",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassifiedListingViewModelId",
                table: "Owner",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardViewModelId",
                table: "Lot",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "FormResponse",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassifiedListingViewModelId",
                table: "ClassifiedImage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactPhone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiveEmails",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DbItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ClassifiedCategoryId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassifiedListingViewModelId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassifiedListing_ClassifiedCategoryId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassifiedListingId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassifiedListing_Description",
                table: "DbItem",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "DbItem",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ListingDate",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommonAreaAssetId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommonAreaAsset_Description",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PurchasePrice",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DbItemId",
                table: "DbItem",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "DbItem",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "File_Description",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileURL",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormResponseId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LotHistoryId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeyId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "DbItem",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyHistory_ApplicationUserId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardViewModelId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIssued",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReturned",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeyHistoryId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeyHistory_KeyId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LotId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeyHistory_OwnerId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PaidAmount",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyHistory_Status",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Maintenance_CommonAreaAssetId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maintenance_Description",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerLot_LotId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerLot_OwnerId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId1",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerLotId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transaction_ApplicationUserId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePaid",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transaction_Description",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Transaction_LotId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Transaction_OwnerId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transaction_Status",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType_Description",
                table: "DbItem",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbItem",
                table: "DbItem",
                column: "DbItemId");

            migrationBuilder.CreateTable(
                name: "AdminPhotoViewModels",
                columns: table => new
                {
                    AdminPhotoViewModelsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedListingViewModel",
                columns: table => new
                {
                    ClassifiedListingViewModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassifiedListingDbItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedListingViewModel", x => x.ClassifiedListingViewModelId);
                    table.ForeignKey(
                        name: "FK_ClassifiedListingViewModel_DbItem_ClassifiedListingDbItemId",
                        column: x => x.ClassifiedListingDbItemId,
                        principalTable: "DbItem",
                        principalColumn: "DbItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DashboardViewModel",
                columns: table => new
                {
                    DashboardViewModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardViewModel", x => x.DashboardViewModelId);
                    table.ForeignKey(
                        name: "FK_DashboardViewModel_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErrorViewModel",
                columns: table => new
                {
                    ErrorViewModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorViewModel", x => x.ErrorViewModelId);
                });

            migrationBuilder.CreateTable(
                name: "LostAndFoundItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostAndFoundItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LostAndFoundItem_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owner_AdminPhotoViewModelsId",
                table: "Owner",
                column: "AdminPhotoViewModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_ClassifiedListingViewModelId",
                table: "Owner",
                column: "ClassifiedListingViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_DashboardViewModelId",
                table: "Lot",
                column: "DashboardViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_ApplicationUserId",
                table: "FormResponse",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedImage_ClassifiedListingViewModelId",
                table: "ClassifiedImage",
                column: "ClassifiedListingViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OwnerId1",
                table: "AspNetUsers",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_ClassifiedListingViewModelId",
                table: "DbItem",
                column: "ClassifiedListingViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_ApplicationUserId",
                table: "DbItem",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_ClassifiedListing_ClassifiedCategoryId",
                table: "DbItem",
                column: "ClassifiedListing_ClassifiedCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_OwnerId",
                table: "DbItem",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_FormResponseId",
                table: "DbItem",
                column: "FormResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_LotHistoryId",
                table: "DbItem",
                column: "LotHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_KeyHistory_ApplicationUserId",
                table: "DbItem",
                column: "KeyHistory_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_DashboardViewModelId",
                table: "DbItem",
                column: "DashboardViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_KeyHistory_KeyId",
                table: "DbItem",
                column: "KeyHistory_KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_LotId",
                table: "DbItem",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_KeyHistory_OwnerId",
                table: "DbItem",
                column: "KeyHistory_OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_Maintenance_CommonAreaAssetId",
                table: "DbItem",
                column: "Maintenance_CommonAreaAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_OwnerLot_LotId",
                table: "DbItem",
                column: "OwnerLot_LotId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_OwnerLot_OwnerId",
                table: "DbItem",
                column: "OwnerLot_OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_OwnerId1",
                table: "DbItem",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_Transaction_ApplicationUserId",
                table: "DbItem",
                column: "Transaction_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_Transaction_LotId",
                table: "DbItem",
                column: "Transaction_LotId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_Transaction_OwnerId",
                table: "DbItem",
                column: "Transaction_OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItem_TransactionTypeId",
                table: "DbItem",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminPhotoViewModels_PhotoId",
                table: "AdminPhotoViewModels",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListingViewModel_ClassifiedListingDbItemId",
                table: "ClassifiedListingViewModel",
                column: "ClassifiedListingDbItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardViewModel_OwnerId",
                table: "DashboardViewModel",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LostAndFoundItem_ApplicationUserId",
                table: "LostAndFoundItem",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Owner_OwnerId1",
                table: "AspNetUsers",
                column: "OwnerId1",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifiedImage_DbItem_ClassifiedListingId",
                table: "ClassifiedImage",
                column: "ClassifiedListingId",
                principalTable: "DbItem",
                principalColumn: "DbItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifiedImage_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "ClassifiedImage",
                column: "ClassifiedListingViewModelId",
                principalTable: "ClassifiedListingViewModel",
                principalColumn: "ClassifiedListingViewModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "DbItem",
                column: "ClassifiedListingViewModelId",
                principalTable: "ClassifiedListingViewModel",
                principalColumn: "ClassifiedListingViewModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_AspNetUsers_ApplicationUserId",
                table: "DbItem",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_DbItem_ClassifiedListing_ClassifiedCategoryId",
                table: "DbItem",
                column: "ClassifiedListing_ClassifiedCategoryId",
                principalTable: "DbItem",
                principalColumn: "DbItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Owner_OwnerId",
                table: "DbItem",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_FormResponse_FormResponseId",
                table: "DbItem",
                column: "FormResponseId",
                principalTable: "FormResponse",
                principalColumn: "FormResponseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_LotHistory_LotHistoryId",
                table: "DbItem",
                column: "LotHistoryId",
                principalTable: "LotHistory",
                principalColumn: "LotHistoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_AspNetUsers_KeyHistory_ApplicationUserId",
                table: "DbItem",
                column: "KeyHistory_ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_DashboardViewModel_DashboardViewModelId",
                table: "DbItem",
                column: "DashboardViewModelId",
                principalTable: "DashboardViewModel",
                principalColumn: "DashboardViewModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_DbItem_KeyHistory_KeyId",
                table: "DbItem",
                column: "KeyHistory_KeyId",
                principalTable: "DbItem",
                principalColumn: "DbItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Lot_LotId",
                table: "DbItem",
                column: "LotId",
                principalTable: "Lot",
                principalColumn: "LotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Owner_KeyHistory_OwnerId",
                table: "DbItem",
                column: "KeyHistory_OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_DbItem_Maintenance_CommonAreaAssetId",
                table: "DbItem",
                column: "Maintenance_CommonAreaAssetId",
                principalTable: "DbItem",
                principalColumn: "DbItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Lot_OwnerLot_LotId",
                table: "DbItem",
                column: "OwnerLot_LotId",
                principalTable: "Lot",
                principalColumn: "LotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_AspNetUsers_OwnerLot_OwnerId",
                table: "DbItem",
                column: "OwnerLot_OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
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
                name: "FK_DbItem_Lot_Transaction_LotId",
                table: "DbItem",
                column: "Transaction_LotId",
                principalTable: "Lot",
                principalColumn: "LotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_Owner_Transaction_OwnerId",
                table: "DbItem",
                column: "Transaction_OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbItem_DbItem_TransactionTypeId",
                table: "DbItem",
                column: "TransactionTypeId",
                principalTable: "DbItem",
                principalColumn: "DbItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormResponse_AspNetUsers_ApplicationUserId",
                table: "FormResponse",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lot_DashboardViewModel_DashboardViewModelId",
                table: "Lot",
                column: "DashboardViewModelId",
                principalTable: "DashboardViewModel",
                principalColumn: "DashboardViewModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_AdminPhotoViewModels_AdminPhotoViewModelsId",
                table: "Owner",
                column: "AdminPhotoViewModelsId",
                principalTable: "AdminPhotoViewModels",
                principalColumn: "AdminPhotoViewModelsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "Owner",
                column: "ClassifiedListingViewModelId",
                principalTable: "ClassifiedListingViewModel",
                principalColumn: "ClassifiedListingViewModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Owner_OwnerId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassifiedImage_DbItem_ClassifiedListingId",
                table: "ClassifiedImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassifiedImage_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "ClassifiedImage");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_AspNetUsers_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_DbItem_ClassifiedListing_ClassifiedCategoryId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Owner_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_FormResponse_FormResponseId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_LotHistory_LotHistoryId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_AspNetUsers_KeyHistory_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_DashboardViewModel_DashboardViewModelId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_DbItem_KeyHistory_KeyId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Lot_LotId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Owner_KeyHistory_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_DbItem_Maintenance_CommonAreaAssetId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Lot_OwnerLot_LotId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_AspNetUsers_OwnerLot_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Owner_OwnerId1",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_AspNetUsers_Transaction_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Lot_Transaction_LotId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_Owner_Transaction_OwnerId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DbItem_DbItem_TransactionTypeId",
                table: "DbItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FormResponse_AspNetUsers_ApplicationUserId",
                table: "FormResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_Lot_DashboardViewModel_DashboardViewModelId",
                table: "Lot");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_AdminPhotoViewModels_AdminPhotoViewModelsId",
                table: "Owner");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_ClassifiedListingViewModel_ClassifiedListingViewModelId",
                table: "Owner");

            migrationBuilder.DropTable(
                name: "AdminPhotoViewModels");

            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "ClassifiedListingViewModel");

            migrationBuilder.DropTable(
                name: "DashboardViewModel");

            migrationBuilder.DropTable(
                name: "ErrorViewModel");

            migrationBuilder.DropTable(
                name: "LostAndFoundItem");

            migrationBuilder.DropIndex(
                name: "IX_Owner_AdminPhotoViewModelsId",
                table: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Owner_ClassifiedListingViewModelId",
                table: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Lot_DashboardViewModelId",
                table: "Lot");

            migrationBuilder.DropIndex(
                name: "IX_FormResponse_ApplicationUserId",
                table: "FormResponse");

            migrationBuilder.DropIndex(
                name: "IX_ClassifiedImage_ClassifiedListingViewModelId",
                table: "ClassifiedImage");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OwnerId1",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbItem",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_ClassifiedListingViewModelId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_ClassifiedListing_ClassifiedCategoryId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_OwnerId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_FormResponseId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_LotHistoryId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_KeyHistory_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_DashboardViewModelId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_KeyHistory_KeyId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_LotId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_KeyHistory_OwnerId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_Maintenance_CommonAreaAssetId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_OwnerLot_LotId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_OwnerLot_OwnerId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_OwnerId1",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_Transaction_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_Transaction_LotId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_Transaction_OwnerId",
                table: "DbItem");

            migrationBuilder.DropIndex(
                name: "IX_DbItem_TransactionTypeId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "AdminPhotoViewModelsId",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "ClassifiedListingViewModelId",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "DashboardViewModelId",
                table: "Lot");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "FormResponse");

            migrationBuilder.DropColumn(
                name: "ClassifiedListingViewModelId",
                table: "ClassifiedImage");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmergencyContactPhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReceiveEmails",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClassifiedCategoryId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "ClassifiedListingViewModelId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "ClassifiedListing_ClassifiedCategoryId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "ClassifiedListingId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "ClassifiedListing_Description",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "ListingDate",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "CommonAreaAssetId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "CommonAreaAsset_Description",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DbItemId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "File_Description",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "FileURL",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "FormResponseId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "LotHistoryId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "KeyHistory_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DashboardViewModelId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DateIssued",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DateReturned",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "KeyHistoryId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "KeyHistory_KeyId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "LotId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "KeyHistory_OwnerId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "KeyHistory_Status",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Maintenance_CommonAreaAssetId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Maintenance_Description",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "MaintenanceId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "OwnerLot_LotId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "OwnerLot_OwnerId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "OwnerLotId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Transaction_ApplicationUserId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "DatePaid",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Transaction_Description",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Transaction_LotId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Transaction_OwnerId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "Transaction_Status",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "DbItem");

            migrationBuilder.DropColumn(
                name: "TransactionType_Description",
                table: "DbItem");

            migrationBuilder.RenameTable(
                name: "DbItem",
                newName: "TransactionType");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TransactionType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClassifiedCategory",
                columns: table => new
                {
                    ClassifiedCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedCategory", x => x.ClassifiedCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CommonAreaAsset",
                columns: table => new
                {
                    CommonAreaAssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasePrice = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonAreaAsset", x => x.CommonAreaAssetId);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormResponseId = table.Column<int>(type: "int", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LotHistoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_File_FormResponse_FormResponseId",
                        column: x => x.FormResponseId,
                        principalTable: "FormResponse",
                        principalColumn: "FormResponseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_File_LotHistory_LotHistoryId",
                        column: x => x.LotHistoryId,
                        principalTable: "LotHistory",
                        principalColumn: "LotHistoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Key",
                columns: table => new
                {
                    KeyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "OwnerLot",
                columns: table => new
                {
                    OwnerLotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerLot", x => x.OwnerLotId);
                    table.ForeignKey(
                        name: "FK_OwnerLot_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerLot_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePaid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedListing",
                columns: table => new
                {
                    ClassifiedListingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassifiedCategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedListing", x => x.ClassifiedListingId);
                    table.ForeignKey(
                        name: "FK_ClassifiedListing_ClassifiedCategory_ClassifiedCategoryId",
                        column: x => x.ClassifiedCategoryId,
                        principalTable: "ClassifiedCategory",
                        principalColumn: "ClassifiedCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassifiedListing_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonAreaAssetId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_Maintenance_CommonAreaAsset_CommonAreaAssetId",
                        column: x => x.CommonAreaAssetId,
                        principalTable: "CommonAreaAsset",
                        principalColumn: "CommonAreaAssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeyHistory",
                columns: table => new
                {
                    KeyHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReturned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    KeyId = table.Column<int>(type: "int", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    PaidAmount = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyHistory", x => x.KeyHistoryId);
                    table.ForeignKey(
                        name: "FK_KeyHistory_Key_KeyId",
                        column: x => x.KeyId,
                        principalTable: "Key",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyHistory_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyHistory_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListing_ClassifiedCategoryId",
                table: "ClassifiedListing",
                column: "ClassifiedCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListing_OwnerId",
                table: "ClassifiedListing",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_File_FormResponseId",
                table: "File",
                column: "FormResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_File_LotHistoryId",
                table: "File",
                column: "LotHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyHistory_KeyId",
                table: "KeyHistory",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyHistory_LotId",
                table: "KeyHistory",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyHistory_OwnerId",
                table: "KeyHistory",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CommonAreaAssetId",
                table: "Maintenance",
                column: "CommonAreaAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLot_LotId",
                table: "OwnerLot",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLot_OwnerId",
                table: "OwnerLot",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_LotId",
                table: "Transaction",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_OwnerId",
                table: "Transaction",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifiedImage_ClassifiedListing_ClassifiedListingId",
                table: "ClassifiedImage",
                column: "ClassifiedListingId",
                principalTable: "ClassifiedListing",
                principalColumn: "ClassifiedListingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
