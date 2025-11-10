using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Dominio.Interfaces;

public interface IComentario
{
    Task<Comentario> ICriacaoComentario(Comentario comentario);
}
