using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class PhuongThucTT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhuongThucTT",
                columns: table => new
                {
                    MaPT = table.Column<string>(type: "TEXT", nullable: false),
                    PhuongThucthanhToan = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucTT", x => x.MaPT);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhuongThucTT");
        }
    }
}
