using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnicosRegistros.Migrations
{
    /// <inheritdoc />
    public partial class Tecnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Tecnicos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Tecnicos");
        }
    }
}
