USE GeoGarbage
DECLARE @GUIDIDENTITY_TABLE UNIQUEIDENTIFIER

--TRUNCATE TABLE Usuario
--TRUNCATE TABLE ConstrutorChaveEstrangeira
--TRUNCATE TABLE ConstrutorCampo
--TRUNCATE TABLE ConstrutorTabela

DELETE FROM Usuario
DELETE FROM ConstrutorChaveEstrangeira
DELETE FROM ConstrutorCampo
DELETE FROM ConstrutorTabela


SET @GUIDIDENTITY_TABLE = NEWID()
--Usuario
INSERT INTO Usuario Values(@GUIDIDENTITY_TABLE,'William','williamxbr@gmail.com','Will','will',1,0)

--Tabelas
SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'Jornada','Jornada')
--Campos da Tabelas
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'IdJornada','IdJornada',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'InicioJornada','InicioJornada',2,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'IdVeiculo','IdVeiculo',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'OdometroInicial','OdometroInicial',1,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'HorimetroInicial','HorimetroInicial',1,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'FimDaJornada','FimDaJornada',2,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'OdometroFinal','OdometroFinal',1,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'HorimetroFinal','HorimetroFinal',1,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'Status','Status',1,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'DescargaPendente','DescargaPendente',2,1,1,1) 

SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'DescargaAterro','DescargaAterro')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'IdDescarga','IdDescarga',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'InicioDaViagemParaDescarga','InicioDaViagemParaDescarga' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'OdometroInicioDaViagemParaDescarga','OdometroInicioDaViagemParaDescarga',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'HorimetroInicioDaViagemParaDescarga', 'HorimetroInicioDaViagemParaDescarga' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'InicioDescargaAterro', 'InicioDescargaAterro' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'InicioDescargaAterroOdometro','InicioDescargaAterroOdometro' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'InicioDescargaAterroHorimetro','InicioDescargaAterroHorimetro' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'DataHoraRegistroDoPeso','DataHoraRegistroDoPeso' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'PesoDaDescarga','PesoDaDescarga' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'EmViagem','EmViagem' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'DataHoraRegistroRecibo','DataHoraRegistroRecibo' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'Recibo','Recibo' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'Cliente','Cliente')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdCliente','IdCliente',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'NomeCliente','NomeCliente',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Ativo','Ativo' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'DescargaDeColeta','DescargaDeColeta')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdDescargaDeColetas','IdDescargaDeColetas',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdSetorJornada','IdSetorJornada',0,0,0,0)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'Device','Device')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdDevice','IdDevice',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'ChaveDevice','ChaveDevice',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'ModeloDevice','ModeloDevice',0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'DeviceInstalado','DeviceInstalado')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdInstalacao','IdInstalacao' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdDevice','IdDevice',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdVeiculo','IdVeiculo',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdUsuario','IdUsuario',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Ativo','Ativo' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'Garagem','Garagem')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdGaragem','IdGaragem',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Nome','Nome',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Ativo','Ativo',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdCliente','IdCliente',0,0,0,0)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'Interrupcao','Interrupcao')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdInterrupcao','IdInterrupcao',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraInterrupcao','DataHoraInterrupcao',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraFimInterrupcao','DataHoraFimInterrupcao',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdVeiculo','IdVeiculo',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Odometro','Odometro',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Horimetro','Horimetro',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdJornada','IdJornada',0,0,0,0)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'MotivosInterrupcao','MotivosInterrupcao')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdMotivo','IdMotivo',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Motivo','Motivo' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Ativo','Ativo',0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'Perfil','Perfil')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdPerfil','IdPerfil' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Nome','Nome',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Descricao','Descricao',0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'RecursosDaJornada','RecursosDaJornada')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdJornada','IdJornada',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdRecursoDeColeta','IdRecursoDeColeta',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraAlocacao','DataHoraAlocacao',0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'RecursosDeColeta','RecursosDeColeta')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE, 'Senha','Senha',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdCliente','IdCliente' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Nome','Nome',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Perfil','Perfil',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Ativo','Ativo',0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'RetornoParaCompletarColeta','RetornoParaCompletarColeta')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdRecursoDeColeta','',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdSetorJornada','' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraRetorno','' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Odometro','' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Horimetro','' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'RetornoParaGaragem','RetornoParaGaragem')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdRetorno','IdRetorno' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdGaragem','IdGaragem' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdJornada','IdJornada' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraSelecaoGaragem','DataHoraSelecaoGaragem' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraInicioRetorno','DataHoraInicioRetorno' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'OdometroPartida','OdometroPartida' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'HorimetroPartida','HorimetroPartida' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraChegada','DataHoraChegada' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'OdometroChegada','OdometroChegada' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'HorimetroChegada','HorimetroChegada' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'EmViagem','EmViagem' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'RotaRealizada','RotaRealizada')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdJornada','IdJornada',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Ping','Ping' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Latitude','Latitude',0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Longitude','Longitude' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'SelecaoDeNovoSetor','SelecaoDeNovoSetor')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdNovoSetor','IdNovoSetor' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdJornada','IdJornada' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraSelecao','DataHoraSelecao' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Odometro','Odometro' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Horimetro','Horimetro' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'Setor','Setor')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdSetor','IdSetor' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdCliente','IdCliente' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'NomeSetor','NomeSetor' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'Ativo','Ativo' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'SetoresDaJornada','SetoresDaJornada')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdSetorJornada','IdSetorJornada' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdSetor','IdSetor' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'IdJornada','IdJornada' ,0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraDoVinculoDoSetorNaJornada','DataHoraDoVinculoDoSetorNaJornada' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraInicioSetor','DataHoraInicioSetor' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'OdometroInicioSetor','OdometroInicioSetor' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'HorimetroInicioSetor','HorimetroInicioSetor' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'DataHoraEncerramentoSetor','DataHoraEncerramentoSetor' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'OdometroNoEncerramentoDoSetor','OdometroNoEncerramentoDoSetor' ,0,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,  'HorimetroNoEncerramentoDoSetor','HorimetroNoEncerramentoDoSetor' ,0,1,1,1)


SET @GUIDIDENTITY_TABLE = NEWID()
INSERT INTO ConstrutorTabela Values(@GUIDIDENTITY_TABLE,'Veiculo','Veiculo')

INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'IdVeiculo','IdVeiculo',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'IdentificacaoNoCliente','IdentificacaoNoCliente',2,1,1,1)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'IdCliente','IdCliente',0,0,0,0)
INSERT INTO ConstrutorCampo Values(NEWID(),@GUIDIDENTITY_TABLE,'Ativo','Ativo',1,1,1,1)



DECLARE @TABELA UNIQUEIDENTIFIER
DECLARE @CAMPO UNIQUEIDENTIFIER
DECLARE @TABELAMESTRE UNIQUEIDENTIFIER
DECLARE @CAMPOMESTRE UNIQUEIDENTIFIER

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'DescargaDeColeta'
SELECT @CAMPO = IdConstrutorCampo FROM ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdSetorJornada'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'SetoresDaJornada'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdSetorJornada'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'DescargaDeColeta'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdDescargaAterro'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'DescargaAterro'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdDescargaAterro'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'DeviceInstalado'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdDevice'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Device'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdDevice'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'DeviceInstalado'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdVeiculo'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Veiculo'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdVeiculo'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'DeviceInstalado'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdUsuario'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Usuario'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdUsuario'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Interrupcao'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdMotivoInterrupcao'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'MotivosInterrupcao'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdMotivoInterrupcao'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Interrupcao'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdVeiculo'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Veiculo'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdVeiculo'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Interrupcao'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdJornada'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Jornada'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdJornada'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'RecursosDaJornada'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdRecursoDeColeta'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'RecursosDeColeta'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdRecursoDeColeta'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'RecursosDaJornada'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdJornada'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Jornada'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdJornada'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'RetornoParaCompletarColeta'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdSetorJornada'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'SetoresDaJornada'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdSetorJornada'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'RetornoParaGaragem'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdJornada'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Jornada'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdJornada'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'RetornoParaGaragem'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdGaragem'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Garagem'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdGaragem'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'RotaRealizada'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdJornada'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Jornada'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdJornada'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'SelecaoDeNovoSetor'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdJornada'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Jornada'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdJornada'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'SetoresDaJornada'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdJornada'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Jornada'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdJornada'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'SetoresDaJornada'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdSetor'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Setor'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdSetor'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)

SELECT @TABELA = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Jornada'
SELECT @CAMPO = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELA AND Nome LIKE 'IdVeiculo'
SELECT @TABELAMESTRE = IdConstrutorTabela FROM CONSTRUTORTABELA WHERE NOME LIKE 'Veiculo'
SELECT @CAMPOMESTRE = IdConstrutorCampo FROM dbo.ConstrutorCampo WHERE IdConstrutorTabela = @TABELAMESTRE AND Nome LIKE 'IdVeiculo'
INSERT INTO ConstrutorChaveEstrangeira VALUES(NEWID(),@TABELA, @CAMPO,@TABELAMESTRE,@CAMPOMESTRE)


