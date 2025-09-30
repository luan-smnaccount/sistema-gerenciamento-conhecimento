using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
{
    public void Configure(EntityTypeBuilder<Avaliacao> builder)
    {
        builder.ToTable(nameof(Avaliacao));

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(a => a.IdUsuarioAvaliacao)
            .WithMany()
            .HasForeignKey("IdUsuarioAvaliacao")
            .IsRequired();

        builder.HasOne(a => a.IdTipoAvaliacao)
            .WithMany()
            .HasForeignKey("IdTipoAvaliacao")
            .IsRequired();

        builder.Property(a => a.NotaFinal)
            .IsRequired();

        builder.Property(a => a.DataAvaliacao)
            .IsRequired();

        builder.Property(a => a.DataAtualizacao);
    }
}

