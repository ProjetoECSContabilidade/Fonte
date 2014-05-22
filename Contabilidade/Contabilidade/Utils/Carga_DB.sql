--SCRIPT DE CARGA INICIAL DO BANCO DE DADOS. (DESENVOLVIMENTO)
--Apaga o banco para criar novamente
--drop database Contabilidde

use Contabilidde
go

--insert setores
INSERT INTO Setor (Descricao) VALUES ('Gerencia')
INSERT INTO Setor (Descricao) VALUES ('Recursos Humanos')
INSERT INTO Setor (Descricao) VALUES ('Fiscal')
INSERT INTO Setor (Descricao) VALUES ('Contábil')
select * from Setor


select * from Usuario


