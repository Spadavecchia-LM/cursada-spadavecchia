using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace parcial1.EF;

public partial class MiDBContext : DbContext
{
    public MiDBContext(DbContextOptions<MiDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Titulare> Titulares { get; set; }

    public virtual DbSet<Tramite> Tramites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<Titulare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("titulares");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni)
                .HasMaxLength(45)
                .HasColumnName("dni");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tramite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tramites");

            entity.HasIndex(e => e.ProductoId, "producto_id");

            entity.HasIndex(e => e.TitularId, "titular_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaTramite)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_tramite");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.TitularId).HasColumnName("titular_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.Tramites)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tramites_ibfk_2");

            entity.HasOne(d => d.Titular).WithMany(p => p.Tramites)
                .HasForeignKey(d => d.TitularId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tramites_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
