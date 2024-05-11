using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramitesVisas.API.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gerentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Edad = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVisas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVisas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSolicitud = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaAgenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: true),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    TipoVisasId = table.Column<int>(type: "int", nullable: true),
                    IdTipoVisa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Personas_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Solicitudes_TipoVisas_TipoVisasId",
                        column: x => x.TipoVisasId,
                        principalTable: "TipoVisas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaSubida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SolicitudesId = table.Column<int>(type: "int", nullable: true),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Solicitudes_SolicitudesId",
                        column: x => x.SolicitudesId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Historiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoEvento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SolicitudesId = table.Column<int>(type: "int", nullable: true),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historiales_Solicitudes_SolicitudesId",
                        column: x => x.SolicitudesId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolicitudesId = table.Column<int>(type: "int", nullable: true),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Solicitudes_SolicitudesId",
                        column: x => x.SolicitudesId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Renovaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRenovacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SolicitudesId = table.Column<int>(type: "int", nullable: true),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renovaciones_Solicitudes_SolicitudesId",
                        column: x => x.SolicitudesId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_SolicitudesId",
                table: "Documentos",
                column: "SolicitudesId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_SolicitudesId",
                table: "Historiales",
                column: "SolicitudesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_SolicitudesId",
                table: "Pagos",
                column: "SolicitudesId");

            migrationBuilder.CreateIndex(
                name: "IX_Renovaciones_SolicitudesId",
                table: "Renovaciones",
                column: "SolicitudesId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_PersonasId",
                table: "Solicitudes",
                column: "PersonasId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_TipoVisasId",
                table: "Solicitudes",
                column: "TipoVisasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Gerentes");

            migrationBuilder.DropTable(
                name: "Historiales");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Renovaciones");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TipoVisas");
        }
    }
}
