IF DB_ID('BD_FOLHA') IS NOT NULL
BEGIN
    USE master; 
    ALTER DATABASE BD_FOLHA SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BD_FOLHA;
END

CREATE DATABASE BD_FOLHA;
GO

USE BD_FOLHA;
GO

CREATE TABLE Cargo (
  IdCargo INT PRIMARY KEY IDENTITY(1,1),
  NomeCargo VARCHAR(50) NOT NULL,
  CargaHoraria INT NOT NULL,
  SalarioBase DECIMAL(10,2) NOT NULL,
  INSS DECIMAL(3) NOT NULL
);
GO

CREATE TABLE Funcionario (
  IdFuncionario INT PRIMARY KEY IDENTITY(1,1),
  Cargo INT REFERENCES Cargo(IdCargo),
  Nome VARCHAR(50) NOT NULL,
  CPF VARCHAR(15) NOT NULL,
  DataNasc DATE NOT NULL,
  Telefone VARCHAR(20),
  Email VARCHAR(50),
  DataAdmissao DATE,
  Instituicao VARCHAR(50) NOT NULL,
  Agencia INT NOT NULL,
  ContaCorrente VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Ferias (
  IdFerias INT PRIMARY KEY IDENTITY(1,1),
  Funcionario INT REFERENCES Funcionario(IdFuncionario),
  DataInicioFerias DATE NOT NULL,
  DataFimFerias DATE NOT NULL,
  ValorFerias DECIMAL(10,2) NOT NULL,
  Status VARCHAR (20) NOT NULL
);
GO

CREATE TABLE Pagamentos (
  IdPagamento INT PRIMARY KEY IDENTITY(1,1),
  Funcionario INT REFERENCES Funcionario(IdFuncionario),
  DataPagamento DATE,
  ValorPago DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE HorasTrabalhadas (
  IdHorasTrabalhadas INT PRIMARY KEY IDENTITY(1,1),
  Funcionario INT REFERENCES Funcionario(IdFuncionario),
  DataHorasTrabalhadas DATE,
  HoraEntradaHorasTrabalhadas VARCHAR(5),
  HoraSaidaHorasTrabalhadas VARCHAR(5)
);
GO

CREATE TABLE Beneficio (
  IdBeneficio INT PRIMARY KEY IDENTITY(1,1),
  NomeBeneficio VARCHAR(30),
  ValorBeneficio VARCHAR(30)
);
GO

CREATE TABLE BeneficioFuncionario (
  IdBeneficioFuncionario INT PRIMARY KEY IDENTITY(1,1),
  Funcionario INT REFERENCES Funcionario(IdFuncionario) NOT NULL,
  Beneficio INT REFERENCES Beneficio(IdBeneficio) NOT NULL
);
GO

-- INSERTS / CADASTROS
-- Inserir dados na tabela Cargo
-- Inserir dados na tabela Cargo (sem o campo IdCargo)
INSERT INTO Cargo (NomeCargo, CargaHoraria, SalarioBase, INSS)
VALUES ('Gerente', 160, 5000.00, 15.5),
       ('Analista', 140, 3500.00, 10.0),
       ('Assistente', 120, 2500.00, 8.0);

-- Inserir dados na tabela Funcionario (sem o campo IdFuncionario)
INSERT INTO Funcionario (Cargo, Nome, CPF, DataNasc, Telefone, Email, DataAdmissao, Instituicao, Agencia, ContaCorrente)
VALUES (1, 'João Silva', '123.456.789-01', '15/05/1990', '(11) 555-1234', 'joao@email.com', '10/02/2020', 'Itaú', 1234, '123-456-789'),
       (2, 'Maria Santos', '987.654.321-09', '22/08/1988', '(11) 555-5678', 'maria@email.com', '05/07/2019', 'Santander', 5678, '987-654-321');

-- Inserir dados na tabela Ferias (sem o campo IdFerias)
INSERT INTO Ferias (Funcionario, DataInicioFerias, DataFimFerias, ValorFerias)
VALUES (1, '15/07/2022', '30/07/2022', 2000.00),
       (2, '05/08/2022', '20/08/2022', 1500.00);

-- Inserir dados na tabela Pagamentos (sem o campo IdPagamento)
INSERT INTO Pagamentos (Funcionario, DataPagamento, ValorPago)
VALUES (1, '31/07/2022', 5000.00),
       (2, '31/08/2022', 3500.00);

-- Inserir dados na tabela HorasTrabalhadas (sem o campo IdHorasTrabalhadas)
INSERT INTO HorasTrabalhadas (Funcionario, DataHorasTrabalhadas, HoraEntradaHorasTrabalhadas, HoraSaidaHorasTrabalhadas)
VALUES (1, '01/07/2022', '08:00', '17:00'),
       (2, '01/08/2022', '09:00', '18:00');

-- Inserir dados na tabela Beneficio (sem o campo IdBeneficio)
INSERT INTO Beneficio (NomeBeneficio, ValorBeneficio)
VALUES ('Vale Alimentação', '300.00'),
       ('Vale Refeição', '730.00');

-- Inserir dados na tabela BeneficioFuncionario (sem o campo IDBeneficioFuncionario)
INSERT INTO BeneficioFuncionario (Funcionario, Beneficio)
VALUES (1, 1),
       (1, 2),
       (2, 1);


