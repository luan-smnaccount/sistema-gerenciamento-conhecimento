using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class Categoria
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public short Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
}
