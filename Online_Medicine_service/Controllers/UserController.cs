using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Medicine_service.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Homepage()
        {
            return View();
        }
    }
}