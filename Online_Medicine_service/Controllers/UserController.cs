using Online_Medicine_service.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Online_Medicine_service.Models.Database.Models;

namespace Online_Medicine_service.Controllers
{
    public class UserController : Controller
    {
        Entities Project = new Entities();
        // GET: User
        public ActionResult Homepage()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Category,categorymodel>();
                    cfg.CreateMap<Product, productmodel>();
                }

                );
            var categorie = Project.Categories.ToList();
            Mapper mapper = new Mapper(config);
            var categories = mapper.Map<List<categorymodel>>(categorie);
            ViewBag.categories = categories;
            var products = Project.Products.ToList();
            var product = mapper.Map<List<productmodel>>(products);
            return View(product);
        }
    }
}