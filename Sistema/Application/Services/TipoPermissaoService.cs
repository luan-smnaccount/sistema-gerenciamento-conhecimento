using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Application.Interfaces;
using Sistema.Context;
using Sistema.Models;

namespace Sistema.Application.Services;

public class TipoPermissaoService : ITipoPermissao
{
    private readonly AppDbContext _db;

    public TipoPermissaoService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<TipoPermissao> ICriacaoTipoPermissao(TipoPermissao entity)
    {
        if (entity == null) throw new ArgumentException(nameof(entity));

        await _db.TipoPermissao.AddAsync(entity);
        try
        {
            await _db.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            var detalhesErros = ex.InnerException?.Message ?? ex.Message;
            throw new Exception(detalhesErros, ex);
        }
    }
}

