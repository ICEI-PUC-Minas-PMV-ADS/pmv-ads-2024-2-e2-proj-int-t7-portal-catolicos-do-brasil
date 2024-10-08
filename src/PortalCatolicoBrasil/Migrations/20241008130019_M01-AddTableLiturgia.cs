using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCatolicoBrasil.Migrations
{
    public partial class M01AddTableLiturgia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "antifona",
                columns: table => new
                {
                    AntifonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ofertorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comunhao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_antifona", x => x.AntifonaID);
                });

            migrationBuilder.CreateTable(
                name: "evangelho",
                columns: table => new
                {
                    EvangelhoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evangelho", x => x.EvangelhoID);
                });

            migrationBuilder.CreateTable(
                name: "primeira_leitura",
                columns: table => new
                {
                    PrimeiraLeituraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primeira_leitura", x => x.PrimeiraLeituraID);
                });

            migrationBuilder.CreateTable(
                name: "salmo",
                columns: table => new
                {
                    SalmoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refrao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salmo", x => x.SalmoID);
                });

            migrationBuilder.CreateTable(
                name: "liturgia",
                columns: table => new
                {
                    LiturgiaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiturgiaText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oferendas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comunhao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimeiraLeituraID = table.Column<int>(type: "int", nullable: true),
                    SegundaLeitura = table.Column<string>(type: "int", nullable: true),
                    SalmoID = table.Column<int>(type: "int", nullable: true),
                    EvangelhoID = table.Column<int>(type: "int", nullable: true),
                    AntifonaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liturgias", x => x.LiturgiaID);
                    table.ForeignKey(
                        name: "FK_Liturgias_antifona_AntifonaID",
                        column: x => x.AntifonaID,
                        principalTable: "antifona",
                        principalColumn: "AntifonaID");
                    table.ForeignKey(
                        name: "FK_Liturgias_evangelho_EvangelhoID",
                        column: x => x.EvangelhoID,
                        principalTable: "evangelho",
                        principalColumn: "EvangelhoID");
                    table.ForeignKey(
                        name: "FK_Liturgias_primeira_leitura_PrimeiraLeituraID",
                        column: x => x.PrimeiraLeituraID,
                        principalTable: "primeira_leitura",
                        principalColumn: "PrimeiraLeituraID");
                    table.ForeignKey(
                        name: "FK_Liturgias_salmo_SalmoID",
                        column: x => x.SalmoID,
                        principalTable: "salmo",
                        principalColumn: "SalmoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Liturgias_AntifonaID",
                table: "Liturgia",
                column: "AntifonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Liturgias_EvangelhoID",
                table: "Liturgia",
                column: "EvangelhoID");

            migrationBuilder.CreateIndex(
                name: "IX_Liturgias_PrimeiraLeituraID",
                table: "Liturgia",
                column: "PrimeiraLeituraID");

            migrationBuilder.CreateIndex(
                name: "IX_Liturgias_SalmoID",
                table: "Liturgia",
                column: "SalmoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Liturgia");

            migrationBuilder.DropTable(
                name: "antifona");

            migrationBuilder.DropTable(
                name: "evangelho");

            migrationBuilder.DropTable(
                name: "primeira_leitura");

            migrationBuilder.DropTable(
                name: "salmo");
        }
    }
}
