using Microsoft.EntityFrameworkCore;
using SistemaGestaoConhecimento.Dominio;

namespace SistemaGestaoConhecimento.Infra;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Cargo> Cargo { get; set; }
    public DbSet<Departamento> Departamento { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
}
