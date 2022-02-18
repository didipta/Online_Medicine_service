using Online_Medicine_service.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Medicine_service.Controllers
{
    
    public class productController : Controller
    {
        Entities Project = new Entities();
        // GET: product
        [HttpGet]
        public ActionResult Productshow(int id)
        {

            var Prodruct = (from P in Project.Products
                             where P.P_categorie_id == id
                             select P).ToList();
            ViewBag.categories= (from C in Project.Categories
                                 where C.Id == id
                                 select C).FirstOrDefault();
            return View(Prodruct);
        }

        public ActionResult Addtocart(int id)
        {
            var Prodruct = (from P in Project.Products
                            where P.Id == id
                            select P).FirstOrDefault();
           var categori  = (from C in Project.Categories
                                  where C.Id == Prodruct.P_categorie_id
                                  select C).FirstOrDefault();
            ViewBag.categories = categori;
            ViewBag.Products = (from P in Project.Products
                                where P.P_categorie_id == categori.Id
                                select P).ToList();
            return View(Prodruct);
        }
    }
}