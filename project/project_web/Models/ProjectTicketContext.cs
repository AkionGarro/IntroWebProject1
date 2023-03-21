using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace project_web.Models;

public partial class ProjectTicketContext : IdentityDbContext
{
    public ProjectTicketContext()
    {
    }

    public ProjectTicketContext(DbContextOptions<ProjectTicketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asiento> Asientos { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Entrada> Entradas { get; set; }

    public virtual DbSet<Escenario> Escenarios { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<TipoEscenario> TipoEscenarios { get; set; }

    public virtual DbSet<TipoEvento> TipoEventos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=specialticket;User=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Asiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asiento", tb => tb.HasComment("tipos de asiento del escenario"));

            entity.HasIndex(e => e.IdEscenario, "id_escenario");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasColumnType("int(11)")
                .HasColumnName("cantidad");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Created_By");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdEscenario)
                .HasColumnType("int(11)")
                .HasColumnName("id_escenario");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.IdEscenarioNavigation).WithMany(p => p.Asientos)
                .HasForeignKey(d => d.IdEscenario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("asiento_ibfk_1");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("compra");

            entity.HasIndex(e => e.IdEntrada, "id_entrada");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnType("int(11)");
            entity.Property(e => e.Cantidad)
                .HasColumnType("int(11)")
                .HasColumnName("cantidad");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Created_By");
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.FechaReserva)
                .HasColumnType("datetime")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(255)
                .HasColumnName("id_cliente");
            entity.Property(e => e.IdEntrada)
                .HasColumnType("int(11)")
                .HasColumnName("id_entrada");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnType("int(11)");

            entity.HasOne(d => d.IdEntradaNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdEntrada)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("compra_ibfk_2");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("entradas");

            entity.HasIndex(e => e.IdEvento, "id_evento");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Created_By");
            entity.Property(e => e.Disponibles)
                .HasColumnType("int(11)")
                .HasColumnName("disponibles");
            entity.Property(e => e.IdEvento)
                .HasColumnType("int(11)")
                .HasColumnName("id_evento");
            entity.Property(e => e.Precio)
                .HasPrecision(10)
                .HasColumnName("precio");
            entity.Property(e => e.TipoAsiento)
                .HasMaxLength(100)
                .HasColumnName("tipo_asiento");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("entradas_ibfk_1");
        });

        modelBuilder.Entity<Escenario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("escenario");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Created_By");
            entity.Property(e => e.Localizacion)
                .HasMaxLength(100)
                .HasColumnName("localizacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("evento");

            entity.HasIndex(e => e.IdEscenario, "id_escenario");

            entity.HasIndex(e => e.IdTipoEvento, "id_tipo_evento");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Created_By");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdEscenario)
                .HasColumnType("int(11)")
                .HasColumnName("id_escenario");
            entity.Property(e => e.IdTipoEvento)
                .HasColumnType("int(11)")
                .HasColumnName("id_tipo_evento");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.IdEscenarioNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdEscenario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("evento_ibfk_1");

            entity.HasOne(d => d.IdTipoEventoNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdTipoEvento)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("evento_ibfk_2");
        });

        modelBuilder.Entity<TipoEscenario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipo_escenario");

            entity.HasIndex(e => e.IdEscenario, "id_escenario");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Created_By");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdEscenario)
                .HasColumnType("int(11)")
                .HasColumnName("id_escenario");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Updated_By");

            entity.HasOne(d => d.IdEscenarioNavigation).WithMany(p => p.TipoEscenarios)
                .HasForeignKey(d => d.IdEscenario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("tipo_escenario_ibfk_1");
        });

        modelBuilder.Entity<TipoEvento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipo_evento");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Created_By");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("int(11)")
                .HasColumnName("Updated_By");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
