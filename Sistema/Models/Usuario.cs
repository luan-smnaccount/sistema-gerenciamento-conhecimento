using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models;

public class Usuario
{
    public int Id { get; set; }
    public TipoPermissao IdTipoPermissao { get; set; }
    public Cargo IdCargo { get; set; }
    public Departamento IdDepartamento { get; set; }
    public StatusUsuario IdStatusUsuario { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateOnly DataCriacao { get; set; }
    public DateOnly DataAtualizacao { get; set; }
}

