using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class TipoPermissaoConfiguration : IEntityTypeConfiguration<TipoPermissao>
{
    public void Configure(EntityTypeBuilder<TipoPermissao> builder)
    {
        builder.ToTable(nameof(TipoPermissao));

        builder.HasKey(tp => tp.Id);
        builder.Property(tp => tp.Id)
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(tp => tp.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
    }
}

