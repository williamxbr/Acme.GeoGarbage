using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Acme.GeoGarbage.UI.MVC.Filtros
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class FiltroAutenticacaoGenerico : AuthorizationFilterAttribute
    {
        public FiltroAutenticacaoGenerico()
        {
        }

        private readonly bool _estaAtivo = true;

        public FiltroAutenticacaoGenerico(bool estaAtivo)
        {
            _estaAtivo = estaAtivo;
        }

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (!_estaAtivo) return;

            var identidade = FetchAuthHeader(filterContext);

            if (identidade == null)
            {
                ChallengeAuthRequest(filterContext);
                return;
            }

            var genericPrincipal = new GenericPrincipal(identidade, null);
            Thread.CurrentPrincipal = genericPrincipal;

            if (!OnAuthorizeUser(identidade.Name, identidade.Password, filterContext))
            {
                ChallengeAuthRequest(filterContext);
                return;
            }
            base.OnAuthorization(filterContext);
        }

        protected virtual bool OnAuthorizeUser(string user, string pass, HttpActionContext filterContext)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return false;
            return true;
        }

        protected virtual BasicAuthenticationIdentity FetchAuthHeader(HttpActionContext filterContext)
        {
            string authHeaderValue = null;
            var authRequest = filterContext.Request.Headers.Authorization;
            if (authRequest != null && !String.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
                authHeaderValue = authRequest.Parameter;
            if (string.IsNullOrEmpty(authHeaderValue))
                return null;
            authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue));
            var credentials = authHeaderValue.Split(':');
            return credentials.Length < 2 ? null : new BasicAuthenticationIdentity(credentials[0], credentials[1]);
        }

        private static void ChallengeAuthRequest(HttpActionContext filterContext)
        {
            var dnsHost = filterContext.Request.RequestUri.DnsSafeHost;
            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            filterContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", dnsHost));
        }
    }
}