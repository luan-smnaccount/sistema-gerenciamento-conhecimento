namespace SistemaGestaoConhecimento.Dominio;

public interface IDepartamento
{
    Task<Departamento> ICricaoDepartamento(Departamento entity);
}
