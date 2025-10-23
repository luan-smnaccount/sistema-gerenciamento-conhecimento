using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoConhecimento.Dominio;

namespace SistemaGestaoConhecimento.Api;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuario _Iusuario;

    public UsuarioController(IUsuario iusuario)
    {
        _Iusuario = iusuario;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Usuario usuario)
    {
        if (usuario == null) return BadRequest("Usuario é nulo");

        try
        {
            await _Iusuario.ICriacaoUsuario(usuario);
            return StatusCode(200, new
            {
                Sucesso = true,
                Message = "Usuário cadastrado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Message = "Erro ao cadastrar usuario",
                Detalhes = ex.Message
            });
        }
    }
}
