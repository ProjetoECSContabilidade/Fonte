--SCRIPT DE CARGA INICIAL DO BANCO DE DADOS. (DESENVOLVIMENTO)
--Apaga o banco para criar novamente
--DROP DATABASE Contabilidde
--GO

use Contabilidde
go

--insert setores
INSERT INTO Setor (Descricao) VALUES ('Fiscal')
INSERT INTO Setor (Descricao) VALUES ('Cont�bil')
INSERT INTO Setor (Descricao) VALUES ('Recursos Humanos')
INSERT INTO Setor (Descricao) VALUES ('Gerencia')
select * from Setor

--insert usuarios
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Rubia Vieira','rubia@outlook.com', 'Coordenador', 2, 'rubia.cv', 'ecs2014', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Elisabeth Dvorak','elisabeth.dvorak@thomsonreuters.com', 'Analista Cont�bil', 4, 'elisabeth', 'q1w2e3r4', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Jessica Amorim','jessica.am@ibest.com', 'Analista Cont�bil', 4, 'jessi.a', 'etchalele', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Lucas','lucas@gmail.com', 'Gerente', 1, 'lucas.ger', 'lord421', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Fabiana Siqueira','fabiana@tr.com', 'Analista de RH', 3, 'fabi.s', '123456', 0)
select * from Usuario


