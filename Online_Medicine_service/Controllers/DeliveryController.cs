using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using Online_Medicine_service.Models.Database.Models;
using Project.Models.Entities;
using Prroject.Models.Entities;

namespace Prroject.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Deliverinfo()
        {
            Entities db = new Entities();
            var orders = db.deliverinfoes.ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<deliverinfo, deliverinfoModel>();
                cfg.CreateMap<myorder, myordersModel>();
            }
            );
            var mapper = new Mapper(config);
            var data = mapper.Map<List<deliverinfoModel>>(orders);






            return View(data);



        }
        public ActionResult Dashboard()
        {
            Entities db = new Entities();
            var data = db.myorders.ToList();
            return View(data);
        }


        public ActionResult Process(int id)
        {
            Entities db = new Entities();
            var order = (from o in db.myorders where o.Id == id select o).FirstOrDefault();

            order.O_status = "Delivered the product";
            db.Entry(order).CurrentValues.SetValues(order);
            db.SaveChanges();



            return RedirectToAction("Dashboard");
        }
        public ActionResult Cancel(int id)
        {
            Entities db = new Entities();
            var order = (from o in db.myorders where o.Id == id select o).FirstOrDefault();

            order.O_status = "Canceled";
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        public ActionResult Profilee()
        {
            Entities db = new Entities();
            var username = Session["Usernmae"].ToString();
            var data = (from u in db.Systemusers where u.U_username == username select u).FirstOrDefault();
            return View(data);
        }




    }




}