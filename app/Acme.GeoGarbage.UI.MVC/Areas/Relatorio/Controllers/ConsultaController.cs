using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web.Mvc;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IConsultaPastaAplicacaoServico _consultaPastaAplicacaoServico;
        private readonly IConsultaDinamicaAplicacaoServico _consultaDinamicaAplicacaoServico;
        private readonly IConsultaDinamicaTabelaAplicacaoServico _consultaDinamicaTabelaAplicacaoServico;
        private readonly IConsultaDinamicaCampoAplicacaoServico _consultaDinamicaCampoAplicacaoServico;
        private readonly IConsultaDinamicaCondicaoAplicacaoServico _consultaDinamicaCondicaoAplicacaoServico;

        public ConsultaController(IConsultaPastaAplicacaoServico consultaPastaAplicacaoServico,
                                  IConsultaDinamicaAplicacaoServico consultaDinamicaAplicacaoServico,
                                  IConsultaDinamicaTabelaAplicacaoServico consultaDinamicaTabelaAplicacaoServico,
                                  IConsultaDinamicaCampoAplicacaoServico consultaDinamicaCampoAplicacaoServico,
                                  IConsultaDinamicaCondicaoAplicacaoServico consultaDinamicaCondicaoAplicacaoServico)
        {
            _consultaPastaAplicacaoServico = consultaPastaAplicacaoServico;
            _consultaDinamicaAplicacaoServico = consultaDinamicaAplicacaoServico;
            _consultaDinamicaTabelaAplicacaoServico = consultaDinamicaTabelaAplicacaoServico;
            _consultaDinamicaCampoAplicacaoServico = consultaDinamicaCampoAplicacaoServico;
            _consultaDinamicaCondicaoAplicacaoServico = consultaDinamicaCondicaoAplicacaoServico;
        }

        // GET: Relatorio/Consulta
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaPastas()
        {
            var consultaPastaViewModel = _consultaPastaAplicacaoServico.BuscaTodos();

            return Json(consultaPastaViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CriarPasta(string pasta)
        {
            ConsultaPasta folder = _consultaPastaAplicacaoServico.BuscaPorPasta(pasta);

            string msg = "";

            if (folder == null)
            {
                folder = new ConsultaPasta();
                folder.IdConsultaPasta = Guid.NewGuid();
                folder.NomePasta = pasta;
                _consultaPastaAplicacaoServico.Adiciona(folder);
                msg = "Pasta criada com sucesso";
            }
            else
            {
                msg = "Pasta já existente, por favor informe outro nome!";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CriarConsultaDinamica(string pasta, string nomeconsulta, string[] postTabelas, string[] postCampos, string[] postFuncoes)
        {
            try
            {
                foreach (string tabela in postTabelas)
                {
                    Console.WriteLine(tabela);
                }
                foreach (string campo in postCampos)
                {
                    Console.WriteLine(campo);
                }
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.DenyGet);
            }
        }
    }
}