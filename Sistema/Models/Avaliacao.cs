using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class Avaliacao
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public TipoAvaliacao IdTipoAvaliacao { get; set; }
    public int NotaFinal { get; set; }
    public DateOnly DataAvaliacao { get; set; }
    public DateOnly DataAtualizacao { get; set; }

    public IEnumerable<UsuarioAvaliacao> UsuarioAvaliacao { get; set; }
    public IEnumerable<ConteudoAvaliacao> ConteudoAvaliacao { get; set; }
}

