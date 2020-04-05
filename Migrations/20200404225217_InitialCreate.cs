using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "G",
                columns: table => new
                {
                    key = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gridId = table.Column<int>(nullable: true),
                    cId = table.Column<int>(nullable: false),
                    action = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_G", x => x.key);
                    table.ForeignKey(
                        name: "FK_G_LocationGroup_gridId",
                        column: x => x.gridId,
                        principalTable: "LocationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    XLoc = table.Column<int>(nullable: false),
                    YLoc = table.Column<int>(nullable: false),
                    myD = table.Column<int>(nullable: false),
                    LocationGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_LocationGroup_LocationGroupId",
                        column: x => x.LocationGroupId,
                        principalTable: "LocationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_G_gridId",
                table: "G",
                column: "gridId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationGroupId",
                table: "Location",
                column: "LocationGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "G");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "LocationGroup");
        }
    }
}
