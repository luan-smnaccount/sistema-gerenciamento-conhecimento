using Microsoft.EntityFrameworkCore;
using SistemaGestaoConhecimento.Dominio;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Infra;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Cargo> Cargo { get; set; }
    public DbSet<Departamento> Departamento { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Comentario> Comentario { get; set; }
    public DbSet<Avaliacao> Avaliacao { get; set; }
    public DbSet<Modulo> Modulo { get; set; }
    public DbSet<Anexo> Anexo { get; set; }
    public DbSet<Conteudo> Conteudo { get; set; }
}
