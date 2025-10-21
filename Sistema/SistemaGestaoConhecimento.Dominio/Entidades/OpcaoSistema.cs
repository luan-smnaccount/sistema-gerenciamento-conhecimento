using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class OpcaoSistema
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public OpcaoSistema IdOpcaoSistema { get; set; }
    public string Nome { get; set; }
    public string DescricaoOpcao { get; set; }
    public string Rota { get; set; }

    public IEnumerable<PerfilOpcaoSistemaPermissao> PerfilOpcaoSistemaPermissao { get; set; }
}
