using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acme.GeoGarbage.UI.MVC.Areas.Monitoramento.Controllers
{
    public class HomeController : Controller
    {
        // GET: Monitoramento/Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult IndexPartial()
        {
            return PartialView();
        }

    }
}