using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class RecursoDaJornadaController : ApiController
    {
        //RecursoDaJornada
        private readonly IRecursoDaJornadaAplicacaoServico _recursoDaJornadaAplicacaoServico;

        public RecursoDaJornadaController(IRecursoDaJornadaAplicacaoServico recursoDaJornadaAplicacaoServico)
        {
            _recursoDaJornadaAplicacaoServico = recursoDaJornadaAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _recursoDaJornadaAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpPost]
        public bool post_VincularRecursosNaJornada(List<RecursoDaJornada> recursos)
        {
            try
            {
                foreach (RecursoDaJornada recursoDaJornada in recursos)
                {
                    _recursoDaJornadaAplicacaoServico.Adiciona(recursoDaJornada);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
