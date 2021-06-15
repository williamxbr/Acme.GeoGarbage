using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.Filtros;
using Acme.GeoGarbage.UI.MVC.FiltrosAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    [AutorizacaoRequerida]
    public class GaragemController : ApiController
    {
        private readonly IGaragemAplicacaoServico _garagemAplicacaoServico;

        public GaragemController(IGaragemAplicacaoServico garagemAplicacaoServico)
        {
            _garagemAplicacaoServico = garagemAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _garagemAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public IEnumerable<Garagem> GetAll()
        {
            var garagens = _garagemAplicacaoServico.BuscaTodos();
            return garagens;
        }

        [HttpGet]
        public IEnumerable<Garagem> Get_ListarGaragens(Guid idcliente)
        {
            //Guid idcliente = Guid.Parse(IUCliente);
            var garagens = _garagemAplicacaoServico.BuscaTodos().Where(f => f.IdCliente == idcliente).Where(f => f.Ativo == true);
            return garagens;
        }
    }
}
