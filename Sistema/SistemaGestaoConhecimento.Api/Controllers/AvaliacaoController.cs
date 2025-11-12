using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoConhecimento.Dominio.Entidades;
using SistemaGestaoConhecimento.Dominio.Interfaces;

namespace SistemaGestaoConhecimento.Api.Controllers;

[ApiController]
[Route("api/avalicao")]
public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacao _Iavaliacao;

    public AvaliacaoController(IAvaliacao iavaliacao)
    {
        _Iavaliacao = iavaliacao;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Avaliacao avaliacao)
    {
        if (avaliacao == null) return BadRequest("Avaliação é nula");

        try
        {
            await _Iavaliacao.ICriacaoAvaliacao(avaliacao);
            return StatusCode(200, new
            {
                Sucesso = true,
                Message = "Avaliacao cadastrada com sucesso!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Sucesso = false,
                Message = "Erro ao cadastrar avaliacao",
                Detalhe = ex.Message
            });
        }
    }
}
