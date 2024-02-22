using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Inicial_Structure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Residente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    deudor = table.Column<bool>(type: "boolean", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    inicio = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    fin = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AreaComun",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    capacidad_maxima = table.Column<int>(type: "integer", nullable: false),
                    estado = table.Column<string>(type: "text", nullable: false),
                    fin_cierre = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    turno_id = table.Column<Guid>(type: "uuid", nullable: false),
                    condominio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaComun", x => x.id);
                    table.ForeignKey(
                        name: "FK_AreaComun_Condominio_condominio_id",
                        column: x => x.condominio_id,
                        principalTable: "Condominio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AreaComun_Turno_turno_id",
                        column: x => x.turno_id,
                        principalTable: "Turno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    estado = table.Column<string>(type: "text", nullable: false),
                    inicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    fin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    area_comun_id = table.Column<Guid>(type: "uuid", nullable: false),
                    residente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reserva_AreaComun_area_comun_id",
                        column: x => x.area_comun_id,
                        principalTable: "AreaComun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Residente_residente_id",
                        column: x => x.residente_id,
                        principalTable: "Residente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaComun_condominio_id",
                table: "AreaComun",
                column: "condominio_id");

            migrationBuilder.CreateIndex(
                name: "IX_AreaComun_turno_id",
                table: "AreaComun",
                column: "turno_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_area_comun_id",
                table: "Reserva",
                column: "area_comun_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_residente_id",
                table: "Reserva",
                column: "residente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "AreaComun");

            migrationBuilder.DropTable(
                name: "Residente");

            migrationBuilder.DropTable(
                name: "Condominio");

            migrationBuilder.DropTable(
                name: "Turno");
        }
    }
}
