using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class Avaliacao
{
    public int Id { get; set; }
    public UsuarioAvaliacao IdUsuarioAvaliacao { get; set; }
    public TipoAvaliacao IdTipoAvaliacao { get; set; }
    public int NotaFinal { get; set; }
    public DateOnly DataAvaliacao { get; set; }
    public DateOnly DataAtualizacao { get; set; }

    public IEnumerable<UsuarioAvaliacao> UsuarioAvaliacao { get; set; }
    public IEnumerable<ConteudoAvaliacao> ConteudoAvaliacao { get; set; }
}

