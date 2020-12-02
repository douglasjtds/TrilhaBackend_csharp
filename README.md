# TrilhaBackend_csharp
1. [Desafio 1](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/basico/desafio3#desafio-1)
2. [Desafio 2](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/basico/desafio3#desafio-2)
2. [Desafio 3](https://github.com/douglasjtds/TrilhaBackend_csharp/tree/feature/basico/desafio3#desafio-3)

## Desafio 1
https://classroom.google.com/u/1/c/NjE3NTE1NjY5MTha/a/NjI2MjQ0MjE3NTJa/details

Repositório __em construção__ com os desafios propostos na trilha BackEnd focada em C#, feita pela Zup.

<em>Os desafios serão entregues em branches de acordo com cada tarefa.</em>

## Desafio 2

Branch: /feature/basico/desafio2 

## Desafio 3

Branch: /feature/basico/desafio3 (__em construção__)

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
~~~