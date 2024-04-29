using Microsoft.EntityFrameworkCore;

namespace API.Models;
public class ApiContext : DbContext
{
    public DbSet<CrearAccionesCampoRequest> AccionesCampo { get; set; }
    public DbSet<AccionesCampoDetalleRequest> AccionesCampoDetalle { get; set; }
    public string DbPath { get; }

    public ApiContext(DbContextOptions options) : base(options)
    {
        DbPath = AppConfig.dbPath;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}