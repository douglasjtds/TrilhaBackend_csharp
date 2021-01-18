using Clientes.Application.UseCases;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Repositorios;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Clientes.Test
{
    public class RemoverClienteTest
    {
        [Fact(DisplayName = "RemoverClienteSuccess: Deve remover com sucesso um cliente.")]
        public void RemoverCliente_DeveRemoverUmClienteValido_Success()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var cliente = new Cliente
            {
                Nome = "Teste Cliente Válido para remover",
                CPF = "123456",
                Email = "cliente@cliente.com.br",
                Idade = 25,
                Telefone = "91091112535",
                Endereco = "rua sobradinho, 101"
            };

            var logger = Mock.Of<ILogger<RemoverClienteUseCase>>();

            mockRepository.Setup(s => s.Excluir(It.IsAny<string>())).Returns(true);

            var useCase = new RemoverClienteUseCase(
                logger,
                mockRepository.Object
            );

            string mensagem;

            // Act
            var result = useCase.Execute(cliente.CPF, out mensagem);

            // Assert
            result.Should().BeTrue();
        }


        [Fact(DisplayName = "RemoverClienteError: Deve tentar remover um cliente.")]
        public void RemoverCliente_DeveTentarRemoverUmClienteQueNaoExiste_Error()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var cliente = new Cliente
            {
                Nome = "Teste Cliente Válido para remover",
                CPF = "123456",
                Email = "cliente@cliente.com.br",
                Idade = 25,
                Telefone = "91091112535",
                Endereco = "rua sobradinho, 101"
            };

            var logger = Mock.Of<ILogger<RemoverClienteUseCase>>();

            mockRepository.Setup(s => s.Excluir(It.IsAny<string>())).Returns(false);

            var useCase = new RemoverClienteUseCase(
                logger,
                mockRepository.Object
            );

            string mensagem;

            // Act
            var result = useCase.Execute("123456789", out mensagem);

            // Assert
            result.Should().BeFalse();
        }
    }
}
