using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SpecialTicketWeb.Migrations
{
    /// <inheritdoc />
    public partial class IdentitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "escenario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    localizacion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'current_timestamp()'"),
                    Created_By = table.Column<int>(type: "int(11)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_By = table.Column<int>(type: "int(11)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_evento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'current_timestamp()'"),
                    Created_By = table.Column<int>(type: "int(11)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_By = table.Column<int>(type: "int(11)", nullable: false),
                    Active = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<int>(type: "int(11)", nullable: false),
                    rol = table.Column<int>(type: "int(11)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'current_timestamp()'"),
                    Created_By = table.Column<int>(type: "int(11)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_By = table.Column<int>(type: "int(11)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cantidad = table.Column<int>(type: "int(11)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'current_timestamp()'"),
                    Created_By = table.Column<int>(type: "int(11)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_By = table.Column<int>(type: "int(11)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_escenario = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "asiento_ibfk_1",
                        column: x => x.id_escenario,
                        principalTable: "escenario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "tipos de asiento del escenario")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_escenario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'current_timestamp()'"),
                    Created_By = table.Column<int>(type: "int(11)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_By = table.Column<int>(type: "int(11)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_escenario = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "tipo_escenario_ibfk_1",
                        column: x => x.id_escenario,
                        principalTable: "escenario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "evento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'current_timestamp()'"),
                    Created_By = table.Column<int>(type: "int(11)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_By = table.Column<int>(type: "int(11)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_tipo_evento = table.Column<int>(type: "int(11)", nullable: false),
                    id_escenario = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "evento_ibfk_1",
                        column: x => x.id_escenario,
                        principalTable: "escenario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "evento_ibfk_2",
                        column: x => x.id_tipo_evento,
                        principalTable: "tipo_evento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tipo_asiento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'current_timestamp()'"),
                    Created_By = table.Column<int>(type: "int(11)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated_By = table.Column<int>(type: "int(11)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_evento = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "entradas_ibfk_1",
                        column: x => x.id_evento,
                        principalTable: "evento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(type: "int(11)", nullable: false),
                    fecha_reserva = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_By = table.Column<int>(type: "int(11)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int(11)", nullable: false),
                    Active = table.Column<int>(type: "int(11)", nullable: false),
                    id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    id_entrada = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "compra_ibfk_1",
                        column: x => x.id_cliente,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "compra_ibfk_2",
                        column: x => x.id_entrada,
                        principalTable: "entradas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "id_escenario",
                table: "asiento",
                column: "id_escenario");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_cliente",
                table: "compra",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "id_entrada",
                table: "compra",
                column: "id_entrada");

            migrationBuilder.CreateIndex(
                name: "id_evento",
                table: "entradas",
                column: "id_evento");

            migrationBuilder.CreateIndex(
                name: "id_escenario1",
                table: "evento",
                column: "id_escenario");

            migrationBuilder.CreateIndex(
                name: "id_tipo_evento",
                table: "evento",
                column: "id_tipo_evento");

            migrationBuilder.CreateIndex(
                name: "id_escenario2",
                table: "tipo_escenario",
                column: "id_escenario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asiento");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "tipo_escenario");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "entradas");

            migrationBuilder.DropTable(
                name: "evento");

            migrationBuilder.DropTable(
                name: "escenario");

            migrationBuilder.DropTable(
                name: "tipo_evento");
        }
    }
}
