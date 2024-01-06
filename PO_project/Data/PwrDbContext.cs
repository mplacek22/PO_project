using PO_project.Models;
using Microsoft.EntityFrameworkCore;

namespace PO_project.Data
{
    public class PwrDbContext : DbContext
    {
        public PwrDbContext(DbContextOptions<PwrDbContext> options) : base(options){}
        public DbSet<Stopien> Stopnie { get; set; }
        public DbSet<Jezyk> Jezyki { get; set; }
        public DbSet<CzasTrwania> CzasyTrwania { get; set; }
        public DbSet<Lokalizacja> Lokalizacje { get; set; }
        public DbSet<Tryb> Tryby { get; set; }
        public DbSet<Wydzial> Wydzialy { get; set; }
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Pracodawca> Pracodawcy { get; set; }
        public DbSet<Kierunek> Kierunki { get; set; }
        public DbSet<Specjalizacja> Specjalizacje { get; set; }
        public DbSet<KierunekPraktyki> Praktyki { get; set; }
        public DbSet<KierunekPerspektywy> Perspektywy { get; set; }
        public DbSet<HistoryczneDane> HistoryczneDane { get; set; }
        public DbSet<KierunekMiejscaPracy> MiejscaPracy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            //modelBuilder.Entity<Wydzial>()
            //    .HasOne(c => c.Lokalizacja)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<PO_project.Models.Pytanie> Pytanie { get; set; } = default!;

    }
}
