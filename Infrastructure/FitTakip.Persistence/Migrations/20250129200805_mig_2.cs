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
            migrationBuilder.RenameColumn(
                name: "Açiklama",
                table: "Randevular",
                newName: "Aciklama");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_EgitmenId",
                table: "Kullanicilar",
                column: "EgitmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Kullanicilar_EgitmenId",
                table: "Kullanicilar",
                column: "EgitmenId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Kullanicilar_EgitmenId",
                table: "Kullanicilar");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_EgitmenId",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "Aciklama",
                table: "Randevular",
                newName: "Açiklama");
        }
    }
}
