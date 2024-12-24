using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTakip.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SifreKarmasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KalanDersSayisi = table.Column<int>(type: "int", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AbonelikSonlanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsletmeId = table.Column<int>(type: "int", nullable: true),
                    EgitmenId = table.Column<int>(type: "int", nullable: true),
                    Statu = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Olcumler",
                columns: table => new
                {
                    OlcumId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boy = table.Column<int>(type: "int", nullable: false),
                    Kilo = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Omuz = table.Column<int>(type: "int", nullable: false),
                    Gogus = table.Column<int>(type: "int", nullable: false),
                    SagKol = table.Column<int>(type: "int", nullable: false),
                    SolKol = table.Column<int>(type: "int", nullable: false),
                    Bel = table.Column<int>(type: "int", nullable: false),
                    Kalca = table.Column<int>(type: "int", nullable: false),
                    SagBacak = table.Column<int>(type: "int", nullable: false),
                    SolBacak = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olcumler", x => x.OlcumId);
                    table.ForeignKey(
                        name: "FK_Olcumler_Kullanicilar_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeId = table.Column<int>(type: "int", nullable: false),
                    EgitmenId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Açiklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuId);
                    table.ForeignKey(
                        name: "FK_Randevular_Kullanicilar_EgitmenId",
                        column: x => x.EgitmenId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId");
                    table.ForeignKey(
                        name: "FK_Randevular_Kullanicilar_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Olcumler_UyeId",
                table: "Olcumler",
                column: "UyeId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_EgitmenId",
                table: "Randevular",
                column: "EgitmenId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_UyeId",
                table: "Randevular",
                column: "UyeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Olcumler");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
