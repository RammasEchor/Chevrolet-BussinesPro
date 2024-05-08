using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_businesspro.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrearCitaRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CveCitaExterna = table.Column<string>(type: "TEXT", nullable: false),
                    CEAsesor = table.Column<string>(type: "TEXT", nullable: false),
                    CEEstatusCita = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCita = table.Column<string>(type: "TEXT", nullable: false),
                    HoraCita = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCitaReal = table.Column<string>(type: "TEXT", nullable: true),
                    HoraCitaReal = table.Column<string>(type: "TEXT", nullable: true),
                    FechaEntrega = table.Column<string>(type: "TEXT", nullable: true),
                    HoraEntrega = table.Column<string>(type: "TEXT", nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    Per_idpersona = table.Column<int>(type: "INTEGER", nullable: true),
                    AnModelo = table.Column<int>(type: "INTEGER", nullable: true),
                    IdUnidadesCatalogo = table.Column<string>(type: "TEXT", nullable: true),
                    Placas = table.Column<string>(type: "TEXT", nullable: true),
                    CveUsuario = table.Column<int>(type: "INTEGER", nullable: true),
                    IdOrden = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroSerie = table.Column<string>(type: "TEXT", nullable: true),
                    Propietario = table.Column<int>(type: "INTEGER", nullable: true),
                    Contacto = table.Column<int>(type: "INTEGER", nullable: true),
                    Conductor = table.Column<int>(type: "INTEGER", nullable: true),
                    CEMarca = table.Column<string>(type: "TEXT", nullable: true),
                    Kilometraje = table.Column<string>(type: "TEXT", nullable: true),
                    MortivoServicio = table.Column<string>(type: "TEXT", nullable: true),
                    CEColorExterior = table.Column<string>(type: "TEXT", nullable: true),
                    CEColorInterior = table.Column<string>(type: "TEXT", nullable: true),
                    BServicioCitaRepro = table.Column<bool>(type: "INTEGER", nullable: true),
                    IdServicioCitaRepro = table.Column<int>(type: "INTEGER", nullable: true),
                    BConfirmacion = table.Column<bool>(type: "INTEGER", nullable: true),
                    FechaDOFU = table.Column<string>(type: "TEXT", nullable: true),
                    IdDocInterf = table.Column<string>(type: "TEXT", nullable: true),
                    BServicioExpress = table.Column<bool>(type: "INTEGER", nullable: true),
                    InterfazOrigen = table.Column<string>(type: "TEXT", nullable: true),
                    ObsExternas = table.Column<string>(type: "TEXT", nullable: true),
                    MedioTransporte = table.Column<string>(type: "TEXT", nullable: true),
                    IdEmpresa = table.Column<int>(type: "INTEGER", nullable: true),
                    IdSucursal = table.Column<int>(type: "INTEGER", nullable: true),
                    ResponsableMtto = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearCitaRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrearAccionesCampoRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CitaID = table.Column<long>(type: "INTEGER", nullable: true),
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
                    table.PrimaryKey("PK_CrearAccionesCampoRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrearAccionesCampoRequest_CrearCitaRequest_CitaID",
                        column: x => x.CitaID,
                        principalTable: "CrearCitaRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrearPaqueteRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CvePaqueteServ = table.Column<string>(type: "TEXT", nullable: false),
                    NombrePaqueteServ = table.Column<string>(type: "TEXT", nullable: false),
                    Origen = table.Column<int>(type: "INTEGER", nullable: false),
                    DescripcionPaqueteServ = table.Column<string>(type: "TEXT", nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    PrecioUT = table.Column<double>(type: "REAL", nullable: false),
                    MoCosto = table.Column<double>(type: "REAL", nullable: false),
                    MoVenta = table.Column<double>(type: "REAL", nullable: false),
                    ReCosto = table.Column<double>(type: "REAL", nullable: false),
                    ReVenta = table.Column<double>(type: "REAL", nullable: false),
                    TtCosto = table.Column<double>(type: "REAL", nullable: false),
                    TtVenta = table.Column<double>(type: "REAL", nullable: false),
                    PorIva = table.Column<double>(type: "REAL", nullable: false),
                    FechaCTref = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCTprecio = table.Column<string>(type: "TEXT", nullable: true),
                    Kilometraje = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSucursal = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTaller = table.Column<string>(type: "TEXT", nullable: true),
                    BExclusivo = table.Column<string>(type: "TEXT", nullable: false),
                    CitaID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearPaqueteRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrearPaqueteRequest_CrearCitaRequest_CitaID",
                        column: x => x.CitaID,
                        principalTable: "CrearCitaRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccionesCampoDetalleRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccionCampoID = table.Column<long>(type: "INTEGER", nullable: false),
                    CEClasificacion = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Tiempo = table.Column<double>(type: "REAL", nullable: true),
                    Cantidad = table.Column<double>(type: "REAL", nullable: true),
                    IdParte = table.Column<string>(type: "TEXT", nullable: true),
                    CveOperacion = table.Column<string>(type: "TEXT", nullable: true),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesCampoDetalleRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionesCampoDetalleRequest_CrearAccionesCampoRequest_AccionCampoID",
                        column: x => x.AccionCampoID,
                        principalTable: "CrearAccionesCampoRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccionesCampoSeriesRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccionCampoID = table.Column<long>(type: "INTEGER", nullable: false),
                    Serie = table.Column<string>(type: "TEXT", nullable: false),
                    Origen = table.Column<int>(type: "INTEGER", nullable: false),
                    BRealizado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaRealizacion = table.Column<string>(type: "TEXT", nullable: true),
                    CEDistribuidor = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioActualiza = table.Column<int>(type: "INTEGER", nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesCampoSeriesRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionesCampoSeriesRequest_CrearAccionesCampoRequest_AccionCampoID",
                        column: x => x.AccionCampoID,
                        principalTable: "CrearAccionesCampoRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrearPaqueteOperacionesResquest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CvePaqueteServ = table.Column<string>(type: "TEXT", nullable: true),
                    IdPaqueteServConse = table.Column<int>(type: "INTEGER", nullable: false),
                    CveOperacion = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    TipoMO = table.Column<int>(type: "INTEGER", nullable: false),
                    NivelMO = table.Column<int>(type: "INTEGER", nullable: false),
                    UnidadesTimpo = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioVenta = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoEreact = table.Column<string>(type: "TEXT", nullable: true),
                    RepTiempo = table.Column<string>(type: "TEXT", nullable: true),
                    PaqueteID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearPaqueteOperacionesResquest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrearPaqueteOperacionesResquest_CrearPaqueteRequest_PaqueteID",
                        column: x => x.PaqueteID,
                        principalTable: "CrearPaqueteRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrearPaquetePartesResquet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdParte = table.Column<string>(type: "TEXT", nullable: true),
                    CvePaqueteServ = table.Column<string>(type: "TEXT", nullable: true),
                    CantidadPartes = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoPrecio = table.Column<string>(type: "TEXT", nullable: true),
                    PrecioUnitario = table.Column<int>(type: "INTEGER", nullable: false),
                    CtoUniEst = table.Column<int>(type: "INTEGER", nullable: false),
                    PaqueteID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearPaquetePartesResquet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrearPaquetePartesResquet_CrearPaqueteRequest_PaqueteID",
                        column: x => x.PaqueteID,
                        principalTable: "CrearPaqueteRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrearPaqueteTotsResquest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CvePaqueteServ = table.Column<string>(type: "TEXT", nullable: true),
                    IdPaqueteServConse = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    TipoTT = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioVenta = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProveedor = table.Column<int>(type: "INTEGER", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoEreact = table.Column<string>(type: "TEXT", nullable: true),
                    PaqueteID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearPaqueteTotsResquest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrearPaqueteTotsResquest_CrearPaqueteRequest_PaqueteID",
                        column: x => x.PaqueteID,
                        principalTable: "CrearPaqueteRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrearPaqueteVehiculoResquest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCatalogo = table.Column<string>(type: "TEXT", nullable: true),
                    Modelo = table.Column<string>(type: "TEXT", nullable: true),
                    CvePaqueteServ = table.Column<string>(type: "TEXT", nullable: true),
                    PaqueteID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearPaqueteVehiculoResquest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrearPaqueteVehiculoResquest_CrearPaqueteRequest_PaqueteID",
                        column: x => x.PaqueteID,
                        principalTable: "CrearPaqueteRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionesCampoDetalleRequest_AccionCampoID",
                table: "AccionesCampoDetalleRequest",
                column: "AccionCampoID");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesCampoSeriesRequest_AccionCampoID",
                table: "AccionesCampoSeriesRequest",
                column: "AccionCampoID");

            migrationBuilder.CreateIndex(
                name: "IX_CrearAccionesCampoRequest_CitaID",
                table: "CrearAccionesCampoRequest",
                column: "CitaID");

            migrationBuilder.CreateIndex(
                name: "IX_CrearPaqueteOperacionesResquest_PaqueteID",
                table: "CrearPaqueteOperacionesResquest",
                column: "PaqueteID");

            migrationBuilder.CreateIndex(
                name: "IX_CrearPaquetePartesResquet_PaqueteID",
                table: "CrearPaquetePartesResquet",
                column: "PaqueteID");

            migrationBuilder.CreateIndex(
                name: "IX_CrearPaqueteRequest_CitaID",
                table: "CrearPaqueteRequest",
                column: "CitaID");

            migrationBuilder.CreateIndex(
                name: "IX_CrearPaqueteTotsResquest_PaqueteID",
                table: "CrearPaqueteTotsResquest",
                column: "PaqueteID");

            migrationBuilder.CreateIndex(
                name: "IX_CrearPaqueteVehiculoResquest_PaqueteID",
                table: "CrearPaqueteVehiculoResquest",
                column: "PaqueteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccionesCampoDetalleRequest");

            migrationBuilder.DropTable(
                name: "AccionesCampoSeriesRequest");

            migrationBuilder.DropTable(
                name: "CrearPaqueteOperacionesResquest");

            migrationBuilder.DropTable(
                name: "CrearPaquetePartesResquet");

            migrationBuilder.DropTable(
                name: "CrearPaqueteTotsResquest");

            migrationBuilder.DropTable(
                name: "CrearPaqueteVehiculoResquest");

            migrationBuilder.DropTable(
                name: "CrearAccionesCampoRequest");

            migrationBuilder.DropTable(
                name: "CrearPaqueteRequest");

            migrationBuilder.DropTable(
                name: "CrearCitaRequest");
        }
    }
}
