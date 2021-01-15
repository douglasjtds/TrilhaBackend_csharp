using Clientes.Application.UseCases;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Clientes.Test
{
    public class BuscarClienteTest
    {

        [Fact(DisplayName = "BuscarClienteSuccess: Deve retornar com sucesso um cliente.")]
        public void BuscarCliente_DeveEncontrarUmClienteValido_Success()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var cliente = new Cliente
            {
                Nome = "Teste Cliente Válido",
                CPF = "123456",
                Email = "cliente@cliente.com.br",
                Idade = 25,
                Telefone = "91091112535",
                Endereco = "rua sobradinho, 101"
            };

            var logger = Mock.Of<ILogger<BuscarClienteUseCase>>();

            var useCase = new BuscarClienteUseCase(
                logger,
                mockRepository.Object
            );


            // Act
            var result = useCase.Execute(cliente.CPF);

            // Assert
            result.Contains(cliente);
        }
    }
}
