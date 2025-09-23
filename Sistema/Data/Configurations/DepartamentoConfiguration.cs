using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Models;

namespace Sistema.Data.Configurations;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable(nameof(Departamento));

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .IsRequired();
            
        builder.Property(d => d.Nome)
            .HasMaxLength(50)
            .IsRequired();
    }
}

