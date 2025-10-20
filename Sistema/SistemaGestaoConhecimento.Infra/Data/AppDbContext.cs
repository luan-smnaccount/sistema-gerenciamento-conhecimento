using Microsoft.EntityFrameworkCore;
using SistemaGestaoConhecimento.Dominio;

namespace SistemaGestaoConhecimento.Infra;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AnexoTipo> AnexoTipo { get; set; }
    public DbSet<AvaliacaoTipo> AvaliacaoTipo { get; set; }
    public DbSet<Cargo> Cargo { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<ConteudoTipo> ConteudoTipo { get; set; }
    public DbSet<Departamento> Departamento { get; set; }
    public DbSet<OpcaoSistema> OpcaoSistema { get; set; }
    public DbSet<Perfil> Perfil { get; set; }
    public DbSet<PerfilOpcaoSistemaPermissao> PerfilOpcaoSistemaPermissao { get; set; }
    public DbSet<Permissao> Permissao { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<UsuarioStatus> UsuarioStatuse { get; set; }
}
