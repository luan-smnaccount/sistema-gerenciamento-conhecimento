using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class TipoAvaliacaoConfiguration : IEntityTypeConfiguration<TipoAvaliacao>
{
    public void Configure(EntityTypeBuilder<TipoAvaliacao> builder)
    {
        builder.ToTable(nameof(TipoAvaliacao));

        builder.HasKey(tpav => tpav.Id);
        builder.Property(tpav => tpav.Id)
            .ValueGeneratedOnAdd();

        builder.Property(tpav => tpav.Nome)
            .HasMaxLength(50)
            .IsRequired();
    }
}

