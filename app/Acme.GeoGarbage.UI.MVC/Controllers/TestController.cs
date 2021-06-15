using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class TestController : ApiController
    {
        public IEnumerable Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
