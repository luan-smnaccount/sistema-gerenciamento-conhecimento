using Microsoft.AspNetCore.Mvc;
using SistemaGestaoConhecimento.Dominio.Entidades;
using SistemaGestaoConhecimento.Dominio.Interfaces;

namespace SistemaGestaoConhecimento.Api.Controllers;

[ApiController]
[Route("api/modulo")]
public class ModuloController : ControllerBase
{
    private readonly IModulo _Imodulo;

    public ModuloController(IModulo imodulo)
    {
        _Imodulo = imodulo;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Modulo modulo)
    {
        if (modulo == null) return BadRequest("Modulo é nulo");

        try
        {
            await _Imodulo.ICriacaoModulo(modulo);
            return StatusCode(200, new
            {
                Sucesso = true,
                Message = "Modulo cadastrado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Message = "Erro ao cadastrar modulo",
                Detalhe = ex.Message
            });
        }
    }
}
