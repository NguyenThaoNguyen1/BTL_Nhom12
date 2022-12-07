using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Nhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhanvien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    GioiTinhNV = table.Column<string>(type: "TEXT", nullable: true),
                    TenPB = table.Column<string>(type: "TEXT", nullable: false),
                    DiaChiNV = table.Column<string>(type: "TEXT", nullable: true),
                    EmailNV = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SDTNV = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    ChucVuNV = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanvien", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_Nhanvien_Phongban_TenPB",
                        column: x => x.TenPB,
                        principalTable: "Phongban",
                        principalColumn: "MaPB",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nhanvien_TenPB",
                table: "Nhanvien",
                column: "TenPB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhanvien");
        }
    }
}
