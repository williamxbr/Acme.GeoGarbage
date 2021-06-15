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
    public class DescargaAterroController : ApiController
    {
        private readonly IDescargaAterroAplicacaoServico _descargaAterroAplicacaoServico;
        private readonly IDescargaDeColetaAplicacaoServico _descargaDeColetaAplicacaoServico;

        public DescargaAterroController(IDescargaAterroAplicacaoServico descargaAterroAplicacaoServico,
                                        IDescargaDeColetaAplicacaoServico descargaDeColetaAplicacaoServico)
        {
            _descargaAterroAplicacaoServico = descargaAterroAplicacaoServico;
            _descargaDeColetaAplicacaoServico = descargaDeColetaAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _descargaAterroAplicacaoServico.Dispose();
                _descargaDeColetaAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpPost]
        [Route("api/DescargaAterro/post_DescargaAterro")]
        public bool post_DescargaAterro(DescargaAterro descargaAterro)
        {
            try
            {
                _descargaAterroAplicacaoServico.Adiciona(descargaAterro);
                if (descargaAterro.DescargaDeColetas == null) return true;
                foreach (DescargaDeColeta descargaDeColeta in descargaAterro.DescargaDeColetas)
                {
                    _descargaDeColetaAplicacaoServico.Adiciona(descargaDeColeta);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/DescargaAterro/post_AtualizarOdometro")]
        public bool post_AtualizarOdometro()
        {
            try
            {
                List<DescargaAterro> descargaAterrosDescarga = _descargaAterroAplicacaoServico.Consultar()
                    .Where(p => p.InicioDescargaAterroOdometro == 0.00).Where(p => p.InicioDescargaAterro > new DateTime(1900, 1, 1)).ToList();
                foreach (DescargaAterro descargaAterro in descargaAterrosDescarga)
                {
                    _descargaAterroAplicacaoServico.AtualizaOdometroInicioDescarga(descargaAterro);
                }
                List<DescargaAterro> descargaAterrosViagem = _descargaAterroAplicacaoServico.Consultar()
                    .Where(p => p.OdometroInicioDaViagemParaDescarga == 0.00).Where(p => p.InicioDescargaAterro > new DateTime(1900, 1, 1)).ToList();
                foreach (DescargaAterro descargaAterro in descargaAterrosViagem)
                {
                    _descargaAterroAplicacaoServico.AtualizaOdometroInicioViagem(descargaAterro);
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
        [Route("api/DescargaAterro/post_AtualizarHorimetro")]
        public bool post_AtualizarHorimetro()
        {
            try
            {
                List<DescargaAterro> descargaAterrosDescarga =
                    _descargaAterroAplicacaoServico.Consultar()
                    .Where(p => p.InicioDescargaAterroHorimetro == 0.00)
                    .Where(p => p.InicioDescargaAterro > new DateTime(1900, 1, 1))
                        .ToList();
                foreach (DescargaAterro descargaAterro in descargaAterrosDescarga)
                {
                    _descargaAterroAplicacaoServico.AtualizaHorimetroInicioDescarga(descargaAterro);
                }

                List<DescargaAterro> descargaAterrosViagem =
                    _descargaAterroAplicacaoServico.Consultar()
                        .Where(p => p.HorimetroInicioDaViagemParaDescarga == 0.00)
                        .Where(p => p.InicioDaViagemParaDescarga > new DateTime(1900, 1, 1)).ToList();
                foreach (DescargaAterro descargaAterro in descargaAterrosViagem)
                {
                    _descargaAterroAplicacaoServico.AtualizaHorimetroInicioViagem(descargaAterro);
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
