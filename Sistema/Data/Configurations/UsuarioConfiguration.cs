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
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(u => u.IdCargo)
            .WithMany()
            .HasForeignKey("IdCargo")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(u => u.IdDepartamento)
            .WithMany()
            .HasForeignKey("IdDepartamento")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(u => u.IdTipoPermissao)
            .WithMany()
            .HasForeignKey("IdTipoPermissao")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(u => u.IdStatusUsuario)
            .WithMany()
            .HasForeignKey("IdStatusUsuario")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(u => u.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Senha)
            .HasColumnType("varchar")
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(u => u.DataCriacao)
            .HasColumnType("data")
            .IsRequired();

        builder.Property(u => u.DataAtualizacao)
            .HasColumnType("date")
            .IsRequired();

        builder.HasMany(u => u.HistoricoVersao)
            .WithOne(hv => hv.IdUsuario)
            .HasForeignKey("IdUsuario")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Comentario)
            .WithOne(c => c.IdUsuario)
            .HasForeignKey("IdUsuario")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.UsuarioAvaliacao)
            .WithOne(ua => ua.IdUsuario)
            .HasForeignKey("IdUsuario")
            .OnDelete(DeleteBehavior.Restrict);
    }
}

