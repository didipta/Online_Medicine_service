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

            //Ratind part

            var Rating = (from C in Project.Ratings
                            where C.Product_id == id
                            select C).ToList();
            ViewBag.Ratings = Rating;
            double x = 0;
            foreach (var item in Rating)
            {
                x += item.rating1;
            }

            double y = (x / Rating.Count());
            ViewBag.totalrat = y;



            //////////////////////////
            ///

            ///categories parts///
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
                ViewBag.username = username;



                var Ratingss = (from C in Project.Ratings
                              where C.Product_id == id && C.username== username
                                select C).FirstOrDefault();

                if (Ratingss==null)
                {
                    ViewBag.rates ="";
                }
                else
                {
                    string a= (Ratingss.rating1).ToString();
                    ViewBag.rates = a;
                }
                
            }
            else
            {
                ViewBag.useer =" ";
                ViewBag.rating = " ";
              

            }
            return View(Prodruct);
        }
        [Authorize]
        public ActionResult reviwerating()
        {
            Rating raingss = new Rating
            {
                Product_id = Int32.Parse(Request["product_id"]),
                Review = Request["review"],
                rating1 = Convert.ToDouble(Request["rating"]),
                username = Session["Usernmae"].ToString(),


            };
            Project.Ratings.Add(raingss);
            Project.SaveChanges();
            return RedirectToAction("Addtocart", new{ id=Request["product_id"] });
        }
        }
}