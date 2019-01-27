using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Api_Karttapaikat.Models
{
    public partial class PaikkaDbContext : DbContext
    {
        public PaikkaDbContext()
        {
        }

        public PaikkaDbContext(DbContextOptions<PaikkaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kiertue> Kiertue { get; set; }
        public virtual DbSet<KiertueEtappi> KiertueEtappi { get; set; }
        public virtual DbSet<PaikanTyyppi> PaikanTyyppi { get; set; }
        public virtual DbSet<Paikkamerkinta> Paikkamerkinta { get; set; }
        public virtual DbSet<Siirtymistapa> Siirtymistapa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-BKNS57P\\SQLEXPRESS;Database=PaikkaDb;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=tcp:paikkadb.database.windows.net,1433;Initial Catalog=PaikkaDbAzure;Persist Security Info=False;User ID=xxx;Password=xxx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kiertue>(entity =>
            {
                entity.Property(e => e.KiertueId).HasColumnName("kiertueId");

                entity.Property(e => e.Kuvaus)
                    .HasColumnName("kuvaus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SiirtymistapaId).HasColumnName("siirtymistapaId");

                entity.HasOne(d => d.Siirtymistapa)
                    .WithMany(p => p.Kiertue)
                    .HasForeignKey(d => d.SiirtymistapaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kiertue_Siirtymistapa");
            });

            modelBuilder.Entity<KiertueEtappi>(entity =>
            {
                entity.HasKey(e => e.EtappiId);

                entity.Property(e => e.EtappiId).HasColumnName("etappiId");

                entity.Property(e => e.KiertueId).HasColumnName("kiertueId");

                entity.Property(e => e.PaikkaId).HasColumnName("paikkaId");

                entity.HasOne(d => d.Kiertue)
                    .WithMany(p => p.KiertueEtappi)
                    .HasForeignKey(d => d.KiertueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KiertueEtappi_Kiertue");

                entity.HasOne(d => d.Paikka)
                    .WithMany(p => p.KiertueEtappi)
                    .HasForeignKey(d => d.PaikkaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KiertueEtappi_Paikkamerkinta");
            });

            modelBuilder.Entity<PaikanTyyppi>(entity =>
            {
                entity.HasKey(e => e.TyyppiId);

                entity.Property(e => e.TyyppiId).HasColumnName("tyyppiId");

                entity.Property(e => e.Tyyppi)
                    .IsRequired()
                    .HasColumnName("tyyppi")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paikkamerkinta>(entity =>
            {
                entity.HasKey(e => e.PaikkaId);

                entity.Property(e => e.PaikkaId).HasColumnName("paikkaId");

                entity.Property(e => e.Kuvaus)
                    .HasColumnName("kuvaus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.TyyppiId).HasColumnName("tyyppiId");

                entity.HasOne(d => d.Tyyppi)
                    .WithMany(p => p.Paikkamerkinta)
                    .HasForeignKey(d => d.TyyppiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paikkamerkinta_PaikanTyyppi");
            });

            modelBuilder.Entity<Siirtymistapa>(entity =>
            {
                entity.HasKey(e => e.TapaId);

                entity.Property(e => e.TapaId).HasColumnName("tapaId");

                entity.Property(e => e.Selite)
                    .HasColumnName("selite")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
