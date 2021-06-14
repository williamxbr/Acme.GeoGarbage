﻿using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace Acme.GeoGarbage.UI.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Acme.GeoGarbage.UI.MVC.Controllers" }
            );
        }
    }
}
