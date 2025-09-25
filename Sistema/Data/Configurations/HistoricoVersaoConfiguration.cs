using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class HistoricoVersaoConfiguration : IEntityTypeConfiguration<HistoricoVersao>
{
    public void Configure(EntityTypeBuilder<HistoricoVersao> builder)
    {
        builder.ToTable(nameof(HistoricoVersao));

        builder.HasKey(hv => hv.Id);
        builder.Property(hv => hv.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(hv => hv.IdConteudo)
            .WithMany()
            .HasForeignKey("IdConteudo")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(hv => hv.IdUsuario)
            .WithMany()
            .HasForeignKey("IdUsuario")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(hv => hv.DescricaoVersao)
            .HasMaxLength(255);

        builder.Property(hv => hv.DataVersao)
            .IsRequired();
    }
}
