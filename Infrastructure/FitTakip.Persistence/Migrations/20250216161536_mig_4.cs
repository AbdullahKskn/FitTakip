using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTakip.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsletmeId",
                table: "Giderler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsletmeId",
                table: "Gelirler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsletmeId",
                table: "Giderler");

            migrationBuilder.DropColumn(
                name: "IsletmeId",
                table: "Gelirler");
        }
    }
}
