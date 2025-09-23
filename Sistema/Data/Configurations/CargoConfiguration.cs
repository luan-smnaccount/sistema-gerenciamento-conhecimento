using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.ToTable(nameof(Cargo));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .IsRequired();
            
        builder.Property(c => c.Nome)
            .HasMaxLength(50)
            .IsRequired();
    }
}

