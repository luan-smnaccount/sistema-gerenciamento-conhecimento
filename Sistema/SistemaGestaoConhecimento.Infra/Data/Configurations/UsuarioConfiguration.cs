using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoConhecimento.Dominio;

namespace SistemaGestaoConhecimento.Infra;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));

        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.UsuarioStatus)
            .WithMany(us => us.Usuarios)
            .HasForeignKey(u => u.IdUsuarioStatus)
            .IsRequired();

        builder.HasOne(u => u.Perfil)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(u => u.IdPerfil)
            .IsRequired();

        builder.HasOne(u => u.Cargo)
            .WithMany(c => c.Usuarios)
            .HasForeignKey(u => u.IdCargo)
            .IsRequired();

        builder.HasOne(u => u.Departamento)
            .WithMany(d => d.Usuarios)
            .HasForeignKey(u => u.IdDepartamento)
            .IsRequired();

        builder.Property(u => u.NomeCompleto)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(320)
            .IsRequired();

        builder.Property(u => u.Senha)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(u => u.CPF)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(u => u.CEP)
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(u => u.Rua)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Cidade)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.UF)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(u => u.NumResidencia)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(u => u.Telefone)
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(u => u.UsuarioCadastro)
            .IsRequired();

        builder.Property(u => u.DataHoraCadastro)
            .IsRequired();

        builder.Property(u => u.UsuarioAtualizacao);

        builder.Property(u => u.DataHoraAtualizacao);

        builder.Property(u => u.DataAdmissao)
            .IsRequired();

        builder.Property(u => u.DataDemissao);

        builder.Property(u => u.IdUsuarioStatus)
            .IsRequired();

        builder.Property(u => u.IdPerfil)
            .IsRequired();

        builder.Property(u => u.IdCargo)
            .IsRequired();

        builder.Property(u => u.IdDepartamento)
            .IsRequired();
    }
}
