using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_businesspro.Migrations
{
    /// <inheritdoc />
    public partial class VeriousItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrearOrdenRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdVehiculosVIN = table.Column<int>(type: "INTEGER", nullable: false),
                    IdOrden = table.Column<string>(type: "TEXT", nullable: false),
                    FechaHoraOrden = table.Column<string>(type: "TEXT", nullable: true),
                    IdPropietario = table.Column<int>(type: "INTEGER", nullable: true),
                    IdContacto = table.Column<int>(type: "INTEGER", nullable: true),
                    IdConductor = table.Column<int>(type: "INTEGER", nullable: true),
                    IdRespMtto = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteFacturar = table.Column<int>(type: "INTEGER", nullable: false),
                    KilometrajeActual = table.Column<int>(type: "INTEGER", nullable: false),
                    NoTorre = table.Column<string>(type: "TEXT", nullable: true),
                    CEAsesor = table.Column<string>(type: "TEXT", nullable: false),
                    CEEstatusOrden = table.Column<string>(type: "TEXT", nullable: true),
                    FechaHoraPromesaEntrega = table.Column<string>(type: "TEXT", nullable: true),
                    NoPolizaSeguro = table.Column<string>(type: "TEXT", nullable: true),
                    CEAseguradora = table.Column<string>(type: "TEXT", nullable: true),
                    NoSiniestro = table.Column<string>(type: "TEXT", nullable: true),
                    CEFormaPago = table.Column<string>(type: "TEXT", nullable: true),
                    IdServicioCita = table.Column<int>(type: "INTEGER", nullable: true),
                    FechaHoraCierreOrden = table.Column<string>(type: "TEXT", nullable: true),
                    CETipoOrden = table.Column<string>(type: "TEXT", nullable: true),
                    BAplicaIva = table.Column<int>(type: "INTEGER", nullable: false),
                    NoSalida = table.Column<double>(type: "REAL", nullable: true),
                    ImporteDeducible = table.Column<double>(type: "REAL", nullable: true),
                    NoFlotilla = table.Column<double>(type: "REAL", nullable: true),
                    CEMotivoCancelacion = table.Column<string>(type: "TEXT", nullable: true),
                    Katashiki = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroPlaca = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroEconomico = table.Column<string>(type: "TEXT", nullable: true),
                    NoEconomico = table.Column<string>(type: "TEXT", nullable: true),
                    BModificarCita = table.Column<int>(type: "INTEGER", nullable: true),
                    BCambioFechaPromesaEntrega = table.Column<int>(type: "INTEGER", nullable: true),
                    MotivoCambioFechaEntrega = table.Column<string>(type: "TEXT", nullable: true),
                    FechaProximoSevicio = table.Column<string>(type: "TEXT", nullable: true),
                    UsoCFDI = table.Column<string>(type: "TEXT", nullable: true),
                    BExpress = table.Column<int>(type: "INTEGER", nullable: true),
                    VigenciaSeguro = table.Column<string>(type: "TEXT", nullable: true),
                    BGarantiaExtendida = table.Column<int>(type: "INTEGER", nullable: true),
                    KilometrajeSalida = table.Column<int>(type: "INTEGER", nullable: true),
                    BCredito = table.Column<int>(type: "INTEGER", nullable: true),
                    IdEmpresa = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSucursal = table.Column<int>(type: "INTEGER", nullable: false),
                    Facturas = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearOrdenRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreEmpresa = table.Column<string>(type: "TEXT", nullable: false),
                    CveEmpresa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacturaRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CETipoDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    FolioDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteFactura = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaHoraDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    CEEstatusDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    IdPedido = table.Column<string>(type: "TEXT", nullable: true),
                    IdPedidoPartes = table.Column<string>(type: "TEXT", nullable: true),
                    CEFormaPago = table.Column<string>(type: "TEXT", nullable: true),
                    MontoDescuento = table.Column<double>(type: "REAL", nullable: true),
                    VentaBruta = table.Column<double>(type: "REAL", nullable: true),
                    MontoIVA = table.Column<double>(type: "REAL", nullable: true),
                    MontoTotal = table.Column<double>(type: "REAL", nullable: true),
                    BIVADesglosado = table.Column<int>(type: "INTEGER", nullable: true),
                    CEMoneda = table.Column<string>(type: "TEXT", nullable: true),
                    TipoCambio = table.Column<double>(type: "REAL", nullable: true),
                    IdEmpresa = table.Column<int>(type: "INTEGER", nullable: true),
                    IdSucursal = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrearOrdenDetalleRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Consec = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoParte = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    CEClasificacion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaHoraSolicitud = table.Column<string>(type: "TEXT", nullable: true),
                    FechaHoraInicio = table.Column<string>(type: "TEXT", nullable: true),
                    FechaHoraTermino = table.Column<string>(type: "TEXT", nullable: true),
                    CEMecanico = table.Column<string>(type: "TEXT", nullable: true),
                    UnidadTiempo = table.Column<double>(type: "REAL", nullable: true),
                    Cantidad = table.Column<double>(type: "REAL", nullable: true),
                    CantidadSurtido = table.Column<double>(type: "REAL", nullable: true),
                    FechaHoraSurtido = table.Column<string>(type: "TEXT", nullable: true),
                    PrecioUnitario = table.Column<double>(type: "REAL", nullable: true),
                    IVA = table.Column<double>(type: "REAL", nullable: true),
                    Costo = table.Column<double>(type: "REAL", nullable: true),
                    Subtotal = table.Column<double>(type: "REAL", nullable: true),
                    CEEstatusClasificacion = table.Column<string>(type: "TEXT", nullable: true),
                    CETipoPrecio = table.Column<string>(type: "TEXT", nullable: true),
                    IdPaqueteServ = table.Column<int>(type: "INTEGER", nullable: true),
                    ExistenciaPartes = table.Column<double>(type: "REAL", nullable: true),
                    NivelMO = table.Column<int>(type: "INTEGER", nullable: true),
                    CveOperacion = table.Column<string>(type: "TEXT", nullable: true),
                    NoPedidoPartes = table.Column<double>(type: "REAL", nullable: true),
                    Proveedor = table.Column<int>(type: "INTEGER", nullable: true),
                    FechaHoraPedidoParte = table.Column<string>(type: "TEXT", nullable: true),
                    FacturaTOT = table.Column<string>(type: "TEXT", nullable: true),
                    ConsecutivoTOT = table.Column<double>(type: "REAL", nullable: true),
                    IVATOT = table.Column<double>(type: "REAL", nullable: true),
                    BVentaAdicional = table.Column<int>(type: "INTEGER", nullable: true),
                    TiempoPagado = table.Column<double>(type: "REAL", nullable: true),
                    CostoPagado = table.Column<double>(type: "REAL", nullable: true),
                    DisponiblePartes = table.Column<double>(type: "REAL", nullable: true),
                    CEGrupo = table.Column<string>(type: "TEXT", nullable: true),
                    CESubgrupo = table.Column<string>(type: "TEXT", nullable: true),
                    ConsecutivoSurtido = table.Column<double>(type: "REAL", nullable: true),
                    PrecioListaPartes = table.Column<double>(type: "REAL", nullable: true),
                    PorcentajeDescuento = table.Column<double>(type: "REAL", nullable: true),
                    ImpuestoDescuento = table.Column<double>(type: "REAL", nullable: true),
                    MontoDescuento = table.Column<double>(type: "REAL", nullable: true),
                    CodigoOperacionExterna = table.Column<string>(type: "TEXT", nullable: true),
                    RenServicios = table.Column<int>(type: "INTEGER", nullable: true),
                    CETipoTrab = table.Column<string>(type: "TEXT", nullable: true),
                    FechaHoraRealOperacion = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoRealOperacion = table.Column<double>(type: "REAL", nullable: true),
                    CEMotivoCancelacion = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroChipsOperacion = table.Column<double>(type: "REAL", nullable: true),
                    RepTiempo = table.Column<double>(type: "REAL", nullable: true),
                    OrdenID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearOrdenDetalleRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrearOrdenDetalleRequest_CrearOrdenRequest_OrdenID",
                        column: x => x.OrdenID,
                        principalTable: "CrearOrdenRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrearOrdenDetalleRequest_OrdenID",
                table: "CrearOrdenDetalleRequest",
                column: "OrdenID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrearOrdenDetalleRequest");

            migrationBuilder.DropTable(
                name: "EmpresaRequest");

            migrationBuilder.DropTable(
                name: "FacturaRequest");

            migrationBuilder.DropTable(
                name: "CrearOrdenRequest");
        }
    }
}
