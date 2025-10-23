using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class Perfil
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public short Id { get; set; }
    public string Nome { get; set; }

    public IEnumerable<PerfilOpcaoSistemaPermissao> PerfilOpcaoSistemaPermissao { get; set; }
    public IEnumerable<Usuario> Usuarios { get; set; }
}
