using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTakip.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaketId",
                table: "Uyeler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_PaketId",
                table: "Uyeler",
                column: "PaketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uyeler_Paketler_PaketId",
                table: "Uyeler",
                column: "PaketId",
                principalTable: "Paketler",
                principalColumn: "PaketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uyeler_Paketler_PaketId",
                table: "Uyeler");

            migrationBuilder.DropIndex(
                name: "IX_Uyeler_PaketId",
                table: "Uyeler");

            migrationBuilder.DropColumn(
                name: "PaketId",
                table: "Uyeler");
        }
    }
}
