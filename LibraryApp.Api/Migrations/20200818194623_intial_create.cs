using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Api.Migrations
{
    public partial class intial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                    table.ForeignKey(
                        name: "FK_Books_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "id", "CityName", "LibraryName" },
                values: new object[] { 1, "Tanta", "TantaLibrary" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "id", "CityName", "LibraryName" },
                values: new object[] { 2, "Mansoura", "MansouraLibrary" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "Author", "Category", "Name", "PhotoPath", "Price", "locationId" },
                values: new object[,]
                {
                    { 1, "PFirstBook", 0, "FirstBook", "images/1.jpg", 100, 1 },
                    { 2, "PSecondBook", 0, "SecondBook", "images/2.jpg", 120, 1 },
                    { 3, "PThirdBook", 1, "ThirdBook", "images/3.jpg", 300, 2 },
                    { 4, "PFourthBook", 2, "FourthBook", "images/4.jpg", 210, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_locationId",
                table: "Books",
                column: "locationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
