namespace SistemaGestaoConhecimento.Dominio;

public class UsuarioStatus
{
    public byte Id { get; set; }
    public string Nome { get; set; }
    
    public IEnumerable<Usuario> Usuario { get; set; }
}
