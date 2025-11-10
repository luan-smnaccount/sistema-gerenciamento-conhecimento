using SistemaGestaoConhecimento.Infra;
using SistemaGestaoConhecimento.Dominio.Interfaces;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Api.Services;

public class ComentarioService : IComentario
{
    private readonly AppDbContext _db;

    public ComentarioService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Comentario> ICriacaoComentario(Comentario entity)
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
