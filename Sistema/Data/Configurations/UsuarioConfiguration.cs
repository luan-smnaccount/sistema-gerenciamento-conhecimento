using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .IsRequired();

        builder.HasOne(u => u.IdCargo)
            .WithMany()
            .HasForeignKey("IdCargo")
            .IsRequired();

        builder.HasOne(u => u.IdDepartamento)
            .WithMany()
            .HasForeignKey("IdDepartamento")
            .IsRequired();

        builder.HasOne(u => u.IdTipoPermissao)
            .WithMany()
            .HasForeignKey("IdTipoPermissao")
            .IsRequired();

        builder.HasOne(u => u.IdStatusUsuario)
            .WithMany()
            .HasForeignKey("IdStatusUsuario")
            .IsRequired();

        builder.Property(u => u.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Senha)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(u => u.DataCriacao)
            .IsRequired();

        builder.Property(u => u.DataAtualizacao)
            .IsRequired();

        builder.HasMany(u => u.HistoricoVersao)
            .WithOne(hv => hv.IdUsuario)
            .HasForeignKey("IdUsuario");

        builder.HasMany(u => u.Comentario)
            .WithOne(c => c.IdUsuario)
            .HasForeignKey("IdUsuario");

        builder.HasMany(u => u.UsuarioAvaliacao)
            .WithOne(ua => ua.IdUsuario)
            .HasForeignKey("IdUsuario");
    }
}

