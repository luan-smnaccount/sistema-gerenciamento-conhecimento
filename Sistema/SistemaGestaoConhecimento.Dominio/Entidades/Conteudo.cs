using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoConhecimento.Dominio.Entidades;

public class Conteudo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdConteudoTipo { get; set; }
    public int IdCategoria { get; set; }
    public int IdTag { get; set; }
    public string ConteudoAula { get; set; }
    public string Descricao { get; set; }
    public string LinkVideo { get; set; }
    public int UsuarioCadastro { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public int? UsuarioAtualizacao { get; set; }
    public DateTime? DataHoraAtualizacao { get; set; }

    public Tag Tag { get; set; }
    public Categoria Categoria { get; set; }
    public ConteudoTipo ConteudoTipo { get; set; }
}
