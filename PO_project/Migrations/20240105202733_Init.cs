using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PO_project.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.AdresId);
                });

            migrationBuilder.CreateTable(
                name: "CzasyTrwania",
                columns: table => new
                {
                    CzasTrwaniaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CzasyTrwania", x => x.CzasTrwaniaId);
                });

            migrationBuilder.CreateTable(
                name: "Jezyki",
                columns: table => new
                {
                    JezykId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jezyki", x => x.JezykId);
                });

            migrationBuilder.CreateTable(
                name: "Lokalizacje",
                columns: table => new
                {
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokalizacje", x => x.LokalizacjaId);
                });

            migrationBuilder.CreateTable(
                name: "Stopnie",
                columns: table => new
                {
                    StopienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stopnie", x => x.StopienId);
                });

            migrationBuilder.CreateTable(
                name: "Tryby",
                columns: table => new
                {
                    TrybId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tryby", x => x.TrybId);
                });

            migrationBuilder.CreateTable(
                name: "Pracodawcy",
                columns: table => new
                {
                    PracodawcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracodawcy", x => x.PracodawcaId);
                    table.ForeignKey(
                        name: "FK_Pracodawcy_Adresy_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresy",
                        principalColumn: "AdresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wydzialy",
                columns: table => new
                {
                    WydzialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydzialy", x => x.WydzialId);
                    table.ForeignKey(
                        name: "FK_Wydzialy_Lokalizacje_LokalizacjaId",
                        column: x => x.LokalizacjaId,
                        principalTable: "Lokalizacje",
                        principalColumn: "LokalizacjaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kierunki",
                columns: table => new
                {
                    KierunekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JezykId = table.Column<int>(type: "int", nullable: false),
                    StopienId = table.Column<int>(type: "int", nullable: false),
                    TrybId = table.Column<int>(type: "int", nullable: false),
                    CzasTrwaniaId = table.Column<int>(type: "int", nullable: false),
                    WydzialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kierunki", x => x.KierunekId);
                    table.ForeignKey(
                        name: "FK_Kierunki_CzasyTrwania_CzasTrwaniaId",
                        column: x => x.CzasTrwaniaId,
                        principalTable: "CzasyTrwania",
                        principalColumn: "CzasTrwaniaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kierunki_Jezyki_JezykId",
                        column: x => x.JezykId,
                        principalTable: "Jezyki",
                        principalColumn: "JezykId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kierunki_Stopnie_StopienId",
                        column: x => x.StopienId,
                        principalTable: "Stopnie",
                        principalColumn: "StopienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kierunki_Tryby_TrybId",
                        column: x => x.TrybId,
                        principalTable: "Tryby",
                        principalColumn: "TrybId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kierunki_Wydzialy_WydzialId",
                        column: x => x.WydzialId,
                        principalTable: "Wydzialy",
                        principalColumn: "WydzialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryczneDane",
                columns: table => new
                {
                    Year = table.Column<int>(type: "int", nullable: false),
                    KierunekId = table.Column<int>(type: "int", nullable: false),
                    PointThreshold = table.Column<double>(type: "float", nullable: false),
                    CandidatesPerSpot = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryczneDane", x => new { x.Year, x.KierunekId });
                    table.ForeignKey(
                        name: "FK_HistoryczneDane_Kierunki_KierunekId",
                        column: x => x.KierunekId,
                        principalTable: "Kierunki",
                        principalColumn: "KierunekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiejscaPracy",
                columns: table => new
                {
                    KierunekId = table.Column<int>(type: "int", nullable: false),
                    PracodawcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejscaPracy", x => new { x.KierunekId, x.PracodawcaId });
                    table.ForeignKey(
                        name: "FK_MiejscaPracy_Kierunki_KierunekId",
                        column: x => x.KierunekId,
                        principalTable: "Kierunki",
                        principalColumn: "KierunekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiejscaPracy_Pracodawcy_PracodawcaId",
                        column: x => x.PracodawcaId,
                        principalTable: "Pracodawcy",
                        principalColumn: "PracodawcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perspektywy",
                columns: table => new
                {
                    KierunekId = table.Column<int>(type: "int", nullable: false),
                    PracodawcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perspektywy", x => new { x.KierunekId, x.PracodawcaId });
                    table.ForeignKey(
                        name: "FK_Perspektywy_Kierunki_KierunekId",
                        column: x => x.KierunekId,
                        principalTable: "Kierunki",
                        principalColumn: "KierunekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perspektywy_Pracodawcy_PracodawcaId",
                        column: x => x.PracodawcaId,
                        principalTable: "Pracodawcy",
                        principalColumn: "PracodawcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Praktyki",
                columns: table => new
                {
                    KierunekId = table.Column<int>(type: "int", nullable: false),
                    PracodawcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Praktyki", x => new { x.KierunekId, x.PracodawcaId });
                    table.ForeignKey(
                        name: "FK_Praktyki_Kierunki_KierunekId",
                        column: x => x.KierunekId,
                        principalTable: "Kierunki",
                        principalColumn: "KierunekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Praktyki_Pracodawcy_PracodawcaId",
                        column: x => x.PracodawcaId,
                        principalTable: "Pracodawcy",
                        principalColumn: "PracodawcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specjalizacje",
                columns: table => new
                {
                    SpecjalizacjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KierunekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specjalizacje", x => x.SpecjalizacjaId);
                    table.ForeignKey(
                        name: "FK_Specjalizacje_Kierunki_KierunekId",
                        column: x => x.KierunekId,
                        principalTable: "Kierunki",
                        principalColumn: "KierunekId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Kierunki",
                columns: new[] { "KierunekId", "Abbreviation", "CzasTrwaniaId", "Description", "JezykId", "Name", "StopienId", "TrybId", "WydzialId" },
                values: new object[,]
                {
                    { 1, "IST", 5, "Najlepszy kierunek", 1, "Informatyka Stosowana", 1, 1, 4 },
                    { 2, "ARC", 6, "Opis architektury.", 1, "Architektura", 1, 1, 1 },
                    { 3, "ISTA", 5, "Second best one.", 2, "Applied Computer Science", 1, 1, 4 },
                    { 4, "BUD-2", 4, "", 1, "Budownictwo", 2, 2, 2 },
                    { 5, "BUD-2N", 5, "", 1, "Budownictwo", 2, 1, 2 }
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

            migrationBuilder.CreateIndex(
                name: "IX_HistoryczneDane_KierunekId",
                table: "HistoryczneDane",
                column: "KierunekId");

            migrationBuilder.CreateIndex(
                name: "IX_Kierunki_CzasTrwaniaId",
                table: "Kierunki",
                column: "CzasTrwaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kierunki_JezykId",
                table: "Kierunki",
                column: "JezykId");

            migrationBuilder.CreateIndex(
                name: "IX_Kierunki_StopienId",
                table: "Kierunki",
                column: "StopienId");

            migrationBuilder.CreateIndex(
                name: "IX_Kierunki_TrybId",
                table: "Kierunki",
                column: "TrybId");

            migrationBuilder.CreateIndex(
                name: "IX_Kierunki_WydzialId",
                table: "Kierunki",
                column: "WydzialId");

            migrationBuilder.CreateIndex(
                name: "IX_MiejscaPracy_PracodawcaId",
                table: "MiejscaPracy",
                column: "PracodawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perspektywy_PracodawcaId",
                table: "Perspektywy",
                column: "PracodawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracodawcy_AdresId",
                table: "Pracodawcy",
                column: "AdresId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Praktyki_PracodawcaId",
                table: "Praktyki",
                column: "PracodawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Specjalizacje_KierunekId",
                table: "Specjalizacje",
                column: "KierunekId");

            migrationBuilder.CreateIndex(
                name: "IX_Wydzialy_LokalizacjaId",
                table: "Wydzialy",
                column: "LokalizacjaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryczneDane");

            migrationBuilder.DropTable(
                name: "MiejscaPracy");

            migrationBuilder.DropTable(
                name: "Perspektywy");

            migrationBuilder.DropTable(
                name: "Praktyki");

            migrationBuilder.DropTable(
                name: "Specjalizacje");

            migrationBuilder.DropTable(
                name: "Pracodawcy");

            migrationBuilder.DropTable(
                name: "Kierunki");

            migrationBuilder.DropTable(
                name: "Adresy");

            migrationBuilder.DropTable(
                name: "CzasyTrwania");

            migrationBuilder.DropTable(
                name: "Jezyki");

            migrationBuilder.DropTable(
                name: "Stopnie");

            migrationBuilder.DropTable(
                name: "Tryby");

            migrationBuilder.DropTable(
                name: "Wydzialy");

            migrationBuilder.DropTable(
                name: "Lokalizacje");
        }
    }
}
