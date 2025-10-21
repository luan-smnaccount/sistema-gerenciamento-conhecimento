using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio;

[NotMapped]
public class UsuarioStatus
{
    public byte Id { get; set; }
    public string Nome { get; set; }

    public IEnumerable<Usuario> Usuario { get; set; }
}
