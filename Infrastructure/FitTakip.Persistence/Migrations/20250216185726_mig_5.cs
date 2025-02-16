using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTakip.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fiyat",
                table: "Giderler",
                newName: "Tutar");

            migrationBuilder.RenameColumn(
                name: "Fiyat",
                table: "Gelirler",
                newName: "Tutar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tutar",
                table: "Giderler",
                newName: "Fiyat");

            migrationBuilder.RenameColumn(
                name: "Tutar",
                table: "Gelirler",
                newName: "Fiyat");
        }
    }
}
