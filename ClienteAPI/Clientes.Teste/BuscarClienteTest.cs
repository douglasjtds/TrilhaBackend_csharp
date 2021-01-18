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

            mockRepository.Setup(s => s.Get(It.IsAny<string>));

            var useCase = new BuscarClienteUseCase(
                logger,
                mockRepository.Object
            );


            // Act
            var result = useCase.Execute(cliente.CPF);

            // Assert
            result.Contains(cliente);
            result.Should().NotBeEmpty();
        }


        [Fact(DisplayName = "BuscarClientesSuccess: Deve retornar com sucesso uma lista de clientes.")]
        public void BuscarClientes_DeveEncontrarVariosClientesValidos_Success()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var clientes = new List<Cliente>() {
                new Cliente
                {
                    Nome = "Teste Cliente Válido",
                    CPF = "123456",
                    Email = "cliente@cliente.com.br",
                    Idade = 25,
                    Telefone = "91091112535",
                    Endereco = "rua sobradinho, 101"
                },
                new Cliente
                {
                    Nome = "Teste Cliente Válido 2",
                    CPF = "66666",
                    Email = "cliente2@cliente.com.br",
                    Idade = 30,
                    Telefone = "91091112535",
                    Endereco = "rua sobradinho, 151"
                },
                new Cliente
                {
                    Nome = "Teste Cliente Válido 3",
                    CPF = "66666",
                    Email = "cliente3@cliente.com.br",
                    Idade = 52,
                    Telefone = "91091112535",
                    Endereco = "rua sobradinho, 250"
                }
            };

            var logger = Mock.Of<ILogger<BuscarClienteUseCase>>();

            var useCase = new BuscarClienteUseCase(
                logger,
                mockRepository.Object
            );

            // Act
            var result = useCase.Execute();

            // Assert
            result.Should().NotBeEmpty();
        }
    }
}
