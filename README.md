# TrilhaBackend_csharp
1. [Desafio 1](#desafio1)
2. [Desafio 2](#desafio2)
2. [Desafio 3](#desafio3)

## Desafio 1
https://classroom.google.com/u/1/c/NjE3NTE1NjY5MTha/a/NjI2MjQ0MjE3NTJa/details

Repositório __em construção__ com os desafios propostos na trilha BackEnd focada em C#, feita pela Zup.

<em>Os desafios serão entregues em branches de acordo com cada tarefa.</em>

## Desafio 2

Branch: /feature/basico/desafio2 

## Desafio 3

Branch: /feature/basico/desafio3 (__em construção__)

### How to
para executar testes nesse banco de dados execute os seguintes comandos para criação do banco:

~~~
USE [master]
GO

/****** Object:  Database [dbClientes]    Script Date: 01/12/2020 19:38:47 ******/
CREATE DATABASE [dbClientes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbClientes', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbClientes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbClientes_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbClientes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbClientes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [dbClientes] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [dbClientes] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [dbClientes] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [dbClientes] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [dbClientes] SET ARITHABORT OFF 
GO

ALTER DATABASE [dbClientes] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [dbClientes] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [dbClientes] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [dbClientes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [dbClientes] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [dbClientes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [dbClientes] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [dbClientes] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [dbClientes] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [dbClientes] SET  DISABLE_BROKER 
GO

ALTER DATABASE [dbClientes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [dbClientes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [dbClientes] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [dbClientes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [dbClientes] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [dbClientes] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [dbClientes] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [dbClientes] SET RECOVERY FULL 
GO

ALTER DATABASE [dbClientes] SET  MULTI_USER 
GO

ALTER DATABASE [dbClientes] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [dbClientes] SET DB_CHAINING OFF 
GO

ALTER DATABASE [dbClientes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [dbClientes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [dbClientes] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [dbClientes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [dbClientes] SET QUERY_STORE = OFF
GO

ALTER DATABASE [dbClientes] SET  READ_WRITE 
GO

~~~


e rode o seguinte script para criação da tabela de clientes e alguns inserts de exemplo:

~~~
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