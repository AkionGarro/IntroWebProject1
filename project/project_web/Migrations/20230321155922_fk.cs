using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_web.Migrations
{
    /// <inheritdoc />
    public partial class fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "compra",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_compra_UserId",
                table: "compra",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_compra_AspNetUsers_UserId",
                table: "compra",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compra_AspNetUsers_UserId",
                table: "compra");

            migrationBuilder.DropIndex(
                name: "IX_compra_UserId",
                table: "compra");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "compra");

            migrationBuilder.AddColumn<int>(
                name: "ComprasId",
                table: "AspNetUsers",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ComprasId",
                table: "AspNetUsers",
                column: "ComprasId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_compra_ComprasId",
                table: "AspNetUsers",
                column: "ComprasId",
                principalTable: "compra",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
