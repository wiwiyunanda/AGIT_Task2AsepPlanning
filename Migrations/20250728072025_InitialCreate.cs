using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2AsepPlanning.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plannings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Senin = table.Column<int>(type: "int", nullable: false),
                    Selasa = table.Column<int>(type: "int", nullable: false),
                    Rabu = table.Column<int>(type: "int", nullable: false),
                    Kamis = table.Column<int>(type: "int", nullable: false),
                    Jumat = table.Column<int>(type: "int", nullable: false),
                    Sabtu = table.Column<int>(type: "int", nullable: false),
                    Minggu = table.Column<int>(type: "int", nullable: false),
                    SeninResult = table.Column<int>(type: "int", nullable: false),
                    SelasaResult = table.Column<int>(type: "int", nullable: false),
                    RabuResult = table.Column<int>(type: "int", nullable: false),
                    KamisResult = table.Column<int>(type: "int", nullable: false),
                    JumatResult = table.Column<int>(type: "int", nullable: false),
                    SabtuResult = table.Column<int>(type: "int", nullable: false),
                    MingguResult = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plannings");
        }
    }
}
