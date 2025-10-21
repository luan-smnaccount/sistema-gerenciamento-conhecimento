using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class PerfilOpcaoSistemaPermissao
{
    public Perfil IdPerfil { get; set; }
    public OpcaoSistema IdOpcaoSistema { get; set; }
    public Permissao IdPermissao { get; set; }
}
