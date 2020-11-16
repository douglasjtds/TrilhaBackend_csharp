using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace TrilhaBackendCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var repository = new ClienteRepositorio();
            //foreach (var cliente  in repository.Consultar())
            //    Console.WriteLine(cliente.Imprimir);

            /*Console.WriteLine("Exercício de CRUD do Desafio 2! TRILHA BACKEND!\r");
            Console.WriteLine("------------------------\n");

            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente();

            int menuControl;

            do
            {
                // Ask the user to choose an option.
                Console.WriteLine("Escolha a opção que deseja executar:");
                Console.WriteLine("\t1 - Create");
                Console.WriteLine("\t2 - Read");
                Console.WriteLine("\t3 - Update");
                Console.WriteLine("\t4 - Delete");
                Console.WriteLine("\t0 - Sair do programa");
                Console.Write("O que deseja executar? ");

                // Use a switch statement to call the methods.
                menuControl = Int32.Parse(Console.ReadLine());
                switch (menuControl)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Read();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    default:
                        Console.WriteLine("\nSaindo da aplicação");
                        CloseConsole();
                        break;
                }
            } while (menuControl != 0);
            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the CRUD console app...");
            Console.ReadKey();


            #region [CRUD methods]
            void Create()
            {
                //A operação de Create deve popular o cadastro de um cliente e inserir na estrutura.
                Console.WriteLine("\nVocê escolheu adicionar um novo cliente.\n");
                Console.Write("Digite o nome do novo cliente: ");
                cliente.Nome = Console.ReadLine();

                Console.Write("Digite a idade do novo cliente: ");
                cliente.Idade = Console.ReadLine();

                Console.Write("Digite o CPF do novo cliente: ");
                cliente.CPF = Console.ReadLine();

                Console.Write("Digite o e-mail do novo cliente: ");
                cliente.Email = Console.ReadLine();

                Console.Write("Digite o telefone do novo cliente: ");
                cliente.Telefone = Console.ReadLine();

                Console.Write("Digite o endereço do novo cliente: ");
                cliente.Endereco = Console.ReadLine();

                clientes.Add(cliente);

                Console.WriteLine("\nNovo cliente cadastrado com sucesso.\n");

                Console.Clear();
            }

            void Read()
            {
                //A operação de Read  deve permitir visualizar todos os clientes ou um só pelo CPF.
                Console.WriteLine("\nVocê escolheu a opção de buscar por cliente(s).\n");
                Console.WriteLine("Deseja buscar por todos os clientes ou por um específico? ");

                Console.WriteLine("\tt - Todos");
                Console.WriteLine("\te - Um específico");

                switch (Console.ReadLine())
                {
                    case "t":
                        foreach (var item in clientes)
                        {
                            Console.WriteLine("Nome: {0}", item.Nome);
                            Console.WriteLine("Idade: {0}", item.Idade);
                            Console.WriteLine("CPF: {0}", item.CPF);
                            Console.WriteLine("Email: {0}", item.Email);
                            Console.WriteLine("Telefone: {0}", item.Telefone);
                            Console.WriteLine("Endereco: {0}", item.Endereco);
                        }

                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadKey();
                        break;
                    case "e":
                        Console.WriteLine("Digite o CPF do cliente que deseja visualizar: ");
                        var cpfBuscado = Console.ReadLine();

                        foreach (var item in clientes)
                        {
                            if (item.CPF == cpfBuscado)
                            {
                                Console.WriteLine("Nome: {0}", item.Nome);
                                Console.WriteLine("Idade: {0}", item.Idade);
                                Console.WriteLine("CPF: {0}", item.CPF);
                                Console.WriteLine("Email: {0}", item.Email);
                                Console.WriteLine("Telefone: {0}", item.Telefone);
                                Console.WriteLine("Endereco: {0}", item.Endereco);
                            }
                        }
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }

            void Update()
            {
                //A operação de Update deve permitir alterar um ou mais dos dados de um cliente a partir do CPF dele(O campo CPF não pode ser alterado).
                Console.WriteLine("\nVocê escolheu a opção de atualizar os dados de um cliente.\n");
                Console.WriteLine("Digite o CPF do cliente que deseja atualizar (O campo CPF não pode ser alterado): ");

                var cpfCliente = Console.ReadLine();
                foreach (var item in clientes)
                {
                    if (cpfCliente == item.CPF)
                    {
                        Console.Write("Digite o novo nome do novo cliente: ");
                        cliente.Nome = Console.ReadLine();

                        Console.Write("Digite a nova idade do novo cliente: ");
                        cliente.Idade = Console.ReadLine();

                        Console.Write("Digite o novo e-mail do novo cliente: ");
                        cliente.Email = Console.ReadLine();

                        Console.Write("Digite o novo telefone do novo cliente: ");
                        cliente.Telefone = Console.ReadLine();

                        Console.Write("Digite o novo endereço do novo cliente: ");
                        cliente.Endereco = Console.ReadLine();
                    }
                    clientes.Add(item); //acho que não posso fazer isso pq vai ficar dois clientes com o mesmo CPF e dados diferentes
                }
                Console.Clear();
            }

            void Delete()
            {
                //A operação de Delete deve permitir excluir um cliente da estrutura pelo CPF dele.
                Console.WriteLine("\nVocê escolheu a opção de excluir um cliente.\n");
                Console.WriteLine("Digite o CPF do cliente que deseja excluir: ");
                var cpfCliente = Console.ReadLine();

                foreach (var item in clientes)
                {
                    if (cpfCliente == item.CPF)
                        clientes.Remove(item);
                }

                Console.Clear();
            }
            #endregion

            #region para fechar o programa
            static void CloseConsole()
            {
                Console.WriteLine();
                Console.WriteLine("Você saiu do programa. Clique qualquer tecla para fechar...");
            }
            #endregion
            */
        }
    }
}
