using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Infra.Data.Configurations;

public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
{
    public void Configure(EntityTypeBuilder<Avaliacao> builder)
    {
        builder.ToTable(nameof(Avaliacao));

        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.AvaliacaoTipo)
            .WithMany(at => at.Avaliacoes)
            .HasForeignKey(a => a.IdAvaliacaoTipo)
            .IsRequired();

        builder.HasOne(a => a.Usuario)
            .WithMany(u => u.Avaliacoes)
            .HasForeignKey(a => a.IdUsuario)
            .IsRequired();

        builder.Property(a => a.NotaFinal);

        builder.Property(a => a.DataAvaliacao)
            .IsRequired();

        builder.Property(a => a.DataHoraCadastro)
            .IsRequired();

        builder.Property(a => a.UsuarioAtualizacao);

        builder.Property(a => a.DataHoraAtualizacao);

        builder.Property(a => a.IdAvaliacaoTipo)
            .IsRequired();

        builder.Property(a => a.IdUsuario)
            .IsRequired();
    }
}
