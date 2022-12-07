using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Kyhopdong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kyhopdong",
                columns: table => new
                {
                    SoHD = table.Column<string>(type: "TEXT", nullable: false),
                    MaQL = table.Column<string>(type: "TEXT", nullable: true),
                    MaKH = table.Column<string>(type: "TEXT", nullable: true),
                    MaDV = table.Column<string>(type: "TEXT", nullable: true),
                    NoiDung = table.Column<string>(type: "TEXT", nullable: false),
                    DiaDiem = table.Column<string>(type: "TEXT", nullable: false),
                    NgayKi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ThoiGianThanhToan = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "TEXT", nullable: true),
                    TrachNhiemChung = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kyhopdong", x => x.SoHD);
                    table.ForeignKey(
                        name: "FK_Kyhopdong_Dichvu_MaDV",
                        column: x => x.MaDV,
                        principalTable: "Dichvu",
                        principalColumn: "MaDV");
                    table.ForeignKey(
                        name: "FK_Kyhopdong_Khachhang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "Khachhang",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK_Kyhopdong_Nguoiquanli_MaQL",
                        column: x => x.MaQL,
                        principalTable: "Nguoiquanli",
                        principalColumn: "MaQL");
                    table.ForeignKey(
                        name: "FK_Kyhopdong_PhuongThucTT_PhuongThucThanhToan",
                        column: x => x.PhuongThucThanhToan,
                        principalTable: "PhuongThucTT",
                        principalColumn: "MaPT");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kyhopdong_MaDV",
                table: "Kyhopdong",
                column: "MaDV");

            migrationBuilder.CreateIndex(
                name: "IX_Kyhopdong_MaKH",
                table: "Kyhopdong",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_Kyhopdong_MaQL",
                table: "Kyhopdong",
                column: "MaQL");

            migrationBuilder.CreateIndex(
                name: "IX_Kyhopdong_PhuongThucThanhToan",
                table: "Kyhopdong",
                column: "PhuongThucThanhToan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kyhopdong");
        }
    }
}
