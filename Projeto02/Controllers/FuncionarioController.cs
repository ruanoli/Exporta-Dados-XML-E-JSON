using Projeto02.Entities;
using Projeto02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Controllers
{
    /// <summary>
    /// Controlador para operações de funcionário
    /// </summary>
    public class FuncionarioController
    {
        /// <summary>
        /// Método para realizar o fluxo de cadastro de um funcionário.
        /// </summary>
        public void CadastrarFuncionario()
        {
            try
            {
                #region Leitura de dados do Setor
                var setor = new Setor();

                setor.Id = Guid.NewGuid();

                Console.WriteLine("Insira o nome do setor");
                setor.Nome = Console.ReadLine();

                #endregion

                #region Leitura dos dados da Função

                var funcao = new Funcao();
                funcao.Id = Guid.NewGuid();

                Console.WriteLine("Insira o nome da função:");
                funcao.Nome = Console.ReadLine();

                Console.WriteLine("Descreva a função:");
                funcao.Descricao = Console.ReadLine();

                #endregion

                #region Leitura dos dados do Funcionário

                var funcionario = new Funcionario();
                funcionario.Id = Guid.NewGuid();
                funcionario.Setor = setor;
                funcionario.Funcao = funcao;

                Console.WriteLine("Insira o nome do Funcioário:");
                funcionario.Nome = Console.ReadLine();

                Console.WriteLine("Insira o CPF do funcionário:");
                funcionario.Cpf = Console.ReadLine();

                Console.WriteLine("Insira a matrícula do funcioário:");
                funcionario.Matricula = Console.ReadLine();

                Console.WriteLine("Informe a data de admissão:");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Dados capturados com sucesso!");

                #endregion


                #region Exportando os arquivos

                Console.WriteLine("\nDeseja exportar os dados em qual formato? JSON digite 'J' ou XML digite 'X'.");
                var opcao = Console.ReadLine().ToLower();

                switch (opcao)
                {
                    case "x":
                        var funcionarioXml = new FuncionarioRepositoryXml();
                        funcionarioXml.Exportar(funcionario);
                        Console.WriteLine("\nDados em XML exportados com sucesso!");

                        break;
                    case "j":
                        var funcionarioJson = new FuncionarioRepositoryJson();
                        funcionarioJson.Exportar(funcionario);
                        Console.WriteLine("\nDados em JSON exportados com sucesso!");

                        break;
                    default:
                        Console.WriteLine("\nFormato inválido");
                        break;
                }

                #endregion
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"Erro de validação: {ae.Message}");

                Console.WriteLine("Deseja tentar novamente?");

                var opcao = Console.ReadLine();

                if( opcao != null && opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();

                    CadastrarFuncionario(); //recursividade
                }
                else
                {
                    Console.WriteLine("Programa encerrado.");

                }


            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao realizar o cadastro {ex.Message}");
            }
        }
    }
}
