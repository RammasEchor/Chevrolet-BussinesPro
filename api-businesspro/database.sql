CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "CrearCitaRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearCitaRequest" PRIMARY KEY AUTOINCREMENT,
    "CveCitaExterna" TEXT NOT NULL,
    "CEAsesor" TEXT NOT NULL,
    "CEEstatusCita" TEXT NOT NULL,
    "FechaCita" TEXT NOT NULL,
    "HoraCita" TEXT NOT NULL,
    "FechaCitaReal" TEXT NULL,
    "HoraCitaReal" TEXT NULL,
    "FechaEntrega" TEXT NULL,
    "HoraEntrega" TEXT NULL,
    "Observaciones" TEXT NULL,
    "Per_idpersona" INTEGER NULL,
    "AnModelo" INTEGER NULL,
    "IdUnidadesCatalogo" TEXT NULL,
    "Placas" TEXT NULL,
    "CveUsuario" INTEGER NULL,
    "IdOrden" TEXT NULL,
    "NumeroSerie" TEXT NULL,
    "Propietario" INTEGER NULL,
    "Contacto" INTEGER NULL,
    "Conductor" INTEGER NULL,
    "CEMarca" TEXT NULL,
    "Kilometraje" TEXT NULL,
    "MortivoServicio" TEXT NULL,
    "CEColorExterior" TEXT NULL,
    "CEColorInterior" TEXT NULL,
    "BServicioCitaRepro" INTEGER NULL,
    "IdServicioCitaRepro" INTEGER NULL,
    "BConfirmacion" INTEGER NULL,
    "FechaDOFU" TEXT NULL,
    "IdDocInterf" TEXT NULL,
    "BServicioExpress" INTEGER NULL,
    "InterfazOrigen" TEXT NULL,
    "ObsExternas" TEXT NULL,
    "MedioTransporte" TEXT NULL,
    "IdEmpresa" INTEGER NULL,
    "IdSucursal" INTEGER NULL,
    "ResponsableMtto" INTEGER NULL
);

CREATE TABLE "CrearOrdenRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearOrdenRequest" PRIMARY KEY AUTOINCREMENT,
    "IdVehiculosVIN" INTEGER NOT NULL,
    "IdOrden" TEXT NOT NULL,
    "FechaHoraOrden" TEXT NULL,
    "IdPropietario" INTEGER NULL,
    "IdContacto" INTEGER NULL,
    "IdConductor" INTEGER NULL,
    "IdRespMtto" INTEGER NULL,
    "ClienteFacturar" INTEGER NOT NULL,
    "KilometrajeActual" INTEGER NOT NULL,
    "NoTorre" TEXT NULL,
    "CEAsesor" TEXT NOT NULL,
    "CEEstatusOrden" TEXT NULL,
    "FechaHoraPromesaEntrega" TEXT NULL,
    "NoPolizaSeguro" TEXT NULL,
    "CEAseguradora" TEXT NULL,
    "NoSiniestro" TEXT NULL,
    "CEFormaPago" TEXT NULL,
    "IdServicioCita" INTEGER NULL,
    "FechaHoraCierreOrden" TEXT NULL,
    "CETipoOrden" TEXT NULL,
    "BAplicaIva" INTEGER NOT NULL,
    "NoSalida" REAL NULL,
    "ImporteDeducible" REAL NULL,
    "NoFlotilla" REAL NULL,
    "CEMotivoCancelacion" TEXT NULL,
    "Katashiki" TEXT NULL,
    "NumeroPlaca" TEXT NULL,
    "NumeroEconomico" TEXT NULL,
    "NoEconomico" TEXT NULL,
    "BModificarCita" INTEGER NULL,
    "BCambioFechaPromesaEntrega" INTEGER NULL,
    "MotivoCambioFechaEntrega" TEXT NULL,
    "FechaProximoSevicio" TEXT NULL,
    "UsoCFDI" TEXT NULL,
    "BExpress" INTEGER NULL,
    "VigenciaSeguro" TEXT NULL,
    "BGarantiaExtendida" INTEGER NULL,
    "KilometrajeSalida" INTEGER NULL,
    "BCredito" INTEGER NULL,
    "IdEmpresa" INTEGER NOT NULL,
    "IdSucursal" INTEGER NOT NULL,
    "Facturas" TEXT NULL
);

CREATE TABLE "CrearUnidadRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearUnidadRequest" PRIMARY KEY AUTOINCREMENT,
    "CveCatalogo" TEXT NOT NULL,
    "AnModelo" INTEGER NOT NULL,
    "Descripcion" TEXT NULL,
    "CEMarca" TEXT NULL,
    "CEClase" TEXT NULL,
    "CELinea" TEXT NULL,
    "ClaveVehicular" TEXT NULL,
    "CEPuertas" TEXT NULL,
    "CEClilindros" TEXT NULL,
    "Cm3" REAL NULL,
    "Potencia" INTEGER NULL,
    "CECombustible" TEXT NULL,
    "CECapacidadPasajeros" TEXT NULL,
    "CETransmision" TEXT NULL,
    "CEFamilia" TEXT NULL,
    "Observaciones" TEXT NULL,
    "CETipoMotor" TEXT NULL,
    "ToneladasCarga" REAL NULL,
    "NumeroLlantas" INTEGER NULL,
    "CodigoModelo" TEXT NULL,
    "CodigoPlanta" TEXT NULL,
    "CodigoMotor" TEXT NULL,
    "CodigoTransmision" TEXT NULL,
    "CETipoTraccion" TEXT NULL,
    "CEPaisOrigen" TEXT NULL,
    "Torque" INTEGER NULL,
    "Suspension" TEXT NULL,
    "TipoDireccion" TEXT NULL,
    "TipoFrenos" TEXT NULL,
    "VoltajeBateria" REAL NULL,
    "KmXLitro" REAL NULL,
    "CETipoInterior" TEXT NULL,
    "DistanciaEjes" REAL NULL,
    "VelocidadMaxima" INTEGER NULL,
    "PresoBrutoVe" REAL NULL
);

CREATE TABLE "EmpresaRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_EmpresaRequest" PRIMARY KEY AUTOINCREMENT,
    "NombreEmpresa" TEXT NOT NULL,
    "CveEmpresa" TEXT NOT NULL
);

CREATE TABLE "FacturaRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_FacturaRequest" PRIMARY KEY AUTOINCREMENT,
    "CETipoDocumento" TEXT NOT NULL,
    "FolioDocumento" TEXT NOT NULL,
    "ClienteFactura" INTEGER NOT NULL,
    "FechaHoraDocumento" TEXT NULL,
    "CEEstatusDocumento" TEXT NULL,
    "IdPedido" TEXT NULL,
    "IdPedidoPartes" TEXT NULL,
    "CEFormaPago" TEXT NULL,
    "MontoDescuento" REAL NULL,
    "VentaBruta" REAL NULL,
    "MontoIVA" REAL NULL,
    "MontoTotal" REAL NULL,
    "BIVADesglosado" INTEGER NULL,
    "CEMoneda" TEXT NULL,
    "TipoCambio" REAL NULL,
    "IdEmpresa" INTEGER NULL,
    "IdSucursal" INTEGER NULL
);

CREATE TABLE "PersonaDatosFisicaRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaDatosFisicaRequest" PRIMARY KEY AUTOINCREMENT,
    "Pdf_sexo" INTEGER NULL,
    "Pdf_nacionalidad" TEXT NULL,
    "Tit_idtitulo" INTEGER NULL,
    "Edc_idedocivil" INTEGER NULL,
    "Pai_paisnacimiento" INTEGER NULL,
    "Per_fechanacimiento" TEXT NULL,
    "Per_curp" TEXT NULL,
    "Per_situacionlaboral" TEXT NULL,
    "Per_empresa" TEXT NULL,
    "Per_puestoocupa" TEXT NULL,
    "Per_antiguedadlaboral" TEXT NULL,
    "Per_ingresomensual" REAL NULL,
    "Paisnacionalidad" INTEGER NULL,
    "Id_acteconomica" INTEGER NULL,
    "Paisnumtel" TEXT NULL
);

CREATE TABLE "PersonaDatosMoralRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaDatosMoralRequest" PRIMARY KEY AUTOINCREMENT,
    "Pdm_lugarescritura" TEXT NULL,
    "Pmd_fechaconstitutiva" TEXT NULL,
    "Pmd_fechainscripcion" TEXT NULL,
    "Pdm_nombrerepresentantelegal" TEXT NULL,
    "Tps_idtiposociedad" INTEGER NULL,
    "Pdm_numeroescritura" INTEGER NULL,
    "Pdm_libro" TEXT NULL,
    "Pdm_folio" TEXT NULL,
    "Pdm_volumen" TEXT NULL,
    "Pdm_numeroescriturarepresentantelegal" INTEGER NULL,
    "Pdm_librorepresentantelegal" TEXT NULL,
    "Pdm_foliorepresentantelegal" TEXT NULL,
    "Pdm_volumenrepresentantelegal" TEXT NULL,
    "Pdm_lugarrepresentantelegal" TEXT NULL,
    "Pdm_fechainscripcionrepresentantelegal" TEXT NULL,
    "Paisnacionalidad" INTEGER NULL,
    "Id_acteconomica" INTEGER NULL,
    "Paisnumtel" TEXT NULL,
    "Actaconst" TEXT NULL,
    "Fideicomiso" TEXT NULL,
    "Idreppermoral" INTEGER NULL,
    "Rpublicoestado" TEXT NULL,
    "Rpublicofecha" TEXT NULL,
    "Rpubliconumero" TEXT NULL,
    "Rlegalestado" TEXT NULL,
    "Rlegalnotario" TEXT NULL,
    "Rlegalnotnumero" TEXT NULL,
    "Tnotarialestado" TEXT NULL,
    "Tnotarialnotnumero" TEXT NULL,
    "Tnotarialnotario" TEXT NULL,
    "Tnotarialnumero" TEXT NULL
);

CREATE TABLE "SucursalRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_SucursalRequest" PRIMARY KEY AUTOINCREMENT,
    "IdEmpresa" INTEGER NOT NULL,
    "NombreSucursal" TEXT NOT NULL,
    "CveSucursal" TEXT NOT NULL
);

CREATE TABLE "VehiculoOtrasMarcasRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_VehiculoOtrasMarcasRequest" PRIMARY KEY AUTOINCREMENT,
    "OTMModelo" TEXT NULL,
    "OTMTipoAuto" TEXT NULL,
    "CEOTMMarca" TEXT NULL,
    "OTMTipoMotor" TEXT NULL,
    "OTMCilindros" TEXT NULL,
    "OTMTransmision" TEXT NULL,
    "OTMTraccion" TEXT NULL,
    "CEOTMColorExt" TEXT NULL,
    "CEOTMColorInt" TEXT NULL,
    "OTMNoMotor" TEXT NULL,
    "OTMPuertas" TEXT NULL,
    "OTMCapacidad" TEXT NULL,
    "OTMCombustible" TEXT NULL
);

CREATE TABLE "CrearAccionesCampoRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearAccionesCampoRequest" PRIMARY KEY AUTOINCREMENT,
    "CitaID" INTEGER NULL,
    "CveAccionesCampo" TEXT NOT NULL,
    "NombreAccionesCampo" TEXT NOT NULL,
    "IdEmpresa" INTEGER NULL,
    "IdSucursal" INTEGER NULL,
    "CETipoCampana" TEXT NOT NULL,
    "FechaInicio" TEXT NOT NULL,
    "FechaTermino" TEXT NULL,
    "NombreResponsable" TEXT NULL,
    "KilometrajeLimite" INTEGER NULL,
    CONSTRAINT "FK_CrearAccionesCampoRequest_CrearCitaRequest_CitaID" FOREIGN KEY ("CitaID") REFERENCES "CrearCitaRequest" ("Id")
);

CREATE TABLE "CrearPaqueteRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearPaqueteRequest" PRIMARY KEY AUTOINCREMENT,
    "CvePaqueteServ" TEXT NOT NULL,
    "NombrePaqueteServ" TEXT NOT NULL,
    "Origen" INTEGER NOT NULL,
    "DescripcionPaqueteServ" TEXT NULL,
    "Observaciones" TEXT NULL,
    "PrecioUT" REAL NOT NULL,
    "MoCosto" REAL NOT NULL,
    "MoVenta" REAL NOT NULL,
    "ReCosto" REAL NOT NULL,
    "ReVenta" REAL NOT NULL,
    "TtCosto" REAL NOT NULL,
    "TtVenta" REAL NOT NULL,
    "PorIva" REAL NOT NULL,
    "FechaCTref" TEXT NULL,
    "FechaCTprecio" TEXT NULL,
    "Kilometraje" INTEGER NOT NULL,
    "IdEmpresa" INTEGER NOT NULL,
    "IdSucursal" INTEGER NOT NULL,
    "IdTaller" TEXT NULL,
    "BExclusivo" TEXT NOT NULL,
    "CitaID" INTEGER NULL,
    CONSTRAINT "FK_CrearPaqueteRequest_CrearCitaRequest_CitaID" FOREIGN KEY ("CitaID") REFERENCES "CrearCitaRequest" ("Id")
);

CREATE TABLE "CrearOrdenDetalleRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearOrdenDetalleRequest" PRIMARY KEY AUTOINCREMENT,
    "Consec" INTEGER NOT NULL,
    "CodigoParte" TEXT NULL,
    "Descripcion" TEXT NULL,
    "CEClasificacion" TEXT NULL,
    "FechaHoraSolicitud" TEXT NULL,
    "FechaHoraInicio" TEXT NULL,
    "FechaHoraTermino" TEXT NULL,
    "CEMecanico" TEXT NULL,
    "UnidadTiempo" REAL NULL,
    "Cantidad" REAL NULL,
    "CantidadSurtido" REAL NULL,
    "FechaHoraSurtido" TEXT NULL,
    "PrecioUnitario" REAL NULL,
    "IVA" REAL NULL,
    "Costo" REAL NULL,
    "Subtotal" REAL NULL,
    "CEEstatusClasificacion" TEXT NULL,
    "CETipoPrecio" TEXT NULL,
    "IdPaqueteServ" INTEGER NULL,
    "ExistenciaPartes" REAL NULL,
    "NivelMO" INTEGER NULL,
    "CveOperacion" TEXT NULL,
    "NoPedidoPartes" REAL NULL,
    "Proveedor" INTEGER NULL,
    "FechaHoraPedidoParte" TEXT NULL,
    "FacturaTOT" TEXT NULL,
    "ConsecutivoTOT" REAL NULL,
    "IVATOT" REAL NULL,
    "BVentaAdicional" INTEGER NULL,
    "TiempoPagado" REAL NULL,
    "CostoPagado" REAL NULL,
    "DisponiblePartes" REAL NULL,
    "CEGrupo" TEXT NULL,
    "CESubgrupo" TEXT NULL,
    "ConsecutivoSurtido" REAL NULL,
    "PrecioListaPartes" REAL NULL,
    "PorcentajeDescuento" REAL NULL,
    "ImpuestoDescuento" REAL NULL,
    "MontoDescuento" REAL NULL,
    "CodigoOperacionExterna" TEXT NULL,
    "RenServicios" INTEGER NULL,
    "CETipoTrab" TEXT NULL,
    "FechaHoraRealOperacion" TEXT NULL,
    "TiempoRealOperacion" REAL NULL,
    "CEMotivoCancelacion" TEXT NULL,
    "NumeroChipsOperacion" REAL NULL,
    "RepTiempo" REAL NULL,
    "OrdenID" INTEGER NOT NULL,
    CONSTRAINT "FK_CrearOrdenDetalleRequest_CrearOrdenRequest_OrdenID" FOREIGN KEY ("OrdenID") REFERENCES "CrearOrdenRequest" ("Id") ON DELETE CASCADE
);

CREATE TABLE "UnidadColorRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_UnidadColorRequest" PRIMARY KEY AUTOINCREMENT,
    "IdUnidadesCatalogoColor" INTEGER NOT NULL,
    "CETipoColor" TEXT NOT NULL,
    "UnidadID" INTEGER NOT NULL,
    CONSTRAINT "FK_UnidadColorRequest_CrearUnidadRequest_UnidadID" FOREIGN KEY ("UnidadID") REFERENCES "CrearUnidadRequest" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PersonaRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaRequest" PRIMARY KEY AUTOINCREMENT,
    "Tpo_idtipo" INTEGER NOT NULL,
    "Per_paterno" TEXT NULL,
    "Per_materno" TEXT NULL,
    "Per_nombreorazonsocial" TEXT NULL,
    "Per_rfc" TEXT NULL,
    "Per_avisopriv" INTEGER NULL,
    "Per_enviopubli" INTEGER NULL,
    "Tpa_idactividad" INTEGER NULL,
    "Per_nombrecomercial" TEXT NULL,
    "Ctapagopred" TEXT NULL,
    "Idmediocontacto" INTEGER NULL,
    "Idclienterefacciones" INTEGER NULL,
    "Idsucursal" INTEGER NULL,
    "Idregimenfiscal" INTEGER NULL,
    "Idformapago" INTEGER NULL,
    "Idtipoclienteventas" INTEGER NULL,
    "Idaviso" INTEGER NULL,
    "Idejecutivo" INTEGER NULL,
    "DatospersonafisicaId" INTEGER NULL,
    "DatospersonamoralId" INTEGER NULL,
    CONSTRAINT "FK_PersonaRequest_PersonaDatosFisicaRequest_DatospersonafisicaId" FOREIGN KEY ("DatospersonafisicaId") REFERENCES "PersonaDatosFisicaRequest" ("Id"),
    CONSTRAINT "FK_PersonaRequest_PersonaDatosMoralRequest_DatospersonamoralId" FOREIGN KEY ("DatospersonamoralId") REFERENCES "PersonaDatosMoralRequest" ("Id")
);

CREATE TABLE "CrearVehiculoRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearVehiculoRequest" PRIMARY KEY AUTOINCREMENT,
    "CEOrigenUnidad" TEXT NULL,
    "NumeroSerie" TEXT NOT NULL,
    "IdVehiculosVINOrigen" INTEGER NOT NULL,
    "NumeroPlaca" TEXT NULL,
    "IdUnidadesCatalogoColorInt" INTEGER NOT NULL,
    "IdUnidadesCatalogoColorExt" INTEGER NULL,
    "NumeroMotor" TEXT NULL,
    "FechaVenta" TEXT NULL,
    "CEDistribuidorVendedor" TEXT NULL,
    "IdUnidadesCatalogo" INTEGER NULL,
    "UltimoKilometraje" REAL NULL,
    "GarantiaExtendida" TEXT NULL,
    "NoInventario" REAL NULL,
    "CESituacion" TEXT NULL,
    "CEUbicacion" TEXT NULL,
    "IdPropietario" INTEGER NULL,
    "IdConductor" INTEGER NULL,
    "IdContacto" INTEGER NULL,
    "IdRespMtto" INTEGER NULL,
    "NumeroEntrega" REAL NULL,
    "FechaEntrega" TEXT NULL,
    "Observaciones" TEXT NULL,
    "NoSerieAlternativo" TEXT NULL,
    "NoEconomico" TEXT NULL,
    "IdEmpresa" INTEGER NULL,
    "IdSucursal" INTEGER NULL,
    "OtrasmarcasId" INTEGER NULL,
    CONSTRAINT "FK_CrearVehiculoRequest_VehiculoOtrasMarcasRequest_OtrasmarcasId" FOREIGN KEY ("OtrasmarcasId") REFERENCES "VehiculoOtrasMarcasRequest" ("Id")
);

CREATE TABLE "AccionesCampoDetalleRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AccionesCampoDetalleRequest" PRIMARY KEY AUTOINCREMENT,
    "AccionCampoID" INTEGER NOT NULL,
    "CEClasificacion" TEXT NOT NULL,
    "Descripcion" TEXT NOT NULL,
    "Tiempo" REAL NULL,
    "Cantidad" REAL NULL,
    "IdParte" TEXT NULL,
    "CveOperacion" TEXT NULL,
    "Nivel" INTEGER NULL,
    CONSTRAINT "FK_AccionesCampoDetalleRequest_CrearAccionesCampoRequest_AccionCampoID" FOREIGN KEY ("AccionCampoID") REFERENCES "CrearAccionesCampoRequest" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AccionesCampoSeriesRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AccionesCampoSeriesRequest" PRIMARY KEY AUTOINCREMENT,
    "AccionCampoID" INTEGER NOT NULL,
    "Serie" TEXT NOT NULL,
    "Origen" INTEGER NOT NULL,
    "BRealizado" INTEGER NOT NULL,
    "FechaRealizacion" TEXT NULL,
    "CEDistribuidor" TEXT NULL,
    "UsuarioActualiza" INTEGER NULL,
    "Observaciones" TEXT NULL,
    CONSTRAINT "FK_AccionesCampoSeriesRequest_CrearAccionesCampoRequest_AccionCampoID" FOREIGN KEY ("AccionCampoID") REFERENCES "CrearAccionesCampoRequest" ("Id") ON DELETE CASCADE
);

CREATE TABLE "CrearPaqueteOperacionesResquest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearPaqueteOperacionesResquest" PRIMARY KEY AUTOINCREMENT,
    "CvePaqueteServ" TEXT NULL,
    "IdPaqueteServConse" INTEGER NOT NULL,
    "CveOperacion" TEXT NULL,
    "Descripcion" TEXT NULL,
    "TipoMO" INTEGER NOT NULL,
    "NivelMO" INTEGER NOT NULL,
    "UnidadesTimpo" INTEGER NOT NULL,
    "PrecioVenta" INTEGER NOT NULL,
    "Costo" INTEGER NOT NULL,
    "CodigoEreact" TEXT NULL,
    "RepTiempo" TEXT NULL,
    "PaqueteID" INTEGER NOT NULL,
    CONSTRAINT "FK_CrearPaqueteOperacionesResquest_CrearPaqueteRequest_PaqueteID" FOREIGN KEY ("PaqueteID") REFERENCES "CrearPaqueteRequest" ("Id") ON DELETE CASCADE
);

CREATE TABLE "CrearPaquetePartesResquet" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearPaquetePartesResquet" PRIMARY KEY AUTOINCREMENT,
    "IdParte" TEXT NULL,
    "CvePaqueteServ" TEXT NULL,
    "CantidadPartes" INTEGER NOT NULL,
    "TipoPrecio" TEXT NULL,
    "PrecioUnitario" INTEGER NOT NULL,
    "CtoUniEst" INTEGER NOT NULL,
    "PaqueteID" INTEGER NOT NULL,
    CONSTRAINT "FK_CrearPaquetePartesResquet_CrearPaqueteRequest_PaqueteID" FOREIGN KEY ("PaqueteID") REFERENCES "CrearPaqueteRequest" ("Id") ON DELETE CASCADE
);

CREATE TABLE "CrearPaqueteTotsResquest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearPaqueteTotsResquest" PRIMARY KEY AUTOINCREMENT,
    "CvePaqueteServ" TEXT NULL,
    "IdPaqueteServConse" INTEGER NOT NULL,
    "Descripcion" TEXT NULL,
    "TipoTT" INTEGER NOT NULL,
    "PrecioVenta" INTEGER NOT NULL,
    "Costo" INTEGER NOT NULL,
    "IdProveedor" INTEGER NOT NULL,
    "Observaciones" TEXT NULL,
    "CodigoEreact" TEXT NULL,
    "PaqueteID" INTEGER NOT NULL,
    CONSTRAINT "FK_CrearPaqueteTotsResquest_CrearPaqueteRequest_PaqueteID" FOREIGN KEY ("PaqueteID") REFERENCES "CrearPaqueteRequest" ("Id") ON DELETE CASCADE
);

CREATE TABLE "CrearPaqueteVehiculoResquest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_CrearPaqueteVehiculoResquest" PRIMARY KEY AUTOINCREMENT,
    "IdCatalogo" TEXT NULL,
    "Modelo" TEXT NULL,
    "CvePaqueteServ" TEXT NULL,
    "PaqueteID" INTEGER NOT NULL,
    CONSTRAINT "FK_CrearPaqueteVehiculoResquest_CrearPaqueteRequest_PaqueteID" FOREIGN KEY ("PaqueteID") REFERENCES "CrearPaqueteRequest" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PersonaCorreoRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaCorreoRequest" PRIMARY KEY AUTOINCREMENT,
    "Cor_predeterminada" INTEGER NULL,
    "Cor_dircorreo" TEXT NULL,
    "PersonaRequestId" INTEGER NULL,
    CONSTRAINT "FK_PersonaCorreoRequest_PersonaRequest_PersonaRequestId" FOREIGN KEY ("PersonaRequestId") REFERENCES "PersonaRequest" ("Id")
);

CREATE TABLE "PersonaDireccionRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaDireccionRequest" PRIMARY KEY AUTOINCREMENT,
    "Dir_idrol" INTEGER NULL,
    "Tpd_idtipodireccion" INTEGER NOT NULL,
    "Dir_predeterminada" INTEGER NULL,
    "Referencias" TEXT NULL,
    "Dir_iddireccion" INTEGER NOT NULL,
    "PersonaRequestId" INTEGER NULL,
    CONSTRAINT "FK_PersonaDireccionRequest_PersonaRequest_PersonaRequestId" FOREIGN KEY ("PersonaRequestId") REFERENCES "PersonaRequest" ("Id")
);

CREATE TABLE "PersonaIdentificacionRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaIdentificacionRequest" PRIMARY KEY AUTOINCREMENT,
    "Tpi_ididentifica" INTEGER NOT NULL,
    "Ide_numero" TEXT NULL,
    "Aut_idautoridad" INTEGER NOT NULL,
    "Ide_fechaemision" TEXT NULL,
    "Ide_fechavigencia" TEXT NULL,
    "Otrotipoidentifica" TEXT NULL,
    "Esleylavado" INTEGER NULL,
    "PersonaRequestId" INTEGER NULL,
    CONSTRAINT "FK_PersonaIdentificacionRequest_PersonaRequest_PersonaRequestId" FOREIGN KEY ("PersonaRequestId") REFERENCES "PersonaRequest" ("Id")
);

CREATE TABLE "PersonaRedesSocialesRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaRedesSocialesRequest" PRIMARY KEY AUTOINCREMENT,
    "Rds_idtipo" INTEGER NULL,
    "Red_predeterminado" INTEGER NULL,
    "Red_nombreusuario" TEXT NULL,
    "PersonaRequestId" INTEGER NULL,
    CONSTRAINT "FK_PersonaRedesSocialesRequest_PersonaRequest_PersonaRequestId" FOREIGN KEY ("PersonaRequestId") REFERENCES "PersonaRequest" ("Id")
);

CREATE TABLE "PersonaRelDmsRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaRelDmsRequest" PRIMARY KEY AUTOINCREMENT,
    "Rdm_cveusrdms" TEXT NULL,
    "Rdm_cesistemaorigen" TEXT NULL,
    "PersonaRequestId" INTEGER NULL,
    CONSTRAINT "FK_PersonaRelDmsRequest_PersonaRequest_PersonaRequestId" FOREIGN KEY ("PersonaRequestId") REFERENCES "PersonaRequest" ("Id")
);

CREATE TABLE "PersonaTelefonoRequest" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PersonaTelefonoRequest" PRIMARY KEY AUTOINCREMENT,
    "Ttl_idtipo" INTEGER NOT NULL,
    "Tel_predeterminado" INTEGER NULL,
    "Tel_lada" TEXT NULL,
    "Tel_numero" TEXT NULL,
    "Tel_horalocalizaini" INTEGER NULL,
    "Tel_horalocalizafin" INTEGER NULL,
    "Tel_extensiones" TEXT NULL,
    "PersonaRequestId" INTEGER NULL,
    CONSTRAINT "FK_PersonaTelefonoRequest_PersonaRequest_PersonaRequestId" FOREIGN KEY ("PersonaRequestId") REFERENCES "PersonaRequest" ("Id")
);

CREATE INDEX "IX_AccionesCampoDetalleRequest_AccionCampoID" ON "AccionesCampoDetalleRequest" ("AccionCampoID");

CREATE INDEX "IX_AccionesCampoSeriesRequest_AccionCampoID" ON "AccionesCampoSeriesRequest" ("AccionCampoID");

CREATE INDEX "IX_CrearAccionesCampoRequest_CitaID" ON "CrearAccionesCampoRequest" ("CitaID");

CREATE INDEX "IX_CrearOrdenDetalleRequest_OrdenID" ON "CrearOrdenDetalleRequest" ("OrdenID");

CREATE INDEX "IX_CrearPaqueteOperacionesResquest_PaqueteID" ON "CrearPaqueteOperacionesResquest" ("PaqueteID");

CREATE INDEX "IX_CrearPaquetePartesResquet_PaqueteID" ON "CrearPaquetePartesResquet" ("PaqueteID");

CREATE INDEX "IX_CrearPaqueteRequest_CitaID" ON "CrearPaqueteRequest" ("CitaID");

CREATE INDEX "IX_CrearPaqueteTotsResquest_PaqueteID" ON "CrearPaqueteTotsResquest" ("PaqueteID");

CREATE INDEX "IX_CrearPaqueteVehiculoResquest_PaqueteID" ON "CrearPaqueteVehiculoResquest" ("PaqueteID");

CREATE INDEX "IX_CrearVehiculoRequest_OtrasmarcasId" ON "CrearVehiculoRequest" ("OtrasmarcasId");

CREATE INDEX "IX_PersonaCorreoRequest_PersonaRequestId" ON "PersonaCorreoRequest" ("PersonaRequestId");

CREATE INDEX "IX_PersonaDireccionRequest_PersonaRequestId" ON "PersonaDireccionRequest" ("PersonaRequestId");

CREATE INDEX "IX_PersonaIdentificacionRequest_PersonaRequestId" ON "PersonaIdentificacionRequest" ("PersonaRequestId");

CREATE INDEX "IX_PersonaRedesSocialesRequest_PersonaRequestId" ON "PersonaRedesSocialesRequest" ("PersonaRequestId");

CREATE INDEX "IX_PersonaRelDmsRequest_PersonaRequestId" ON "PersonaRelDmsRequest" ("PersonaRequestId");

CREATE INDEX "IX_PersonaRequest_DatospersonafisicaId" ON "PersonaRequest" ("DatospersonafisicaId");

CREATE INDEX "IX_PersonaRequest_DatospersonamoralId" ON "PersonaRequest" ("DatospersonamoralId");

CREATE INDEX "IX_PersonaTelefonoRequest_PersonaRequestId" ON "PersonaTelefonoRequest" ("PersonaRequestId");

CREATE INDEX "IX_UnidadColorRequest_UnidadID" ON "UnidadColorRequest" ("UnidadID");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240508235044_InitialCreate', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240510193311_TestMigrations', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240511185242_ProdMigration', '8.0.4');

COMMIT;


