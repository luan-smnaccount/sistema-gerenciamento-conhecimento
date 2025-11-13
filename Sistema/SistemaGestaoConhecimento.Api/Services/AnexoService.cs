using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaGestaoConhecimento.Dominio.Entidades;
using SistemaGestaoConhecimento.Dominio.Interfaces;
using SistemaGestaoConhecimento.Infra;

namespace SistemaGestaoConhecimento.Api.Services;

public class AnexoService : IAnexo
{
    private readonly AppDbContext _db;

    public AnexoService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Anexo> ICriacaoAnexo(Anexo entity)
    {
        entity.DataHoraCadastro = DateTime.Now;
        await _db.AddAsync(entity);

        try
        {
            await _db.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            var detalheErro = ex.InnerException?.Message ?? ex.Message;
            throw new Exception(detalheErro, ex);
        }
    }
}
