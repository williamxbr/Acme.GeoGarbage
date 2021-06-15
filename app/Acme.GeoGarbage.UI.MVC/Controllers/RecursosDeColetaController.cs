using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.FiltrosAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    [AutorizacaoRequerida]
    public class RecursosDeColetaController : ApiController
    {
        private readonly IRecursoDeColetaAplicacaoServico _recursosDeColetaAplicacaoServico;

        public RecursosDeColetaController(IRecursoDeColetaAplicacaoServico recursosDeColetaAplicacaoServico)
        {
            _recursosDeColetaAplicacaoServico = recursosDeColetaAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _recursosDeColetaAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public IEnumerable<RecursoDeColeta> Get_ListarRecursos()
        {
            var recursosDeColeta = _recursosDeColetaAplicacaoServico.BuscaTodos();
            return recursosDeColeta;
        }

        [HttpGet]
        public IEnumerable<RecursoDeColeta> Get_ListarRecursos(Guid idcliente)
        {
            var recursosDeColeta = _recursosDeColetaAplicacaoServico.BuscaTodos().Where(f => f.IdCliente == idcliente).Where(f => f.Ativo);
            return recursosDeColeta;
        }
    }
}
