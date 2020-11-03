using System;
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
