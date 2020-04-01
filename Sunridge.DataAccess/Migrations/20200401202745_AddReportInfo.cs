using Microsoft.EntityFrameworkCore.Migrations;

namespace Sunridge.DataAccess.Migrations
{
    public partial class AddReportInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentHoursItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(nullable: true),
                    Hours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentHoursItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborHoursItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborActivity = table.Column<string>(nullable: true),
                    Hours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborHoursItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ListingDate = table.Column<string>(nullable: true),
                    ResolvedDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Suggestion = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Resolved = table.Column<bool>(nullable: false),
                    LaborHoursId = table.Column<int>(nullable: false),
                    EquipmentHoursId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentHoursItem");

            migrationBuilder.DropTable(
                name: "LaborHoursItem");

            migrationBuilder.DropTable(
                name: "ReportItem");
        }
    }
}
