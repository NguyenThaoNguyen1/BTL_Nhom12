using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLPTPMQLNHOM12.Migrations
{
    /// <inheritdoc />
    public partial class Nguoiquanli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nguoiquanli",
                columns: table => new
                {
                    MaQL = table.Column<string>(type: "TEXT", nullable: false),
                    TenQL = table.Column<string>(type: "TEXT", nullable: true),
                    TenPB = table.Column<string>(type: "TEXT", nullable: true),
                    SoTKNQL = table.Column<string>(type: "TEXT", nullable: true),
                    DiaChiNQL = table.Column<string>(type: "TEXT", nullable: true),
                    SDTNQl = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    EmailNQL = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoiquanli", x => x.MaQL);
                    table.ForeignKey(
                        name: "FK_Nguoiquanli_Phongban_TenPB",
                        column: x => x.TenPB,
                        principalTable: "Phongban",
                        principalColumn: "MaPB");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nguoiquanli_TenPB",
                table: "Nguoiquanli",
                column: "TenPB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nguoiquanli");
        }
    }
}
