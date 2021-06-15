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
    public class SetorController : ApiController
    {
        private readonly ISetorAplicacaoServico _setorAplicacaoServico;

        public SetorController(ISetorAplicacaoServico setorAplicacaoServico)
        {
            _setorAplicacaoServico = setorAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _setorAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public IEnumerable<Setor> Get_ListarSetores()
        {
            var setores = _setorAplicacaoServico.BuscaTodos();
            return setores;
        }

        [HttpGet]
        [Route("api/setor/{idcliente}")]
        public IEnumerable<Setor> Get_ListarSetores(Guid? idcliente)
        {
            //Guid idcliente = Guid.Parse(IUCliente);
            var setores = _setorAplicacaoServico.BuscaTodos().Where(f => f.IdCliente == idcliente).Where(f => f.Ativo);
            return setores;
        }


    }
}
