--SCRIPT DE CARGA INICIAL DO BANCO DE DADOS. (DESENVOLVIMENTO)
--Apaga o banco para criar novamente
--DROP DATABASE Contabilidde
--GO

use Contabilidde
go

--insert setores
INSERT INTO Setor (Descricao) VALUES ('Fiscal')
INSERT INTO Setor (Descricao) VALUES ('Contábil')
INSERT INTO Setor (Descricao) VALUES ('Recursos Humanos')
INSERT INTO Setor (Descricao) VALUES ('Gerencia')
select * from Setor

--insert usuarios
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Rubia','rubia@outlook.com', 'Coordenador', 2, 'rubia.cv', 'ecs2014', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Lucas','lucas@gmail.com', 'Gerente', 1, 'lucas.ger', 'lord421', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Sansa Stark','sansa@winterfel.com', 'Analista de RH', 3, 'sansa.sansa', 'diejofrey', 0)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Cersei Lannister','cersei@laniesters.com', 'Analista Contábil', 4, 'cersei.lannister', 'dontkilljofrey', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Tyrion Lannister','tyrion@jackass.com', 'Analista Contábil', 4, 'tyrionrocks', 'shea', 1)
select * from Usuario


