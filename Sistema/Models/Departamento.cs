using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class Departamento
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public short Id { get; set; }
    public Usuario IdUsuario { get; set; }
    public string Nome { get; set; }

    public IEnumerable<Usuario> Usuario { get; set; }
}
