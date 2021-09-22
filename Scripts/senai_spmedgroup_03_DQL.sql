--Inicio DQL

USE SPMedicalGroup
GO

SELECT * FROM Medico

SELECT * FROM Especialidade

--Mostrou a quantidade de usu�rios ap�s realizar a importa��o do banco de dados
--Estudar importa��o e exporta��o de banco de dados! - Pedir explica��o sobre isso!

--Converteu a data de nascimento do usu�rio para o formato (mm-dd-yyyy) na exibi��o
SELECT CONVERT (VARCHAR,DataNasc,101) AS 'Data de Nascimento' FROM Paciente;
GO

--Criou uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
--Inicio da fun��o de calculo:
CREATE FUNCTION calculo_Medico_Especialidade(
	@Tema VARCHAR(50)
)
RETURNS INT
AS
BEGIN

DECLARE @qtndMedico AS INT
SET @qtndMedico = (SELECT COUNT(Medico.Nome) FROM Medico

INNER JOIN Especialidade
ON Especialidade.idEspecialidade = Medico.idEspecialidade
WHERE Especialidade.Tema = @Tema)
RETURN @qtndMedico
END
GO

--Fim da fun��o de calculo:

--Execu��o da fun��o:
SELECT NumeroMedico = dbo.calculo_Medico_Especialidade ('Acupuntura');
GO


--Criou uma fun��o para que retorne a idade do usu�rio a partir de uma determinada stored procedure
--Inicio da Stored procedure de calculo de idade dos pacientes:
CREATE PROCEDURE cauculo_Idade
AS
BEGIN
SELECT NomePaci 'Nome do Paciente', rg 'RG', cpf 'CPF', Endereco 'Endere�o', Telcontato 'Telefone', DATEDIFF(year, (DataNasc), GETDATE()) 'Idade' FROM Paciente
END
GO
--Fim da Stored procedure.

--OB: O que � DATEDIFF? 
--Diferen�a de datas!

--Execu��o da Stored procedure:
EXEC cauculo_Idade;
GO

--Fim DQL