using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SistemaGestaoConhecimento.Infra.Data.InterfacesConnection;

public interface IConnection
{
    void ConfigureConnection(DbContextOptionsBuilder options, IConfiguration configuration);
}
