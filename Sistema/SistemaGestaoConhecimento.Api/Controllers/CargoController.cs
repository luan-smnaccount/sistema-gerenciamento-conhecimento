using Microsoft.AspNetCore.Mvc;
using SistemaGestaoConhecimento.Dominio;

namespace SistemaGestaoConhecimento.Api;

[ApiController]
[Route("api/cargo")]
public class CargoController : ControllerBase
{
    private readonly ICargo _Icargo;

    public CargoController(ICargo icargo)
    {
        _Icargo = icargo;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Cargo cargo)
    {
        if (cargo == null) return BadRequest("Cargo está nulo");

        try
        {
            await _Icargo.ICriacaoCargo(cargo);
            return StatusCode(200, new
            {
                Sucesso = true,
                Menssagem = "Cargo cadastrado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Menssagem = "Erro ao cadastrar cargo",
                Detalhe = ex.Message
            });
        }
    }
}
