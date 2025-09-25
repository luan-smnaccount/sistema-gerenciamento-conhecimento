using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Application.Interfaces;
using Sistema.Context;
using Sistema.Models;

namespace Sistema.Application.Services;

public class StatusUsuarioService : IStatusUsuario
{
    private readonly AppDbContext _db;

    public StatusUsuarioService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<StatusUsuario> ICriacaoStatusUsuario(StatusUsuario entity)
    {
        if (entity == null) throw new ArgumentException(nameof(entity));

        await _db.StatusUsuario.AddAsync(entity);

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

