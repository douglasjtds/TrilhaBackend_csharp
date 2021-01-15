using Clientes.Application.UseCases;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;


namespace Clientes.Test
{
    public class SalvarClienteTest
    {
        [Fact(DisplayName = "SalvarNovoClienteSuccess: Deve salvar com sucesso um novo cliente.")]
        public void SalvarNovoCliente_DeveSalvarUmClienteValido_Success()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var cliente = new Cliente
            {
                Nome = "Teste Cliente Válido para salvar",
                CPF = "123456",
                Email = "cliente@cliente.com.br",
                Idade = 25,
                Telefone = "91091112535",
                Endereco = "rua sobradinho, 101"
            };

            var logger = Mock.Of<ILogger<SalvarClienteUseCase>>();

            var useCase = new SalvarClienteUseCase(
                logger,
                mockRepository.Object
            );

            string mensagem;

            // Act
            var result = useCase.Execute(cliente, out mensagem);

            // Assert
            result.Should().BeTrue();
        }


        [Fact(DisplayName = "AtualizarClienteSuccess: Deve atualizar com sucesso um cliente já existente.")]
        public void AtualizarCliente_DeveAtualizarUmClienteValido_Success()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var cliente = new Cliente
            {
                Nome = "Teste Cliente Válido para atualizar",
                CPF = "123456",
                Email = "cliente@cliente.com.br",
                Idade = 25,
                Telefone = "91091112535",
                Endereco = "rua sobradinho, 101"
            };

            var logger = Mock.Of<ILogger<SalvarClienteUseCase>>();

            var useCase = new SalvarClienteUseCase(
                logger,
                mockRepository.Object
            );

            string mensagem;

            // Act
            var result = useCase.Execute(cliente, out mensagem, "123456");

            // Assert
            result.Should().BeTrue();
        }
    }
}
