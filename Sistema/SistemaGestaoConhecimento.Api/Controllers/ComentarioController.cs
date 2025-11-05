using Microsoft.AspNetCore.Mvc;
using SistemaGestaoConhecimento.Dominio.Entidades;
using SistemaGestaoConhecimento.Dominio.Interfaces;

namespace SistemaGestaoConhecimento.Api.Controllers;

[ApiController]
[Route("api/comentario")]
public class ComentarioController : ControllerBase
{
    private readonly IComentario _Icomentario;

    public ComentarioController(IComentario icomentario)
    {
        _Icomentario = icomentario;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Comentario comentario)
    {
        if (comentario == null) return BadRequest("Comentario é nulo");

        try
        {
            await _Icomentario.ICriacaoComentario(comentario);
            return StatusCode(200, new
            {
                Sucesso = true,
                Message = "Comentario cadastrado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Message = "Erro ao cadastrar comentario",
                Detalhes = ex.Message
            });
        }
    }
}

