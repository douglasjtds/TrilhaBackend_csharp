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

            mockRepository.Setup(s => s.Adicionar(cliente));

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

            mockRepository.Setup(s => s.Atualizar("123456", cliente)).Returns(true);

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


        [Fact(DisplayName = "SalvarNovoClienteError: Deve tentar salvar um novo cliente com um número no lugar do nome e dar erro.")]
        public void SalvarNovoCliente_DeveTentarSalvarUmClienteInvalido_NomeError()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var cliente = new Cliente
            {
                Nome = "666",
                CPF = "123456",
                Email = "cliente@cliente.com.br",
                Idade = 25,
                Telefone = "91091112535",
                Endereco = "rua sobradinho, 101"
            };

            var logger = Mock.Of<ILogger<SalvarClienteUseCase>>();

            mockRepository.Setup(s => s.Adicionar(cliente));

            var useCase = new SalvarClienteUseCase(
                logger,
                mockRepository.Object
            );

            string mensagem;

            // Act
            var result = useCase.Execute(cliente, out mensagem);

            // Assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "SalvarNovoClienteError: Deve tentar salvar um novo cliente com uma letra no campo CPF.")]
        public void SalvarNovoCliente_DeveTentarSalvarUmClienteInvalido_CPFError()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var cliente = new Cliente
            {
                Nome = "teste",
                CPF = "1234s56",
                Email = "cliente@cliente.com.br",
                Idade = 25,
                Telefone = "91091112535",
                Endereco = "rua sobradinho, 101"
            };

            var logger = Mock.Of<ILogger<SalvarClienteUseCase>>();

            mockRepository.Setup(s => s.Adicionar(cliente));

            var useCase = new SalvarClienteUseCase(
                logger,
                mockRepository.Object
            );

            string mensagem;

            // Act
            var result = useCase.Execute(cliente, out mensagem);

            // Assert
            result.Should().BeFalse();
        }


        [Fact(DisplayName = "AtualizarClienteError: Deve tentar atualizar o CPF de um cliente existente.")]
        public void AtualizarCliente_DeveTentarAtualizarOCPFDeUmCliente_CPFError()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepositorio>();
            var cliente = new Cliente
            {
                Nome = "teste",
                CPF = "123456",
                Email = "cliente@cliente.com.br",
                Idade = 25,
                Telefone = "91091112535",
                Endereco = "rua sobradinho, 101"
            };

            var logger = Mock.Of<ILogger<SalvarClienteUseCase>>();

            mockRepository.Setup(s => s.Atualizar("1234567", cliente)).Returns(false);

            var useCase = new SalvarClienteUseCase(
                logger,
                mockRepository.Object
            );

            string mensagem;

            // Act
            var result = useCase.Execute(cliente, out mensagem, "1234567");

            // Assert
            result.Should().BeFalse();
        }
    }
}
