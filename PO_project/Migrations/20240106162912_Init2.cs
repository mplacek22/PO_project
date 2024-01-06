using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO_project.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specjalizacje",
                columns: new[] { "SpecjalizacjaId", "Description", "KierunekId", "Name" },
                values: new object[] { 2, "Opis budownictwa wodnego", 4, "Budownictwo Wodne" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specjalizacje",
                keyColumn: "SpecjalizacjaId",
                keyValue: 2);
        }
    }
}
