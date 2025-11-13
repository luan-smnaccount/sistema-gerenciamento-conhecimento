using System.ComponentModel.DataAnnotations.Schema;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class Tag
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public short Id { get; set; }
    public string Nome { get; set; }

    public IEnumerable<Conteudo> Conteudos { get; set; }
}
