using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class SetorDaJornadaController : ApiController
    {
        private readonly ISetorDaJornadaAplicacaoServico _setorDaJornadaAplicacaoServico;
        private readonly ISetorAplicacaoServico _setorAplicacaoServico;
        private readonly IPontoDeColetaAplicacaoServico _pontoDeColetaAplicacaoServico;
        private readonly IExecucaoPontoDeColetaAplicacaoServico _execucaoPontoDeColetaAplicacaoServico;
        private readonly IRetornoParaCompletarColetaAplicacaoServico _retornoParaCompletarColetaAplicacaoServico;

        public SetorDaJornadaController(ISetorDaJornadaAplicacaoServico setorDaJornadaAplicacaoServico,
                                        ISetorAplicacaoServico setorAplicacaoServico,
                                        IPontoDeColetaAplicacaoServico pontoDeColetaAplicacaoServico,
                                        IExecucaoPontoDeColetaAplicacaoServico execucaoPontoDeColetaAplicacaoServico,
                                        IRetornoParaCompletarColetaAplicacaoServico retornoParaCompletarColetaAplicacaoServico)
        {
            _setorDaJornadaAplicacaoServico = setorDaJornadaAplicacaoServico;
            _setorAplicacaoServico = setorAplicacaoServico;
            _pontoDeColetaAplicacaoServico = pontoDeColetaAplicacaoServico;
            _execucaoPontoDeColetaAplicacaoServico = execucaoPontoDeColetaAplicacaoServico;
            _retornoParaCompletarColetaAplicacaoServico = retornoParaCompletarColetaAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _setorDaJornadaAplicacaoServico.Dispose();
                _setorAplicacaoServico.Dispose();
                _pontoDeColetaAplicacaoServico.Dispose();
                _execucaoPontoDeColetaAplicacaoServico.Dispose();
                _retornoParaCompletarColetaAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("api/SetorDaJornada/post_IniciarColeta")]
        public bool post_IniciarColeta(SetorDaJornada coleta)
        {
            try
            {
                _setorDaJornadaAplicacaoServico.Atualiza(coleta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/SetorDaJornada/post_EncerrarColeta")]
        public bool post_EncerrarColeta(SetorDaJornada coleta)
        {
            try
            {
                _setorDaJornadaAplicacaoServico.Atualiza(coleta);
                if (coleta.RetornoParaCompletarColetas == null) return true;
                foreach (RetornoParaCompletarColeta retornoParaCompletarColeta in coleta.RetornoParaCompletarColetas)
                {
                    _retornoParaCompletarColetaAplicacaoServico.Adiciona(retornoParaCompletarColeta);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/SetorDaJornada/post_StatusSetorJornada")]
        public bool post_StatusSetorJornada(Guid idSetorJornada, StatusDeOperacao status)
        {
            try
            {
                SetorDaJornada setorDaJornada = _setorDaJornadaAplicacaoServico.BuscaId(idSetorJornada);

                if (setorDaJornada != null)
                {
                    setorDaJornada.Status = status;
                    _setorDaJornadaAplicacaoServico.Atualiza(setorDaJornada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/SetorDaJornada/post_DirigindoParaSetor")]
        public bool post_DirigindoParaSetor(SetorDaJornada setorDaJornada)
        {
            try
            {
                //1.API recebe objeto SetoresDaJornada e salva objeto em sua respectiva entidade de dados;
                //2.Recupera o IdSetor do objeto;
                _setorDaJornadaAplicacaoServico.Adiciona(setorDaJornada);
                //3.Recupera da entidade “PontoDeColeta” todos os pontos de coleta do setor recuperado no passo 2;
                //List<PontoDeColeta> listPontoDeColetas = _pontoDeColetaAplicacaoServico.BuscaTodos()
                //    .Where(p => p.IdSetor == setorDaJornada.IdSetor).ToList();
                IQueryable<PontoDeColeta> listPontoDeColetas = _pontoDeColetaAplicacaoServico.Consultar().Where(p => p.IdSetor == setorDaJornada.IdSetor);

                //4.Para cada PontoDeColeta recuperado cria objeto ExecussaoPontoDeColeta e salva os novos objetos na entidade “ExecussaoPontoDeColeta” para o IdSetorDaJornada;
                foreach (PontoDeColeta pontoDeColeta in listPontoDeColetas.ToList())
                {
                    ExecucaoPontoDeColeta execucaoPontoDeColeta =
                        new ExecucaoPontoDeColeta
                        {
                            IdPontoDeColeta = pontoDeColeta.IdPontoDeColeta,
                            IdSetorDeJornada = setorDaJornada.IdSetorDaJornada,
                            StatusDePassagem = StatusDePassagem.APassar,
                            Passagem = new DateTime(1900, 1, 1)
                        };
                    _execucaoPontoDeColetaAplicacaoServico.Adiciona(execucaoPontoDeColeta);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/SetorDaJornada/post_AtualizarOdometro")]
        public bool post_AtualizarOdometro()
        {
            try
            {
                List<SetorDaJornada> setorDaJornadasInicio =
                    _setorDaJornadaAplicacaoServico.Consultar().Where(p => p.OdometroInicioSetor == 0.00)
                        .Where(p => p.DataHoraInicioSetor > new DateTime(1900, 1, 1)).ToList();
                foreach (SetorDaJornada setorDaJornada in setorDaJornadasInicio)
                {
                    _setorDaJornadaAplicacaoServico.AtualizaOdometroInicial(setorDaJornada);
                }
                List<SetorDaJornada> setorDaJornadasFinal =
                    _setorDaJornadaAplicacaoServico.Consultar().Where(p => p.OdometroNoEncerramentoDoSetor == 0.00)
                        .Where(p => p.DataHoraEncerramentoSetor > new DateTime(1900, 1, 1)).ToList();
                foreach (SetorDaJornada setorDaJornada in setorDaJornadasFinal)
                {
                    _setorDaJornadaAplicacaoServico.AtualizaOdometroFinal(setorDaJornada);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpPost]
        [Route("api/SetorDaJornada/post_AtualizarHorimetro")]
        public bool post_AtualizarHorimetro()
        {
            try
            {
                List<SetorDaJornada> setorDaJornadasInicio =
                    _setorDaJornadaAplicacaoServico.Consultar().Where(p => p.HorimetroInicioSetor == 0.00)
                        .Where(p => p.DataHoraInicioSetor > new DateTime(1900, 1, 1)).ToList();
                foreach (SetorDaJornada setorDaJornada in setorDaJornadasInicio)
                {
                    _setorDaJornadaAplicacaoServico.AtualizaHorimetroInicial(setorDaJornada);
                }

                List<SetorDaJornada> setorDaJornadasFinal =
                    _setorDaJornadaAplicacaoServico.Consultar().Where(p => p.HorimetroNoEncerramentoDoSetor == 0.00)
                        .Where(p => p.DataHoraEncerramentoSetor > new DateTime(1900, 1, 1)).ToList();
                foreach (SetorDaJornada setorDaJornada in setorDaJornadasFinal)
                {
                    _setorDaJornadaAplicacaoServico.AtualizaHorimetroFinal(setorDaJornada);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


    }
}
