using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace Acme.GeoGarbage.UI.MVC.Filtros
{
    public class ApiAuthenticationFilter : FiltroAutenticacaoGenerico
    {
        public ApiAuthenticationFilter()
        {
        }

        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }

        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var provider = actionContext.ControllerContext.Configuration
                               .DependencyResolver.GetService(typeof(IUsuarioAplicacaoServico)) as IUsuarioAplicacaoServico;
            if (provider != null)
            {
                var user = provider.BuscaPorLoginSenha(username, password);
                if (user != null)
                {
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                        basicAuthenticationIdentity.UserId = user.IdUsuario;
                    return true;
                }
            }
            return false;
        }

    }
}