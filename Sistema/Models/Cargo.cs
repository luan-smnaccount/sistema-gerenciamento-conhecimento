using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class Cargo
{
    public short Id { get; set; }
    public Usuario IdUsuario { get; set; }
    public string Nome { get; set; }

    public IEnumerable<Usuario> Usuario { get; set; }
}

