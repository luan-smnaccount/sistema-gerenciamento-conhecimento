using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoConhecimento.Dominio;

namespace SistemaGestaoConhecimento.Infra;

public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.ToTable(nameof(Cargo));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.UsuarioCadastro)
            .IsRequired();

        builder.Property(c => c.DataHoraCadastro)
            .IsRequired();

        builder.Property(c => c.UsuarioAtualizacao);

        builder.Property(c => c.DataHoraAtualizacao);
    }
}
