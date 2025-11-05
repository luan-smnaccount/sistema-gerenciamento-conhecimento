using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoConhecimento.Dominio.Entidades;

public class Comentario
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public string Descricao { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public int? UsuarioAtualizacao { get; set; }
    public DateTime? DataHoraAtualizacao { get; set; }

    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; }
}
