# TrilhaBackend_csharp
- Nível Básico
1. [Desafio 1](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-b%C3%A1sico---desafio-1)
2. [Desafio 2](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-b%C3%A1sico---desafio-2)
3. [Desafio 3](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-b%C3%A1sico---desafio-3)
4. [Desafio 4](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-b%C3%A1sico---desafio-4)

- Nível 1
1. [Desafio 1](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-1---desafio-1)
2. [Desafio 2](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-1---desafio-2)
3. [Desafio 3](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-1---desafio-3)
4. [Desafio 4](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-1---desafio-4)
5. [Desafio 5](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/nivel1/desafio3#n%C3%ADvel-1---desafio-5)


## Nível Básico - Desafio 1
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

## Nível Básico - Desafio 2

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

## Nível Básico - Desafio 3

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

USE [dbClientes]

CREATE TABLE CLIENTES(
	ID INT IDENTITY(1,1) PRIMARY KEY,
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
 
~~~

## Nível Básico - Desafio 4

__Branch:__ /feature/basico/desafio4

__Objetivo:__ Worker service.
Criar um relatório em formato de arquivo txt.
   1. Crie um novo projeto do tipo Worker Service.
     1. a. Leia a tabela de cliente.
	   1. b. Escreva todos registro da tabela em um arquivo TXT.
	     1. b.a. Adicione um cabeçalho com todos os campos da tabela.
		   1. b.b. Formate o tamanho dos campos para que o layout do relatório fique apresentável.


## Nível 1 - Desafio 1
__Branch:__ /feature/nivel1/desafio1

__Objetivo:__ Criar uma API REST (MVC).

- Utilizar o template do Visual Studio API com padrão MVC e Entity Framework. 
- Realizar operações de CRUD persistindo tudo no banco de dados.
	- Utilize a mesma estrutura de tabela e dados do desafio anterior.
	
1. Criar uma API REST com padrão MVC em .NET Core 3.1 que implemente as quatro operações para os dados de um cliente, persistir os dados no banco SqlServer lembre se de utilizar o Entity Framework.
2. Utilizar Code First + Migration
3. Exponha as operações do CRUD de clientes em uma API REST, utilizando para isso o IIS.
4. Um cliente deve ter cadastrado pelo menos os seguintes dados: nome, idade, CPF, e-mail, telefone e endereço.
	- A operação de Create deve popular o cadastro de um cliente e inserir na estrutura (método POST).
	- A operação de Read   deve permitir visualizar todos os clientes ou um só pelo CPF. (método GET) 
	- A operação de Update deve permitir alterar um ou mais dos dados de um cliente a partir do CPF dele (O campo CPF não pode ser alterado)(método PUT).
	- A operação de Delete deve permitir excluir um cliente da estrutura pelo CPF dele (método DELETE).


## Nível 1 - Desafio 2
__Branch:__ /feature/nivel1/desafio2

__Objetivo:__ Implementar o Swagger.

## Nível 1 - Desafio 3
__Branch:__ /feature/nivel1/desafio3 (__em construção__)

__Objetivo:__ Criar Integração com API

Geralmente um sistema não vive sozinho, quase sempre temos de implementar integrações com outros sistemas, para buscar ou enviar dados pertinentes ao projeto.

Desenvolva a integração com a API da Marvel, com o serviço (https://developer.marvel.com/docs) /v1/public/comics, usando o System.Net.Http para comunicar com a API. De posse dos dados, persista informações relevantes para o projeto, como id, ean, title, description, entre outros.

### How to
para executar testes com banco de dados, adicione a nova tabela COMIC com o script abaixo e depois faça a chamada com algum Herói válido, como por exemplo:
- Deadpool
- Captain America
- 3-D Man
- Spider-Man
- https://www.marvel.com/characters (__outros__)

~~~
USE [dbClientes]

CREATE TABLE COMIC(
	ID INT PRIMARY KEY,
	TITLE VARCHAR(100) NOT NULL,
	EAN VARCHAR(100),
	DESCRIPTION VARCHAR(500)
);
~~~


## Nível 1 - Desafio 4

__Branch:__ /feature/nivel1/desafio4

__Objetivo:__ Implementar testes unitários utilizando xUnit.

## Nível Extra - Docker/Cache com Redis

__Branch:__ /feature/nivel-extra/docker

__Objetivo:__ Utilizar o banco de dados em uma imagem do Docker e adicionar funcionalidade de cache com o Redis.

### How to
Esse passo a passo foi seguido de acordo com as instruções em:
https://www.michalbialecki.com/2020/04/23/set-up-a-sql-server-in-a-docker-container/

Para utilizar o banco de dados em uma imagem do Docker foi utilizado os seguintes comandos:

~~~
docker pull mcr.microsoft.com/mssql/server:2017-latest
~~~
Para baixar a imagem da Microsoft para trabalhar com SQL Server

~~~
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=bancoClientes01" -p 1433:1433 --name dbClientes -d mcr.microsoft.com/mssql/server:2017-latest
~~~
Para criar e rodar um container do docker para o banco com o nome dbClientes com usuário 'sa' e senha 'bancoClientes01'

Agora, para os testes, deve-se rodar os mesmos scripts do "How to" do Nível Básico - Desafio 3,
para criarmos uma base igual com a mesma tabela de Clientes.

## Nível 1 - Desafio 5

__Objetivo:__ Implementar logs utilizando o Log - Utilize o Illoguer

Obs.: Isso já foi feito em branches anteriores.