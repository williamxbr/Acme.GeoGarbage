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
    public class InterrupcaoController : ApiController
    {
        private readonly IInterrupcaoAplicacaoServico _interrupcaoAplicacaoServico;

        public InterrupcaoController(IInterrupcaoAplicacaoServico interrupcaoAplicacaoServico)
        {
            _interrupcaoAplicacaoServico = interrupcaoAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _interrupcaoAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("api/Interrupcao/post_InformarInterrupcao")]
        public bool post_InformarInterrupcao(Interrupcao motivo)
        {
            try
            {
                _interrupcaoAplicacaoServico.Adiciona(motivo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/Interrupcao/post_InformarDesinterrupcao")]
        public bool post_InformarDesinterrupcao(Interrupcao motivo)
        {
            try
            {
                _interrupcaoAplicacaoServico.Atualiza(motivo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/Interrupcao/post_AtualizarOdometro")]
        public bool post_AtualizarOdometro()
        {
            try
            {
                List<Interrupcao> interrupcaos = _interrupcaoAplicacaoServico.Consultar().Where(p => p.Odometro == 0.00).Where(p => p.DataHoraInterrupcao > new DateTime(1900, 1, 1))
                    .ToList();
                foreach (Interrupcao interrupcao in interrupcaos)
                {
                    _interrupcaoAplicacaoServico.AtualizaOdometro(interrupcao);
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
        [Route("api/Interrupcao/post_AtualizarHorimetro")]
        public bool post_AtualizarHorimetro()
        {
            try
            {
                List<Interrupcao> interrupcaos = _interrupcaoAplicacaoServico.Consultar().Where(p => p.DataHoraInterrupcao > new DateTime(1900, 1, 1))
                    .Where(p => p.Horimetro == 0.00).ToList();
                foreach (Interrupcao interrupcao in interrupcaos)
                {
                    _interrupcaoAplicacaoServico.AtualizaHorimetro(interrupcao);
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
