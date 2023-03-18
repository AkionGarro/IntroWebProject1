﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_web.Models;

#nullable disable

namespace project_web.Migrations
{
    [DbContext(typeof(ProjectTicketContext))]
    [Migration("20230318200711_Identidad")]
    partial class Identidad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("project_web.Models.Asiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int(11)")
                        .HasColumnName("cantidad");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created_At")
                        .HasDefaultValueSql("'current_timestamp()'");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Created_By");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.Property<int>("IdEscenario")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_escenario");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Updated_At");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Updated_By");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEscenario" }, "id_escenario");

                    b.ToTable("asiento", null, t =>
                        {
                            t.HasComment("tipos de asiento del escenario");
                        });
                });

            modelBuilder.Entity("project_web.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("Active")
                        .HasColumnType("int(11)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int(11)")
                        .HasColumnName("cantidad");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Created_At");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Created_By");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_pago");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_reserva");

                    b.Property<string>("IdCliente")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id_cliente");

                    b.Property<int>("IdEntrada")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_entrada");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Updated_At");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int(11)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEntrada" }, "id_entrada");

                    b.ToTable("compra", (string)null);
                });

            modelBuilder.Entity("project_web.Models.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created_At")
                        .HasDefaultValueSql("'current_timestamp()'");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Created_By");

                    b.Property<int>("Disponibles")
                        .HasColumnType("int(11)")
                        .HasColumnName("disponibles");

                    b.Property<int>("IdEvento")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_evento");

                    b.Property<decimal>("Precio")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("precio");

                    b.Property<string>("TipoAsiento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("tipo_asiento");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Updated_At");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Updated_By");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEvento" }, "id_evento");

                    b.ToTable("entradas", (string)null);
                });

            modelBuilder.Entity("project_web.Models.Escenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created_At")
                        .HasDefaultValueSql("'current_timestamp()'");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Created_By");

                    b.Property<string>("Localizacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("localizacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Updated_At");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Updated_By");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("escenario", (string)null);
                });

            modelBuilder.Entity("project_web.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created_At")
                        .HasDefaultValueSql("'current_timestamp()'");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Created_By");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha");

                    b.Property<int>("IdEscenario")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_escenario");

                    b.Property<int>("IdTipoEvento")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_tipo_evento");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Updated_At");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Updated_By");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEscenario" }, "id_escenario")
                        .HasDatabaseName("id_escenario1");

                    b.HasIndex(new[] { "IdTipoEvento" }, "id_tipo_evento");

                    b.ToTable("evento", (string)null);
                });

            modelBuilder.Entity("project_web.Models.TipoEscenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created_At")
                        .HasDefaultValueSql("'current_timestamp()'");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Created_By");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.Property<int>("IdEscenario")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_escenario");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Updated_At");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Updated_By");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEscenario" }, "id_escenario")
                        .HasDatabaseName("id_escenario2");

                    b.ToTable("tipo_escenario", (string)null);
                });

            modelBuilder.Entity("project_web.Models.TipoEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("Active")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created_At")
                        .HasDefaultValueSql("'current_timestamp()'");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Created_By");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Updated_At");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int(11)")
                        .HasColumnName("Updated_By");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipo_evento", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project_web.Models.Asiento", b =>
                {
                    b.HasOne("project_web.Models.Escenario", "IdEscenarioNavigation")
                        .WithMany("Asientos")
                        .HasForeignKey("IdEscenario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("asiento_ibfk_1");

                    b.Navigation("IdEscenarioNavigation");
                });

            modelBuilder.Entity("project_web.Models.Compra", b =>
                {
                    b.HasOne("project_web.Models.Entrada", "IdEntradaNavigation")
                        .WithMany("Compras")
                        .HasForeignKey("IdEntrada")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("compra_ibfk_2");

                    b.Navigation("IdEntradaNavigation");
                });

            modelBuilder.Entity("project_web.Models.Entrada", b =>
                {
                    b.HasOne("project_web.Models.Evento", "IdEventoNavigation")
                        .WithMany("Entrada")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("entradas_ibfk_1");

                    b.Navigation("IdEventoNavigation");
                });

            modelBuilder.Entity("project_web.Models.Evento", b =>
                {
                    b.HasOne("project_web.Models.Escenario", "IdEscenarioNavigation")
                        .WithMany("Eventos")
                        .HasForeignKey("IdEscenario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("evento_ibfk_1");

                    b.HasOne("project_web.Models.TipoEvento", "IdTipoEventoNavigation")
                        .WithMany("Eventos")
                        .HasForeignKey("IdTipoEvento")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("evento_ibfk_2");

                    b.Navigation("IdEscenarioNavigation");

                    b.Navigation("IdTipoEventoNavigation");
                });

            modelBuilder.Entity("project_web.Models.TipoEscenario", b =>
                {
                    b.HasOne("project_web.Models.Escenario", "IdEscenarioNavigation")
                        .WithMany("TipoEscenarios")
                        .HasForeignKey("IdEscenario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("tipo_escenario_ibfk_1");

                    b.Navigation("IdEscenarioNavigation");
                });

            modelBuilder.Entity("project_web.Models.Entrada", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("project_web.Models.Escenario", b =>
                {
                    b.Navigation("Asientos");

                    b.Navigation("Eventos");

                    b.Navigation("TipoEscenarios");
                });

            modelBuilder.Entity("project_web.Models.Evento", b =>
                {
                    b.Navigation("Entrada");
                });

            modelBuilder.Entity("project_web.Models.TipoEvento", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
