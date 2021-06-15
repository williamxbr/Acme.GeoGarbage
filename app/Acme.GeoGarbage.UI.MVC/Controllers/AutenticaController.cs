using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.Filtros;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    [ApiAuthenticationFilter]
    public class AutenticaController : ApiController
    {
        private readonly ITokenAplicacaoServico _tokenAplicacaoServico;
        private readonly IUsuarioAplicacaoServico _usuarioAplicacaoServico;

        public AutenticaController(ITokenAplicacaoServico tokenAplicacaoServico, IUsuarioAplicacaoServico usuarioAplicacaoServico)
        {
            _tokenAplicacaoServico = tokenAplicacaoServico;
            _usuarioAplicacaoServico = usuarioAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tokenAplicacaoServico.Dispose();
                _usuarioAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public HttpResponseMessage Get_AutenticarUsuario()
        {
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    Guid userId = basicAuthenticationIdentity.UserId;
                    return GetAuthToken(userId);
                }
            }
            return null;
        }

        private HttpResponseMessage GetAuthToken(Guid userId)
        {
            Token token = _tokenAplicacaoServico.GenerateToken(userId);
            Usuario user = _usuarioAplicacaoServico.BuscaId(userId);
            var response = Request.CreateResponse<Usuario>(HttpStatusCode.OK, user);
            response.Headers.Add("Token", token.AutorizeToken.ToString());
            //response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("TokenExpiry", "240");
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }

    }
}
