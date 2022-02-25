using Online_Medicine_service.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Online_Medicine_service.Models.Database.Models;
using System.IO;
using Online_Medicine_service.Models;

namespace Online_Medicine_service.Controllers
{
    public class UserController : Controller
    {
        Entities Project = new Entities();
        // GET: User
       // [Authorize]
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
            if (Session["Usernmae"]!= null)
            {
                ViewBag.username = Session["Usernmae"].ToString();
            }
            else
            {
                ViewBag.username = " ";
            }
           
            return View(product);
        }
        [HttpGet]
        [Authorize]
        public ActionResult Profilepage()
        {

            if (Session["Usernmae"] != null)
            {
                var username = Session["Usernmae"].ToString();
                var useer = (from u in Project.Systemusers
                             where u.U_username == username
                             select u).FirstOrDefault();

                return View(useer);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Profileimg()
        {
            if (Session["Usernmae"] != null)
            {
                var username = Session["Usernmae"].ToString();
                var useer = (from u in Project.Systemusers
                             where u.U_username == username
                             select u).FirstOrDefault();

                useer.U_profileimg = Request["Imgfile"];
                Project.Entry(useer).CurrentValues.SetValues(useer);
                Project.SaveChanges();
                return RedirectToAction("Profilepage");

            }
            return View();
        }

    }
}