using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoConhecimento.Dominio.Entidades;

public class Anexo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public byte IdAnexoTipo { get; set; }
    public string Nome { get; set; }
    public string CaminhoArquivo { get; set; }
    public int UsuarioCadastro { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public int? UsuarioAtualizacao { get; set; }
    public DateTime? DataHoraAtualizacao { get; set; }

    public AnexoTipo AnexoTipo { get; set; }
}
