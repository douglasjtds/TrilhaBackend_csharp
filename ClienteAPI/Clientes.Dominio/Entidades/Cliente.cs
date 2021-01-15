namespace Clientes.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente()
        {

        }

        public Cliente(int idCliente, string nome, int idade, string cpf, string email, string telefone, string endereco)
        {
            IdCliente = idCliente;
            Nome = nome;
            Idade = idade;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }


        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        //public class ClienteValidator : AbstractValidator<Cliente>
        //{
        //    public ClienteValidator()
        //    {
        //        RuleFor(cliente => cliente.Nome).NotNull().NotEmpty();
        //        RuleFor(cliente => cliente.Idade).NotNull().NotEmpty();
        //        RuleFor(cliente => cliente.CPF).NotNull().NotEmpty();
        //        RuleFor(cliente => cliente.Email).NotNull().NotEmpty();
        //        RuleFor(cliente => cliente.Telefone).NotNull().NotEmpty();
        //        RuleFor(cliente => cliente.Endereco).NotNull().NotEmpty();
        //    }
        //}
    }
}
