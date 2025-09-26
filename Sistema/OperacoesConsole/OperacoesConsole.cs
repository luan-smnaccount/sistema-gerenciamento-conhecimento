using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Application.Interfaces;
using Sistema.Controllers;
using Sistema.Models;

namespace Sistema.OperacoesConsole;

public class OperacoesConsole
{
    private readonly ICargo _cargoSevice;
    private readonly IDepartamento _departamentoService;
    private readonly IStatusUsuario _statusUsuarioService;
    private readonly ITipoPermissao _tipoPermissaoService;

    public OperacoesConsole(ICargo cargoService, IDepartamento departamentoService, IStatusUsuario statusUsuarioService, ITipoPermissao tipoPermissao)
    {
        _cargoSevice = cargoService;
        _departamentoService = departamentoService;
        _statusUsuarioService = statusUsuarioService;
        _tipoPermissaoService = tipoPermissao;
    }

    public void Menu()
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("\n === Bem-vindo(a)! === ");
            Console.WriteLine("[1] - Cadastrar");
            Console.WriteLine("[2] - Listar");
            Console.WriteLine("[3] - Atualizar");
            Console.WriteLine("[4] - Remover");
            Console.WriteLine("[0] - Sair");

            Console.WriteLine(" ");
            Console.Write("Informe qual operação você deseja realizar: ");
            string entrada = Console.ReadLine()!;

            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine(" ");
                Console.WriteLine("Entrada inválida. Tente novamente.");
                Thread.Sleep(1500);
                return;
            }

            switch (opcao)
            {
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    Listar();
                    break;
                case 3:
                    Atualizar();
                    break;
                case 4:
                    Remover();
                    break;
                case 0:
                    goto EncerrarPrograma;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente");
                    Thread.Sleep(1500);
                    break;
            }

        } while (opcao != 0);

    EncerrarPrograma:
        Console.Clear();
        Console.WriteLine("Encerrando programa...");
        Thread.Sleep(1500);
    }

    public void Cadastrar()
    {
        Console.WriteLine("");
        string tipoCadastro = StringValidation("Informe o que você deseja cadastrar: ");

        if (string.Equals(tipoCadastro, "cargo", StringComparison.OrdinalIgnoreCase))
        {
            string nomeCargo = StringValidation("Informo o nome do cargo que deseja cadastrar: ");

            var cargo = new Cargo
            {
                Nome = nomeCargo
            };

            _cargoSevice.ICriacaoCargo(cargo).GetAwaiter();

            Console.WriteLine("");
            Console.WriteLine("Cargo cadastrado com sucesso");
            Thread.Sleep(3000);
        }
        else if (string.Equals(tipoCadastro, "departamento", StringComparison.OrdinalIgnoreCase))
        {
            string nomeDepartamento = Console.ReadLine();

            var departamento = new Departamento
            {
                Nome = nomeDepartamento
            };

            _departamentoService.ICriacaoDepartamento(departamento).GetAwaiter();

            Console.WriteLine("");
            Console.WriteLine("Departamento cadastrado com sucesso");
            Thread.Sleep(3000);
        }
        else if (string.Equals(tipoCadastro, "status", StringComparison.OrdinalIgnoreCase))
        {
            string nomeStatus = Console.ReadLine();

            var statusUsuario = new StatusUsuario
            {
                Status = nomeStatus
            };

            _statusUsuarioService.ICriacaoStatusUsuario(statusUsuario).GetAwaiter();

            Console.WriteLine("");
            Console.WriteLine("Status cadastrado com sucesso");
            Thread.Sleep(3000);
        }

        else if (string.Equals(tipoCadastro, "permissao", StringComparison.OrdinalIgnoreCase))
        {
            string nomePermissao = Console.ReadLine();

            var tipoPermissao = new TipoPermissao
            {
                Nome = nomePermissao
            };

            _tipoPermissaoService.ICriacaoTipoPermissao(tipoPermissao).GetAwaiter();

            Console.WriteLine("");
            Console.WriteLine("Tipo permissao cadastrado com sucesso");
            Thread.Sleep(3000);
        }
    }

    public void Listar()
    {
    }

    public void Remover()
    {
    }

    public void Atualizar()
    {
    }

    public static string StringValidation(string mensagem)
    {
        string valor;

        while (true)
        {
            Console.Write(mensagem);
            valor = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(valor))
            {
                return valor;
            }

            Console.WriteLine("Entrada inválida. O campo não pode ser vazio.");
        }
    }
}

