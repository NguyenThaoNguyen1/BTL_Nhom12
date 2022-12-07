using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Phongban : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phongban",
                columns: table => new
                {
                    MaPB = table.Column<string>(type: "TEXT", nullable: false),
                    TenPB = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongban", x => x.MaPB);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phongban");
        }
    }
}
