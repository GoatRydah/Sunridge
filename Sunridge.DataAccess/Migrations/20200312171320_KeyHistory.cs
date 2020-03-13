using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class KeyHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedCategory",
                columns: table => new
                {
                    ClassifiedCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedCategory", x => x.ClassifiedCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    LotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(nullable: false),
                    LotNumber = table.Column<string>(nullable: false),
                    TaxId = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.LotId);
                    table.ForeignKey(
                        name: "FK_Lot_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Occupation = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmergencyContactName = table.Column<string>(nullable: true),
                    EmergencyContactPhone = table.Column<string>(nullable: true),
                    ReceiveEmails = table.Column<bool>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "LotHistory",
                columns: table => new
                {
                    LotHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotId = table.Column<int>(nullable: false),
                    PrivacyLevel = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotHistory", x => x.LotHistoryId);
                    table.ForeignKey(
                        name: "FK_LotHistory_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotInventory",
                columns: table => new
                {
                    LotInventoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotInventory", x => x.LotInventoryId);
                    table.ForeignKey(
                        name: "FK_LotInventory_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotInventory_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedListing",
                columns: table => new
                {
                    ClassifiedListingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    ClassifiedCategoryId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(maxLength: 75, nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    ListingDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
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
                name: "FormResponse",
                columns: table => new
                {
                    FormResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(nullable: false),
                    FormType = table.Column<string>(maxLength: 3, nullable: false),
                    LotId = table.Column<int>(nullable: true),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Suggestion = table.Column<string>(nullable: true),
                    PrivacyLevel = table.Column<string>(nullable: true),
                    Resolved = table.Column<bool>(nullable: false),
                    ResolveDate = table.Column<DateTime>(nullable: true),
                    ResolveUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormResponse", x => x.FormResponseId);
                    table.ForeignKey(
                        name: "FK_FormResponse_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormResponse_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeyHistory",
                columns: table => new
                {
                    KeyHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    KeyId = table.Column<int>(nullable: false),
                    LotId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    DateIssued = table.Column<DateTime>(nullable: false),
                    DateReturned = table.Column<DateTime>(nullable: true),
                    PaidAmount = table.Column<float>(nullable: false),
                    OwnerId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "OwnerLot",
                columns: table => new
                {
                    OwnerLotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    LotId = table.Column<int>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
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
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LotId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
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
                name: "ClassifiedImage",
                columns: table => new
                {
                    ClassifiedImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassifiedListingId = table.Column<int>(nullable: false),
                    IsMainImage = table.Column<bool>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    ImageExtension = table.Column<string>(nullable: true)
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
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotHistoryId = table.Column<int>(nullable: true),
                    FormResponseId = table.Column<int>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Private = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_FormResponse_FormResponseId",
                        column: x => x.FormResponseId,
                        principalTable: "FormResponse",
                        principalColumn: "FormResponseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_LotHistory_LotHistoryId",
                        column: x => x.LotHistoryId,
                        principalTable: "LotHistory",
                        principalColumn: "LotHistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsArchive = table.Column<bool>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LotHistoryId = table.Column<int>(nullable: false),
                    FileURL = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FormResponseId = table.Column<int>(nullable: true)
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
                name: "InKindWorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Hours = table.Column<double>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    FormResponseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InKindWorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InKindWorkHours_FormResponse_FormResponseId",
                        column: x => x.FormResponseId,
                        principalTable: "FormResponse",
                        principalColumn: "FormResponseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedImage_ClassifiedListingId",
                table: "ClassifiedImage",
                column: "ClassifiedListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListing_ClassifiedCategoryId",
                table: "ClassifiedListing",
                column: "ClassifiedCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedListing_OwnerId",
                table: "ClassifiedListing",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_FormResponseId",
                table: "Comment",
                column: "FormResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_LotHistoryId",
                table: "Comment",
                column: "LotHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OwnerId",
                table: "Comment",
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
                name: "IX_FormResponse_LotId",
                table: "FormResponse",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_OwnerId",
                table: "FormResponse",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_InKindWorkHours_FormResponseId",
                table: "InKindWorkHours",
                column: "FormResponseId");

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
                name: "IX_Lot_AddressId",
                table: "Lot",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_LotHistory_LotId",
                table: "LotHistory",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_LotInventory_InventoryId",
                table: "LotInventory",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LotInventory_LotId",
                table: "LotInventory",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_AddressId",
                table: "Owner",
                column: "AddressId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassifiedImage");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "InKindWorkHours");

            migrationBuilder.DropTable(
                name: "KeyHistory");

            migrationBuilder.DropTable(
                name: "LotInventory");

            migrationBuilder.DropTable(
                name: "OwnerLot");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "ClassifiedListing");

            migrationBuilder.DropTable(
                name: "LotHistory");

            migrationBuilder.DropTable(
                name: "FormResponse");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "ClassifiedCategory");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
