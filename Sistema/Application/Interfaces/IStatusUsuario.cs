using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Models;

namespace Sistema.Application.Interfaces;

public interface IStatusUsuario
{
    Task<StatusUsuario> ICriacaoStatusUsuario(StatusUsuario entity);
}

