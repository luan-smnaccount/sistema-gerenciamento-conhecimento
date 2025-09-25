using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class UsuarioAvaliacao
{
    [Key]
    public int Id { get; set; }

    public int IdUsuario { get; set; }
    public int IdAvaliacao { get; set; }

    public Usuario Usuario { get; set; }
    public Avaliacao Avaliacao { get; set; }
}

