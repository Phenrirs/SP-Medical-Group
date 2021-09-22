--Inicio DML

USE SPMedicalGroup
GO

--Inicio tabelas independentes

--Instituicao
INSERT INTO Instituicao(CNPJ,RazaoSocial,NomeFantasia,Endereco,TelContato)
VALUES ('86.400.902/0001-30','SP Medical Group','Clinica Possarle','AV.Barão Limeira,532, São Paulo,SP','11 4002-8922');
GO

--Especialidade
INSERT INTO Especialidade(Tema)
VALUES ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),
	   ('Cirurgia da Mão'),('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pediátrica'),
	   ('Cirurgia Plástica'),('Cirurgia Torácica'),('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),
	   ('Urologia'),('Pediatria'),('Psiquiatria');
GO

--TipoUsuario
INSERT INTO TipoUsuario(NomeTipoUser)
VALUES ('Administrador'),('Médico'),('Paciente');
GO

--Fim tabelas independentes

--Inicio tabelas dependentes

--Usuario
INSERT INTO Usuario(idTipo)
VALUES (1),(2),(2),(2),(3),(3),(3),(3),(3),(3),(3);
GO

--Aqui não precisa de dados dos usuários em si, como dos pacientes e dos médicos, isso por conta da cardinalidade, seu burrão.

--Medico
INSERT INTO Medico(idInstituicao,idUsuario,idEspecialidade,CRM,Nome,Email)
VALUES (1,2,2,'54356-SP','Ricardo Lemos','ricardo.lemos@spmedicalgroup.com.br'),
	   (1,2,17,'53452-SP','Roberto Possarle','roberto.possarle@spmedicalgroup.com.br'),
	   (1,2,16,'65463-SP','Helena Strada','helena.souza@spmedicalgroup.com.br');
GO

--Paciente
INSERT INTO Paciente(idUsuario,NomePaci,Email,DataNasc,TelContato,RG,CPF,Endereco)
VALUES (5,'Ligia','ligia@gmail.com','13/10/1983','11 3456-7654','43522543-5','94839859000','Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
	   (6,'Alexandre','alexandre@gmail.com','23/07/2001','11 98765-6543','32654345-7','73556944057','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
	   (7,'Fernando','fernando@gmail.com','10/10/1978','11 97208-4453','54636525-3','16839338002','Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
	   (8,'Henrique','henrique@gmail.com','13/10/1985','11 3456-6543','54366362-5','14332654765','R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
	   (9,'João','joao@hotmail.com','27/08/1975','11 7656-6377','53254444-1','91305348010','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
	   (10,'Bruno','bruno@gmail.com','21/03/1972','11 95436-8769','54566266-7','79799299004','Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
	   (11,'Mariana','mariana@outlook.com','05/03/2018',NULL,'54566266-8','13771913039','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

--Situação
INSERT INTO Situacao(Descricao)
VALUES ('Realizada'),('Cancelada'),('Agendada');
GO

--Consulta
INSERT INTO Consulta(idPaciente,idMedico,idSituacao,DataConsulta,HorarioEntrada,HorarioSaida)
VALUES (7,3,1,'20/01/2020','15:00:00','16:00:00'),(2,2,2,'06/01/2020','10:00:00','11:00:00'),
	   (3,2,1,'07/02/2020','11:00:00','12:00:00'),(2,1,1,'06/02/2018','10:00:00','11:00:00'),
	   (4,1,2,'07/02/2019','11:00:00','12:00:00'),(7,3,3,'08/03/2020','15:00:00','16:00:00'),
	   (4,1,3,'09/03/2020','11:00:00','12:00:00');
GO

--Ta rolando conflito para inserir pois o idPaciente é FK! - O que fazer?

--Fim DML
