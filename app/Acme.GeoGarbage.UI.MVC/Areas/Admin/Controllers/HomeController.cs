using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acme.GeoGarbage.UI.MVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult AdminViewPartial()
        {
            return PartialView();
        }
    }
}