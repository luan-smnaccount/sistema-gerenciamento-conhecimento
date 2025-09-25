using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class UsuarioAvaliacaoConfiguration : IEntityTypeConfiguration<UsuarioAvaliacao>
{
    public void Configure(EntityTypeBuilder<UsuarioAvaliacao> builder)
    {
        builder.ToTable(nameof(UsuarioAvaliacao));

        builder.HasOne(ua => ua.Usuario)
                .WithMany(u => u.UsuarioAvaliacao)
                .HasForeignKey(ua => ua.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        builder.HasOne(ua => ua.Avaliacao)
            .WithMany(a => a.UsuarioAvaliacao)
            .HasForeignKey(ua => ua.IdAvaliacao)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}

