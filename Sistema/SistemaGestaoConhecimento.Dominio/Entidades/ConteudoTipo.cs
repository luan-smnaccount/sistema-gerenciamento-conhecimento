using System.ComponentModel.DataAnnotations.Schema;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class ConteudoTipo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte Id { get; set; }
    public string Nome { get; set; }

    public IEnumerable<Conteudo> Conteudos { get; set; }
}
