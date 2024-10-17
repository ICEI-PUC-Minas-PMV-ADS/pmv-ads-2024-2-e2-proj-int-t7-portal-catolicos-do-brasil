using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCatolicoBrasil.Migrations
{
    /// <inheritdoc />
    public partial class M01AddTableEventos : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
