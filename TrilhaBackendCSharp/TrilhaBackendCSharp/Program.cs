using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using TrilhaBackendCSharp.Dominio.Entidades;
using TrilhaBackendCSharp.Infraestrutura.Repositorios;

namespace TrilhaBackendCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var repository = new ClienteRepositorio();

            /*//teste consultar
            foreach (var cliente in repository.Consultar(""))
                Console.WriteLine(cliente.Imprimir);

            //teste salvar
            //Cliente novoCliente = new Cliente("Douglas", 25, "1", "teste@teste.com", "2345678", "Rua 1");
            //repository.Salvar(novoCliente);
            //foreach (var cliente in repository.Consultar(""))
            //    Console.WriteLine(cliente.Imprimir);


            //teste remover
            //repository.Remover("12161543");
            //foreach (var cliente in repository.Consultar("12161543"))
            //    Console.WriteLine(cliente.Imprimir);

            Console.WriteLine("----------teste update----------");
            Cliente atualizarCliente = new Cliente("Douglas", 25, "123456789", "douglas.tertuliano@zup.com.br", "91848090", "Rua São Geraldo");
            repository.Salvar(atualizarCliente);
            foreach (var cliente in repository.Consultar())
                Console.WriteLine(cliente.Imprimir); */

            Console.WriteLine("Exercício de CRUD do Desafio 2! TRILHA BACKEND!\r");
            Console.WriteLine("------------------------\n");

            //List<Cliente> clientes = new List<Cliente>();
            //Cliente cliente = new Cliente();

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
                var nome = Console.ReadLine();

                Console.Write("Digite a idade do novo cliente: ");
                int idade = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite o CPF do novo cliente: ");
                var cpf = Console.ReadLine();

                Console.Write("Digite o e-mail do novo cliente: ");
                var email = Console.ReadLine();

                Console.Write("Digite o telefone do novo cliente: ");
                var telefone = Console.ReadLine();

                Console.Write("Digite o endereço do novo cliente: ");
                var endereco = Console.ReadLine();

                var cliente = new Cliente(nome, idade, cpf, email, telefone, endereco);

                repository.Salvar(cliente);

                Console.WriteLine("\nNovo cliente cadastrado com sucesso.\n");

                Console.Clear();
            }

            void Read()
            {
                //A operação de Read  deve permitir visualizar todos os clientes ou um só pelo CPF.
                Console.WriteLine("\nVocê escolheu a opção de buscar por cliente(s).\n");
                Console.WriteLine("Você pode digitar o CPF específico para buscar ou apenas apertar enter para buscar todos: ");

                var valorDigitado = Console.ReadLine();

                //teste consultar
                foreach (var cliente in repository.Consultar(valorDigitado))
                    Console.WriteLine("\n" + cliente.Imprimir);

                Console.Clear();
            }

            void Update()
            {
                //A operação de Update deve permitir alterar um ou mais dos dados de um cliente a partir do CPF dele(O campo CPF não pode ser alterado).
                Console.WriteLine("\nVocê escolheu a opção de atualizar os dados de um cliente.\n");
                Console.WriteLine("Digite o CPF do cliente que deseja atualizar (O campo CPF não pode ser alterado): ");
                var cpfCliente = Console.ReadLine();

                Console.WriteLine("\nAdicione os novos dados desse Cliente.\n");

                Console.Write("Digite o novo nome do cliente: ");
                var nome = Console.ReadLine();

                Console.Write("Digite a nova idade do cliente: ");
                var idade = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite o novo e-mail do cliente: ");
                var email = Console.ReadLine();

                Console.Write("Digite o novo telefone do cliente: ");
                var telefone = Console.ReadLine();

                Console.Write("Digite o novo endereco do cliente: ");
                var endereco = Console.ReadLine();

                var clienteAtualizado = new Cliente(nome, idade, cpfCliente, email, telefone, endereco);
                repository.Salvar(clienteAtualizado);

                Console.WriteLine("\nCliente atualizado com sucesso.\n");

                Console.Clear();
            }

            void Delete()
            {
                //A operação de Delete deve permitir excluir um cliente da estrutura pelo CPF dele.
                Console.WriteLine("\nVocê escolheu a opção de excluir um cliente.\n");
                Console.WriteLine("Digite o CPF do cliente que deseja excluir: ");
                var cpfCliente = Console.ReadLine();

                if (repository.Remover(cpfCliente))
                    Console.WriteLine("\nCliente com o CPF {0} removido com sucesso.\n", cpfCliente);
                else
                    Console.WriteLine("\nCliente com o CPF {0} não encontrado na base.\n", cpfCliente);

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

        }
    }
}
