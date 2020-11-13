namespace TrilhaBackendCSharp.Infraestrutura.DatabaseInMemory
{
    internal class Create
    {
        public static readonly string CREATE_DATABASE_IN_MEMORY = @"
            CREATE TABLE CLIENTES(
                NOME VARCHAR(50) NOT NULL,
                IDADE INT NOT NULL,
                CPF [CHAR](15) NOT NULL,
                EMAIL VARCHAR(50) NOT NULL,
                TELEFONE VARCHAR(20) NOT NULL,
                ENDERECO VARCHAR(100) NOT NULL,
            );

            INSERT INTO CLIENTES VALUES ('Fulano', 60, '12161543', 'teste@teste', '31919118196', 'Rua tal...');
        ";
    }
}
