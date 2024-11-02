using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCatolicoBrasil.Migrations
{
    /// <inheritdoc />
    public partial class EditNameTableSntoDia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_santo_do_dia",
                table: "santo_do_dia");

            migrationBuilder.RenameTable(
                name: "santo_do_dia",
                newName: "SantoDia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SantoDia",
                table: "SantoDia",
                column: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SantoDia",
                table: "SantoDia");

            migrationBuilder.RenameTable(
                name: "SantoDia",
                newName: "santo_do_dia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_santo_do_dia",
                table: "santo_do_dia",
                column: "Data");
        }
    }
}
