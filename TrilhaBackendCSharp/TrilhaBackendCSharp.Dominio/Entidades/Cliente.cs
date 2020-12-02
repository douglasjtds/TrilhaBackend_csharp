namespace TrilhaBackendCSharp.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente(string nome, int idade, string cpf, string email, string telefone, string endereco)
        {
            Nome = nome;
            Idade = idade;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public string Imprimir => string.Concat("Nome: ", Nome, "\nIdade: ", Idade, "\nCPF: ", CPF, "\nE-mail: ", Email, "\nTelefone: ", Telefone, "\nEndereço: ", Endereco, "\n");
    }
}
