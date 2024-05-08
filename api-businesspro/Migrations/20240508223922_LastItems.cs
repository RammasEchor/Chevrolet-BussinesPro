using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_businesspro.Migrations
{
    /// <inheritdoc />
    public partial class LastItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrearUnidadRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CveCatalogo = table.Column<string>(type: "TEXT", nullable: false),
                    AnModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    CEMarca = table.Column<string>(type: "TEXT", nullable: true),
                    CEClase = table.Column<string>(type: "TEXT", nullable: true),
                    CELinea = table.Column<string>(type: "TEXT", nullable: true),
                    ClaveVehicular = table.Column<string>(type: "TEXT", nullable: true),
                    CEPuertas = table.Column<string>(type: "TEXT", nullable: true),
                    CEClilindros = table.Column<string>(type: "TEXT", nullable: true),
                    Cm3 = table.Column<double>(type: "REAL", nullable: true),
                    Potencia = table.Column<int>(type: "INTEGER", nullable: true),
                    CECombustible = table.Column<string>(type: "TEXT", nullable: true),
                    CECapacidadPasajeros = table.Column<string>(type: "TEXT", nullable: true),
                    CETransmision = table.Column<string>(type: "TEXT", nullable: true),
                    CEFamilia = table.Column<string>(type: "TEXT", nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    CETipoMotor = table.Column<string>(type: "TEXT", nullable: true),
                    ToneladasCarga = table.Column<double>(type: "REAL", nullable: true),
                    NumeroLlantas = table.Column<int>(type: "INTEGER", nullable: true),
                    CodigoModelo = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoPlanta = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoMotor = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoTransmision = table.Column<string>(type: "TEXT", nullable: true),
                    CETipoTraccion = table.Column<string>(type: "TEXT", nullable: true),
                    CEPaisOrigen = table.Column<string>(type: "TEXT", nullable: true),
                    Torque = table.Column<int>(type: "INTEGER", nullable: true),
                    Suspension = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDireccion = table.Column<string>(type: "TEXT", nullable: true),
                    TipoFrenos = table.Column<string>(type: "TEXT", nullable: true),
                    VoltajeBateria = table.Column<double>(type: "REAL", nullable: true),
                    KmXLitro = table.Column<double>(type: "REAL", nullable: true),
                    CETipoInterior = table.Column<string>(type: "TEXT", nullable: true),
                    DistanciaEjes = table.Column<double>(type: "REAL", nullable: true),
                    VelocidadMaxima = table.Column<int>(type: "INTEGER", nullable: true),
                    PresoBrutoVe = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearUnidadRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoOtrasMarcasRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OTMModelo = table.Column<string>(type: "TEXT", nullable: true),
                    OTMTipoAuto = table.Column<string>(type: "TEXT", nullable: true),
                    CEOTMMarca = table.Column<string>(type: "TEXT", nullable: true),
                    OTMTipoMotor = table.Column<string>(type: "TEXT", nullable: true),
                    OTMCilindros = table.Column<string>(type: "TEXT", nullable: true),
                    OTMTransmision = table.Column<string>(type: "TEXT", nullable: true),
                    OTMTraccion = table.Column<string>(type: "TEXT", nullable: true),
                    CEOTMColorExt = table.Column<string>(type: "TEXT", nullable: true),
                    CEOTMColorInt = table.Column<string>(type: "TEXT", nullable: true),
                    OTMNoMotor = table.Column<string>(type: "TEXT", nullable: true),
                    OTMPuertas = table.Column<string>(type: "TEXT", nullable: true),
                    OTMCapacidad = table.Column<string>(type: "TEXT", nullable: true),
                    OTMCombustible = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoOtrasMarcasRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadColorRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUnidadesCatalogoColor = table.Column<int>(type: "INTEGER", nullable: false),
                    CETipoColor = table.Column<string>(type: "TEXT", nullable: false),
                    UnidadID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadColorRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadColorRequest_CrearUnidadRequest_UnidadID",
                        column: x => x.UnidadID,
                        principalTable: "CrearUnidadRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrearVehiculoRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CEOrigenUnidad = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroSerie = table.Column<string>(type: "TEXT", nullable: false),
                    IdVehiculosVINOrigen = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroPlaca = table.Column<string>(type: "TEXT", nullable: true),
                    IdUnidadesCatalogoColorInt = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUnidadesCatalogoColorExt = table.Column<int>(type: "INTEGER", nullable: true),
                    NumeroMotor = table.Column<string>(type: "TEXT", nullable: true),
                    FechaVenta = table.Column<string>(type: "TEXT", nullable: true),
                    CEDistribuidorVendedor = table.Column<string>(type: "TEXT", nullable: true),
                    IdUnidadesCatalogo = table.Column<int>(type: "INTEGER", nullable: true),
                    UltimoKilometraje = table.Column<double>(type: "REAL", nullable: true),
                    GarantiaExtendida = table.Column<string>(type: "TEXT", nullable: true),
                    NoInventario = table.Column<double>(type: "REAL", nullable: true),
                    CESituacion = table.Column<string>(type: "TEXT", nullable: true),
                    CEUbicacion = table.Column<string>(type: "TEXT", nullable: true),
                    IdPropietario = table.Column<int>(type: "INTEGER", nullable: true),
                    IdConductor = table.Column<int>(type: "INTEGER", nullable: true),
                    IdContacto = table.Column<int>(type: "INTEGER", nullable: true),
                    IdRespMtto = table.Column<int>(type: "INTEGER", nullable: true),
                    NumeroEntrega = table.Column<double>(type: "REAL", nullable: true),
                    FechaEntrega = table.Column<string>(type: "TEXT", nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    NoSerieAlternativo = table.Column<string>(type: "TEXT", nullable: true),
                    NoEconomico = table.Column<string>(type: "TEXT", nullable: true),
                    IdEmpresa = table.Column<int>(type: "INTEGER", nullable: true),
                    IdSucursal = table.Column<int>(type: "INTEGER", nullable: true),
                    OtrasmarcasId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearVehiculoRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrearVehiculoRequest_VehiculoOtrasMarcasRequest_OtrasmarcasId",
                        column: x => x.OtrasmarcasId,
                        principalTable: "VehiculoOtrasMarcasRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrearVehiculoRequest_OtrasmarcasId",
                table: "CrearVehiculoRequest",
                column: "OtrasmarcasId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadColorRequest_UnidadID",
                table: "UnidadColorRequest",
                column: "UnidadID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrearVehiculoRequest");

            migrationBuilder.DropTable(
                name: "UnidadColorRequest");

            migrationBuilder.DropTable(
                name: "VehiculoOtrasMarcasRequest");

            migrationBuilder.DropTable(
                name: "CrearUnidadRequest");
        }
    }
}
