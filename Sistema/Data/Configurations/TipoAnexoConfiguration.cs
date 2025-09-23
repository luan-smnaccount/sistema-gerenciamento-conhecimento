using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class TipoAnexoConfiguration : IEntityTypeConfiguration<TipoAnexo>
{
    public void Configure(EntityTypeBuilder<TipoAnexo> builder)
    {
        builder.ToTable(nameof(TipoAnexo));

        builder.HasKey(tpa => tpa.Id);
        builder.Property(tpa => tpa.Id)
            .IsRequired();

        builder.Property(tpa => tpa.NomeTipoAnexo)
            .HasMaxLength(50)
            .IsRequired();
    }
}

