using Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Infraestrutura.EntityFramework.Mappers
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("dbo.CLIENTES")
                .HasKey(o => o.IdCliente);

            builder.Property(p => p.IdCliente)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(o => o.Idade)
                .HasColumnName("IDADE")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(o => o.CPF)
                .HasColumnName("CPF")
                .HasColumnType("CHAR(15)")
                .IsRequired();

            builder.Property(o => o.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(o => o.Telefone)
                .HasColumnName("TELEFONE")
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            builder.Property(o => o.Endereco)
                .HasColumnName("ENDERECO")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
        }
    }
}
