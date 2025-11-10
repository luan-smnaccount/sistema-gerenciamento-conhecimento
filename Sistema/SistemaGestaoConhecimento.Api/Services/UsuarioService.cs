using SistemaGestaoConhecimento.Dominio;
using SistemaGestaoConhecimento.Infra;

namespace SistemaGestaoConhecimento.Api;

public class UsuarioService : IUsuario
{
    private readonly AppDbContext _db;

    public UsuarioService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Usuario> ICriacaoUsuario(Usuario entity)
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
