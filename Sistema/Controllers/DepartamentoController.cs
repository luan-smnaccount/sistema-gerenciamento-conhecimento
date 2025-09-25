using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema.Application.Interfaces;
using Sistema.Models;

namespace Sistema.Controllers;

[ApiController]
[Route("api/departamento")]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamento _departamentoService;

    public DepartamentoController(IDepartamento departamentoService)
    {
        _departamentoService = departamentoService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Departamento departamento)
    {
        if (departamento == null) return BadRequest("Departamento é nulo");

        try
        {
            await _departamentoService.ICriacaoDepartamento(departamento);
            return StatusCode(200, new
            {
                Sucesso = true,
                Menssagem = "Departamento criado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Menssagem = "Erro ao cadastrar Departamento",
                Detalhes = ex.Message
            });
        }
    }
}

