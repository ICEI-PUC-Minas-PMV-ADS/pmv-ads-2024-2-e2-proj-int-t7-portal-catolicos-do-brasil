using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCatolicoBrasil.Migrations
{
    /// <inheritdoc />
<<<<<<<< Updated upstream:src/PortalCatolicoBrasil/Migrations/20241025190437_MO1-AddTables.cs
    public partial class MO1AddTables : Migration
========
    public partial class M01Addtables : Migration
>>>>>>>> Stashed changes:src/PortalCatolicoBrasil/Migrations/20241105200654_M01-Addtables.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeParoquia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TituloEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    HorarioInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataEncerramento = table.Column<DateOnly>(type: "date", nullable: false),
                    HorarioEncerramento = table.Column<TimeSpan>(type: "time", nullable: false),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Igreja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeIgreja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igreja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "santo_do_dia",
                columns: table => new
                {
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_santo_do_dia", x => x.Data);
                });

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
                    Hora1 = table.Column<TimeOnly>(type: "time", nullable: true),
                    Hora2 = table.Column<TimeOnly>(type: "time", nullable: true),
                    Hora3 = table.Column<TimeOnly>(type: "time", nullable: true),
                    Hora4 = table.Column<TimeOnly>(type: "time", nullable: true),
                    Hora5 = table.Column<TimeOnly>(type: "time", nullable: true),
                    Hora6 = table.Column<TimeOnly>(type: "time", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
<<<<<<<< Updated upstream:src/PortalCatolicoBrasil/Migrations/20241025190437_MO1-AddTables.cs
                name: "HoraMissa");
========
                name: "Igreja");
>>>>>>>> Stashed changes:src/PortalCatolicoBrasil/Migrations/20241105200654_M01-Addtables.cs

            migrationBuilder.DropTable(
                name: "santo_do_dia");

            migrationBuilder.DropTable(
                name: "DiaMissa");

            migrationBuilder.DropTable(
                name: "Igreja");
        }
    }
}
