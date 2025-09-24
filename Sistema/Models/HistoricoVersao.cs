using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class HistoricoVersao
{
    public int Id { get; set; }
    public Conteudo IdConteudo { get; set; }
    public Usuario IdUsuario { get; set; }
    public string DescricaoVersao { get; set; }
    public DateTime DataVersao { get; set; }
}
