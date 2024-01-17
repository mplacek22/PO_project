using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PO_project.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "Pytania",
                columns: table => new
                {
                    PytanieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pytania", x => x.PytanieId);
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
                name: "Odpowiedzi",
                columns: table => new
                {
                    OdzpowiedzId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PytanieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odpowiedzi", x => x.OdzpowiedzId);
                    table.ForeignKey(
                        name: "FK_Odpowiedzi_Pytania_PytanieId",
                        column: x => x.PytanieId,
                        principalTable: "Pytania",
                        principalColumn: "PytanieId",
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
                    WydzialId = table.Column<int>(type: "int", nullable: false),
                    OlimpiadyString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RysunekRequired = table.Column<bool>(type: "bit", nullable: false),
                    BiologiaRequired = table.Column<bool>(type: "bit", nullable: false),
                    PrzedmiotyDodatkoweString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxWskaznikRekrutacyjny = table.Column<int>(type: "int", nullable: false)
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
                    { 8, 5.0 },
                    { 9, 5.5 },
                    { 10, 6.0 }
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
                table: "Pytania",
                columns: new[] { "PytanieId", "Tresc" },
                values: new object[,]
                {
                    { 1, "Czy czujesz się bardziej komfortowo w abstrakcyjnym świecie liczb i teorii, czy też bardziej w realnym, konkretnym środowisku projektowym?" },
                    { 2, "Czy preferujesz rozwiązywanie problemów, zastanawianie się nad ich przyczynami i skutkami, czy bardziej cenisz sobie konkretne prace projektowe?" },
                    { 3, "Czy fascynuje Cię proces projektowania algorytmów i ich optymalizacja, czy bardziej kieruje tobą praktyczne zastosowanie rozwiązań?" },
                    { 4, "Czy zainspirowałbyś/łabyś się projektowaniem i tworzeniem nowoczesnych przestrzeni architektonicznych, czy też bardziej przyciągają cię aspekty techniczne budowy?" },
                    { 5, "Czy bardziej cię pociąga praca nad systemami informatycznymi, czy może masz skłonności do zajmowania się infrastrukturą energetyczną, a może projektowaniem infrastrutur?" }
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
                table: "Odpowiedzi",
                columns: new[] { "OdzpowiedzId", "PytanieId", "Tresc" },
                values: new object[,]
                {
                    { 1, 1, "Abstrakcyjny świat liczb i teorii to coś, co przyciąga moją uwagę." },
                    { 2, 1, "Bardziej czuję się komfortowo w realnym środowisku projektowym." },
                    { 3, 1, "Zależy od sytuacji, lubię łączyć oba światy." },
                    { 4, 2, "Lubię analizować i rozwiązywać problemy, zastanawiać się nad ich korzeniami." },
                    { 5, 2, "Cenię sobie konkretną pracę projektową nad analizą problemów." },
                    { 6, 2, "Zarówno analiza problemów, jak i prace projektowe są dla mnie równie interesujące." },
                    { 7, 3, "Proces projektowania algorytmów to coś, co mnie naprawdę fascynuje." },
                    { 8, 3, "Bardziej kieruje mnie praktyczne zastosowanie rozwiązań niż projektowanie algorytmów." },
                    { 9, 3, "Nie mam jednoznacznej preferencji, obie strony są dla mnie atrakcyjne." },
                    { 10, 4, "Inspiruje mnie projektowanie nowoczesnych przestrzeni architektonicznych." },
                    { 11, 4, "Interesują mnie bardziej aspekty techniczne i konstrukcyjne budowy." },
                    { 12, 4, "Trudno mi się zdecydować, obie dziedziny wydają się interesujące." },
                    { 13, 5, "Praca nad systemami informatycznymi przyciąga moją uwagę." },
                    { 14, 5, "Skłaniam się bardziej w stronę zajmowania się infrastrukturą energetyczną." },
                    { 15, 5, "preferuję projektowanie infrastruktur" }
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
                    { 4, "W4", 1, "Wydział Informatyki i Telekomunikacji" },
                    { 5, "W5", 1, "Elektryczny" },
                    { 6, "W7", 1, "Inżynierii środowiska" },
                    { 7, "W13", 1, "Matematyki" },
                    { 8, "W14", 1, "Medyczny" }
                });

            migrationBuilder.InsertData(
                table: "Kierunki",
                columns: new[] { "KierunekId", "Abbreviation", "BiologiaRequired", "CzasTrwaniaId", "Description", "JezykId", "MaxWskaznikRekrutacyjny", "Name", "OlimpiadyString", "PrzedmiotyDodatkoweString", "RysunekRequired", "StopienId", "TrybId", "WydzialId" },
                values: new object[,]
                {
                    { 1, "IST", false, 5, "Najlepszy kierunek", 1, 535, "Informatyka Stosowana", "Matematyczna,Fizyczna", "Fizyka,Informatyka", false, 1, 1, 4 },
                    { 2, "ARC", false, 6, "Opis architektury.", 1, 1195, "Architektura", "", "Fizyka", true, 1, 1, 1 },
                    { 3, "ISTA", false, 5, "Second best one.", 2, 535, "Applied Computer Science", "", "Fizyka,Informatyka", false, 1, 1, 4 },
                    { 4, "BUD-2", false, 4, "", 1, 535, "Budownictwo", "", "Fizyka", false, 2, 2, 2 },
                    { 5, "CBE", false, 4, "", 1, 535, "Cyberbezpieczeństwo", "", "Fizyka,Informatyka", false, 1, 1, 4 },
                    { 6, "ENG", false, 4, "", 1, 535, "Energetyka", "", "Fizyka", false, 2, 2, 2 },
                    { 7, "MAT", false, 4, "", 1, 535, "Matematyka", "", "Fizyka,Informatyka", false, 2, 2, 7 },
                    { 8, "OPT", false, 4, "", 1, 535, "Informatyczne systemy automatyki", "", "Fizyka,Informatyka", false, 2, 1, 4 },
                    { 9, "OPT", false, 4, "", 1, 535, "Informatyka algorytmiczna", "", "Fizyka,Informatyka", false, 1, 1, 4 },
                    { 10, "OPT", false, 4, "", 1, 535, "Inżynieria systemów", "", "Fizyka,Informatyka", false, 1, 1, 4 },
                    { 11, "OPT", false, 4, "", 1, 535, "Telekomunikacja", "", "Fizyka,Informatyka", false, 2, 1, 4 },
                    { 12, "LEK", true, 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a cursus metus. Sed quis aliquet libero, at condimentum dui. Sed laoreet bibendum ex, non facilisis justo semper at. Vestibulum blandit dolor sit amet diam ultricies, nec consectetur ante hendrerit. Integer rhoncus ipsum tellus. Ut nisl leo, semper eu ex non, scelerisque ornare leo. Suspendisse potenti. Vestibulum porta tortor in ligula pretium, sit amet lobortis ante auctor.\r\n\r\nIn tristique auctor enim, porta porta leo tempor vitae. Aenean sit amet eros imperdiet, scelerisque neque mollis, sagittis mi. Maecenas sit amet euismod nibh. Fusce leo purus, sodales id tellus at, mattis pharetra nunc. Donec egestas mattis varius. Phasellus varius, sapien vel auctor vehicula, augue erat convallis sapien, eget vulputate lorem mi aliquet nulla. Nam volutpat auctor dolor eu dignissim. Donec augue tortor, commodo in porttitor at, tempus et augue. In eu eros ligula.\r\n\r\nPhasellus viverra mauris eget nisi finibus dapibus. Donec ut consectetur sem, eu feugiat purus. Aenean eu fermentum leo. Mauris vulputate blandit ipsum, a ultrices nibh gravida nec. Donec aliquet gravida urna ut lobortis. Nam ut tempus eros, a vestibulum erat. Nulla dictum placerat ligula quis cursus. Maecenas at mi at risus sollicitudin semper. Nulla velit dolor, condimentum ac congue at.", 1, 535, "Lekarski", "", "Fizyka,Chemia", false, 1, 1, 8 }
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
                values: new object[,]
                {
                    { 1, "Opis budownictwa lądowego", 4, "Budownictwo Lądowe" },
                    { 2, "Opis budownictwa wodnego", 4, "Budownictwo Wodne" }
                });

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
                name: "IX_Odpowiedzi_PytanieId",
                table: "Odpowiedzi",
                column: "PytanieId");

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
                name: "Odpowiedzi");

            migrationBuilder.DropTable(
                name: "Perspektywy");

            migrationBuilder.DropTable(
                name: "Praktyki");

            migrationBuilder.DropTable(
                name: "Specjalizacje");

            migrationBuilder.DropTable(
                name: "Pytania");

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
