using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _construtorTabelaAplicacaoServico.Dispose();
                _construtorCampoAplicacaoServico.Dispose();
                _construtorChaveEstrangeiraAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: Relatorio/Construtor
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult ConstrutorViewPartial()
        {
            return PartialView();
        }

        public JsonResult BuscaTabelas()
        {            
            var construtorTabelasViewModel =
               Mapper.Map<IEnumerable<ConstrutorTabela>, IEnumerable<ConstrutorTabelaViewModel>>(_construtorTabelaAplicacaoServico.BuscaTodos().OrderBy(p => p.Nome));
            return Json(construtorTabelasViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscaCampos(List<Guid> tabelas)
        {
            var construtorCampoViewModel =
                Mapper.Map<IEnumerable<ConstrutorCampo>, IEnumerable<ConstrutorCampoViewModel>>(
                    _construtorCampoAplicacaoServico
                        .BuscaTodos()
                        .Where(d => tabelas.Contains(d.IdConstrutorTabela))
                        .Where(d => d.Selecionavel));

            foreach (var id in construtorCampoViewModel)
            {
                id.ConstrutorTabela =
                    Mapper.Map<ConstrutorTabela, ConstrutorTabelaViewModel>(
                        _construtorTabelaAplicacaoServico.BuscaId(id.IdConstrutorTabela));
            }

            return Json(construtorCampoViewModel.OrderBy(p => p.ConstrutorTabela.Nome).ThenBy(p => p.Nome), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscaRelacionamentos(List<Guid> tabelas)
        {
            if (tabelas != null)
            {
                var construtorChaveEstrangeiraModel = Mapper
                    .Map<IEnumerable<ConstrutorChaveEstrangeira>, IEnumerable<ConstrutorChaveEstrangeiraViewModel>>(
                        _construtorChaveEstrangeiraAplicacaoServico
                            .BuscaTodos()
                            .Where(d => tabelas.Contains(d.IdConstrutorTabela))
                            .Where(d => tabelas.Contains(d.IdConstrutorTabelaMestre))).OrderBy(p => p.IdConstrutorTabelaMestre);

                foreach (var id in construtorChaveEstrangeiraModel)
                {

                    id.ConstrutorTabela =
                        Mapper.Map<ConstrutorTabela, ConstrutorTabelaViewModel>(
                            _construtorTabelaAplicacaoServico.BuscaId(id.IdConstrutorTabela));

                    id.ConstrutorTabelaMestre =
                        Mapper.Map<ConstrutorTabela, ConstrutorTabelaViewModel>(
                            _construtorTabelaAplicacaoServico.BuscaId(id.IdConstrutorTabelaMestre));

                    id.ConstrutorCampo =
                        Mapper.Map<ConstrutorCampo, ConstrutorCampoViewModel>(
                            _construtorCampoAplicacaoServico.BuscaId(id.IdConstrutorCampo));

                    id.ConstrutorCampoMestre =
                        Mapper.Map<ConstrutorCampo, ConstrutorCampoViewModel>(
                            _construtorCampoAplicacaoServico.BuscaId(id.IdConstrutorCampoMestre));
                }

                return Json(construtorChaveEstrangeiraModel, JsonRequestBehavior.AllowGet);

            }
            return null;
        }

    }
}