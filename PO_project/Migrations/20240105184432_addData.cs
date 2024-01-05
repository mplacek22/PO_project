using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PO_project.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adresy",
                columns: new[] { "AdresId", "BuildingNumber", "City", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "4", "Wroclaw", "50-030", "Grabiszynska" },
                    { 2, "219", "Wroclaw", "51-518", "Piekna" },
                    { 3, "30", "Warszawa", "01-015", "Gorna" }
                });

            migrationBuilder.InsertData(
                table: "CzasyTrwania",
                columns: new[] { "CzasTrwaniaId", "Value" },
                values: new object[,]
                {
                    { 1, 1.5 },
                    { 2, 2.0 },
                    { 3, 2.5 },
                    { 4, 3.0 },
                    { 5, 3.5 },
                    { 6, 4.0 },
                    { 7, 4.5 },
                    { 8, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Jezyki",
                columns: new[] { "JezykId", "Name" },
                values: new object[,]
                {
                    { 1, "Polski" },
                    { 2, "Angielski" }
                });

            migrationBuilder.InsertData(
                table: "Lokalizacje",
                columns: new[] { "LokalizacjaId", "Name" },
                values: new object[,]
                {
                    { 1, "Wroclaw" },
                    { 2, "Jelenia Góra" },
                    { 3, "Legnica" },
                    { 4, "Wałbrzych" }
                });

            migrationBuilder.InsertData(
                table: "Stopnie",
                columns: new[] { "StopienId", "Name" },
                values: new object[,]
                {
                    { 1, "I" },
                    { 2, "II" }
                });

            migrationBuilder.InsertData(
                table: "Tryby",
                columns: new[] { "TrybId", "Name" },
                values: new object[,]
                {
                    { 1, "Stacjonarny" },
                    { 2, "Niestacjonarny" }
                });

            migrationBuilder.InsertData(
                table: "Kierunki",
                columns: new[] { "KierunekId", "Abbreviation", "CzasTrwaniaId", "Description", "JezykId", "Name", "StopienId", "TrybId" },
                values: new object[,]
                {
                    { 1, "IST", 5, "Najlepszy kierunek", 1, "Informatyka Stosowana", 1, 1 },
                    { 2, "ARC", 6, "Opis architektury.", 1, "Architektura", 1, 1 },
                    { 3, "ISTA", 5, "Second best one.", 2, "Applied Computer Science", 1, 1 },
                    { 4, "BUD-2", 4, "", 1, "Budownictwo", 2, 2 },
                    { 5, "BUD-2N", 5, "", 1, "Budownictwo", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Pracodawcy",
                columns: new[] { "PracodawcaId", "AdresId", "CompanyName", "Description", "Link" },
                values: new object[,]
                {
                    { 1, 3, "Zdisław Firma", "Firma", "https://ZdzislawFirma.pl" },
                    { 2, 2, "Firma Budowlana", null, null },
                    { 3, 1, "Warsztaty Moniki", null, null }
                });

            migrationBuilder.InsertData(
                table: "Wydzialy",
                columns: new[] { "WydzialId", "Abbreviation", "LokalizacjaId", "Name" },
                values: new object[,]
                {
                    { 1, "W1", 1, "Wydział Architektury" },
                    { 2, "W2", 1, "Wydział Budownictwa" },
                    { 3, "W3", 1, "Wydział Chemiczny" },
                    { 4, "W4", 1, "Wydział Informatyki i Telekomunikacji" }
                });

            migrationBuilder.InsertData(
                table: "HistoryczneDane",
                columns: new[] { "KierunekId", "Year", "CandidatesPerSpot", "PointThreshold" },
                values: new object[,]
                {
                    { 1, 2020, 2.0, 370.0 },
                    { 2, 2020, 1.8500000000000001, 360.0 },
                    { 3, 2020, 1.05, 200.0 },
                    { 1, 2021, 2.0, 400.0 },
                    { 1, 2022, 2.6000000000000001, 430.0 }
                });

            migrationBuilder.InsertData(
                table: "MiejscaPracy",
                columns: new[] { "KierunekId", "PracodawcaId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Perspektywy",
                columns: new[] { "KierunekId", "PracodawcaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 1 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Praktyki",
                columns: new[] { "KierunekId", "PracodawcaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 2 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Specjalizacje",
                columns: new[] { "SpecjalizacjaId", "Description", "KierunekId", "Name" },
                values: new object[] { 1, "Opis budownictwa lądowego", 4, "Budownictwo Lądowe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CzasyTrwania",
                keyColumn: "CzasTrwaniaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CzasyTrwania",
                keyColumn: "CzasTrwaniaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CzasyTrwania",
                keyColumn: "CzasTrwaniaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CzasyTrwania",
                keyColumn: "CzasTrwaniaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CzasyTrwania",
                keyColumn: "CzasTrwaniaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HistoryczneDane",
                keyColumns: new[] { "KierunekId", "Year" },
                keyValues: new object[] { 1, 2020 });

            migrationBuilder.DeleteData(
                table: "HistoryczneDane",
                keyColumns: new[] { "KierunekId", "Year" },
                keyValues: new object[] { 2, 2020 });

            migrationBuilder.DeleteData(
                table: "HistoryczneDane",
                keyColumns: new[] { "KierunekId", "Year" },
                keyValues: new object[] { 3, 2020 });

            migrationBuilder.DeleteData(
                table: "HistoryczneDane",
                keyColumns: new[] { "KierunekId", "Year" },
                keyValues: new object[] { 1, 2021 });

            migrationBuilder.DeleteData(
                table: "HistoryczneDane",
                keyColumns: new[] { "KierunekId", "Year" },
                keyValues: new object[] { 1, 2022 });

            migrationBuilder.DeleteData(
                table: "Lokalizacje",
                keyColumn: "LokalizacjaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lokalizacje",
                keyColumn: "LokalizacjaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lokalizacje",
                keyColumn: "LokalizacjaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MiejscaPracy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Perspektywy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Perspektywy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Perspektywy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Perspektywy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Perspektywy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Perspektywy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Perspektywy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Perspektywy",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Praktyki",
                keyColumns: new[] { "KierunekId", "PracodawcaId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Specjalizacje",
                keyColumn: "SpecjalizacjaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wydzialy",
                keyColumn: "WydzialId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wydzialy",
                keyColumn: "WydzialId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wydzialy",
                keyColumn: "WydzialId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wydzialy",
                keyColumn: "WydzialId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kierunki",
                keyColumn: "KierunekId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lokalizacje",
                keyColumn: "LokalizacjaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracodawcy",
                keyColumn: "PracodawcaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracodawcy",
                keyColumn: "PracodawcaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pracodawcy",
                keyColumn: "PracodawcaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "AdresId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "AdresId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "AdresId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CzasyTrwania",
                keyColumn: "CzasTrwaniaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CzasyTrwania",
                keyColumn: "CzasTrwaniaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CzasyTrwania",
                keyColumn: "CzasTrwaniaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jezyki",
                keyColumn: "JezykId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jezyki",
                keyColumn: "JezykId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stopnie",
                keyColumn: "StopienId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stopnie",
                keyColumn: "StopienId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tryby",
                keyColumn: "TrybId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tryby",
                keyColumn: "TrybId",
                keyValue: 2);
        }
    }
}
