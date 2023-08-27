using Projeto02.Controllers;

namespace Projeto02;

/// <summary>
/// Classe para inicialização do projeto
/// </summary>
public class Program
{

    public static void Main(string[] args)
    {
        var funcionarioController = new FuncionarioController();

        funcionarioController.CadastrarFuncionario();

        Console.ReadKey();
    }
}