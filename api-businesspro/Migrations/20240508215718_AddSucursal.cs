using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_businesspro.Migrations
{
    /// <inheritdoc />
    public partial class AddSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SucursalRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdEmpresa = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreSucursal = table.Column<string>(type: "TEXT", nullable: false),
                    CveSucursal = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalRequest", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SucursalRequest");
        }
    }
}
