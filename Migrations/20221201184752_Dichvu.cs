using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Dichvu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dichvu",
                columns: table => new
                {
                    MaDV = table.Column<string>(type: "TEXT", nullable: false),
                    MaLoaiDV = table.Column<string>(type: "TEXT", nullable: true),
                    TenDV = table.Column<string>(type: "TEXT", nullable: false),
                    DonViTinh = table.Column<string>(type: "TEXT", nullable: true),
                    DonGia = table.Column<string>(type: "TEXT", nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dichvu", x => x.MaDV);
                    table.ForeignKey(
                        name: "FK_Dichvu_Loaidichvu_MaLoaiDV",
                        column: x => x.MaLoaiDV,
                        principalTable: "Loaidichvu",
                        principalColumn: "MaLoaiDV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dichvu_MaLoaiDV",
                table: "Dichvu",
                column: "MaLoaiDV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dichvu");
        }
    }
}
