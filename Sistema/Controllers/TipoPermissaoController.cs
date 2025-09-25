using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema.Application.Interfaces;
using Sistema.Models;

namespace Sistema.Controllers;

[ApiController]
[Route("api/tipoPermissao")]

public class TipoPermissaoController : ControllerBase
{
    private readonly ITipoPermissao _tipoPermissaoService;

    public TipoPermissaoController(ITipoPermissao tipoPermissaoService)
    {
        _tipoPermissaoService = tipoPermissaoService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] TipoPermissao tipoPermissao)
    {
        if (tipoPermissao == null) return BadRequest("Tipo permissão é null");

        try
        {
            await _tipoPermissaoService.ICriacaoTipoPermissao(tipoPermissao);
            return StatusCode(200, new
            {
                Sucesso = true,
                Menssagem = "Tipo permissao criada com sucesso"
            });
        }
        catch (Exception ex)
        {

            return StatusCode(500, new
            {
                Sucesso = false,
                Menssagem = "Erro ao cadastrar tipo permissao",
                Detalhes = ex.Message
            });
        }
    }
}

