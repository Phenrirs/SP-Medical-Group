--Inicio DDL

CREATE DATABASE SPMedicalGroup
GO

USE SPMedicalGroup
GO

--Inicio tabelas Independentes 

--Instituicao
CREATE TABLE Instituicao(
idInstituicao SMALLINT PRIMARY KEY IDENTITY (1,1),
CNPJ CHAR (18) UNIQUE NOT NULL,
RazaoSocial VARCHAR (100) NOT NULL,
NomeFantasia VARCHAR (100) NOT NULL,
Endereco VARCHAR (250) UNIQUE NOT NULL, 
TelContato CHAR (13) UNIQUE NOT NULL,
);
GO

--Especialidade
CREATE TABLE Especialidade(
idEspecialidade TINYINT PRIMARY KEY IDENTITY (1,1),
Tema VARCHAR (50) UNIQUE NOT NULL,
);
GO

--TipoUsuario
CREATE TABLE TipoUsuario(
idTipo TINYINT PRIMARY KEY IDENTITY (1,1),
NomeTipoUser VARCHAR (30) UNIQUE NOT NULL,
);
GO

--Fim tabela independente

--Inicio tabelas dependentes 

--Usuario
CREATE TABLE Usuario(
idUsuario INT PRIMARY KEY IDENTITY (1,1),
idTipo TINYINT FOREIGN KEY REFERENCES TipoUsuario(idTipo),
);
GO

--Medico
CREATE TABLE Medico(
idMedico INT PRIMARY KEY IDENTITY (1,1),
idInstituicao SMALLINT FOREIGN KEY REFERENCES Instituicao(idInstituicao),
idusuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
idEspecialidade TINYINT FOREIGN KEY REFERENCES Especialidade(idEspecialidade),  
CRM CHAR (8) UNIQUE NOT NULL,
Nome VARCHAR (50) NOT NULL,
Email VARCHAR (200) UNIQUE NOT NULL,
);
GO

--Paciente
CREATE TABLE Paciente(
idPaciente INT PRIMARY KEY IDENTITY (1,1),
idusuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
NomePaci VARCHAR (50) NOT NULL,
Email VARCHAR (200) UNIQUE NOT NULL,
DataNasc DATE NULL,
Telcontato CHAR (13) UNIQUE NULL,
RG CHAR (12) UNIQUE NOT NULL,
CPF CHAR (14) UNIQUE NOT NULL,
Endereco VARCHAR (250) UNIQUE NOT NULL,
);
GO

--Aplicação de um default:
--Situação
CREATE TABLE Situacao(
idSituacao TINYINT PRIMARY KEY IDENTITY (1,1), 
Descricao VARCHAR (9) DEFAULT ('Agendada') NOT NULL,
);
GO

--Consulta
CREATE TABLE Consulta(
idConsulta INT PRIMARY KEY IDENTITY (1,1),
idPaciente INT FOREIGN KEY REFERENCES Paciente(idPaciente),
idMedico INT FOREIGN KEY REFERENCES Medico(idMedico),
idSituacao TINYINT FOREIGN KEY REFERENCES Situacao(idSituacao),
DataConsulta DATE NOT NULL,
HorarioEntrada TIME NOT NULL,
HorarioSaida TIME NOT NULL,
);
GO

--Fim DDL