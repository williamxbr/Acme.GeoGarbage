using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Relatorio/Home
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