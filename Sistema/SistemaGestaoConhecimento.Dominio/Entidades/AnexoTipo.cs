using System.ComponentModel.DataAnnotations.Schema;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class AnexoTipo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte Id { get; set; }
    public string Nome { get; set; }

    public IEnumerable<Anexo> Anexos { get; set; }
}
