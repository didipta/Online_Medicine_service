using Online_Medicine_service.Models.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Medicine_service.Controllers
{
    public class OrdersController : Controller
    {
        [Authorize]
        // GET: Orders
        public ActionResult Addtocart()
        {
            var user = Session["Usernmae"].ToString();
            Entities Project = new Entities();
            var Prodructs = (from P in Project.addtocarts
                             where P.U_username == user
                             select P).ToList();
            ViewBag.count = Prodructs.Count();
            return View(Prodructs);
        }
        [Authorize]
        public ActionResult Addtocartadd()
        {
            Entities Project = new Entities();
            var pid = Int32.Parse(Request["productid"]);
            var pquantity = Int32.Parse(Request["Productquantity"]);

            var Prodructs = (from P in Project.Products
                             where P.Id == pid
                             select P).FirstOrDefault();
            addtocart ad = new addtocart
            {
                p_img = Prodructs.P_img,
                P_name = Prodructs.P_name,
                P_O_quantity = pquantity,
                P_id = Prodructs.Id,
                P_tprice = (Int32.Parse(Prodructs.P_price) * pquantity).ToString(),
                U_username = Session["Usernmae"].ToString()

            };
            Project.addtocarts.Add(ad);
            Project.SaveChanges();

            return RedirectToAction("Addtocart");
        }

        public ActionResult cartitemdelete(int id)
        {
            Entities Project = new Entities();
            var Prodructs = (from P in Project.addtocarts
                             where P.Id == id
                             select P).FirstOrDefault();

            Project.addtocarts.Remove(Prodructs);
            Project.SaveChanges();
            return RedirectToAction("Addtocart");
        }
    }
}