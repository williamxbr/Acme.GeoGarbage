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
    public class ConfiguracaoAppController : ApiController
    {
        private readonly IConfiguracaoAppAplicacaoServico _configuracaoAppAplicacaoServico;

        public ConfiguracaoAppController(IConfiguracaoAppAplicacaoServico configuracaoAppAplicacaoServico)
        {
            _configuracaoAppAplicacaoServico = configuracaoAppAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _configuracaoAppAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public IEnumerable<ConfiguracaoApp> Get_ConfiguracaoApp()
        {
            var configuracaoApp = _configuracaoAppAplicacaoServico.BuscaTodos();
            return configuracaoApp;
        }

        [HttpGet]
        [Route("api/configuracaoapp/{idcliente}")]
        public ConfiguracaoApp Get_ConfiguracaoApp(Guid idcliente)
        {
            //   Guid idcliente = Guid.Parse(IUCliente);
            ConfiguracaoApp configuracaoApp = _configuracaoAppAplicacaoServico.BuscaTodos().FirstOrDefault(f => f.IdCliente == idcliente);
            return configuracaoApp;
        }

    }
}
