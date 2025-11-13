using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaGestaoConhecimento.Dominio.Entidades;

namespace SistemaGestaoConhecimento.Dominio.Interfaces;

public interface IConteudo
{
    Task<Conteudo> ICriacaoConteudo(Conteudo entity);
}
