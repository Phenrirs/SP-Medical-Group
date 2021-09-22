--Inicio DQL

USE SPMedicalGroup
GO

SELECT * FROM Medico

SELECT * FROM Especialidade

--Mostrou a quantidade de usuários após realizar a importação do banco de dados
--Estudar importação e exportação de banco de dados! - Pedir explicação sobre isso!

--Converteu a data de nascimento do usuário para o formato (mm-dd-yyyy) na exibição
SELECT CONVERT (VARCHAR,DataNasc,101) AS 'Data de Nascimento' FROM Paciente;
GO

--Criou uma função para retornar a quantidade de médicos de uma determinada especialidade
--Inicio da função de calculo:
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

--Fim da função de calculo:

--Execução da função:
SELECT NumeroMedico = dbo.calculo_Medico_Especialidade ('Acupuntura');
GO


--Criou uma função para que retorne a idade do usuário a partir de uma determinada stored procedure
--Inicio da Stored procedure de calculo de idade dos pacientes:
CREATE PROCEDURE cauculo_Idade
AS
BEGIN
SELECT NomePaci 'Nome do Paciente', rg 'RG', cpf 'CPF', Endereco 'Endereço', Telcontato 'Telefone', DATEDIFF(year, (DataNasc), GETDATE()) 'Idade' FROM Paciente
END
GO
--Fim da Stored procedure.

--OB: O que é DATEDIFF? 
--Diferença de datas!

--Execução da Stored procedure:
EXEC cauculo_Idade;
GO

--Fim DQL