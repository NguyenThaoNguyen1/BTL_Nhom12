using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Giaonhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Giaonhan",
                columns: table => new
                {
                    MaQL = table.Column<string>(type: "TEXT", nullable: false),
                    MaNV = table.Column<string>(type: "TEXT", nullable: true),
                    MaDV = table.Column<string>(type: "TEXT", nullable: true),
                    TrangThaiHienTai = table.Column<string>(type: "TEXT", nullable: true),
                    NgayGiao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NgayHoanThanh = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giaonhan", x => x.MaQL);
                    table.ForeignKey(
                        name: "FK_Giaonhan_Dichvu_MaDV",
                        column: x => x.MaDV,
                        principalTable: "Dichvu",
                        principalColumn: "MaDV");
                    table.ForeignKey(
                        name: "FK_Giaonhan_Nguoiquanli_MaQL",
                        column: x => x.MaQL,
                        principalTable: "Nguoiquanli",
                        principalColumn: "MaQL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Giaonhan_Nhanvien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "Nhanvien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Giaonhan_MaDV",
                table: "Giaonhan",
                column: "MaDV");

            migrationBuilder.CreateIndex(
                name: "IX_Giaonhan_MaNV",
                table: "Giaonhan",
                column: "MaNV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giaonhan");
        }
    }
}
