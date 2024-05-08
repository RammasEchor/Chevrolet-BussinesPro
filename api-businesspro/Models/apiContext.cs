using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Models;
public class ApiContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    public DbSet<CrearAccionesCampoRequest> CrearAccionesCampoRequest { get; set; }
    public DbSet<AccionesCampoDetalleRequest> AccionesCampoDetalleRequest { get; set; }
    public DbSet<AccionesCampoSeriesRequest> AccionesCampoSeriesRequest { get; set; }
    public DbSet<CrearPaqueteRequest> CrearPaqueteRequest { get; set; } = default!;
    public DbSet<CrearCitaRequest> CrearCitaRequest { get; set; }
    public string DbPath { get; }

    public ApiContext(DbContextOptions options) : base(options)
    {
        DbPath = AppConfig.dbPath;
    }
    public DbSet<API.Models.EmpresaRequest> EmpresaRequest { get; set; }
    public DbSet<API.Models.FacturaRequest> FacturaRequest { get; set; }
    public DbSet<API.Models.CrearOrdenRequest> CrearOrdenRequest { get; set; }
    public DbSet<API.Models.CrearOrdenDetalleRequest> CrearOrdenDetalleRequest { get; set; }
    public DbSet<API.Models.PersonaRequest> PersonaRequest { get; set; }
    public DbSet<API.Models.SucursalRequest> SucursalRequest { get; set; }
    public DbSet<API.Models.CrearUnidadRequest> CrearUnidadRequest { get; set; }
    public DbSet<API.Models.UnidadColorRequest> UnidadColorRequest { get; set; }
    public DbSet<API.Models.CrearVehiculoRequest> CrearVehiculoRequest { get; set; }
}