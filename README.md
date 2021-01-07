# TrilhaBackend_csharp
- Nível Básico
1. [Desafio 1](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio1#desafio-1)
2. [Desafio 2](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio1#desafio-2)
3. [Desafio 3](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio1#desafio-3)
4. [Desafio 4](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio1#desafio-4)

- Nível 1
1. [Desafio 1](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio1#n%C3%ADvel-1---desafio-1)



## Desafio 1
https://classroom.google.com/u/1/c/NjE3NTE1NjY5MTha/a/NjI2MjQ0MjE3NTJa/details

Repositório __em construção__ com os desafios propostos na trilha BackEnd focada em C#, feita pela Zup.

__Branch:__ main

__Objetivo:__ Crie um repositório para o projeto. 

 1. Acesse o Github e crie um projeto com gitignore para a linguagem C#. 
 2. Adicione um readme construído com Markdown (https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet).
 3. Construir apenas a estrutura do arquivo e evolui ao longo do projeto.
   3.1. Referências para ajudar na construção do arquivo.
			   https://gist.github.com/PurpleBooth/109311bb0361f32d87a2	
			   https://medium.com/@raullesteves/github-como-fazer-um-readme-md-bonit%C3%A3o-c85c8f154f8

<em>Os desafios serão entregues em branches de acordo com cada tarefa. Navegue entre as branches para ver o resultado de cada Desafio.</em>

## Desafio 2

__Branch:__ /feature/basico/desafio2 

__Objetivo:__ CRUD de Clientes (Banco de dados em memória)

Em aplicações do backend, há quatro operações muito comuns a serem implementadas.
Essas operações compõem a sigla inglesa CRUD (Create, Read, Update e Delete).
 
 1. Escreva um programa do tipo Console App em .NET Core 3.1 que implemente essas quatro operações para os dados de um cliente, salvando-os em uma estrutura de dados em memória.	
 2. Crie uma interface textual para as quatro operações.
 3. Um cliente deve ter cadastrado pelo menos os seguintes dados: nome, idade, CPF, e-mail, telefone e endereço.  
	  - A operação de Create deve popular o cadastro de um cliente e inserir na estrutura. 
	  - A operação de Read   deve permitir visualizar todos os clientes ou um só pelo CPF. 
	  - A operação de Update deve permitir alterar um ou mais dos dados de um cliente a partir do CPF dele (O campo CPF não pode ser alterado).
	  - A operação de Delete deve permitir excluir um cliente da estrutura pelo CPF dele.

## Desafio 3

__Branch:__ /feature/basico/desafio3

__Objetivo:__ Persista os clientes (Banco de dados relacional - SQLServer)

É importante armazenar os dados dos clientes de forma mais duradoura. Para isso, temos mecanismos de persistência como os bancos de dados.
Altere o CRUD para operar com o banco de dados relacional (SQLServer), ao invés da estrutura em memória. Para comunicar com o banco de dados SqlServer, utilize o (System.Data.SqlClient).

### How to
para executar testes nesse banco de dados execute os seguintes comandos para criação do banco,
para criação da tabela de clientes e alguns inserts de exemplo:

~~~
USE [master]

CREATE DATABASE [dbClientes];

CREATE TABLE CLIENTES(
	NOME VARCHAR(50) NOT NULL,
	IDADE INT NOT NULL,
	CPF [CHAR](15) NOT NULL,
	EMAIL VARCHAR(50) NOT NULL,
	TELEFONE VARCHAR(20) NOT NULL,
	ENDERECO VARCHAR(100) NOT NULL
);

INSERT INTO CLIENTES VALUES ('Fulano', 60, '12161543', 'teste@teste', '31919118196', 'Rua tal...');
INSERT INTO CLIENTES VALUES ('ciclano', 25, '6666666', 'teste@teste', '666666', 'Rua tal...');
INSERT INTO CLIENTES VALUES('Caldeira',37, '07918947622','thiago.teste@teste.com.br','31995541239','rua mercia 280');
INSERT INTO CLIENTES VALUES('Douglas',25, '123456789',   'douglas.jose@teste.com.br','31995541239','rua monteiro lobato 158');
INSERT INTO CLIENTES VALUES ('Teste cachorro', 60, '345345', 'teste@teste', '34534', 'Rua ...');

CREATE LOGIN usuarioClientes  WITH PASSWORD = 'SUASENHA@123';  
CREATE USER usuarioClientes FOR LOGIN usuarioClientes; 

~~~

## Desafio 4

__Branch:__ /feature/basico/desafio4

__Objetivo:__ Worker service.
Criar um relatório em formato de arquivo txt.
   1. Crie um novo projeto do tipo Worker Service.
     1. a. Leia a tabela de cliente.
	   1. b. Escreva todos registro da tabela em um arquivo TXT.
	     1. b.a. Adicione um cabeçalho com todos os campos da tabela.
		   1. b.b. Formate o tamanho dos campos para que o layout do relatório fique apresentável.


## Nível 1 - Desafio 1
__Branch:__ /feature/nivel1/desafio1 (__em construção__)

__Objetivo:__ Criar uma API REST (MVC).
Utilizar o template do Visual Studio API com padrão MVC e Entity Framework.
Objetivo: Realizar operações de CRUD persistindo tudo no banco de dados.
          Utilize a mesma estrutura de tabela e dados do desafio anterior.

1.1. Criar uma API REST com padrão MVC em .NET Core 3.1 que implemente as quatro operações para os dados de um cliente, persistir os dados no banco SqlServer lembre se de utilizar o Entity Framework.      
      1.2. Utilizar Code First + Migration 
      1.2. Exponha as operações do CRUD de clientes em uma API REST, utilizando para isso o IIS.
      1.3. Um cliente deve ter cadastrado pelo menos os seguintes dados: nome, idade, CPF, e-mail, telefone e endereço.
           A operação de Create deve popular o cadastro de um cliente e inserir na estrutura (método POST).
           A operação de Read   deve permitir visualizar todos os clientes ou um só pelo CPF. (método GET) 
           A operação de Update deve permitir alterar um ou mais dos dados de um cliente a partir do CPF dele (O campo CPF não pode ser alterado)(método PUT).
           A operação de Delete deve permitir excluir um cliente da estrutura pelo CPF dele (método DELETE).