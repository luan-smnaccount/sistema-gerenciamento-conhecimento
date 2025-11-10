using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaGestaoConhecimento.Infra.Data.InterfacesConnection;

namespace SistemaGestaoConhecimento.Infra.Data.EntidadesConnection;

public class SqlServerDatabaseConnection : IConnection
{
    public void ConfigureConnection(DbContextOptionsBuilder options, IConfiguration configuration)
    {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
}
