using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaGestaoConhecimento.Dominio;
using SistemaGestaoConhecimento.Dominio.Entidades;
using SistemaGestaoConhecimento.Dominio.Interfaces;
using SistemaGestaoConhecimento.Infra;

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
