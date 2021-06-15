using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class SelecaoDeNovoSetorController : ApiController
    {
        private readonly ISelecaoDeNovoSetorAplicacaoServico _selecaoDeNovoSetorAplicacaoServico;

        public SelecaoDeNovoSetorController(ISelecaoDeNovoSetorAplicacaoServico selecaoDeNovoSetorAplicacaoServico)
        {
            _selecaoDeNovoSetorAplicacaoServico = selecaoDeNovoSetorAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _selecaoDeNovoSetorAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("api/SelecaoDeNovoSetor/post_AtualizarOdometro")]
        public bool post_AtualizarOdometro()
        {
            try
            {
                List<SelecaoDeNovoSetor> selecaoDeNovoSetors =
                    _selecaoDeNovoSetorAplicacaoServico.Consultar().Where(p => p.Odometro == 0.00)
                        .Where(p => p.DataHoraSelecao > new DateTime(1900, 1, 1)).ToList();
                foreach (SelecaoDeNovoSetor selecaoDeNovoSetor in selecaoDeNovoSetors)
                {
                    _selecaoDeNovoSetorAplicacaoServico.AtualizaOdometro(selecaoDeNovoSetor);
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
        [Route("api/SelecaoDeNovoSetor/post_AtualiarHorimetro")]
        public bool post_AtualizarHorimetro()
        {
            try
            {
                List<SelecaoDeNovoSetor> selecaoDeNovoSetors =
                    _selecaoDeNovoSetorAplicacaoServico.Consultar().Where(p => p.Horimetro == 0.00)
                        .Where(p => p.DataHoraSelecao > new DateTime(1900, 1, 1)).ToList();
                foreach (SelecaoDeNovoSetor selecaoDeNovoSetor in selecaoDeNovoSetors)
                {
                    _selecaoDeNovoSetorAplicacaoServico.AtualizaHorimetro(selecaoDeNovoSetor);
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
        [Route("api/SelecaoDeNovoSetor/post_SelecaoDeNovoSetor")]
        public bool post_SelecaoDeNovoSetor(SelecaoDeNovoSetor selecaoDeNovoSetor)
        {
            try
            {
                _selecaoDeNovoSetorAplicacaoServico.Adiciona(selecaoDeNovoSetor);
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
