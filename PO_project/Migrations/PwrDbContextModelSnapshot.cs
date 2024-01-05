﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PO_project.Data;

#nullable disable

namespace PO_project.Migrations
{
    [DbContext(typeof(PwrDbContext))]
    partial class PwrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PO_project.Models.Adres", b =>
                {
                    b.Property<int>("AdresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdresId"));

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresId");

                    b.ToTable("Adresy");

                    b.HasData(
                        new
                        {
                            AdresId = 1,
                            BuildingNumber = "4",
                            City = "Wroclaw",
                            PostCode = "50-030",
                            Street = "Grabiszynska"
                        },
                        new
                        {
                            AdresId = 2,
                            BuildingNumber = "219",
                            City = "Wroclaw",
                            PostCode = "51-518",
                            Street = "Piekna"
                        },
                        new
                        {
                            AdresId = 3,
                            BuildingNumber = "30",
                            City = "Warszawa",
                            PostCode = "01-015",
                            Street = "Gorna"
                        });
                });

            modelBuilder.Entity("PO_project.Models.CzasTrwania", b =>
                {
                    b.Property<int>("CzasTrwaniaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CzasTrwaniaId"));

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("CzasTrwaniaId");

                    b.ToTable("CzasyTrwania");

                    b.HasData(
                        new
                        {
                            CzasTrwaniaId = 1,
                            Value = 1.5
                        },
                        new
                        {
                            CzasTrwaniaId = 2,
                            Value = 2.0
                        },
                        new
                        {
                            CzasTrwaniaId = 3,
                            Value = 2.5
                        },
                        new
                        {
                            CzasTrwaniaId = 4,
                            Value = 3.0
                        },
                        new
                        {
                            CzasTrwaniaId = 5,
                            Value = 3.5
                        },
                        new
                        {
                            CzasTrwaniaId = 6,
                            Value = 4.0
                        },
                        new
                        {
                            CzasTrwaniaId = 7,
                            Value = 4.5
                        },
                        new
                        {
                            CzasTrwaniaId = 8,
                            Value = 5.0
                        });
                });

            modelBuilder.Entity("PO_project.Models.HistoryczneDane", b =>
                {
                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("KierunekId")
                        .HasColumnType("int");

                    b.Property<double>("CandidatesPerSpot")
                        .HasColumnType("float");

                    b.Property<double>("PointThreshold")
                        .HasColumnType("float");

                    b.HasKey("Year", "KierunekId");

                    b.HasIndex("KierunekId");

                    b.ToTable("HistoryczneDane");

                    b.HasData(
                        new
                        {
                            Year = 2020,
                            KierunekId = 1,
                            CandidatesPerSpot = 2.0,
                            PointThreshold = 370.0
                        },
                        new
                        {
                            Year = 2020,
                            KierunekId = 2,
                            CandidatesPerSpot = 1.8500000000000001,
                            PointThreshold = 360.0
                        },
                        new
                        {
                            Year = 2020,
                            KierunekId = 3,
                            CandidatesPerSpot = 1.05,
                            PointThreshold = 200.0
                        },
                        new
                        {
                            Year = 2021,
                            KierunekId = 1,
                            CandidatesPerSpot = 2.0,
                            PointThreshold = 400.0
                        },
                        new
                        {
                            Year = 2022,
                            KierunekId = 1,
                            CandidatesPerSpot = 2.6000000000000001,
                            PointThreshold = 430.0
                        });
                });

            modelBuilder.Entity("PO_project.Models.Jezyk", b =>
                {
                    b.Property<int>("JezykId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JezykId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("JezykId");

                    b.ToTable("Jezyki");

                    b.HasData(
                        new
                        {
                            JezykId = 1,
                            Name = "Polski"
                        },
                        new
                        {
                            JezykId = 2,
                            Name = "Angielski"
                        });
                });

            modelBuilder.Entity("PO_project.Models.Kierunek", b =>
                {
                    b.Property<int>("KierunekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KierunekId"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("CzasTrwaniaId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JezykId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StopienId")
                        .HasColumnType("int");

                    b.Property<int>("TrybId")
                        .HasColumnType("int");

                    b.HasKey("KierunekId");

                    b.HasIndex("CzasTrwaniaId");

                    b.HasIndex("JezykId");

                    b.HasIndex("StopienId");

                    b.HasIndex("TrybId");

                    b.ToTable("Kierunki");

                    b.HasData(
                        new
                        {
                            KierunekId = 1,
                            Abbreviation = "IST",
                            CzasTrwaniaId = 5,
                            Description = "Najlepszy kierunek",
                            JezykId = 1,
                            Name = "Informatyka Stosowana",
                            StopienId = 1,
                            TrybId = 1
                        },
                        new
                        {
                            KierunekId = 2,
                            Abbreviation = "ARC",
                            CzasTrwaniaId = 6,
                            Description = "Opis architektury.",
                            JezykId = 1,
                            Name = "Architektura",
                            StopienId = 1,
                            TrybId = 1
                        },
                        new
                        {
                            KierunekId = 3,
                            Abbreviation = "ISTA",
                            CzasTrwaniaId = 5,
                            Description = "Second best one.",
                            JezykId = 2,
                            Name = "Applied Computer Science",
                            StopienId = 1,
                            TrybId = 1
                        },
                        new
                        {
                            KierunekId = 4,
                            Abbreviation = "BUD-2",
                            CzasTrwaniaId = 4,
                            Description = "",
                            JezykId = 1,
                            Name = "Budownictwo",
                            StopienId = 2,
                            TrybId = 2
                        },
                        new
                        {
                            KierunekId = 5,
                            Abbreviation = "BUD-2N",
                            CzasTrwaniaId = 5,
                            Description = "",
                            JezykId = 1,
                            Name = "Budownictwo",
                            StopienId = 2,
                            TrybId = 1
                        });
                });

            modelBuilder.Entity("PO_project.Models.KierunekMiejscaPracy", b =>
                {
                    b.Property<int>("KierunekId")
                        .HasColumnType("int");

                    b.Property<int>("PracodawcaId")
                        .HasColumnType("int");

                    b.HasKey("KierunekId", "PracodawcaId");

                    b.HasIndex("PracodawcaId");

                    b.ToTable("MiejscaPracy");

                    b.HasData(
                        new
                        {
                            KierunekId = 1,
                            PracodawcaId = 1
                        });
                });

            modelBuilder.Entity("PO_project.Models.KierunekPerspektywy", b =>
                {
                    b.Property<int>("KierunekId")
                        .HasColumnType("int");

                    b.Property<int>("PracodawcaId")
                        .HasColumnType("int");

                    b.HasKey("KierunekId", "PracodawcaId");

                    b.HasIndex("PracodawcaId");

                    b.ToTable("Perspektywy");

                    b.HasData(
                        new
                        {
                            KierunekId = 1,
                            PracodawcaId = 1
                        },
                        new
                        {
                            KierunekId = 2,
                            PracodawcaId = 1
                        },
                        new
                        {
                            KierunekId = 1,
                            PracodawcaId = 2
                        },
                        new
                        {
                            KierunekId = 1,
                            PracodawcaId = 3
                        },
                        new
                        {
                            KierunekId = 2,
                            PracodawcaId = 2
                        },
                        new
                        {
                            KierunekId = 4,
                            PracodawcaId = 2
                        },
                        new
                        {
                            KierunekId = 4,
                            PracodawcaId = 1
                        },
                        new
                        {
                            KierunekId = 3,
                            PracodawcaId = 1
                        });
                });

            modelBuilder.Entity("PO_project.Models.KierunekPraktyki", b =>
                {
                    b.Property<int>("KierunekId")
                        .HasColumnType("int");

                    b.Property<int>("PracodawcaId")
                        .HasColumnType("int");

                    b.HasKey("KierunekId", "PracodawcaId");

                    b.HasIndex("PracodawcaId");

                    b.ToTable("Praktyki");

                    b.HasData(
                        new
                        {
                            KierunekId = 1,
                            PracodawcaId = 2
                        },
                        new
                        {
                            KierunekId = 2,
                            PracodawcaId = 2
                        },
                        new
                        {
                            KierunekId = 3,
                            PracodawcaId = 2
                        },
                        new
                        {
                            KierunekId = 4,
                            PracodawcaId = 2
                        },
                        new
                        {
                            KierunekId = 5,
                            PracodawcaId = 2
                        },
                        new
                        {
                            KierunekId = 1,
                            PracodawcaId = 1
                        },
                        new
                        {
                            KierunekId = 5,
                            PracodawcaId = 3
                        },
                        new
                        {
                            KierunekId = 4,
                            PracodawcaId = 3
                        },
                        new
                        {
                            KierunekId = 4,
                            PracodawcaId = 1
                        },
                        new
                        {
                            KierunekId = 2,
                            PracodawcaId = 1
                        });
                });

            modelBuilder.Entity("PO_project.Models.Lokalizacja", b =>
                {
                    b.Property<int>("LokalizacjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LokalizacjaId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LokalizacjaId");

                    b.ToTable("Lokalizacje");

                    b.HasData(
                        new
                        {
                            LokalizacjaId = 1,
                            Name = "Wroclaw"
                        },
                        new
                        {
                            LokalizacjaId = 2,
                            Name = "Jelenia Góra"
                        },
                        new
                        {
                            LokalizacjaId = 3,
                            Name = "Legnica"
                        },
                        new
                        {
                            LokalizacjaId = 4,
                            Name = "Wałbrzych"
                        });
                });

            modelBuilder.Entity("PO_project.Models.Pracodawca", b =>
                {
                    b.Property<int>("PracodawcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PracodawcaId"));

                    b.Property<int>("AdresId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PracodawcaId");

                    b.HasIndex("AdresId")
                        .IsUnique();

                    b.ToTable("Pracodawcy");

                    b.HasData(
                        new
                        {
                            PracodawcaId = 1,
                            AdresId = 3,
                            CompanyName = "Zdisław Firma",
                            Description = "Firma",
                            Link = "https://ZdzislawFirma.pl"
                        },
                        new
                        {
                            PracodawcaId = 2,
                            AdresId = 2,
                            CompanyName = "Firma Budowlana"
                        },
                        new
                        {
                            PracodawcaId = 3,
                            AdresId = 1,
                            CompanyName = "Warsztaty Moniki"
                        });
                });

            modelBuilder.Entity("PO_project.Models.Specjalizacja", b =>
                {
                    b.Property<int>("SpecjalizacjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecjalizacjaId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KierunekId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SpecjalizacjaId");

                    b.HasIndex("KierunekId");

                    b.ToTable("Specjalizacje");

                    b.HasData(
                        new
                        {
                            SpecjalizacjaId = 1,
                            Description = "Opis budownictwa lądowego",
                            KierunekId = 4,
                            Name = "Budownictwo Lądowe"
                        });
                });

            modelBuilder.Entity("PO_project.Models.Stopien", b =>
                {
                    b.Property<int>("StopienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StopienId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("StopienId");

                    b.ToTable("Stopnie");

                    b.HasData(
                        new
                        {
                            StopienId = 1,
                            Name = "I"
                        },
                        new
                        {
                            StopienId = 2,
                            Name = "II"
                        });
                });

            modelBuilder.Entity("PO_project.Models.Tryb", b =>
                {
                    b.Property<int>("TrybId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrybId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("TrybId");

                    b.ToTable("Tryby");

                    b.HasData(
                        new
                        {
                            TrybId = 1,
                            Name = "Stacjonarny"
                        },
                        new
                        {
                            TrybId = 2,
                            Name = "Niestacjonarny"
                        });
                });

            modelBuilder.Entity("PO_project.Models.Wydzial", b =>
                {
                    b.Property<int>("WydzialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WydzialId"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LokalizacjaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WydzialId");

                    b.HasIndex("LokalizacjaId");

                    b.ToTable("Wydzialy");

                    b.HasData(
                        new
                        {
                            WydzialId = 1,
                            Abbreviation = "W1",
                            LokalizacjaId = 1,
                            Name = "Wydział Architektury"
                        },
                        new
                        {
                            WydzialId = 2,
                            Abbreviation = "W2",
                            LokalizacjaId = 1,
                            Name = "Wydział Budownictwa"
                        },
                        new
                        {
                            WydzialId = 3,
                            Abbreviation = "W3",
                            LokalizacjaId = 1,
                            Name = "Wydział Chemiczny"
                        },
                        new
                        {
                            WydzialId = 4,
                            Abbreviation = "W4",
                            LokalizacjaId = 1,
                            Name = "Wydział Informatyki i Telekomunikacji"
                        });
                });

            modelBuilder.Entity("PO_project.Models.HistoryczneDane", b =>
                {
                    b.HasOne("PO_project.Models.Kierunek", "Kierunek")
                        .WithMany()
                        .HasForeignKey("KierunekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kierunek");
                });

            modelBuilder.Entity("PO_project.Models.Kierunek", b =>
                {
                    b.HasOne("PO_project.Models.CzasTrwania", "CzasTrwania")
                        .WithMany()
                        .HasForeignKey("CzasTrwaniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PO_project.Models.Jezyk", "Jezyk")
                        .WithMany()
                        .HasForeignKey("JezykId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PO_project.Models.Stopien", "Stopien")
                        .WithMany()
                        .HasForeignKey("StopienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PO_project.Models.Tryb", "Tryb")
                        .WithMany()
                        .HasForeignKey("TrybId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CzasTrwania");

                    b.Navigation("Jezyk");

                    b.Navigation("Stopien");

                    b.Navigation("Tryb");
                });

            modelBuilder.Entity("PO_project.Models.KierunekMiejscaPracy", b =>
                {
                    b.HasOne("PO_project.Models.Kierunek", "Kierunek")
                        .WithMany("MiejscaPracy")
                        .HasForeignKey("KierunekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PO_project.Models.Pracodawca", "Pracodawca")
                        .WithMany("MiejscaPracy")
                        .HasForeignKey("PracodawcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kierunek");

                    b.Navigation("Pracodawca");
                });

            modelBuilder.Entity("PO_project.Models.KierunekPerspektywy", b =>
                {
                    b.HasOne("PO_project.Models.Kierunek", "Kierunek")
                        .WithMany("Perpektywy")
                        .HasForeignKey("KierunekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PO_project.Models.Pracodawca", "Pracodawca")
                        .WithMany("Perpektywy")
                        .HasForeignKey("PracodawcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kierunek");

                    b.Navigation("Pracodawca");
                });

            modelBuilder.Entity("PO_project.Models.KierunekPraktyki", b =>
                {
                    b.HasOne("PO_project.Models.Kierunek", "Kierunek")
                        .WithMany("Praktyki")
                        .HasForeignKey("KierunekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PO_project.Models.Pracodawca", "Pracodawca")
                        .WithMany("Praktyki")
                        .HasForeignKey("PracodawcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kierunek");

                    b.Navigation("Pracodawca");
                });

            modelBuilder.Entity("PO_project.Models.Pracodawca", b =>
                {
                    b.HasOne("PO_project.Models.Adres", "adres")
                        .WithOne("Pracodawca")
                        .HasForeignKey("PO_project.Models.Pracodawca", "AdresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("adres");
                });

            modelBuilder.Entity("PO_project.Models.Specjalizacja", b =>
                {
                    b.HasOne("PO_project.Models.Kierunek", "kierunek")
                        .WithMany()
                        .HasForeignKey("KierunekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kierunek");
                });

            modelBuilder.Entity("PO_project.Models.Wydzial", b =>
                {
                    b.HasOne("PO_project.Models.Lokalizacja", "Lokalizacja")
                        .WithMany()
                        .HasForeignKey("LokalizacjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lokalizacja");
                });

            modelBuilder.Entity("PO_project.Models.Adres", b =>
                {
                    b.Navigation("Pracodawca");
                });

            modelBuilder.Entity("PO_project.Models.Kierunek", b =>
                {
                    b.Navigation("MiejscaPracy");

                    b.Navigation("Perpektywy");

                    b.Navigation("Praktyki");
                });

            modelBuilder.Entity("PO_project.Models.Pracodawca", b =>
                {
                    b.Navigation("MiejscaPracy");

                    b.Navigation("Perpektywy");

                    b.Navigation("Praktyki");
                });
#pragma warning restore 612, 618
        }
    }
}
