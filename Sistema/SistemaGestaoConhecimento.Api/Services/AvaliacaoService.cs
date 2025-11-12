using SistemaGestaoConhecimento.Dominio.Entidades;
using SistemaGestaoConhecimento.Dominio.Interfaces;
using SistemaGestaoConhecimento.Infra;

namespace SistemaGestaoConhecimento.Api.Services;

public class AvaliacaoService : IAvaliacao
{
    private readonly AppDbContext _db;

    public AvaliacaoService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Avaliacao> ICriacaoAvaliacao(Avaliacao entity)
    {
        if (entity == null) throw new ArgumentException(nameof(entity));

        entity.DataHoraCadastro = DateTime.Now;
        await _db.AddAsync(entity);

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
