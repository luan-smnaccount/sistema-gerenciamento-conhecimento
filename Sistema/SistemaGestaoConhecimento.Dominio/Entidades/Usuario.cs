using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio;

public class Usuario
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public UsuarioStatus IdUsuarioStatus { get; set; }
    public Perfil IdPerfil { get; set; }
    public Cargo IdCargo { get; set; }
    public Departamento IdDepartamento { get; set; }
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
    public DateTime DataHoraCriacao { get; set; }
    public int UsuarioAtualizacao { get; set; }
    public DateTime DataHoraAtualizacao { get; set; }
    public DateOnly DataAdmissao { get; set; }
    public DateOnly DataDemissao { get; set; }
}
