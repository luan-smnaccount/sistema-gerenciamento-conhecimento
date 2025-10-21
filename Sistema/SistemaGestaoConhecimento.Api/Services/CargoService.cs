using SistemaGestaoConhecimento.Dominio;
using SistemaGestaoConhecimento.Infra;

namespace SistemaGestaoConhecimento.Api;

public class CargoService : ICargo
{
    private readonly AppDbContext _db;

    public CargoService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Cargo> ICriacaoCargo(Cargo entity)
    {
        if (entity == null) throw new ArgumentException(nameof(entity));

        await _db.Cargo.AddAsync(entity);

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
