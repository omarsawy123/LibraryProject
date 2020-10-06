using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Api.Migrations
{
    public partial class Location_photopath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "id",
                keyValue: 1,
                column: "PhotoPath",
                value: "images/lib1.jpg");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "id",
                keyValue: 2,
                column: "PhotoPath",
                value: "images/lib2.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Locations");
        }
    }
}
