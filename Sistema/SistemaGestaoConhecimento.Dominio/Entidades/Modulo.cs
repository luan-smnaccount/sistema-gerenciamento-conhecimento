using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio.Entidades;

public class Modulo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdAvaliacao { get; set; }
    public int? IdModulo { get; set; }
    public string Nome { get; set; }
    public int UsuarioCadastro { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public int? UsuarioAtualizacao { get; set; }
    public DateTime? DataHoraAtualizacao { get; set; }

    public IEnumerable<Modulo> Modulos { get; set; }

    [ForeignKey("IdModulo")]
    public Modulo modulo { get; set; }

    [ForeignKey("IdAvaliacao")]
    public Avaliacao Avaliacao { get; set; }
}
