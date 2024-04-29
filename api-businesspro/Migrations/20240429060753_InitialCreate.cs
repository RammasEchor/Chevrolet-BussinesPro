using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_businesspro.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccionesCampo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CveAccionesCampo = table.Column<string>(type: "TEXT", nullable: false),
                    NombreAccionesCampo = table.Column<string>(type: "TEXT", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INTEGER", nullable: true),
                    IdSucursal = table.Column<int>(type: "INTEGER", nullable: true),
                    CETipoCampana = table.Column<string>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<string>(type: "TEXT", nullable: false),
                    FechaTermino = table.Column<string>(type: "TEXT", nullable: true),
                    NombreResponsable = table.Column<string>(type: "TEXT", nullable: true),
                    KilometrajeLimite = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesCampo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccionesCampoDetalle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccionesCampoId = table.Column<long>(type: "INTEGER", nullable: false),
                    CEClasificacion = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Tiempo = table.Column<double>(type: "REAL", nullable: true),
                    Cantidad = table.Column<double>(type: "REAL", nullable: true),
                    IdParte = table.Column<string>(type: "TEXT", nullable: true),
                    CveOperacion = table.Column<string>(type: "TEXT", nullable: true),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: true),
                    CrearAccionesCampoRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesCampoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionesCampoDetalle_AccionesCampo_CrearAccionesCampoRequestId",
                        column: x => x.CrearAccionesCampoRequestId,
                        principalTable: "AccionesCampo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccionesCampoSeriesRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccionesCampoId = table.Column<long>(type: "INTEGER", nullable: false),
                    Serie = table.Column<string>(type: "TEXT", nullable: false),
                    Origen = table.Column<int>(type: "INTEGER", nullable: false),
                    BRealizado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaRealizacion = table.Column<string>(type: "TEXT", nullable: true),
                    CEDistribuidor = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioActualiza = table.Column<int>(type: "INTEGER", nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    CrearAccionesCampoRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesCampoSeriesRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionesCampoSeriesRequest_AccionesCampo_CrearAccionesCampoRequestId",
                        column: x => x.CrearAccionesCampoRequestId,
                        principalTable: "AccionesCampo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionesCampoDetalle_CrearAccionesCampoRequestId",
                table: "AccionesCampoDetalle",
                column: "CrearAccionesCampoRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesCampoSeriesRequest_CrearAccionesCampoRequestId",
                table: "AccionesCampoSeriesRequest",
                column: "CrearAccionesCampoRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccionesCampoDetalle");

            migrationBuilder.DropTable(
                name: "AccionesCampoSeriesRequest");

            migrationBuilder.DropTable(
                name: "AccionesCampo");
        }
    }
}
