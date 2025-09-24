using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class StatusUsuario
{
    public byte Id { get; set; }
    public Usuario IdUsuario { get; set; }
    public string Status { get; set; }

    public IEnumerable<Usuario> Usuario { get; set; }
}

