using Microsoft.AspNetCore.Mvc;
using SistemaGestaoConhecimento.Dominio.Entidades;
using SistemaGestaoConhecimento.Dominio.Interfaces;

namespace SistemaGestaoConhecimento.Api.Controllers;

[ApiController]
[Route("api/anexo")]
public class AnexoController : ControllerBase
{
    private readonly IAnexo _Ianexo;

    public AnexoController(IAnexo ianexo)
    {
        _Ianexo = ianexo;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Anexo anexo)
    {
        if (anexo == null) return BadRequest("Anexo é nulo");

        try
        {
            await _Ianexo.ICriacaoAnexo(anexo);
            return StatusCode(200, new
            {
                Sucesso = true,
                Message = "Anexo cadastrado com sucesso!"
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
