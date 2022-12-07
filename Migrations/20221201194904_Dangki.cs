using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Dangki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dangki",
                columns: table => new
                {
                    MaDK = table.Column<string>(type: "TEXT", nullable: false),
                    MaKH = table.Column<string>(type: "TEXT", nullable: true),
                    MaDV = table.Column<string>(type: "TEXT", nullable: true),
                    NgayDangKi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SoLuong = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dangki", x => x.MaDK);
                    table.ForeignKey(
                        name: "FK_Dangki_Dichvu_MaDV",
                        column: x => x.MaDV,
                        principalTable: "Dichvu",
                        principalColumn: "MaDV");
                    table.ForeignKey(
                        name: "FK_Dangki_Khachhang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "Khachhang",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dangki_MaDV",
                table: "Dangki",
                column: "MaDV");

            migrationBuilder.CreateIndex(
                name: "IX_Dangki_MaKH",
                table: "Dangki",
                column: "MaKH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dangki");
        }
    }
}
