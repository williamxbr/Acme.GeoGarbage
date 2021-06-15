using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.Filtros;
using Acme.GeoGarbage.UI.MVC.FiltrosAction;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    [AutorizacaoRequerida]
    public class ClienteController : ApiController
    {
        private readonly IClienteAplicacaoServico _clienteAplicacaoServico;

        public ClienteController(IClienteAplicacaoServico clienteAplicacaoServico)
        {
            _clienteAplicacaoServico = clienteAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public IEnumerable<Cliente> Get_ListarClientes()
        {
            var clientes = _clienteAplicacaoServico.BuscaTodos().Where(t => t.Ativo == true);
            return clientes;
        }

    }
}
