using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Infra.Data.Configurations;

public class ConteudoConfiguration : IEntityTypeConfiguration<Conteudo>
{
    public void Configure(EntityTypeBuilder<Conteudo> builder)
    {
        builder.ToTable(nameof(Conteudo));

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(c => c.Tag)
            .WithMany(t => t.Conteudos)
            .HasForeignKey(c => c.IdTag)
            .IsRequired();

        builder.HasOne(c => c.Categoria)
            .WithMany(ca => ca.Conteudos)
            .HasForeignKey(c => c.IdCategoria)
            .IsRequired();

        builder.HasOne(c => c.ConteudoTipo)
            .WithMany(ct => ct.Conteudos)
            .HasForeignKey(c => c.IdConteudoTipo)
            .IsRequired();

        builder.Property(c => c.ConteudoAula)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .HasMaxLength(120);

        builder.Property(c => c.LinkVideo)
            .HasMaxLength(255);

        builder.Property(c => c.UsuarioCadastro)
            .IsRequired();

        builder.Property(c => c.DataHoraCadastro)
            .IsRequired();

        builder.Property(c => c.UsuarioAtualizacao);

        builder.Property(c => c.DataHoraAtualizacao);

        builder.Property(c => c.IdCategoria)
            .IsRequired();

        builder.Property(c => c.IdConteudoTipo)
            .IsRequired();

        builder.Property(c => c.IdTag)
            .IsRequired();
    }
}
