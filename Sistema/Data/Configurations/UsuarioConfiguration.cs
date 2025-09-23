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
    }
}

