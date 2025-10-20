namespace SistemaGestaoConhecimento.Dominio;

public interface IUsuario
{
    Task<Usuario> ICriacaoUsuario(Usuario entity);
}
