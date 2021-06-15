using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using System.IO;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class RotaRealizadaController : ApiController
    {
        private readonly IRotaRealizadaAplicacaoServico _rotaRealizadaAplicacaoServico;
        private readonly ISetorDaJornadaAplicacaoServico _setorDaJornadaAplicacaoServico;
        private readonly IExecucaoPontoDeColetaAplicacaoServico _execucaoPontoDeColetaAplicacaoServico;
        private readonly IPontoDeColetaAplicacaoServico _pontoDeColetaAplicacaoServico;
        private readonly IJornadaAplicacaoServico _jornadaAplicacaoServico;

        public RotaRealizadaController(IRotaRealizadaAplicacaoServico rotaRealizadaAplicacaoServico,
                                       ISetorDaJornadaAplicacaoServico setorDaJornadaAplicacaoServico,
                                       IExecucaoPontoDeColetaAplicacaoServico execucaoPontoDeColetaAplicacaoServico,
                                       IPontoDeColetaAplicacaoServico pontoDeColetaAplicacaoServico,
                                       IJornadaAplicacaoServico jornadaAplicacaoServico)
        {
            _rotaRealizadaAplicacaoServico = rotaRealizadaAplicacaoServico;
            _setorDaJornadaAplicacaoServico = setorDaJornadaAplicacaoServico;
            _execucaoPontoDeColetaAplicacaoServico = execucaoPontoDeColetaAplicacaoServico;
            _pontoDeColetaAplicacaoServico = pontoDeColetaAplicacaoServico;
            _jornadaAplicacaoServico = jornadaAplicacaoServico;
        }

        [HttpPost]
        [Route("api/RotaRealizada/post_ExecutaListaRotaRealizadaNaoChecados")]
        public bool post_ExecutaListaRotaRealizadaNaoChecados()
        {
            try
            {
                Log("=========================================================");
                Log("Executando RotaRealizada");
                DateTime Horario = DateTime.Now.AddDays(-1);
                IQueryable<Jornada> jornadas = _jornadaAplicacaoServico.Consultar().Where(j => j.InicioJornada >= Horario);

                foreach (Jornada jornada in jornadas.ToList())
                {
                    //List<RotaRealizada> rotaRealizadas = _rotaRealizadaAplicacaoServico.Consultar().Where(p => p.IdJornada == jornada.IdJornada && p.ChecouPonto == false).ToList();
                    IQueryable<RotaRealizada> rotaRealizadas = _rotaRealizadaAplicacaoServico.Consultar().Where(p => p.IdJornada == jornada.IdJornada && p.ChecouPonto == false);

                    //IEnumerable <RotaRealizada> rotaRealizadas = _rotaRealizadaAplicacaoServico.BuscaTodos()
                    //    .Where(p => p.IdJornada == jornada.IdJornada)
                    //    .Where(p => p.ChecouPonto == false);

                    //List<SetorDaJornada> listaSetorDaJornadas = _setorDaJornadaAplicacaoServico.Consultar().Where(x => x.IdJornada == jornada.IdJornada && x.Status != StatusDeOperacao.SetorConcluido).ToList();
                    IQueryable<SetorDaJornada> listaSetorDaJornadas =
                        _setorDaJornadaAplicacaoServico.Consultar()
                            .Where(x => x.IdJornada == jornada.IdJornada);

                    //List<SetorDaJornada> listaSetorDaJornadas = _setorDaJornadaAplicacaoServico
                    //    .BuscaTodos()
                    //    .Where(x => x.IdJornada == jornada.IdJornada)
                    //    .Where(x => x.Status == StatusDeOperacao.EmColeta).ToList();

                    GeoCoordinate ultimaCoordenada = new GeoCoordinate(1, 1);

                    foreach (RotaRealizada rota in rotaRealizadas.ToList())
                    {
                        GeoCoordinate coordenadaAtual = new GeoCoordinate(rota.Latitude, rota.Longitude);

                        if (coordenadaAtual.GetDistanceTo(ultimaCoordenada) >= 5)
                        {
                            ChecaPontosRotaRealizada(rota, listaSetorDaJornadas);
                        }

                        rota.ChecouPonto = true;
                        _rotaRealizadaAplicacaoServico.Atualiza(rota);
                        ultimaCoordenada = coordenadaAtual;
                    }
                }
                Log("Fim RotaRealizada");
                Log("=========================================================");

                return true;

            }
            catch (Exception e)
            {
                Log($" post_ExecutaListaRotaRealizadaNaoChecados {e.Message} InnerException {e.InnerException.Message}");
                throw;
            }
        }

        public void ChecaPontosRotaRealizada(RotaRealizada rota, IQueryable<SetorDaJornada> listaSetorDaJornadas)
        {

            try
            {
                if (listaSetorDaJornadas.Any())
                {
                    //5.Verifica se dentro de um raio de X metros da coordenada recebida no objeto RotaRealizada existe algum ExecussaoPontoDeColeta,
                    //caso sim, avança fluxo, caso não encerra fluxo;
                    foreach (SetorDaJornada setorDaJornada in listaSetorDaJornadas.Where(p => p.IdJornada == rota.IdJornada).Where(p => p.DataHoraInicioSetor <= rota.Ping).Where(p => p.Status == StatusDeOperacao.EmColeta || p.DataHoraEncerramentoSetor >= rota.Ping).ToList())
                    {
                        //IEnumerable<ExecucaoPontoDeColeta> listaExecucaoPontoDeColetas = _execucaoPontoDeColetaAplicacaoServico.BuscaTodos().Where(p => p.IdSetorDeJornada == setorDaJornada.IdSetorDaJornada).ToList();

                        IQueryable<ExecucaoPontoDeColeta> listaExecucaoPontoDeColetas = _execucaoPontoDeColetaAplicacaoServico.Consultar().Where(p => p.IdSetorDeJornada == setorDaJornada.IdSetorDaJornada).Include(p => p.PontoDeColeta).OrderBy(p => p.PontoDeColeta.SequenciaDeColeta);

                        var ultimaExecucaoPontoDeColeta = listaExecucaoPontoDeColetas.Where(p => p.StatusDePassagem == StatusDePassagem.Pulado || p.StatusDePassagem == StatusDePassagem.Passado);

                        int ultimoPontoPassado = ultimaExecucaoPontoDeColeta.Any() ?  ultimaExecucaoPontoDeColeta.ToList().LastOrDefault().PontoDeColeta.SequenciaDeColeta : 0;

                        Log($"Inicio ultimoPontoPassado : {ultimoPontoPassado}");

                        foreach (ExecucaoPontoDeColeta execucaoPontoDeColeta in listaExecucaoPontoDeColetas.ToList())
                        {
                            PontoDeColeta pontoDeColeta = execucaoPontoDeColeta.PontoDeColeta;//_pontoDeColetaAplicacaoServico.BuscaId(execucaoPontoDeColeta.IdPontoDeColeta);

                            GeoCoordinate rotaPontoDeColeta = new GeoCoordinate(pontoDeColeta.Latitude, pontoDeColeta.Longitude);
                            GeoCoordinate rotaRotaRealizada = new GeoCoordinate(rota.Latitude, rota.Longitude);

                            if (rotaRotaRealizada.GetDistanceTo(rotaPontoDeColeta) <= int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["Raio"]))
                            {
                                switch (execucaoPontoDeColeta.StatusDePassagem)
                                {
                                    //6.Realiza ação de acordo o status do ponto:
                                    //a.APassar: atualiza para “Passado”;
                                    //b.NaoCumprido: atualiza para “Pulado”;
                                    case StatusDePassagem.APassar:
                                    case StatusDePassagem.NaoCumprido:
                                        {
                                            if (execucaoPontoDeColeta.StatusDePassagem == StatusDePassagem.APassar || pontoDeColeta.SequenciaDeColeta > ultimoPontoPassado)
                                            {
                                                execucaoPontoDeColeta.StatusDePassagem = StatusDePassagem.Passado;
                                            }
                                            else execucaoPontoDeColeta.StatusDePassagem = StatusDePassagem.Pulado;
                                            execucaoPontoDeColeta.Passagem = DateTime.Now;
                                            _execucaoPontoDeColetaAplicacaoServico.Atualiza(execucaoPontoDeColeta);
                                            ultimoPontoPassado = pontoDeColeta.SequenciaDeColeta;
                                            Log($"ultimo ponto : {ultimoPontoPassado}");
                                            break;
                                        }
                                        //c.Pulado: Nada a fazer;
                                        //d.Passado: Nada a fazer.
                                }
                            }
                        }

                        Log($"Checando pontos não cumprido : {ultimoPontoPassado}");
                        //7.Verifica se existem ExecussaoPontoDeColeta com ordem anterior ao ExecussaoPontoDeColeta atualizado 
                        //cujo status seja igual a “APassar” e atualiza para “Naocumprido”;
                        if (ultimoPontoPassado > 0)
                        {
                            foreach (ExecucaoPontoDeColeta execucaoPontoDeColeta in listaExecucaoPontoDeColetas.Where(p => p.StatusDePassagem == StatusDePassagem.APassar).Where(p => p.PontoDeColeta.SequenciaDeColeta < ultimoPontoPassado).ToList())
                            {
                                //PontoDeColeta pontoDeColeta = _pontoDeColetaAplicacaoServico.BuscaId(execucaoPontoDeColeta.IdPontoDeColeta);

                                //if (pontoDeColeta.SequenciaDeColeta < ultimoPontoPassado)
                               // {
                                    //if (execucaoPontoDeColeta.StatusDePassagem == StatusDePassagem.APassar)
                                    //{
                                        execucaoPontoDeColeta.StatusDePassagem = StatusDePassagem.NaoCumprido;
                                        _execucaoPontoDeColetaAplicacaoServico.Atualiza(execucaoPontoDeColeta);
                                    //}

                               // }
                            }
                        }
                        //8.Fim.
                    }
                }

            }
            catch (Exception e)
            {
                Log($" ChecaPontosRotaRealizada {e.Message} {e.InnerException}");
                throw;
            }
            //3.Verifica na entidade “SetoresDaJornada” se existem setores em execução para a jornada contida no objeto “RotaRealizada”
            //cujo status seja diferente de “SetorConcluido”;

            //4.Se existir um “SetoresDaJornada” no passo 3 continua, caso contrário encerra fluxo;
        }

        [HttpPost]
        [Route("api/RotaRealizada/post_LocalizacaoDoDevice")]
        public bool post_LocalizacaoDoDevice(RotaRealizada rota)
        {
            try
            {
                //1.API recebe objeto Rotarealizada;
                rota.ChecouPonto = !_setorDaJornadaAplicacaoServico.Consultar().Any(x => x.IdJornada == rota.IdJornada && x.Status == StatusDeOperacao.EmColeta);
                
                //2.Armazena objeto na respectiva entidade;
                _rotaRealizadaAplicacaoServico.Adiciona(rota);

                return true;
            }
            catch (Exception e)
            {
                Log($" post_LocalizacaoDoDevice {e.Message}");
                return false;
            }
        }

        public static void Log(string str)
        {
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["Log"] == "1")
            {
                StreamWriter logFile = File.AppendText(@"C:\Britos\Temp\log.txt");
                logFile.WriteLine($"{DateTime.Now} {str}");
                logFile.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _rotaRealizadaAplicacaoServico.Dispose();
                _setorDaJornadaAplicacaoServico.Dispose();
                _execucaoPontoDeColetaAplicacaoServico.Dispose();
                _pontoDeColetaAplicacaoServico.Dispose();
                _jornadaAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
