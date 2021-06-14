using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.Areas.Admin.ViewModels;

namespace Acme.GeoGarbage.UI.MVC.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioAplicacaoServico _usuarioAplicacaoServico;

        public UsuarioController(IUsuarioAplicacaoServico usuarioAplicacaoServico)
        {
            _usuarioAplicacaoServico = usuarioAplicacaoServico;
        }


        // GET: Admin/Usuario
        public ActionResult Index()
        {
            var usuarioViewModel =
                Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioAplicacaoServico.BuscaTodos());
            return View(usuarioViewModel);
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult IndexPartial()
        {
            var usuarioViewModel =
                Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioAplicacaoServico.BuscaTodos());
            return PartialView(usuarioViewModel);
        }


        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDominio = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                usuarioDominio.IdUsuario = Guid.NewGuid();
                _usuarioAplicacaoServico.Adiciona(usuarioDominio);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }
    }
}