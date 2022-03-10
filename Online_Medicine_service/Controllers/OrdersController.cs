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

        public ActionResult Payment()
        {
            var username = Session["Usernmae"].ToString();
            Entities Project = new Entities();
            var uid = (from P in Project.Systemusers
                             where P.U_username==username
                       select P).FirstOrDefault();
            var cartitem = (from c in Project.addtocarts
                       where c.U_username == username
                       select c).ToList();

            myorder order = new myorder();
            order.Oder_id = Request["orderid"];
            order.totale_price = Request["totaleprice"];
            order.Paymanttype = Request["Paymenttype"];
            order.U_username = username;
            order.User_id =uid.Id;
            order.O_status= "Your Order is processing";
            order.totale_iteam = Request["totalorder"];
            Project.myorders.Add(order);
            Project.SaveChanges();
            foreach (var item in cartitem)
            {
                Orderdetail detail = new Orderdetail();
                var productid = (from P in Project.Products
                           where P.Id == item.P_id
                           select P).FirstOrDefault();
                productid.P_quantity =(productid.P_quantity - item.P_O_quantity);
                Project.Entry(productid).CurrentValues.SetValues(productid);
                detail.Order_id = order.Id;
                detail.P_id = item.P_id;
                detail.p_img = item.p_img;
                detail.P_tprice = item.P_tprice;
                detail.status = "Product id ordered";
                detail.U_username = item.U_username;
                detail.P_name = item.P_name;
                detail.P_O_quantity = item.P_O_quantity;
                Project.Orderdetails.Add(detail);
                Project.addtocarts.Remove(item);
                Project.SaveChanges();

            }


            return RedirectToAction("Addtocart");
        }
    }
}