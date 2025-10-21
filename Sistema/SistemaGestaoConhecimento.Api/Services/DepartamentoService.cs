using SistemaGestaoConhecimento.Dominio;
using SistemaGestaoConhecimento.Infra;

namespace SistemaGestaoConhecimento.Api;

public class DepartamentoService : IDepartamento
{
    private readonly AppDbContext _db;

    public DepartamentoService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Departamento> ICricaoDepartamento(Departamento entity)
    {
        if (entity == null) throw new ArgumentException(nameof(entity));

        await _db.Departamento.AddAsync(entity);

        try
        {
            await _db.SaveChangesAsync();
            return entity;
        }
        catch(Exception ex)
        {
            var detalheErro = ex.InnerException?.Message ?? ex.Message;
            throw new Exception(detalheErro, ex);
        }
    }
}
