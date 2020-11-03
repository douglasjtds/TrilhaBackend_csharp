using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CRUD_Desafio2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercício de CRUD do Desafio 2! TRILHA BACKEND!\r");
            Console.WriteLine("------------------------\n");


            // Ask the user to choose an option.
            Console.WriteLine("Escolha a opção que deseja executar:");
            Console.WriteLine("\tc - Create");
            Console.WriteLine("\tr - Read");
            Console.WriteLine("\tu - Update");
            Console.WriteLine("\td - Delete");
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
            }
            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the CRUD console app...");
            Console.ReadKey();



            #region [CRUD methods]
            void Create()
            {
                //List<Cliente> clientes = new List<Cliente>();
                Cliente cliente = new Cliente();

                //nome, idade, CPF, e-mail, telefone e endereço
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
            }

            void Read()
            {

            }

            void Update()
            {

            }

            void Delete()
            {

            } 
            #endregion
        }
    }
}
