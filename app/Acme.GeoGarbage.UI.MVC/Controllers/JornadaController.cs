using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class JornadaController : ApiController
    {
        private readonly IJornadaAplicacaoServico _jornadaAplicacaoServico;
        private readonly ISelecaoDeNovoSetorAplicacaoServico _selecaoDeNovoSetorAplicacaoServico;

        public JornadaController(IJornadaAplicacaoServico jornadaAplicacaoServico,
                                 ISelecaoDeNovoSetorAplicacaoServico selecaoDeNovoSetorAplicacaoServico)
        {
            _jornadaAplicacaoServico = jornadaAplicacaoServico;
            _selecaoDeNovoSetorAplicacaoServico = selecaoDeNovoSetorAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _jornadaAplicacaoServico.Dispose();
                _selecaoDeNovoSetorAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpPost]
        [Route("api/jornada/post_CriarJornada")]
        public bool post_CriarJornada(Jornada jornada)
        {
            try
            {
                _jornadaAplicacaoServico.Adiciona(jornada);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        [HttpPost]
        [Route("api/jornada/post_CancelarJornada")]
        public bool post_CancelarJornada(Guid IUJornada)
        {
            try
            {
                Jornada jornada = _jornadaAplicacaoServico.BuscaId(IUJornada);
                jornada.Status = StatusJornada.NaoConcluida;
                _jornadaAplicacaoServico.Atualiza(jornada);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/jornada/post_EncerrarJornada")]
        public bool post_EncerrarJornada(Jornada jornada)
        {
            try
            {
                _jornadaAplicacaoServico.Atualiza(jornada);
                if (jornada.SelecoesDeNovosSetores == null) return true;
                foreach (SelecaoDeNovoSetor selecaoDeNovoSetor in jornada.SelecoesDeNovosSetores)
                {
                    _selecaoDeNovoSetorAplicacaoServico.Adiciona(selecaoDeNovoSetor);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/jornada/post_StatusJornada")]
        public bool post_StatusJornada(Guid idJornada, StatusDeOperacao status)
        {
            try
            {
                Jornada jornada = _jornadaAplicacaoServico.BuscaId(idJornada);

                if (jornada != null)
                {
                    _jornadaAplicacaoServico.Atualiza(jornada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/jornada/post_AtualizarOdometro")]
        public bool post_AtualizarOdometro()
        {
            try
            {
                IList<Jornada> jornadasOdometroInicio = _jornadaAplicacaoServico.Consultar().Where(p => p.OdometroInicial == 0)
                    .Where(p => p.InicioJornada > new DateTime(1900, 1, 1)).ToList();
                foreach (Jornada jornada in jornadasOdometroInicio)
                {
                    _jornadaAplicacaoServico.AtualizaOdometroInicial(jornada);
                }
                IList<Jornada> jornadasOdometroFinal = _jornadaAplicacaoServico.Consultar().Where(p => p.OdometroFinal == 0)
                    .Where(p => p.FimDaJornada > new DateTime(1900, 1, 1)).ToList();
                foreach (Jornada jornada in jornadasOdometroFinal)
                {
                    _jornadaAplicacaoServico.AtualizaOdometroFinal(jornada);
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
        [Route("api/jornada/post_AtualizarHorimentro")]
        public bool post_AtualizarHorimentro()
        {
            try
            {
                IList<Jornada> jornadasHorimetroInicio = _jornadaAplicacaoServico.Consultar().Where(p => p.HorimetroInicial == 0)
                    .Where(p => p.InicioJornada > new DateTime(1900, 1, 1)).ToList();
                foreach (Jornada jornada in jornadasHorimetroInicio)
                {
                    _jornadaAplicacaoServico.AtualizaHorimetroInicial(jornada);
                }
                IList<Jornada> jornadasHorimetroFinal = _jornadaAplicacaoServico.Consultar().Where(p => p.HorimetroFinal == 0)
                    .Where(p => p.FimDaJornada > new DateTime(1900, 1, 1)).ToList();
                foreach (Jornada jornada in jornadasHorimetroFinal)
                {
                    _jornadaAplicacaoServico.AtualizaHorimetroFinal(jornada);
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
