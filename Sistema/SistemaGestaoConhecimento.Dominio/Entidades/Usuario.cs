using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio;

public class Usuario
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public byte IdUsuarioStatus { get; set; }
    public short IdPerfil { get; set; }
    public short IdCargo { get; set; }
    public short IdDepartamento { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string CPF { get; set; }
    public string CEP { get; set; }
    public string Rua { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }
    public string NumResidencia { get; set; }
    public string Telefone { get; set; }
    public int UsuarioCadastro { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public int? UsuarioAtualizacao { get; set; }
    public DateTime? DataHoraAtualizacao { get; set; }
    public DateOnly DataAdmissao { get; set; }
    public DateOnly? DataDemissao { get; set; }

    public UsuarioStatus UsuarioStatus { get; set; }
    public Perfil Perfil { get; set; }

    [ForeignKey("IdCargo")]
    public Cargo Cargo { get; set; }

    [ForeignKey("IdDepartamento")]
    public Departamento Departamento { get; set; }
}
