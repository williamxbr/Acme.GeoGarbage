using System.Web.Mvc;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio
{
    public class RelatorioAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Relatorio";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Relatorio_default",
                "Relatorio/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "Acme.GeoGarbage.UI.MVC.Areas.Relatorio.Controllers" }
            );
        }
    }
}