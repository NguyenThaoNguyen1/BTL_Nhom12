using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Loaidichvu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loaidichvu",
                columns: table => new
                {
                    MaLoaiDV = table.Column<string>(type: "TEXT", nullable: false),
                    TenLoaiDV = table.Column<string>(type: "TEXT", nullable: false),
                    YeuCaudikem = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaidichvu", x => x.MaLoaiDV);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loaidichvu");
        }
    }
}
