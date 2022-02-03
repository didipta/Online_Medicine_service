using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Medicine_service.Controllers
{
    public class indexController : Controller
    {
        // GET: index
        public ActionResult Indexpage()
        {
            return View();
        }
        public ActionResult Singinpage()
        {
            return View();
        }
    }
}