using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCatolicoBrasil.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:src/PortalCatolicoBrasil/Migrations/20241016142253_M01-AddTableEventos.cs
    public partial class M01AddTableEventos : Migration
========
    public partial class M06AddtableMissa : Migration
>>>>>>>> c05d6f1c47fea78abfeb312f5deff51d5bac9760:src/PortalCatolicoBrasil/Migrations/20241018142940_M06-AddtableMissa.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastroDeMissas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeParoquia = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CadastroDeMissas", x => x.Id);
                });

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
<<<<<<<< HEAD:src/PortalCatolicoBrasil/Migrations/20241016142253_M01-AddTableEventos.cs
========

            migrationBuilder.CreateTable(
                name: "santo_do_dia",
                columns: table => new
                {
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_santo_do_dia", x => x.data);
                });
>>>>>>>> c05d6f1c47fea78abfeb312f5deff51d5bac9760:src/PortalCatolicoBrasil/Migrations/20241018142940_M06-AddtableMissa.cs
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<<< HEAD:src/PortalCatolicoBrasil/Migrations/20241016142253_M01-AddTableEventos.cs
                name: "Eventos");
========
                name: "CadastroDeMissas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "santo_do_dia");
>>>>>>>> c05d6f1c47fea78abfeb312f5deff51d5bac9760:src/PortalCatolicoBrasil/Migrations/20241018142940_M06-AddtableMissa.cs
        }
    }
}
