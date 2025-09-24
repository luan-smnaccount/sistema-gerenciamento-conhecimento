using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class TipoConteudoConfiguration : IEntityTypeConfiguration<TipoConteudo>
{
    public void Configure(EntityTypeBuilder<TipoConteudo> builder)
    {
        builder.ToTable(nameof(TipoConteudo));

        builder.HasKey(tc => tc.Id);
        builder.Property(tc => tc.Id)
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(tc => tc.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
    }
}

