using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.FiltrosAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    [AutorizacaoRequerida]
    public class MotivosInterrupcaoController : ApiController
    {
        private readonly IMotivoInterrupcaoAplicacaoServico _motivosInterrupcaoAplicacaoServico;

        public MotivosInterrupcaoController(IMotivoInterrupcaoAplicacaoServico motivosInterrupcaoAplicacaoServico)
        {
            _motivosInterrupcaoAplicacaoServico = motivosInterrupcaoAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _motivosInterrupcaoAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public IEnumerable<MotivoInterrupcao> Get_MotivosInterrupcao()
        {
            var motivosInterrupcao = _motivosInterrupcaoAplicacaoServico.BuscaTodos().Where(f => f.Ativo);
            return motivosInterrupcao;
        }
    }
}
