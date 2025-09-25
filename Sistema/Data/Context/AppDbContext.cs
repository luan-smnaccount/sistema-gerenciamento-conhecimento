using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema.Models;

namespace Sistema.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TipoPermissao> TipoPermissao { get; set; }
    public DbSet<Cargo> Cargo { get; set; }
    public DbSet<Departamento> Departamento { get; set; }
    public DbSet<StatusUsuario> StatusUsuario { get; set; }
    public DbSet<Usuario> Usuario { get; set; }

    public DbSet<UsuarioAvaliacao> UsuarioAvaliacao { get; set; }
    public DbSet<HistoricoVersao> HistoricoVersao { get; set; }
    public DbSet<Comentario> Comentario { get; set; }

    public DbSet<TipoConteudo> TipoConteudo { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<TipoAnexo> TipoAnexo { get; set; }

    public DbSet<Avaliacao> Avaliacao { get; set; }
    public DbSet<TipoAvaliacao> TipoAvaliacao { get; set; }
}
