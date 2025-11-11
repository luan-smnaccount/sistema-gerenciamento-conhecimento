using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Infra.Data.Configurations;

public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.ToTable(nameof(Modulo));

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(m => m.Avaliacao)
            .WithOne(a => a.Modulo)
            .HasForeignKey<Modulo>(m => m.IdAvaliacao);

        builder.HasOne(m => m.modulo)
            .WithMany(a => a.Modulos)
            .HasForeignKey(m => m.IdModulo);

        builder.Property(m => m.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(m => m.UsuarioCadastro)
            .IsRequired();

        builder.Property(m => m.DataHoraCadastro)
            .IsRequired();

        builder.Property(m => m.UsuarioAtualizacao);

        builder.Property(m => m.DataHoraAtualizacao);

        builder.Property(m => m.IdAvaliacao)
            .IsRequired();

        builder.Property(m => m.IdModulo);
    }
}
