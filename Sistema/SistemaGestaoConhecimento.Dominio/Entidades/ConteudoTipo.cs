using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio;

public class ConteudoTipo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte Id { get; set; }
    public string Nome { get; set; }
}
