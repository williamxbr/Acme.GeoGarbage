using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DocumentFormat.OpenXml.Drawing;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class RetornoPraCompletarColetaController : ApiController
    {
        private readonly IRetornoParaCompletarColetaAplicacaoServico _retornoParaCompletarColetaAplicacaoServico;

        public RetornoPraCompletarColetaController(IRetornoParaCompletarColetaAplicacaoServico retornoParaCompletarColetaAplicacaoServico)
        {
            _retornoParaCompletarColetaAplicacaoServico = retornoParaCompletarColetaAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _retornoParaCompletarColetaAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("api/RetornoPraCompletarColeta/post_AtualizarOdometro")]
        public bool post_AtualizarOdometro()
        {
            try
            {
                List<RetornoParaCompletarColeta> retornoParaCompletarColetas =
                    _retornoParaCompletarColetaAplicacaoServico.Consultar().Where(p => p.Odometro == 0.00)
                        .Where(p => p.DataHoraRetorno > new DateTime(1900, 1, 1)).ToList();
                foreach (RetornoParaCompletarColeta retornoParaCompletarColeta in retornoParaCompletarColetas)
                {
                    _retornoParaCompletarColetaAplicacaoServico.AtualizaOdometro(retornoParaCompletarColeta);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/RetornoPraCompletarColeta/post_AtualizarHorimetro")]
        public bool post_AtualizarHorimetro()
        {
            try
            {
                List<RetornoParaCompletarColeta> retornoParaCompletarColetas =
                    _retornoParaCompletarColetaAplicacaoServico.Consultar().Where(p => p.Horimetro == 0)
                        .Where(p => p.DataHoraRetorno > new DateTime(1900, 1, 1)).ToList();
                foreach (RetornoParaCompletarColeta retornoParaCompletarColeta in retornoParaCompletarColetas)
                {
                    _retornoParaCompletarColetaAplicacaoServico.AtualizaHorimetro(retornoParaCompletarColeta);
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
        [Route("api/RetornoPraCompletarColeta/post_RetornoParaCompletarColeta")]
        public bool post_RetornoParaCompletarColeta(RetornoParaCompletarColeta retornoParaCompletarColeta)
        {
            try
            {
                _retornoParaCompletarColetaAplicacaoServico.Adiciona(retornoParaCompletarColeta);
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
