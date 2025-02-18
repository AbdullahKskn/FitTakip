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
                name: "Adminler",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SifreKarmasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Gelirler",
                columns: table => new
                {
                    GelirId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsletmeId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gelirler", x => x.GelirId);
                });

            migrationBuilder.CreateTable(
                name: "Giderler",
                columns: table => new
                {
                    GiderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsletmeId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giderler", x => x.GiderId);
                });

            migrationBuilder.CreateTable(
                name: "Isletmeler",
                columns: table => new
                {
                    IsletmeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SifreKarmasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbonelikSonlanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isletmeler", x => x.IsletmeId);
                });

            migrationBuilder.CreateTable(
                name: "Egitmenler",
                columns: table => new
                {
                    EgitmenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SifreKarmasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsletmeId = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmenler", x => x.EgitmenId);
                    table.ForeignKey(
                        name: "FK_Egitmenler_Isletmeler_IsletmeId",
                        column: x => x.IsletmeId,
                        principalTable: "Isletmeler",
                        principalColumn: "IsletmeId");
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    UyeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KalanDersSayisi = table.Column<int>(type: "int", nullable: false),
                    IsletmeId = table.Column<int>(type: "int", nullable: false),
                    EgitmenId = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.UyeId);
                    table.ForeignKey(
                        name: "FK_Uyeler_Egitmenler_EgitmenId",
                        column: x => x.EgitmenId,
                        principalTable: "Egitmenler",
                        principalColumn: "EgitmenId");
                    table.ForeignKey(
                        name: "FK_Uyeler_Isletmeler_IsletmeId",
                        column: x => x.IsletmeId,
                        principalTable: "Isletmeler",
                        principalColumn: "IsletmeId");
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
                    Kilo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                        name: "FK_Olcumler_Uyeler_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Uyeler",
                        principalColumn: "UyeId");
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
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuId);
                    table.ForeignKey(
                        name: "FK_Randevular_Egitmenler_EgitmenId",
                        column: x => x.EgitmenId,
                        principalTable: "Egitmenler",
                        principalColumn: "EgitmenId");
                    table.ForeignKey(
                        name: "FK_Randevular_Uyeler_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Uyeler",
                        principalColumn: "UyeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adminler_KullaniciAdi",
                table: "Adminler",
                column: "KullaniciAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Egitmenler_IsletmeId",
                table: "Egitmenler",
                column: "IsletmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Egitmenler_KullaniciAdi",
                table: "Egitmenler",
                column: "KullaniciAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Isletmeler_KullaniciAdi",
                table: "Isletmeler",
                column: "KullaniciAdi",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_EgitmenId",
                table: "Uyeler",
                column: "EgitmenId");

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_IsletmeId",
                table: "Uyeler",
                column: "IsletmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminler");

            migrationBuilder.DropTable(
                name: "Gelirler");

            migrationBuilder.DropTable(
                name: "Giderler");

            migrationBuilder.DropTable(
                name: "Olcumler");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Uyeler");

            migrationBuilder.DropTable(
                name: "Egitmenler");

            migrationBuilder.DropTable(
                name: "Isletmeler");
        }
    }
}
