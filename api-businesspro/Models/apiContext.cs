using Microsoft.EntityFrameworkCore;

namespace API.Models;
public class ApiContext : DbContext
{
    public string DbPath { get; }
    public ApiContext(DbContextOptions options) : base(options) { }
    public DbSet<CrearAccionesCampoRequest> CrearAccionesCampoRequest { get; set; }
    public DbSet<AccionesCampoDetalleRequest> AccionesCampoDetalleRequest { get; set; }
    public DbSet<AccionesCampoSeriesRequest> AccionesCampoSeriesRequest { get; set; }
    public DbSet<CrearPaqueteRequest> CrearPaqueteRequest { get; set; } = default!;
    public DbSet<CrearCitaRequest> CrearCitaRequest { get; set; }
    public DbSet<EmpresaRequest> EmpresaRequest { get; set; }
    public DbSet<FacturaRequest> FacturaRequest { get; set; }
    public DbSet<CrearOrdenRequest> CrearOrdenRequest { get; set; }
    public DbSet<CrearOrdenDetalleRequest> CrearOrdenDetalleRequest { get; set; }
    public DbSet<PersonaRequest> PersonaRequest { get; set; }
    public DbSet<SucursalRequest> SucursalRequest { get; set; }
    public DbSet<CrearUnidadRequest> CrearUnidadRequest { get; set; }
    public DbSet<UnidadColorRequest> UnidadColorRequest { get; set; }
    public DbSet<CrearVehiculoRequest> CrearVehiculoRequest { get; set; }
}