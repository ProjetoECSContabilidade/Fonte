

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
INSERT INTO Obrigacao (Descricao,DiaEntrega,DataValidade,SetorId) VALUES ('SPED CONTÁBIL', 1, '2014-12-20 00:00:00.000', 2)
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
--------------------------------------------------------
--------------------------------------------------------
--------------------------------------------------------


--insert de clientes
INSERT INTO Cliente (RazaoSocial,Cnpj,Municipio,Estado,SetorEconomico,Natureza,
RegimeApuracao,ISSRetencao,AtividadeEconomica,Ativo,ResponsavelFiscal_Id,ResponsavelContabil_Id,ResponsavelRH_Id)
VALUES
('Univille Universidade', '26.385.212/0001-28', 'Joinville','SC', 'Comercio', 'Sociedade Empresária Geral', 'Cumulativo', 'Sim', 'Comércio', 1,	1, 1, 1)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (1,1)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (7,1)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (13,1)

INSERT INTO Cliente (RazaoSocial,Cnpj,Municipio,Estado,SetorEconomico,Natureza,
RegimeApuracao,ISSRetencao,AtividadeEconomica,Ativo,ResponsavelFiscal_Id,ResponsavelContabil_Id,ResponsavelRH_Id)
VALUES
('Rubia SA', '70.431.552/0001-30', 'Florianopolis','SC', 'Comercio', 'Sociedade Cooperativa', 'Não-Cumulativo', 'Nao', 'Indústria', 0,	2, 2, 5)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (1,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (7,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (13,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (2,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (3,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (4,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (7,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (8,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (10,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (11,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (13,4)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (15,4)

INSERT INTO Cliente (RazaoSocial,Cnpj,Municipio,Estado,SetorEconomico,Natureza,
RegimeApuracao,ISSRetencao,AtividadeEconomica,Ativo,ResponsavelFiscal_Id,ResponsavelContabil_Id,ResponsavelRH_Id)
VALUES
('Leadership', '00.985.454/0001-35', 'Curitiba','PR', 'Comercio', 'Sociedade Empresária Geral', 'Cumulativo', 'Sim', 'Comércio', 1,	1, 1, 1)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (1,3)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (7,3)
INSERT INTO ObrigacaoClientes (Obrigacao_Id, Cliente_Id) VALUES (13,3)

select * from Cliente
select * from ObrigacaoClientes


select * from Etapa
select * from EtapaOrdemDeServicoes


