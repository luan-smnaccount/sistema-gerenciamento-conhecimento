using Microsoft.AspNetCore.Mvc;
using SistemaGestaoConhecimento.Dominio;

namespace SistemaGestaoConhecimento.Api;

[ApiController]
[Route("api/departamento")]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamento _Idepartamento;

    public DepartamentoController(IDepartamento Idepartamento)
    {
        _Idepartamento = Idepartamento;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Departamento departamento)
    {
        if (departamento == null) return BadRequest("Departamento é nulo");

        try
        {
            await _Idepartamento.ICricaoDepartamento(departamento);
            return StatusCode(200, new
            {
                Sucesso = true,
                Messagem = "Departamento criado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Message = "Erro ao cadastrar departamento",
                Detalhes = ex.Message
            });
        }
    }
}
