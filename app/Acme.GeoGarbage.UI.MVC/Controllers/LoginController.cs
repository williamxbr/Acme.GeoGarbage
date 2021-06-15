using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.Areas.Admin.ViewModels;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioAplicacaoServico _usuarioAplicacaoServico;

        public LoginController(IUsuarioAplicacaoServico usuarioAplicacaoServico)
        {
            _usuarioAplicacaoServico = usuarioAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _usuarioAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: Login
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel usuario)
        {
            var usuarioViewModel =
                Mapper.Map<Usuario, UsuarioViewModel>(_usuarioAplicacaoServico.BuscaPorLoginSenha(usuario.Login,
                    usuario.Senha));
            if (usuarioViewModel != null )
            {
                FormsAuthentication.SetAuthCookie(usuarioViewModel.IdUsuario.ToString(),true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("","Dados de login estão incorreto");
                return View(usuario);
            }
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [HttpPost]
        public ActionResult LoginPartial(UsuarioViewModel usuario)
        {
            var usuarioViewModel =
                Mapper.Map<Usuario, UsuarioViewModel>(_usuarioAplicacaoServico.BuscaPorLoginSenha(usuario.Login,
                    usuario.Senha));
            if (usuarioViewModel != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.IdUsuario.ToString(), true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Dados de login está incorreto");
                return PartialView(usuario);
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult EnviarSenhaviaEmail()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult EnviarSenhaviaEmail(UsuarioViewModel usuario)
        {
            var usuarioViewModel =
                Mapper.Map<Usuario, UsuarioViewModel>(_usuarioAplicacaoServico.BuscaPorEmail(usuario.Email));

            if (usuarioViewModel != null)
            {
                EnviarEmail(usuarioViewModel);
                return RedirectToAction("EmailEnviado", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Não foi encontrado nenhum registro com o e-mail digitado");
                return View(usuario);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public void EnviarEmail(UsuarioViewModel usuario)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress("william@geogarbage.com.br", "RecuperacaoSenha@geogarbage.com.br");
            email.To.Add(new MailAddress(usuario.Email));
            email.Subject = "Recupearação de senhas";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            email.Body = string.Format("Prezado {0}, <br /><br />", usuario.Nome) +
                         string.Format(
                             "Segue a senha de acesso parao site geogarbage.com.br solicitada no dia {0} às {1}h",
                             DateTime.Now.Date, DateTime.Now.Hour) +
                         "<br /><br />Senha: " + usuario.Senha +
                         "<br /><br />Atenciosamente,<br /><br />Geo Garbage";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.geogarbage.com.br";
            smtp.Port = 587;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("jose@geogarbage.com.br", "setembro1854");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(email);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult EmailEnviado()
        {
            return View();
        }


    }
}