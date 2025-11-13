using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Dominio.Interfaces;

public interface IAnexo
{
    Task<Anexo> ICriacaoAnexo(Anexo entity);
}
