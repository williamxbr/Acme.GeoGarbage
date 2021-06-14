using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using AutoMapper;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.Controllers
{
    public class ConstrutorController : Controller
    {

        private readonly IConstrutorTabelaAplicacaoServico _construtorTabelaAplicacaoServico;
        private readonly IConstrutorCampoAplicacaoServico _construtorCampoAplicacaoServico;
        private readonly IConstrutorChaveEstrangeiraAplicacaoServico _construtorChaveEstrangeiraAplicacaoServico;

        public ConstrutorController(IConstrutorTabelaAplicacaoServico construtorTabelaAplicacaoServico,
                                    IConstrutorCampoAplicacaoServico construtorCampoAplicacaoServico,
                                    IConstrutorChaveEstrangeiraAplicacaoServico construtorChaveEstrangeiraAplicacaoServico)
        {
            _construtorTabelaAplicacaoServico = construtorTabelaAplicacaoServico;
            _construtorCampoAplicacaoServico = construtorCampoAplicacaoServico;
            _construtorChaveEstrangeiraAplicacaoServico = construtorChaveEstrangeiraAplicacaoServico;
        }

        // GET: Relatorio/Construtor
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult IndexPartial()
        {
            return PartialView();
        }

        public JsonResult BuscaTabelas()
        {
            var construtorTabelasViewModel =
               Mapper.Map<IEnumerable<ConstrutorTabela>, IEnumerable<ConstrutorTabelaViewModel>>(_construtorTabelaAplicacaoServico.BuscaTodos());
            return Json(construtorTabelasViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscaCampos(List<Guid> tabelas)
        {
            var construtorCampoViewModel =
                Mapper.Map<IEnumerable<ConstrutorCampo>, IEnumerable<ConstrutorCampoViewModel>>(
                    _construtorCampoAplicacaoServico
                    .BuscaTodos()
                    .Where(d => tabelas.Contains(d.IdConstrutorTabela))
                    .Where(d => d.Selecionavel == true)
                    .OrderBy(d => d.ConstrutorTabela.Nome));
            return Json(construtorCampoViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscaRelacionamentos(List<Guid> tabelas)
        {
            var construtorChaveEstrangeiraModel = Mapper
                .Map<IEnumerable<ConstrutorChaveEstrangeira>, IEnumerable<ConstrutorChaveEstrangeiraViewModel>>(
                    _construtorChaveEstrangeiraAplicacaoServico
                        .BuscaTodos()
                        .Where(d => tabelas.Contains(d.IdConstrutorTabela))
                        .Where(d => tabelas.Contains(d.IdConstrutorTabelaMestre)));
            return Json(construtorChaveEstrangeiraModel, JsonRequestBehavior.AllowGet);
        }

    }
}