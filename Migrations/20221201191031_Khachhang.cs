using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Khachhang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khachhang",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "TEXT", nullable: false),
                    TenKH = table.Column<string>(type: "TEXT", nullable: false),
                    CoQuanKH = table.Column<string>(type: "TEXT", nullable: true),
                    SoTKKH = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    TenNH = table.Column<string>(type: "TEXT", nullable: true),
                    DiaChiKH = table.Column<string>(type: "TEXT", nullable: false),
                    SDTKH = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    EmailKH = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhang", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK_Khachhang_Nganhang_TenNH",
                        column: x => x.TenNH,
                        principalTable: "Nganhang",
                        principalColumn: "MaNH");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Khachhang_TenNH",
                table: "Khachhang",
                column: "TenNH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Khachhang");
        }
    }
}
