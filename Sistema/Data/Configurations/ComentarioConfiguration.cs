using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.ToTable(nameof(Comentario));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(c => c.IdConteudo)
            .WithMany()
            .HasForeignKey("IdConteudo")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(c => c.IdUsuario)
            .WithMany()
            .HasForeignKey("IdUsuario")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(c => c.Mensagem)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();
    }
}

