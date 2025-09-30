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

        builder.HasKey(ua => new { ua.IdUsuario, ua.IdAvaliacao });

        builder.HasOne(ua => ua.IdUsuario)
            .WithMany(u => u.UsuarioAvaliacao)
            .HasForeignKey("IdUsuario")
            .IsRequired();

        builder.HasOne(ua => ua.IdAvaliacao)
            .WithMany(a => a.UsuarioAvaliacao)
            .HasForeignKey("IdAvaliacao")
            .IsRequired();
    }
}

