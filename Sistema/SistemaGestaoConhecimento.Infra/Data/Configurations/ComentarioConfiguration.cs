using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Infra.Data.Configurations;

public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.ToTable(nameof(Comentario));

        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Usuario)
            .WithMany(u => u.Comentarios)
            .HasForeignKey(c => c.IdUsuario)
            .IsRequired();

        builder.Property(c => c.IdUsuario)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .HasMaxLength(220)
            .IsRequired();

        builder.Property(c => c.DataHoraCadastro)
            .IsRequired();

        builder.Property(c => c.UsuarioAtualizacao);
        builder.Property(c => c.DataHoraAtualizacao);
    }
}
