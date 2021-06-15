using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class RetornoParaGaragemController : ApiController
    {
        private readonly IRetornoParaGaragemAplicacaoServico _retornoParaGaragemAplicacaoServico;

        public RetornoParaGaragemController(IRetornoParaGaragemAplicacaoServico retornoParaGaragemAplicacaoServico)
        {
            _retornoParaGaragemAplicacaoServico = retornoParaGaragemAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _retornoParaGaragemAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("api/RetornoParaGaragem/post_ReportarChegadaNaGaragem")]
        public bool post_ReportarChegadaNaGaragem(RetornoParaGaragem reporte)
        {
            try
            {
                _retornoParaGaragemAplicacaoServico.Adiciona(reporte);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/RetornoParaGaragem/post_AtualizarOdometro")]
        public bool post_AtualizarOdometro()
        {
            try
            {
                List<RetornoParaGaragem> listRetornoParaGaragemsPartida =
                    _retornoParaGaragemAplicacaoServico.Consultar().Where(p => p.OdometroPartida == 0.00)
                    .Where(p => p.DataHoraInicioRetorno > new DateTime(1900, 1, 1)).ToList();
                foreach (RetornoParaGaragem retornoParaGaragem in listRetornoParaGaragemsPartida)
                {
                    _retornoParaGaragemAplicacaoServico.AtualizaOdometroPartida(retornoParaGaragem);
                }

                List<RetornoParaGaragem> listRetornoParaGaragemsChegada =
                    _retornoParaGaragemAplicacaoServico.Consultar().Where(p => p.OdometroChegada == 0.00)
                        .Where(p => p.DataHoraChegada > new DateTime(1900, 1, 1)).ToList();
                foreach (RetornoParaGaragem retornoParaGaragem in listRetornoParaGaragemsChegada)
                {
                    _retornoParaGaragemAplicacaoServico.AtualizaOdometroPartida(retornoParaGaragem);
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
        [Route("api/RetornoParaGaragem/post_AtualizarHorimetro")]
        public bool post_AtualizarHorimetro()
        {
            try
            {
                List<RetornoParaGaragem> listRetornoParaGaragemsPartida =
                    _retornoParaGaragemAplicacaoServico.Consultar().Where(p => p.HorimetroPartida == 0.00)
                        .Where(p => p.DataHoraInicioRetorno > new DateTime(1900, 1, 1)).ToList();
                foreach (RetornoParaGaragem retornoParaGaragem in listRetornoParaGaragemsPartida)
                {
                    _retornoParaGaragemAplicacaoServico.AtualizaHorimetroPartida(retornoParaGaragem);
                }

                List<RetornoParaGaragem> listRetornoParaGaragemsChegada =
                    _retornoParaGaragemAplicacaoServico.Consultar().Where(p => p.HorimetroChegada == 0.00)
                        .Where(p => p.DataHoraChegada > new DateTime(1900, 1, 1)).ToList();
                foreach (RetornoParaGaragem retornoParaGaragem in listRetornoParaGaragemsChegada)
                {
                    _retornoParaGaragemAplicacaoServico.AtualizaHorimetroChegada(retornoParaGaragem);
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
