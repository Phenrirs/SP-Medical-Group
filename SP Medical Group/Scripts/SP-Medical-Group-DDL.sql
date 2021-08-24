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
--Uma coisa que fiquei em duvida no Gufi ofoi esse VARCHAR (100), o nomero dentro dos parenteses se refere a quantidade de carcateres correto?
--Então 100 caracteres não seria muito para um nome?

--A mesma duvida que tive no VARCHAR do NomeFantasia permanece nesse caso do Endereço! 

--No casso do char em CNPJ, poderiamos usar outra palavra reservada aqui? minha duvida se trata do fato de qu cnpj se trata de caracteres numéricos 
--e etc - Resposta - Conjunto de caracteres, ou seja, sem propriedades númericas, calculos e etc!



----Esse caso do telefone para contato se refere a duas possibilidades que temos perante ao enunciado do SP Medical Group:
--Primeiro: E se o grupo crescer tanto ao ponto de ter filiais e com isso precisar de outras clinicas fisicas cada uma com sua especialidade, endereço e
--consequentemente, telefone para contato? Pensando nisso ter um telefone de contato unico (Por isso o UNIQUE) para cada endereço seria o ideal.

--Segundo: O pensamento anterior tem uma brecha, e se forem tantas filiais que o melhor para controlar os cadastros seria contruir uma sede de 
--atendimento telefonico? O que nos deixaria com mais uma entidade, logo, mais uma tabela a ser criada e relacionada.

--OBS BONÛS: Os pensamentos anteriores também contem uma brecha como um todo, e se tivermos uma filial que contem duas especialidades no mesmo endereço?


--Especialidade
CREATE TABLE Especialidade(
idEspecialidade TINYINT PRIMARY KEY IDENTITY (1,1),
Tema VARCHAR (50) UNIQUE NOT NULL,
);
GO
--O uso de TINYINT no id se refere a quantidade de especialidades médicas registradas pelo CFM (Conselho Federal de Medicina)
--junto da Comissão Nacional de Residência Médica (CNRM) em 2017 que determinam a existencia de 55 especialidades nessa área

--O "Tema" se refere ao titulo das especialidades, porém o preenchendo percebi uma brecha, para um especialista em um "Sub-tópico" desse tema eu teria
--que criar uma nova tabela ou abranger o cadastro dos dados na tabela "Tema" para Não UNIQUE?


--TipoUsuario
CREATE TABLE TipoUsuario(
idTipo TINYINT PRIMARY KEY IDENTITY (1,1),
NomeTipoUser VARCHAR (30) UNIQUE NOT NULL,
);
GO
--Sobre essa tabela em especifico tenho duas duvidas:
--Primeira: Por que o VARCHAR de 30? Afinal de contas seria mais eficiente, para a economia da memória disponivel do servidor, que contassemos a palavra
--que contém maior quantidade de caracteres registrados nessa tabela e colocassemos essa quantidade ao invés de arredondarmos para um número maior e etc
--Mesma duvida que ve no campo NomeFantasia na tabela Instituições!

--A segunda se refere a onde aplicar a relação dessa tabela TipoUsuarios, eu deveria criar uma tabela intermediaria contendo o id de TipoUsuarios,
--idProntuarios e idMedicos? Tentei encontrar a relação dessa tabela com alguma outra mas de fato não consegui...

--Fim tabela independente

--Inicio tabelas dependentes 

--Medico
CREATE TABLE Medico(
idMedico INT PRIMARY KEY IDENTITY (1,1),
idInstituicao SMALLINT FOREIGN KEY REFERENCES Instituicao(idInstituicao),
idEspecialidade TINYINT FOREIGN KEY REFERENCES Especialidade(idEspecialidade),  
CRM CHAR (8) UNIQUE NOT NULL,
Nome VARCHAR (50) NOT NULL,
Email VARCHAR (200) UNIQUE NOT NULL,
);
GO

--Prontuarios
--OBS: Deixei o Prontuarios como Dependentes pois sinto que, se por acaso o Tipo Usuarios tiver relação com alguma tabela, Prontuarios seria uma delas
--ou vice-versa!
CREATE TABLE Prontuario(
idProntuario INT PRIMARY KEY IDENTITY (1,1)
NomePaci  VARCHAR (50) NOT NULL,
Email VARCHAR (200) UNIQUE NOT NULL,
DataNasc DATE NOT NULL,
Tel CHAR (13) UNIQUE NOT NULL,
RG CHAR (12) UNIQUE NOT NULL,
CPF CHAR (14) UNIQUE NOT NULL,
Endereco VARCHAR (250) UNIQUE NOT NULL,
);
GO

--Em CPF e RG eu utilizei a contagem real de caracteres, por isso essa quantidade de caracteres esta registrada em CHAR!

--Algumas dúvidas sobre a quantidade de caracteres permanece!

--Aplicar o lance do default do telcontato nesse caso, usar o exemplo do banc de daos Gufi!

--Usuario
CREATE DATABASE Usuario(
	idUsuario INT PRIMARY KEY IDENTITY (1,1),
	idTipo TINYINT FOREIGN KEY REFERENCES TipoUsuario(idTipo),
	idMedico INT FOREIGN KEY REFERENCES Medico(idMedico),
);
GO

--CASO ESSA SEJA A FORMA CORRETA NÃO ESQUEÇA DE ALTERAR AS MODELAGENS! - Pedro do Furuto: Sim, essa era a observação correta.
CREATE TABLE Situacao(
idStatus TINYINT PRIMARY KEY IDENTITY (1,1), 
Descriçao VARCHAR (9) NOT NULL,

CREATE TABLE Consulta(
idConsulta INT PRIMARY KEY IDENTITY (1,1),
idProntuario INT FOREIGN KEY REFERENCES Prontuario(idProntuario),
idMedico INT FOREIGN KEY REFERENCES Medico(idMedico),
idSituacao TINYINT FOREIGN KEY REFERENCES Situacao(idSituacao),
DataConsulta DATETIME NOT NULL,
--Fim tabela consultas teste 2

--Fim tabelas dependentes

--_____________________________________________________________________________________________________________
--_____________________________________________________________________________________________________________


--INICIO RASCUNHO COMENTATO NO BLOCO DE NOTAS
--Inicio tabelas independentes:

--Instituições
--FECHADO

--Instituiçoes - como a clnica esta ganahando fama acredito que a
--possibilidade da mesma abrir filiais não é improvavel, 
--consequentemente, seria interessante que o banco tivesse uma 
--entidade "instituições" para cadastrar as variadas filiais, 
--contendo assim - CNPJ, razaoSocial, nomeFantasia(Sub titulo da
--filial), endereço e telContato.

--idInstituiçoes = PK
--CNPJ = 
--RazaoSocial = 
--NomeFantasia = Clinica Possarle
--Endereço = 
--TelContato = 

--Especialidades
--FECHADO

--Especialidades
--idEspecialidades
--Tema

--Fim tabelas idependentes

--Inicio tabelas dependentes

--Médicos
--FECHADO

--Medicos
--idMedicos = PK
--idEspecialidade = FK
--idInstituições = FK
--CRM
--Nome
--Email

--Prontuarios
--FECHADO

--Prontuarios - dados dos pacientes
--idProntuarios
--Nome
--Email
--Data_Nasc
--Tel
--RG
--CPF
--Endereço

--FECHADO

--Consultas - deve conter os dados sobre a consulta (data e situação,
--realizada ou não e etc) em si, no caso dados atuais
--Tabela intermediaria que também é entidade:
--idConsultas = PK
--idProntuarios = FK
--idMédicos = FK
--DataConsulta
--Situaçao

--FECHADO

--Fim tabelas dependentes

--Tabela independente bonûs

--TipoUsuarios
--idTipoUser
--NomeTipoUser - ADMINISTRADOR - MÉDICO - PACIENTE

--Estou em duvida sobre a relação que a tabela de tipos de usuarios
--teria com qualquer outra tabela, essa interpretação no momento me 
--fugiiu! - Duvida respondida - Saulo - Era s´criar uma tabela de "Usuarios"(Cadastro de todos os usuarios) e linkar a tipo usuarios com ela!

--Ideias adicionais:

--No tópico 12 dos critérios avaliados dentro do projeto tem uma stored
--Procedure!

--Descrição da consulta, caso não tenha o default seria o "sem  descrição" e etc
