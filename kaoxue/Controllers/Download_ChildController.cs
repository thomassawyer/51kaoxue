using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kaoxue.Controllers
{
    public class Download_ChildController : Controller
    {
        //
        // GET: /Download_Child/

        public ActionResult Index()
        {
            string param = Request["myTitle"];
            ViewBag.title = param;

            return View();
        }

    }
}
