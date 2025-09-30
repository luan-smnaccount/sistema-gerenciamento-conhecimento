using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class StatusUsuarioConfigure : IEntityTypeConfiguration<StatusUsuario>
{
    public void Configure(EntityTypeBuilder<StatusUsuario> builder)
    {
        builder.ToTable(nameof(StatusUsuario));

        builder.HasKey(su => su.Id);
        builder.Property(su => su.Id)
            .ValueGeneratedOnAdd();

        builder.Property(su => su.Status)
            .HasMaxLength(50)
            .IsRequired();
    }
}

