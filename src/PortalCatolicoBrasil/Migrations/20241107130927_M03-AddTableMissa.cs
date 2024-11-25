using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCatolicoBrasil.Migrations
{
    /// <inheritdoc />
    public partial class M03AddTableMissa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoraMissa");

            migrationBuilder.DropTable(
                name: "DiaMissa");

            migrationBuilder.CreateTable(
                name: "Missa",
                columns: table => new
                {
                    MissaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IgrejaId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hora = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missa", x => x.MissaId);
                    table.ForeignKey(
                        name: "FK_Missa_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missa_IgrejaId",
                table: "Missa",
                column: "IgrejaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Missa");

            migrationBuilder.CreateTable(
                name: "DiaMissa",
                columns: table => new
                {
                    DiaMissaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IgrejaId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaMissa", x => x.DiaMissaId);
                    table.ForeignKey(
                        name: "FK_DiaMissa_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoraMissa",
                columns: table => new
                {
                    HoraMissaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaMissaId = table.Column<int>(type: "int", nullable: false),
                    Hora1 = table.Column<TimeOnly>(type: "time", nullable: false),
                    Hora2 = table.Column<TimeOnly>(type: "time", nullable: false),
                    Hora3 = table.Column<TimeOnly>(type: "time", nullable: false),
                    Hora4 = table.Column<TimeOnly>(type: "time", nullable: false),
                    Hora5 = table.Column<TimeOnly>(type: "time", nullable: false),
                    Hora6 = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraMissa", x => x.HoraMissaId);
                    table.ForeignKey(
                        name: "FK_HoraMissa_DiaMissa_DiaMissaId",
                        column: x => x.DiaMissaId,
                        principalTable: "DiaMissa",
                        principalColumn: "DiaMissaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaMissa_IgrejaId",
                table: "DiaMissa",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraMissa_DiaMissaId",
                table: "HoraMissa",
                column: "DiaMissaId");
        }
    }
}
