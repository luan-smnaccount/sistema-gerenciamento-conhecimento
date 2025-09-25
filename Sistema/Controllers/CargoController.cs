using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema.Application.Interfaces;
using Sistema.Models;

namespace Sistema.Controllers;

[ApiController]
[Route("api/cargo")]
public class CargoController : ControllerBase
{
    private readonly ICargo _cargoService;

    public CargoController(ICargo cargoService)
    {
        _cargoService = cargoService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Cargo cargo)
    {
        if (cargo == null) return BadRequest("Cargo é nulo");

        try
        {
            await _cargoService.ICriacaoCargo(cargo);
            return StatusCode(200, new
            {
                Sucesso = true,
                Menssagem = "Cargo criado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Menssagem = "Erro ao cadastrar cargo",
                Detalhes = ex.Message
            });
        }
    }
}
