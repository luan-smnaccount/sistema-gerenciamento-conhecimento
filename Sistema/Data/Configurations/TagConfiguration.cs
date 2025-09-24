using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable(nameof(Tag));

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(t => t.Nome)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
    }
}

