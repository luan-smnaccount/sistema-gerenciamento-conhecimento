using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio.Entidades;

public class Avaliacao
{
    public int Id { get; set; }
    public byte IdAvaliacaoTipo { get; set; }
    public int IdUsuario { get; set; }
    public decimal? NotaFinal { get; set; }
    public DateOnly DataAvaliacao { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public int? UsuarioAtualizacao { get; set; }
    public DateTime? DataHoraAtualizacao { get; set; }

    [ForeignKey("IdAvaliacaoTipo")]
    public AvaliacaoTipo AvaliacaoTipo { get; set; }

    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; }
}
