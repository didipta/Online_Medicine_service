using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Online_Medicine_service.Models.Database.Models;
using Project.Models.Entities;

namespace Project.Controllers
{
    public class StoreController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            bager();
            Bager();
            Entities db = new Entities();
            var data = db.Ratings.ToList();
            return View(data);
        }
        public ActionResult AddProduct()
        {
            Entities db = new Entities();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                //db insertion
                Entities db = new Entities();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("AddProduct");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            Entities db = new Entities();
            var data1 = (from s in db.Products where s.Id == Id select s).FirstOrDefault();
            return View(data1);
        }
        [HttpPost]
        public ActionResult EditProduct(Product s_Id)
        {
            Entities db = new Entities();
            var datta2 = (from s in db.Products where s.Id == s_Id.Id select s).FirstOrDefault();
            db.Entry(datta2).CurrentValues.SetValues(s_Id); db.SaveChanges();
            return RedirectToAction("AddProduct");
        }
        public ActionResult DeleteProduct(Product p_Id)
        {
            Entities db = new Entities();
            var data2 = (from s in db.Products where s.Id == p_Id.Id select s).FirstOrDefault();
            db.Products.Remove(data2);
            db.SaveChanges();
            return RedirectToAction("AddProduct");
        }
        public ActionResult Profilee()
        {
            Entities db = new Entities();
            var username = Session["Usernmae"].ToString();

            var data = (from u in db.Systemusers
                        where u.U_username == username
                        select u).FirstOrDefault();
            return View(data);
        }
        [HttpGet]
        public ActionResult EditProfile(int Id)
        {
            Entities db = new Entities();
            var dataa2 = (from s in db.Systemusers where s.Id == Id select s).FirstOrDefault();
            return View(dataa2);
        }
        [HttpPost]
        public ActionResult EditProfile(Systemuser s_Id)
        {
            Entities db = new Entities();
            var data2 = (from s in db.Systemusers where s.Id == s_Id.Id select s).FirstOrDefault();
            db.Entry(data2).CurrentValues.SetValues(s_Id); db.SaveChanges();
            return RedirectToAction("Profilee");
        }
        public ActionResult OrderedDetails()
        {
            Entities db = new Entities();
            var orders = db.Orderdetails.ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Orderdetail, OrderDetailsModel>();
                cfg.CreateMap<myorder, myordersModel>();
            }
            );
            var mapper = new Mapper(config);
            var data = mapper.Map<List<OrderDetailsModel>>(orders); return View(data);
        }
        public void bager()
        {
            Entities db = new Entities();
            ViewBag.displayProduct = db.Products.ToList();
            ViewBag.Count = db.Products.Count();
        }
        public void Bager()
        {
            Entities db = new Entities();
            ViewBag.displayProduct = db.returndetelis.ToList();
            ViewBag.Countt = db.returndetelis.Count();
        }
    }
}