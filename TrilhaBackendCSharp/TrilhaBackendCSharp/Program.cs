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
            Console.WriteLine("Exercício de CRUD do Desafio 2! TRILHA BACKEND!\r");
            Console.WriteLine("------------------------\n");

            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente();

            // Ask the user to choose an option.
            Console.WriteLine("Escolha a opção que deseja executar:");
            Console.WriteLine("\tc - Create");
            Console.WriteLine("\tr - Read");
            Console.WriteLine("\tu - Update");
            Console.WriteLine("\td - Delete");
            Console.WriteLine("\ts - Sair");
            Console.Write("O que deseja executar? ");

            // Use a switch statement to call the methods.
            switch (Console.ReadLine())
            {
                case "c":
                    Create();
                    break;
                case "r":
                    Read();
                    break;
                case "u":
                    Update();
                    break;
                case "d":
                    Delete();
                    break;
                case "s":
                    Console.WriteLine("\nSaindo da aplicação");
                    break;
            }
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
                            Console.WriteLine("Nome: ", item.Nome);
                            Console.WriteLine("Idade: ", item.Idade);
                            Console.WriteLine("CPF: ", item.CPF);
                            Console.WriteLine("Email: ", item.Email);
                            Console.WriteLine("Telefone: ", item.Telefone);
                            Console.WriteLine("Endereco: ", item.Endereco);
                        }
                        break;
                    case "e":
                        Console.WriteLine("Digite o CPF do cliente que deseja visualizar: ");
                        var cpfBuscado = Console.ReadLine();

                        foreach (var item in clientes)
                        {
                            if (item.CPF == cpfBuscado)
                            {
                                Console.WriteLine("Nome: ", item.Nome);
                                Console.WriteLine("Idade: ", item.Idade);
                                Console.WriteLine("CPF: ", item.CPF);
                                Console.WriteLine("Email: ", item.Email);
                                Console.WriteLine("Telefone: ", item.Telefone);
                                Console.WriteLine("Endereco: ", item.Endereco);
                            }
                        }
                        break;
                }
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
            }
            #endregion
        }
    }
}
