using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;
using Acme.GeoGarbage.Utilidades;
using System;
using System.Diagnostics;
using System.Linq;

namespace Acme.GeoGarbage.Aplicacao
{
    public class SetorDaJornadaAplicacaoServico : AplicacaoServicoBase<SetorDaJornada>, ISetorDaJornadaAplicacaoServico
    {
        private readonly ISetorDaJornadaServico _setordajornadaServico;
        private readonly IRotaRealizadaServico _rotaRealizadaServico;
        private readonly IJornadaServico _jornadaServico;
        private readonly IVeiculoServico _veiculoServico;
        private readonly ILastMileageEngineServico _lastMileageEngineServico;

        public SetorDaJornadaAplicacaoServico(ISetorDaJornadaServico setordajornadaServico, 
                                              IRotaRealizadaServico rotaRealizadaServico, 
                                              IJornadaServico jornadaServico,
                                              IVeiculoServico veiculoServico,
                                              ILastMileageEngineServico lastMileageEngineServico) : base(setordajornadaServico)
        {
            _setordajornadaServico = setordajornadaServico;
            _rotaRealizadaServico = rotaRealizadaServico;
            _jornadaServico = jornadaServico;
            _veiculoServico = veiculoServico;
            _lastMileageEngineServico = lastMileageEngineServico;
        }

        public int CalcularPorcentagemDeConclusao(SetorDaJornada setor)
        {
            if (setor == null)
            {
                throw new System.Exception("Argumento setor não pode ser nulo.");
            }

            double total = setor.ExecucaoPontoDeColetas.Count();

            if (total != 0)
            {

                double totalExecutado = setor.ExecucaoPontoDeColetas.Count(x => x.StatusDePassagem == StatusDePassagem.Pulado ||
                                                                                x.StatusDePassagem == StatusDePassagem.Passado);

                double porcentagem = (totalExecutado / total) * 100;
                return (int)porcentagem;
            }
            else
            {
                return 0;
            }
        }

        public SinalizacaoPing PegarSinalizacaoPing(SetorDaJornada setor, PadraoDaConta padraoDaConta)
        {
            if (setor == null || padraoDaConta == null)
            {
                throw new NotImplementedException("Argumentos não podem ser nulos.");
            }

            //var rotaRealizada = _rotaRealizadaServico.Pesquisar(x => x.IdJornada == setor.IdJornada &&
            //                                                         x.Ping >= setor.DataHoraDoVinculoDoSetorNaJornada)
            //                                         .OrderByDescending(x => x.Ping)
            //                                         .FirstOrDefault();

            var rotaRealizada = _rotaRealizadaServico.Consultar()
                .Where(x => x.IdJornada == setor.IdJornada && x.Ping >= setor.DataHoraDoVinculoDoSetorNaJornada)
                .OrderByDescending(x => x.Ping).FirstOrDefault();

            if (rotaRealizada != null)
            {
                var minutosUltimaComunicacao = (DateTime.Now - rotaRealizada.Ping).Minutes;

                if (minutosUltimaComunicacao >= padraoDaConta.PingVermelho)
                {
                    return SinalizacaoPing.Vermelho;
                }
                else if (minutosUltimaComunicacao >= padraoDaConta.PingVerde && minutosUltimaComunicacao < padraoDaConta.PingVermelho)
                {
                    return SinalizacaoPing.Amarelo;
                }
                else
                {
                    return SinalizacaoPing.Verde;
                }
            }
            else
            {
                return SinalizacaoPing.Cinza;
            }
        }

        public SinalizacaoDeHorario PegarSinalizacaoHorario(SetorDaJornada setor)
        {

            bool PassouToleranciaProximoPonto(ExecucaoPontoDeColeta proximoPonto)
            {
                if (proximoPonto.PontoDeColeta.Horario.Contains(':'))
                {
                    var horarioTolerancia1 = new TimeSpan(Convert.ToInt32(proximoPonto.PontoDeColeta.Horario.Split(':')[0]),
                                                          Convert.ToInt32(proximoPonto.PontoDeColeta.Horario.Split(':')[1]),
                                                          0).Add(new TimeSpan(0, proximoPonto.PontoDeColeta.Tolerancia1, 0));

                    return DateTime.Now.TimeOfDay > horarioTolerancia1;

                }
                return false;
            }

            if (setor == null)
            {
                throw new Exception("Argumento setor não pode ser nulo.");
            }

            var ultimoPontoPassado = setor.ExecucaoPontoDeColetas.LastOrDefault(x => x.StatusDePassagem == StatusDePassagem.Passado && x.PontoDeColeta.Horario.Contains(':'))
                ?? (setor.ExecucaoPontoDeColetas.FirstOrDefault(x => x.PontoDeColeta.Horario.Contains(':')) != null ?
                    (PassouToleranciaProximoPonto(setor.ExecucaoPontoDeColetas.FirstOrDefault(x => x.PontoDeColeta.Horario.Contains(':')))
                     ? setor.ExecucaoPontoDeColetas.FirstOrDefault(x => x.PontoDeColeta.Horario.Contains(':')) : null) : null);

            if (ultimoPontoPassado != null)
            {

                var proximoExecucaoPontoColeta = ultimoPontoPassado.StatusDePassagem == StatusDePassagem.Passado
                    ? setor.ExecucaoPontoDeColetas.FirstOrDefault(
                        x => x.PontoDeColeta.SequenciaDeColeta > ultimoPontoPassado.PontoDeColeta.SequenciaDeColeta &&
                             x.PontoDeColeta.Horario.Trim().Length > 0)
                    : ultimoPontoPassado;


                if (proximoExecucaoPontoColeta != null && PassouToleranciaProximoPonto(proximoExecucaoPontoColeta))
                {

                    var passagem = proximoExecucaoPontoColeta.PontoDeColeta.Horario;

                    var primeiraToleranciaAcima = new TimeSpan(Convert.ToInt32(passagem.Split(':')[0]),
                                                               Convert.ToInt32(passagem.Split(':')[1]),
                                                               0).Add(new TimeSpan(0, proximoExecucaoPontoColeta.PontoDeColeta.Tolerancia1, 0));

                    var segundaToleranciaAcima = new TimeSpan(Convert.ToInt32(passagem.Split(':')[0]),
                                                              Convert.ToInt32(passagem.Split(':')[1]),
                                                              0).Add(new TimeSpan(0, proximoExecucaoPontoColeta.PontoDeColeta.Tolerancia2, 0));

                    return DateTime.Now.TimeOfDay.IsBetween(primeiraToleranciaAcima, segundaToleranciaAcima) ? SinalizacaoDeHorario.Laranja : SinalizacaoDeHorario.Preto;


                }
                var pontoDeColeta = ultimoPontoPassado.PontoDeColeta;

                if (pontoDeColeta.Tolerancia1 == 0 || pontoDeColeta.Tolerancia2 == 0 || pontoDeColeta.Horario.Trim().Length == 0)
                    return SinalizacaoDeHorario.SemMonitoramento;

                var horario = new TimeSpan(Convert.ToInt32(pontoDeColeta.Horario.Split(':')[0]),
                    Convert.ToInt32(pontoDeColeta.Horario.Split(':')[1]),
                    0);

                int tolerancia = (int)(ultimoPontoPassado.Passagem.TimeOfDay - horario).TotalMinutes;

                switch (tolerancia >= 0)
                {
                    case true:
                        if (tolerancia.IsBetween(0, pontoDeColeta.Tolerancia1)) return SinalizacaoDeHorario.Verde;
                        if (tolerancia.IsBetween(pontoDeColeta.Tolerancia1, pontoDeColeta.Tolerancia2)) return SinalizacaoDeHorario.Laranja;
                        if (tolerancia.IsBetween(pontoDeColeta.Tolerancia2, 9999)) return SinalizacaoDeHorario.Preto;
                        break;
                    case false:
                        if (Math.Abs(tolerancia).IsBetween(0, pontoDeColeta.Tolerancia1)) return SinalizacaoDeHorario.Verde;
                        if (Math.Abs(tolerancia).IsBetween(pontoDeColeta.Tolerancia1, pontoDeColeta.Tolerancia2)) return SinalizacaoDeHorario.Amarelo;
                        if (Math.Abs(tolerancia).IsBetween(pontoDeColeta.Tolerancia2, 9999)) return SinalizacaoDeHorario.Vermelho;
                        break;
                }

            }

            return SinalizacaoDeHorario.Cinza;

        }

        public void AtualizaOdometroInicial(SetorDaJornada setorDaJornada)
        {
            Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            setorDaJornada.OdometroInicioSetor = _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, setorDaJornada.DataHoraInicioSetor);
            _setordajornadaServico.Atualiza(setorDaJornada);
        }

        public void AtualizaOdometroFinal(SetorDaJornada setorDaJornada)
        {
            Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            setorDaJornada.OdometroNoEncerramentoDoSetor = _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, setorDaJornada.DataHoraEncerramentoSetor);
            _setordajornadaServico.Atualiza(setorDaJornada);
        }

        public void AtualizaHorimetroInicial(SetorDaJornada setorDaJornada)
        {
            Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            setorDaJornada.HorimetroInicioSetor = _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, setorDaJornada.DataHoraInicioSetor);
            _setordajornadaServico.Atualiza(setorDaJornada);
        }

        public void AtualizaHorimetroFinal(SetorDaJornada setorDaJornada)
        {
            Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            setorDaJornada.HorimetroNoEncerramentoDoSetor = _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, setorDaJornada.DataHoraEncerramentoSetor);
            _setordajornadaServico.Atualiza(setorDaJornada);
        }
    }
}
