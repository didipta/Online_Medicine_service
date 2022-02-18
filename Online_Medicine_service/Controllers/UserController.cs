using Online_Medicine_service.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Medicine_service.Controllers
{
    public class UserController : Controller
    {
        Entities Project = new Entities();
        // GET: User
        public ActionResult Homepage()
        {
            
            var categories = Project.Categories.ToList();
            ViewBag.categories = categories;
            var product = Project.Products.ToList();
            return View(product);
        }
    }
}