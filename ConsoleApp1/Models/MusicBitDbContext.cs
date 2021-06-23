using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class MusicBitDbContext : DbContext
    {
        public MusicBitDbContext()
        {
        }

        public MusicBitDbContext(DbContextOptions<MusicBitDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artistum> Artista { get; set; }
        public virtual DbSet<Cancion> Cancions { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=localhost; Database=musicbit; Uid=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artistum>(entity =>
            {
                entity.HasKey(e => e.CveArtista)
                    .HasName("PRIMARY");

                entity.ToTable("artista");

                entity.Property(e => e.CveArtista)
                    .HasColumnType("int(11)")
                    .HasColumnName("cve_artista");

                entity.Property(e => e.NombreArtista)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_artista")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Cancion>(entity =>
            {
                entity.HasKey(e => e.CveCancion)
                    .HasName("PRIMARY");

                entity.ToTable("cancion");

                entity.HasIndex(e => e.CveartistaCancion, "FKartista_cancion");

                entity.HasIndex(e => e.CvegeneroCancion, "FKgenero_cancion");

                entity.Property(e => e.CveCancion)
                    .HasColumnType("int(11)")
                    .HasColumnName("cve_cancion");

                entity.Property(e => e.CveartistaCancion)
                    .HasColumnType("int(11)")
                    .HasColumnName("cveartista_cancion")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CvegeneroCancion)
                    .HasColumnType("int(11)")
                    .HasColumnName("cvegenero_cancion")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LetraCancion)
                    .HasColumnType("varchar(20000)")
                    .HasColumnName("letra_cancion")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreCancion)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_cancion")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CveartistaCancionNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.CveartistaCancion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKartista_cancion");

                entity.HasOne(d => d.CvegeneroCancionNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.CvegeneroCancion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKgenero_cancion");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.CveGenero)
                    .HasName("PRIMARY");

                entity.ToTable("genero");

                entity.Property(e => e.CveGenero)
                    .HasColumnType("int(11)")
                    .HasColumnName("cve_genero");

                entity.Property(e => e.NombreGenero)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_genero")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
