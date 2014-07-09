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
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Rubia Vieira','rubia@outlook.com', 'Coordenador', 2, 'rubia.cv', 'ecs2014', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Elisabeth Dvorak','elisabeth.dvorak@thomsonreuters.com', 'Analista Contábil', 4, 'elisabeth', 'q1w2e3r4', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Jessica Amorim','jessica.am@ibest.com', 'Analista Contábil', 4, 'jessi.a', 'etchalele', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Lucas','lucas@gmail.com', 'Gerente', 1, 'lucas.ger', 'lord421', 1)
INSERT INTO Usuario (Nome,Email,Cargo,SetorId,Login,Senha,Ativo) VALUES ('Fabiana Siqueira','fabiana@tr.com', 'Analista de RH', 3, 'fabi.s', '123456', 0)
select * from Usuario

--insert de obrigação
--FISCAL -1
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('SPED FISCAL', 10, '2014-12-31 00:00:00.000', 1)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('EFD Contribuições', 10, '2014-12-31 00:00:00.000', 1)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('DIME', 10, '2014-12-31 00:00:00.000', 1)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('GIA SP', 15, '2014-12-31 00:00:00.000', 1)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('DAPI', 15, '2014-12-31 00:00:00.000', 1)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('SEF II', 15, '2014-12-31 00:00:00.000', 1)
--CONTABIL -2
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('SPED CONTÁBIL', 1, '2014-05-27 00:00:00.000', 2)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('Balanço', 1, '2014-12-31 00:00:00.000', 2)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('DIRF', 10, '2014-12-05 00:00:00.000', 2)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('Livro Diário', 10, '2014-12-31 00:00:00.000', 2)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('Livro Razão', 15, '2014-12-31 00:00:00.000', 2)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('GPS', 15, '2014-12-31 00:00:00.000', 2)
--RH -3
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('Folha de Pagamento', 15, '2014-12-31 00:00:00.000', 3)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('Comprovante de Rendimentos', 15, '2014-12-31 00:00:00.000', 3)
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('Abertura de Empresa', 15, '2014-12-31 00:00:00.000', 3)

select * from Obrigacao



