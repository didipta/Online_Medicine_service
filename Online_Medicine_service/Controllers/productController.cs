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
    
    public class productController : Controller
    {
        Entities Project = new Entities();
        // GET: product
        [HttpGet]
        public ActionResult Productshow(int id)
        {

            var cate = (from C in Project.Categories
                              where C.Id == id
                              select C).FirstOrDefault();
            var config = new MapperConfiguration(
                cfg =>
                {
                    
                    cfg.CreateMap<Category, productcategorymodel>();
                    cfg.CreateMap<Product, productmodel>();
                    

                }

                );
            Mapper mapper = new Mapper(config);
            var data = mapper.Map<productcategorymodel>(cate);

            return View(data);
        }

        public ActionResult Addtocart(int id)
        {
            var Prodruct = (from P in Project.Products
                            where P.Id == id
                            select P).FirstOrDefault();
            var categori = (from C in Project.Categories
                            where C.Id == Prodruct.P_categorie_id
                            select C).FirstOrDefault();
            ViewBag.categories = categori;
            ViewBag.Products = (from P in Project.Products
                                where P.P_categorie_id == categori.Id
                                select P).ToList();

            if (Session["Usernmae"] != null)
            {
                var username= Session["Usernmae"].ToString();
                var useer = (from u in Project.Systemusers
                                 where u.U_username == username
                                 select u).FirstOrDefault();

                ViewBag.useer = useer.U_address;
            }
            else
            {
                ViewBag.useer =" ";
            }
            return View(Prodruct);
        }
    }
}