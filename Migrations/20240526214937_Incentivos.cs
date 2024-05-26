using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnicosRegistros.Migrations
{
    /// <inheritdoc />
    public partial class Incentivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Incentivo",
                table: "TiposTecnicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Incentivos",
                columns: table => new
                {
                    IncentivoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TecnicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    CantidadServicios = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incentivos", x => x.IncentivoId);
                    table.ForeignKey(
                        name: "FK_Incentivos_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "TecnicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_TipoTecnicoId",
                table: "Tecnicos",
                column: "TipoTecnicoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incentivos_TecnicoId",
                table: "Incentivos",
                column: "TecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnicos_TiposTecnicos_TipoTecnicoId",
                table: "Tecnicos",
                column: "TipoTecnicoId",
                principalTable: "TiposTecnicos",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tecnicos_TiposTecnicos_TipoTecnicoId",
                table: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Incentivos");

            migrationBuilder.DropIndex(
                name: "IX_Tecnicos_TipoTecnicoId",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "Incentivo",
                table: "TiposTecnicos");
        }
    }
}
