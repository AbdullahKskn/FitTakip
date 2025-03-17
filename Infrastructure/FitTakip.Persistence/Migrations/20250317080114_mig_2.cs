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
            migrationBuilder.AddColumn<long>(
                name: "PaketId",
                table: "Randevular",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PaketId",
                table: "Randevular",
                column: "PaketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Paketler_PaketId",
                table: "Randevular",
                column: "PaketId",
                principalTable: "Paketler",
                principalColumn: "PaketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Paketler_PaketId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_PaketId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "PaketId",
                table: "Randevular");
        }
    }
}
