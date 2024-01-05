using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PO_project.Migrations
{
    /// <inheritdoc />
    public partial class ptmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 5,
                columns: new[] { "Abbreviation", "CzasTrwaniaId", "Name", "StopienId" },
                values: new object[] { "CBE", 4, "Cyberbezpieczeństwo", 1 });

            migrationBuilder.InsertData(
                table: "Kierunki",
                columns: new[] { "KierunekId", "Abbreviation", "CzasTrwaniaId", "Description", "JezykId", "Name", "StopienId", "TrybId" },
                values: new object[,]
                {
                    { 6, "ENG", 4, "", 1, "Energetyka", 2, 2 },
                    { 7, "MAT", 4, "", 1, "Matematyka", 2, 2 },
                    { 8, "OPT", 4, "", 1, "Optyka", 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 5,
                columns: new[] { "Abbreviation", "CzasTrwaniaId", "Name", "StopienId" },
                values: new object[] { "BUD-2N", 5, "Budownictwo", 2 });
        }
    }
}
