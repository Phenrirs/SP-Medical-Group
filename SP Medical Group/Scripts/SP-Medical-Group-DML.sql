--Inicio DML

USE SP-MedicalGroup
GO

--Inicio tabelas independentes

--Instituicao
INSERT INTO Instituicao(CNPJ,RazaoSocial,NomeFantasia,Endereco,TelContato)
VALUES ('86.400.902/0001-30','SP Medical Group','AV.Bar�o Limeira,532, S�o Paulo,SP','11 4002-8922' );
GO

--Especialidade
INSERT INTO Especialidade(Tema)
VALUES ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),
	   ('Cirurgia da M�o'),('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pedi�trica'),
	   ('Cirurgia Pl�stica'),('Cirurgia Tor�cica'),('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),
	   ('Urologia'),('Pediatria'),('Psiquiatria');
GO

--TipoUsuario
INSERT INTO TipoUsuario(NomeTipoUser)
VALUES ('Administrador'),('M�dico'),('Paciente');
GO

--Fim tabelas independentes

--Inicio tabelas dependentes

--Medico
INSERT INTO Medico(idEspecialidade,CRM,Nome,Email)
VALUES (2,'54356-SP','Ricardo Lemos','ricardo.lemos@spmedicalgroup.com.br'),
	   (18,'53452-SP','Roberto Possarle','roberto.possarle@spmedicalgroup.com.br'),
	   (17,'65463-SP','Helena Strada','helena.souza@spmedicalgroup.com.br');
GO

--Prontuario
INSERT INTO Prontuario(NomePaci,Email,DataNasc,TelContato,RG,CPF,Endere�o)
VALUES ('Ligia','ligia@gmail.com','13/10/1983','11 3456-7654','43522543-5','94839859000','Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000'),
	   ('Alexandre','alexandre@gmail.com','23/07/2001','11 98765-6543','32654345-7','73556944057','Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200'),
	   ('Fernando','fernando@gmail.com','10/10/1978','11 97208-4453','54636525-3','16839338002','Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200'),
	   ('Henrique','henrique@gmail.com','13/10/1985','11 3456-6543','54366362-5','14332654765','R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
	   ('Jo�o','joao@hotmail.com','27/08/1975','11 7656-6377','53254444-1','91305348010','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380'),
	   ('Bruno','bruno@gmail.com','21/03/1972','11 95436-8769','54566266-7','79799299004','Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001'),
	   ('Mariana','mariana@outlook.com','05/03/2018',NULL,'54566266-8','13771913039','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140'),;
GO

--Usuario
INSERT INTO Usuario(idTipo,idProntuario,idMedico)
VALUES (3,1,NULL),(3,2,NULL),(3,3,NULL),(3,4,NULL),(3,5,NULL),(3,6,NULL),(3,7,NULL),(2,NULL,1),(2,NULL,2),(2,NULL,3),;
GO

--Situa��o
INSERT INTO Situa��o(Descri�ao)
VALUES ('Realizada'),('Cancelada'),('Agendada');
GO

--Consulta
INSERT INTO Consulta(idProntuario,idMedico,idSituacao,DataConsulta,HorarioEntrada,HorarioSaida)
VALUES (7,3,1,'20/01/2020','15:00:00','16:00:00'),(2,2,2,'06/01/2020','10:00:00','11:00:00'),
	   (3,2,1,'07/02/2020','11:00:00','12:00:00'),(2,1,1,'06/02/2018','10:00:00','11:00:00'),
	   (4,1,2,'07/02/2019','11:00:00','12:00:00'),(7,3,3,'08/03/2020','15:00:00','16:00:00'),
	   (4,1,3,'09/03/2020','11:00:00','12:00:00');
GO

--Nesse caso eu poderia colocar apenas o id de Usuario?

--No caaso da consulta eu apliquei o Horario de entrada e de saida pois ouvi o saulo matando a duvida de algu�m sobre isso e dando essa ideia para o
--mesmo!

--Consulta Teste 2
INSERT INTO Consulta(idUsuario,DataConsulta,HorarioEntrada,HorarioSaida)
VALUES (,'','',''),(,'','',''),(,'','',''),(,'','',''),(,'','',''),(,'','',''),(,'','','');
GO

--Fim tabelas dependentes


--FIM DML