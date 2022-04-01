-- Estou usando Dbeaver para acesso direto ao Servidor
-- Nen todos os comandos funcionam atualmente, são mais ideias de conceitos

SELECT  Modelo, qtdModelo, QtdSuprimento, (QtdSuprimento - qtdModelo) as Estoque from (
	SELECT Modelo, COUNT(Modelo) as qtdModelo, Suprimento.QtdSuprimento   
	from Equipamento
	inner join Suprimento on Suprimento.ModeloEquipamento=Equipamento.Modelo
	group by Modelo, QtdSuprimento) 
as Estoque;

SELECT Modelo, COUNT(Modelo) as qtdModelo   
from Equipamento
group by Modelo;

SELECT Modelo
from Equipamento;

CREATE VIEW dbo.EstoqueToner AS 
SELECT  Modelo, qtdModelo, QtdSuprimento, (QtdSuprimento - qtdModelo) as Estoque from (
	SELECT Modelo, COUNT(Modelo) as qtdModelo, Suprimento.QtdSuprimento   
	from Equipamento
	inner join Suprimento on Suprimento.ModeloEquipamento=Equipamento.Modelo
	group by Modelo, QtdSuprimento) 
as Estoque;

SELECT idSuprimento, ModeloEquipamento, TipoSuprimento, QtdSuprimento
FROM SistemaTI.dbo.Suprimento;


SELECT DISTINCT  NuSerie
FROM  SistemaTIv2.dbo.Equipamento 
group by NuSerie
HAVING COUNT(NuSerie)>1 ;

-- Contagem de equipamentos com base no processo
SELECT  COUNT(ItemProcessoID), ItemProcessoID, ProcessoId 
from SistemaTIv2.dbo.Equipamento
group  by ItemProcessoID, ProcessoId;  

SELECT * from SistemaTIv2.dbo.Equipamento
WHERE ItemProcessoID  LIKE '0' ;

SELECT  localTipo, Nome 
FROM  SistemaTIv2.dbo.[Local] l  
WHERE localTipo  LIKE 'Escola';


SELECT  DISTINCT localTipo, COUNT(localTipo)  
from  SistemaTIv2.dbo.[Local] l 
group  by localTipo ;


