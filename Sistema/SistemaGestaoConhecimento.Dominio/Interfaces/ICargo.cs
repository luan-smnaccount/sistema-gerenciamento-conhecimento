namespace SistemaGestaoConhecimento.Dominio;

public interface ICargo
{
    Task<Cargo> ICriacaoCargo(Cargo entity);
}
