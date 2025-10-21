using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoConhecimento.Dominio;

namespace SistemaGestaoConhecimento.Infra;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable(nameof(Departamento));

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.Nome)
            .IsRequired();

        builder.Property(c => c.UsuarioCadastro)
            .IsRequired();

        builder.Property(c => c.DataHoraCadastro)
            .IsRequired();

        builder.Property(c => c.UsuarioAtualizacao);

        builder.Property(c => c.DataHoraAtualizacao);
    }
}
