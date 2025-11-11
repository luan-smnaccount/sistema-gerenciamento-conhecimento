using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Dominio.Interfaces;

public interface IModulo
{
    Task<Modulo> ICriacaoModulo(Modulo entity);
}
