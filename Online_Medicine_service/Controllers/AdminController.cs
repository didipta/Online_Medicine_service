
using Online_Medicine_service.Models.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult home()
        {

            TotalProduct();

            return View();





        }
        /*public ActionResult totalProduct()
        {
        /* Entities db = new Entities();
        var totalList = (from s in db.Systemusers
        where s.Usertype.Equals("3")
        select s).Count();
        return View(totalList);



        totalProduct();
        return View();
        }*/



        public void TotalProduct()
        {
            Entities db = new Entities();
            ViewBag.Count = db.Products.Count();
            ViewBag.Countp = db.Systemusers.Count();
            ViewBag.Countc = db.Categories.Count();
            ViewBag.Countr = db.Ratings.Count();
            ViewBag.Countrp = db.Returnproducts.Count();

        }



        [HttpGet]
        public ActionResult login()
        {
            return View();
        }



        public ActionResult Profile(Systemuser systemuser)
        {
            Entities db = new Entities();
            var username = Session["Usernmae"].ToString();

            var data = (from u in db.Systemusers
                        where u.U_username == username
                        select u).FirstOrDefault();
            return View(data);

        }
     
        public ActionResult ProductList()
        {
            using (Entities db = new Entities())
            {
                return View(db.Products.ToList());
            }
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            return RedirectToAction("ProductList");
        }
        public ActionResult ReturnProduct()
        {
            return View();
        }
        public ActionResult ProductTable()
        {
            using (Entities db = new Entities())
            {
                return View(db.Products.ToList());
            }
        }


        [HttpPost]
        public ActionResult EditProduct()
        {
            var Id = Int32.Parse(Request["Id"]);
            Entities db = new Entities();
            var data1 = (from s in db.Products where s.Id == Id select s).FirstOrDefault();
            return View(data1);
        }
        [HttpPost]
        public ActionResult EditProducts(Product s_Id)
        {
            Entities db = new Entities();
            var datta2 = (from s in db.Products where s.Id == s_Id.Id select s).FirstOrDefault();
            db.Entry(datta2).CurrentValues.SetValues(s_Id); db.SaveChanges();
            return RedirectToAction("ProductTable");
        }
        [HttpPost]
        public ActionResult Delete(Product p)
        {
            Entities db = new Entities();
            var data = (from Product in db.Products
                        where Product.Id == p.Id
                        select Product).FirstOrDefault(); db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ProductTable");
        }

        public ActionResult user() //search
        {
            using (Entities db = new Entities())
            {
                return View(db.Systemusers.ToList());
            }
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View(new Systemuser());
        }
        [HttpPost]
        public ActionResult AddUser(Systemuser systemuser)
        {

          
            return RedirectToAction("user");
        }

        [HttpGet]
        public ActionResult SellerList()
        {
            Entities db = new Entities();
            var SellerList = (from s in db.Systemusers
                              where s.Usertype.Equals("Staff")
                              select s).ToList();
            return View(SellerList);
        }



        [HttpGet]
        public ActionResult DeliveryManList()
        {
            Entities db = new Entities();
            var DeliveryList = (from s in db.Systemusers
                                where s.Usertype.Equals("4")
                                select s).ToList();
            return View(DeliveryList);
        }




        [HttpGet]
        public ActionResult CustomerList()
        {
            Entities db = new Entities();
            var CustomerList = (from s in db.Systemusers
                                where s.Usertype.Equals("Customer")
                                select s).ToList();
            return View(CustomerList);
        }




    }
}










      
          