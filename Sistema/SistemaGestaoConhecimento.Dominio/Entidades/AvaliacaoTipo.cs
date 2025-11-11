using System.ComponentModel.DataAnnotations.Schema;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class AvaliacaoTipo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte Id { get; set; }
    public string Nome { get; set; }

    public IEnumerable<Avaliacao> Avaliacoes { get; set; }
}
