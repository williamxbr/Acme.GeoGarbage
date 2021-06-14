using System.Web.Mvc;

namespace Acme.GeoGarbage.UI.MVC.Roles
{
    public class Filtro : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult && filterContext.HttpContext.Request.IsAuthenticated)
                filterContext.HttpContext.Response.Redirect("/Login/AcessoNegado");
        }
    }
}