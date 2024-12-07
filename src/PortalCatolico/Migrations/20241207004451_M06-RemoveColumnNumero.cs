using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCatolico.Migrations
{
    /// <inheritdoc />
    public partial class M06RemoveColumnNumero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Eventos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
