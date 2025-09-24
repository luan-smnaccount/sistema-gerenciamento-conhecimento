using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable(nameof(Categoria));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(c => c.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .HasColumnType("varchar")
            .HasMaxLength(100);
    }
}

