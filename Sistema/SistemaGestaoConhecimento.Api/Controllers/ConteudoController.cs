using Microsoft.AspNetCore.Mvc;
using SistemaGestaoConhecimento.Dominio.Entidades;
using SistemaGestaoConhecimento.Dominio.Interfaces;

namespace SistemaGestaoConhecimento.Api.Controllers;

[ApiController]
[Route("api/conteudo")]
public class ConteudoController : ControllerBase
{
    private readonly IConteudo _IConteudo;

    public ConteudoController(IConteudo iConteudo)
    {
        _IConteudo = iConteudo;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Conteudo conteudo)
    {
        if (conteudo == null) return BadRequest("Conteudo é nulo");

        try
        {
            await _IConteudo.ICriacaoConteudo(conteudo);
            return StatusCode(200, new
            {
                Sucesso = true,
                Message = "Conteudo cadastrado com sucesso!"
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
