USE BD_FOLHA;

create proc MostrarFuncionario
as
Select*From Funcionario
go

exec MostrarFuncionario

create proc InserirFuncionario
@cargo int,
@nome varchar(50),
@cpf varchar(15),
@datanasc date,
@telefone varchar(50),
@email varchar(50),
@dataadmissao date,
@instituicao varchar(50),
@agencia int,
@contacorrente varchar(50)
as
insert into Funcionario values(@cargo,@nome,@cpf,@datanasc,@telefone,@email,@dataadmissao,@instituicao,@agencia,@contacorrente)
go

create proc AlterarFuncionario
@cargo int,
@nome varchar(50),
@cpf varchar(15),
@datanasc date,
@telefone varchar(50),
@email varchar(50),
@dataadmissao date,
@instituicao varchar(50),
@agencia int,
@contacorrente varchar(50),
@id int
as
update Funcionario set Cargo = @cargo, Nome = @nome, CPF = @cpf, DataNasc = @datanasc, Telefone = @telefone,
Email = @email, DataAdmissao = @dataadmissao, Instituicao = @instituicao, Agencia = @agencia,
ContaCorrente = @contacorrente
WHERE IdFuncionario = @id

create proc DeletarFuncionario
@idfunc int
as
Delete from Funcionario where IdFuncionario = @idfunc
go

-- CARGO

create proc MostrarCargo
as
Select*From Cargo
go

create proc InserirCargo
@nomecargo varchar(50),
@cargahoraria int,
@salariobase decimal(10,2),
@inss decimal
as
insert into Cargo values(@nomecargo,@cargahoraria,@salariobase,@inss)
go

create proc AlterarCargo
@nomecargo varchar(50),
@cargahoraria int,
@salariobase decimal(10,2),
@inss decimal,
@idcar int
as
update Cargo set NomeCargo = @nomecargo, CargaHoraria = @cargahoraria, SalarioBase = @salariobase, INSS = @inss
WHERE IdCargo = @idcar

create proc DeletarCargo
@idcar int
as
Delete from Cargo where IdCargo = @idcar
go
 
 exec MostrarCargo

 --HORAS TRABALHADAS

 create proc MostrarHoras
 as
 Select * from HorasTrabalhadas
 go

 create proc InserirHoras
@func int,
@datahora date,
@horaentrada time,
@horasaida time
as
insert into HorasTrabalhadas values(@func,@datahora,@horaentrada,@horasaida)
go

create proc AlterarHoras
@func int,
@datahora date,
@horaentrada time,
@horasaida time,
@idhoras int
as
update HorasTrabalhadas set Funcionario = @func, DataHorasTrabalhadas = @datahora, HoraEntradaHorasTrabalhadas = @horaentrada, HoraSaidaHorasTrabalhadas = @horasaida
WHERE IdHorasTrabalhadas = @idhoras

create proc DeletarHoras
@idhoras int
as
Delete from HorasTrabalhadas where IdHorasTrabalhadas = @idhoras
go

--FÉRIAS

create proc MostrarFerias
as
select*from Ferias
go

create proc AlterarFerias
@status varchar(50),
@idferias int
as
update Ferias set Status = @status
WHERE IdFerias = @idferias



select*from Beneficio

--Pagamento

create proc MostrarPagamento
as
select*from Pagamentos
go

create proc InserirPagamento
@func int,
@datapag date,
@valorpago decimal(10,2)
as
insert into Pagamentos values(@func,@datapag,@valorpago)
go

create proc AlterarPagamento
@func int,
@datapag date,
@valorpago decimal(10,2),
@idpag int
as
update Pagamentos set Funcionario = @func, DataPagamento = @datapag, ValorPago = @valorpago
WHERE IdPagamento = @idpag

create proc DeletarPagamento
@idpag int
as
Delete from Pagamentos where IdPagamento = @idpag
go

