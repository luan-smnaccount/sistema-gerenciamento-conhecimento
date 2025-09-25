using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema.Application.Interfaces;
using Sistema.Models;

namespace Sistema.Controllers;

[ApiController]
[Route("api/statusUsuario")]
public class StatusUsuarioController : ControllerBase
{
    private readonly IStatusUsuario _statusUsuarioService;

    public StatusUsuarioController(IStatusUsuario statusUsuarioService)
    {
        _statusUsuarioService = statusUsuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] StatusUsuario statusUsuario)
    {
        if (statusUsuario == null) return BadRequest("Status usuario é nulo");

        try
        {
            await _statusUsuarioService.ICriacaoStatusUsuario(statusUsuario);
            return StatusCode(200, new
            {
                Sucesso = true,
                Menssagem = "Status usuario criado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Menssagem = "Erro ao cadastrar Status Usuario",
                Detalhes = ex.Message
            });
        }
    }
}
