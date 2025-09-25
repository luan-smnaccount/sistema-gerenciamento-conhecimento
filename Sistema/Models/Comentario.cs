using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class Comentario
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    // public Conteudo IdConteudo { get; set; }
    public Usuario IdUsuario { get; set; }
    public string Mensagem { get; set; }
}

