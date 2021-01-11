using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Infraestrutura.EntityFramework.Mappers
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //builder.Property(p => p.Nome).HasCollumnName("NOME").HasCollumnType("varchar(50)");
            builder.Property(o => o.Nome).HasMaxLength(50);
            builder.Property(o => o.Idade);
            builder.Property(o => o.CPF);
            builder.Property(o => o.Email).HasMaxLength(50);
            builder.Property(o => o.Telefone).HasMaxLength(20);
            builder.Property(o => o.Endereco).HasMaxLength(100);



            //    Nome = nome;
            //Idade = idade;
            //CPF = cpf;
            //Email = email;
            //Telefone = telefone;
            //Endereco = endereco;
        }
    }
}
