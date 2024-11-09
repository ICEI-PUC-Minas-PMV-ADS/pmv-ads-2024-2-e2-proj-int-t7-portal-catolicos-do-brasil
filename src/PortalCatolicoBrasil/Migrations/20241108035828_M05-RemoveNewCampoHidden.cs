using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCatolicoBrasil.Migrations
{
    /// <inheritdoc />
    public partial class M05RemoveNewCampoHidden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Igreja");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Igreja",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
