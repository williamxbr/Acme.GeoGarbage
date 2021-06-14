using System.Web.Mvc;

namespace Acme.GeoGarbage.UI.MVC.Areas.Monitoramento
{
    public class MonitoramentoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Monitoramento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Monitoramento_default",
                "Monitoramento/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "Acme.GeoGarbage.UI.MVC.Areas.Monitoramento.Controllers" }
            );
        }
    }
}