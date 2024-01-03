using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PO_project.Migrations
{
    /// <inheritdoc />
    public partial class DZIALAKURWA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Pracodawcy",
                columns: table => new
                {
                    PracodawcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracodawcy", x => x.PracodawcaId);
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
                name: "Wydzialy",
                columns: table => new
                {
                    WydzialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: true)
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
                name: "Adresy",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PracodawcaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.AdresId);
                    table.ForeignKey(
                        name: "FK_Adresy_Pracodawcy_PracodawcaId",
                        column: x => x.PracodawcaId,
                        principalTable: "Pracodawcy",
                        principalColumn: "PracodawcaId");
                });

            migrationBuilder.CreateTable(
                name: "Kierunki",
                columns: table => new
                {
                    KierunekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JezykId = table.Column<int>(type: "int", nullable: false),
                    StopienId = table.Column<int>(type: "int", nullable: false),
                    TrybId = table.Column<int>(type: "int", nullable: false),
                    CzasTrwaniaId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Adresy",
                columns: new[] { "AdresId", "BuildingNumber", "City", "PostCode", "PracodawcaId", "Street" },
                values: new object[,]
                {
                    { 1, "4", "Wroclaw", "50-030", 2, "Grabiszynska" },
                    { 2, "219", "Wroclaw", "51-518", 1, "Piekna" },
                    { 3, "30", "Warszawa", "01-015", 3, "Gorna" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Adresy_PracodawcaId",
                table: "Adresy",
                column: "PracodawcaId");

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
                name: "IX_MiejscaPracy_PracodawcaId",
                table: "MiejscaPracy",
                column: "PracodawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perspektywy_PracodawcaId",
                table: "Perspektywy",
                column: "PracodawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Praktyki_PracodawcaId",
                table: "Praktyki",
                column: "PracodawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wydzialy_LokalizacjaId",
                table: "Wydzialy",
                column: "LokalizacjaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresy");

            migrationBuilder.DropTable(
                name: "HistoryczneDane");

            migrationBuilder.DropTable(
                name: "MiejscaPracy");

            migrationBuilder.DropTable(
                name: "Perspektywy");

            migrationBuilder.DropTable(
                name: "Praktyki");

            migrationBuilder.DropTable(
                name: "Wydzialy");

            migrationBuilder.DropTable(
                name: "Kierunki");

            migrationBuilder.DropTable(
                name: "Pracodawcy");

            migrationBuilder.DropTable(
                name: "Lokalizacje");

            migrationBuilder.DropTable(
                name: "CzasyTrwania");

            migrationBuilder.DropTable(
                name: "Stopnie");

            migrationBuilder.DropTable(
                name: "Tryby");
        }
    }
}
