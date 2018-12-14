using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kvotesystemet.Models
{
    public partial class kvotesystem_SQLSQLContext : DbContext
    {
        public kvotesystem_SQLSQLContext()
        {
        }

        public kvotesystem_SQLSQLContext(DbContextOptions<kvotesystem_SQLSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblKundelisteMedForskjelligeNummer> TblKundelisteMedForskjelligeNummer { get; set; }
        public virtual DbSet<TblKvotedefinisjoner> TblKvotedefinisjoner { get; set; }
        public virtual DbSet<TblKvotefilerFraZalaris> TblKvotefilerFraZalaris { get; set; }
        public virtual DbSet<TblMaterialMaster> TblMaterialMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.98.4.60;Database=kvotesystem_SQLSQL;User ID=kvotesystemet;Password=kvotesystemet;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblKundelisteMedForskjelligeNummer>(entity =>
            {
                entity.HasKey(e => e.Ansattnr);

                entity.ToTable("tbl_kundeliste_med_forskjellige_nummer");

                entity.Property(e => e.C47Navn)
                    .HasColumnName("C47 Navn")
                    .HasMaxLength(255);

                entity.Property(e => e.C47Nummer).HasColumnName("C47 nummer");

                entity.Property(e => e.Etternavn).HasMaxLength(255);

                entity.Property(e => e.Fornavn).HasMaxLength(255);

                entity.Property(e => e.T0e)
                    .HasColumnName("T0E")
                    .HasMaxLength(255);

                entity.Property(e => e.T0eNavn)
                    .HasColumnName("T0E Navn")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TblKvotedefinisjoner>(entity =>
            {
                entity.HasKey(e => e.Kvote)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Tbl_Kvotedefinisjoner");

                entity.Property(e => e.Kvote)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.UpsizeTs)
                    .HasColumnName("upsize_ts")
                    .IsRowVersion();
            });

            modelBuilder.Entity<TblKvotefilerFraZalaris>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Tbl_Kvotefiler fra Zalaris");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ansettelsesdato).HasMaxLength(255);

                entity.Property(e => e.Brus).HasDefaultValueSql("((0))");

                entity.Property(e => e.Etternavn).HasMaxLength(255);

                entity.Property(e => e.Fornavn).HasMaxLength(255);

                entity.Property(e => e.GratisBrus).HasColumnName("Gratis_brus");

                entity.Property(e => e.Kvotekode).HasMaxLength(255);

                entity.Property(e => e.OppdatertDato)
                    .HasColumnName("Oppdatert_dato")
                    .HasColumnType("datetime");

                entity.Property(e => e.SalgsDato)
                    .HasColumnName("Salgs_dato")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.Stilling).HasMaxLength(255);

                entity.Property(e => e.StillingStatus)
                    .HasColumnName("Stilling_status")
                    .HasMaxLength(255);

                entity.Property(e => e.UpsizeTs)
                    .HasColumnName("upsize_ts")
                    .IsRowVersion();
            });

            modelBuilder.Entity<TblMaterialMaster>(entity =>
            {
                entity.HasKey(e => e.Bsp1)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Tbl_Material_master");

                entity.Property(e => e.Bsp1).HasColumnName("BSP1");

                entity.Property(e => e.IkkeTillatt)
                    .HasColumnName("Ikke tillatt")
                    .HasMaxLength(255);

                entity.Property(e => e.Mg1)
                    .HasColumnName("MG1")
                    .HasMaxLength(255);

                entity.Property(e => e.Tekst).HasMaxLength(255);

                entity.Property(e => e.UpsizeTs)
                    .HasColumnName("upsize_ts")
                    .IsRowVersion();
            });
        }
    }
}
