using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_businesspro.Migrations
{
    /// <inheritdoc />
    public partial class Persona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonaDatosFisicaRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pdf_sexo = table.Column<int>(type: "INTEGER", nullable: true),
                    Pdf_nacionalidad = table.Column<string>(type: "TEXT", nullable: true),
                    Tit_idtitulo = table.Column<int>(type: "INTEGER", nullable: true),
                    Edc_idedocivil = table.Column<int>(type: "INTEGER", nullable: true),
                    Pai_paisnacimiento = table.Column<int>(type: "INTEGER", nullable: true),
                    Per_fechanacimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Per_curp = table.Column<string>(type: "TEXT", nullable: true),
                    Per_situacionlaboral = table.Column<string>(type: "TEXT", nullable: true),
                    Per_empresa = table.Column<string>(type: "TEXT", nullable: true),
                    Per_puestoocupa = table.Column<string>(type: "TEXT", nullable: true),
                    Per_antiguedadlaboral = table.Column<string>(type: "TEXT", nullable: true),
                    Per_ingresomensual = table.Column<double>(type: "REAL", nullable: true),
                    Paisnacionalidad = table.Column<int>(type: "INTEGER", nullable: true),
                    Id_acteconomica = table.Column<int>(type: "INTEGER", nullable: true),
                    Paisnumtel = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaDatosFisicaRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonaDatosMoralRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pdm_lugarescritura = table.Column<string>(type: "TEXT", nullable: true),
                    Pmd_fechaconstitutiva = table.Column<string>(type: "TEXT", nullable: true),
                    Pmd_fechainscripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Pdm_nombrerepresentantelegal = table.Column<string>(type: "TEXT", nullable: true),
                    Tps_idtiposociedad = table.Column<int>(type: "INTEGER", nullable: true),
                    Pdm_numeroescritura = table.Column<int>(type: "INTEGER", nullable: true),
                    Pdm_libro = table.Column<string>(type: "TEXT", nullable: true),
                    Pdm_folio = table.Column<string>(type: "TEXT", nullable: true),
                    Pdm_volumen = table.Column<string>(type: "TEXT", nullable: true),
                    Pdm_numeroescriturarepresentantelegal = table.Column<int>(type: "INTEGER", nullable: true),
                    Pdm_librorepresentantelegal = table.Column<string>(type: "TEXT", nullable: true),
                    Pdm_foliorepresentantelegal = table.Column<string>(type: "TEXT", nullable: true),
                    Pdm_volumenrepresentantelegal = table.Column<string>(type: "TEXT", nullable: true),
                    Pdm_lugarrepresentantelegal = table.Column<string>(type: "TEXT", nullable: true),
                    Pdm_fechainscripcionrepresentantelegal = table.Column<string>(type: "TEXT", nullable: true),
                    Paisnacionalidad = table.Column<int>(type: "INTEGER", nullable: true),
                    Id_acteconomica = table.Column<int>(type: "INTEGER", nullable: true),
                    Paisnumtel = table.Column<string>(type: "TEXT", nullable: true),
                    Actaconst = table.Column<string>(type: "TEXT", nullable: true),
                    Fideicomiso = table.Column<string>(type: "TEXT", nullable: true),
                    Idreppermoral = table.Column<int>(type: "INTEGER", nullable: true),
                    Rpublicoestado = table.Column<string>(type: "TEXT", nullable: true),
                    Rpublicofecha = table.Column<string>(type: "TEXT", nullable: true),
                    Rpubliconumero = table.Column<string>(type: "TEXT", nullable: true),
                    Rlegalestado = table.Column<string>(type: "TEXT", nullable: true),
                    Rlegalnotario = table.Column<string>(type: "TEXT", nullable: true),
                    Rlegalnotnumero = table.Column<string>(type: "TEXT", nullable: true),
                    Tnotarialestado = table.Column<string>(type: "TEXT", nullable: true),
                    Tnotarialnotnumero = table.Column<string>(type: "TEXT", nullable: true),
                    Tnotarialnotario = table.Column<string>(type: "TEXT", nullable: true),
                    Tnotarialnumero = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaDatosMoralRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonaRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tpo_idtipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Per_paterno = table.Column<string>(type: "TEXT", nullable: true),
                    Per_materno = table.Column<string>(type: "TEXT", nullable: true),
                    Per_nombreorazonsocial = table.Column<string>(type: "TEXT", nullable: true),
                    Per_rfc = table.Column<string>(type: "TEXT", nullable: true),
                    Per_avisopriv = table.Column<bool>(type: "INTEGER", nullable: true),
                    Per_enviopubli = table.Column<bool>(type: "INTEGER", nullable: true),
                    Tpa_idactividad = table.Column<bool>(type: "INTEGER", nullable: true),
                    Per_nombrecomercial = table.Column<string>(type: "TEXT", nullable: true),
                    Ctapagopred = table.Column<string>(type: "TEXT", nullable: true),
                    Idmediocontacto = table.Column<int>(type: "INTEGER", nullable: true),
                    Idclienterefacciones = table.Column<int>(type: "INTEGER", nullable: true),
                    Idsucursal = table.Column<int>(type: "INTEGER", nullable: true),
                    Idregimenfiscal = table.Column<int>(type: "INTEGER", nullable: true),
                    Idformapago = table.Column<int>(type: "INTEGER", nullable: true),
                    Idtipoclienteventas = table.Column<int>(type: "INTEGER", nullable: true),
                    Idaviso = table.Column<int>(type: "INTEGER", nullable: true),
                    Idejecutivo = table.Column<int>(type: "INTEGER", nullable: true),
                    DatospersonafisicaId = table.Column<long>(type: "INTEGER", nullable: true),
                    DatospersonamoralId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaRequest_PersonaDatosFisicaRequest_DatospersonafisicaId",
                        column: x => x.DatospersonafisicaId,
                        principalTable: "PersonaDatosFisicaRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonaRequest_PersonaDatosMoralRequest_DatospersonamoralId",
                        column: x => x.DatospersonamoralId,
                        principalTable: "PersonaDatosMoralRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonaCorreoRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cor_predeterminada = table.Column<bool>(type: "INTEGER", nullable: true),
                    Cor_dircorreo = table.Column<string>(type: "TEXT", nullable: true),
                    PersonaRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaCorreoRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaCorreoRequest_PersonaRequest_PersonaRequestId",
                        column: x => x.PersonaRequestId,
                        principalTable: "PersonaRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonaDireccionRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dir_idrol = table.Column<int>(type: "INTEGER", nullable: true),
                    Tpd_idtipodireccion = table.Column<int>(type: "INTEGER", nullable: false),
                    Dir_predeterminada = table.Column<bool>(type: "INTEGER", nullable: true),
                    Referencias = table.Column<string>(type: "TEXT", nullable: true),
                    Dir_iddireccion = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonaRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaDireccionRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaDireccionRequest_PersonaRequest_PersonaRequestId",
                        column: x => x.PersonaRequestId,
                        principalTable: "PersonaRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonaIdentificacionRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tpi_ididentifica = table.Column<int>(type: "INTEGER", nullable: false),
                    Ide_numero = table.Column<string>(type: "TEXT", nullable: true),
                    Aut_idautoridad = table.Column<int>(type: "INTEGER", nullable: false),
                    Ide_fechaemision = table.Column<string>(type: "TEXT", nullable: true),
                    Ide_fechavigencia = table.Column<string>(type: "TEXT", nullable: true),
                    Otrotipoidentifica = table.Column<string>(type: "TEXT", nullable: true),
                    Esleylavado = table.Column<bool>(type: "INTEGER", nullable: true),
                    PersonaRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaIdentificacionRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaIdentificacionRequest_PersonaRequest_PersonaRequestId",
                        column: x => x.PersonaRequestId,
                        principalTable: "PersonaRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonaRedesSocialesRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rds_idtipo = table.Column<int>(type: "INTEGER", nullable: true),
                    Red_predeterminado = table.Column<bool>(type: "INTEGER", nullable: true),
                    Red_nombreusuario = table.Column<string>(type: "TEXT", nullable: true),
                    PersonaRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRedesSocialesRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaRedesSocialesRequest_PersonaRequest_PersonaRequestId",
                        column: x => x.PersonaRequestId,
                        principalTable: "PersonaRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonaRelDmsRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rdm_cveusrdms = table.Column<string>(type: "TEXT", nullable: true),
                    Rdm_cesistemaorigen = table.Column<string>(type: "TEXT", nullable: true),
                    PersonaRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRelDmsRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaRelDmsRequest_PersonaRequest_PersonaRequestId",
                        column: x => x.PersonaRequestId,
                        principalTable: "PersonaRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonaTelefonoRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ttl_idtipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Tel_predeterminado = table.Column<bool>(type: "INTEGER", nullable: true),
                    Tel_lada = table.Column<string>(type: "TEXT", nullable: true),
                    Tel_numero = table.Column<string>(type: "TEXT", nullable: true),
                    Tel_horalocalizaini = table.Column<int>(type: "INTEGER", nullable: true),
                    Tel_horalocalizafin = table.Column<int>(type: "INTEGER", nullable: true),
                    Tel_extensiones = table.Column<string>(type: "TEXT", nullable: true),
                    PersonaRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaTelefonoRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaTelefonoRequest_PersonaRequest_PersonaRequestId",
                        column: x => x.PersonaRequestId,
                        principalTable: "PersonaRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaCorreoRequest_PersonaRequestId",
                table: "PersonaCorreoRequest",
                column: "PersonaRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaDireccionRequest_PersonaRequestId",
                table: "PersonaDireccionRequest",
                column: "PersonaRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaIdentificacionRequest_PersonaRequestId",
                table: "PersonaIdentificacionRequest",
                column: "PersonaRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRedesSocialesRequest_PersonaRequestId",
                table: "PersonaRedesSocialesRequest",
                column: "PersonaRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRelDmsRequest_PersonaRequestId",
                table: "PersonaRelDmsRequest",
                column: "PersonaRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRequest_DatospersonafisicaId",
                table: "PersonaRequest",
                column: "DatospersonafisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRequest_DatospersonamoralId",
                table: "PersonaRequest",
                column: "DatospersonamoralId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTelefonoRequest_PersonaRequestId",
                table: "PersonaTelefonoRequest",
                column: "PersonaRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaCorreoRequest");

            migrationBuilder.DropTable(
                name: "PersonaDireccionRequest");

            migrationBuilder.DropTable(
                name: "PersonaIdentificacionRequest");

            migrationBuilder.DropTable(
                name: "PersonaRedesSocialesRequest");

            migrationBuilder.DropTable(
                name: "PersonaRelDmsRequest");

            migrationBuilder.DropTable(
                name: "PersonaTelefonoRequest");

            migrationBuilder.DropTable(
                name: "PersonaRequest");

            migrationBuilder.DropTable(
                name: "PersonaDatosFisicaRequest");

            migrationBuilder.DropTable(
                name: "PersonaDatosMoralRequest");
        }
    }
}
