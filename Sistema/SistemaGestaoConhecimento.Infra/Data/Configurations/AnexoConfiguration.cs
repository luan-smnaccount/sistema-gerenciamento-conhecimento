using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Infra.Data.Configurations;

public class AnexoConfiguration : IEntityTypeConfiguration<Anexo>
{
    public void Configure(EntityTypeBuilder<Anexo> builder)
    {
        builder.ToTable(nameof(Anexo));

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(a => a.AnexoTipo)
            .WithMany(at => at.Anexos)
            .HasForeignKey(a => a.IdAnexoTipo)
            .IsRequired();

        builder.Property(a => a.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.CaminhoArquivo)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(a => a.UsuarioCadastro)
            .IsRequired();

        builder.Property(a => a.DataHoraCadastro)
            .IsRequired();

        builder.Property(a => a.UsuarioAtualizacao);

        builder.Property(a => a.DataHoraAtualizacao);

        builder.Property(a => a.IdAnexoTipo)
            .IsRequired();
    }
}
