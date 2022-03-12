using Online_Medicine_service.Models.Database;
using Online_Medicine_service.Models.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Online_Medicine_service.Controllers
{
    public class indexController : Controller
    {
        
        // GET: index
        public ActionResult Indexpage()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Singinpage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Singinpage(userlogin sm)
        {

            if (ModelState.IsValid)
            {
                Entities Project = new Entities();
                var data = (from u in Project.Systemusers
                            where u.U_username.Equals(sm.user_name) &&
                            u.U_password.Equals(sm.password_s)
                            select u).FirstOrDefault();
                
                if (data != null)
                {
                    if (data.Usertype== "Customer")
                    {
                        
                        Session["Usernmae"] = data.U_username;
                        Session["Usertype"] = data.Usertype;
                        return RedirectToAction("Homepage", "User");
                    }
                    else if (data.Usertype == "Admin")
                    {
                        
                        Session["Usernmae"] = data.U_username;
                        Session["Usertype"] = data.Usertype;
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else if (data.Usertype == "Staff")
                    {
                       
                        Session["Usernmae"] = data.U_username;
                        Session["Usertype"] = data.Usertype;
                        return RedirectToAction("Index", "Store");
                    }

                }

            }
            return View();
        }


        [HttpGet]
        public ActionResult Singuppage()
        {
            return View();
        }
  
        [HttpPost]
        public ActionResult Singuppage(systemusermodel s)
        {
            if (ModelState.IsValid)
            {
                Entities Project = new Entities();
                Systemuser ss = new Systemuser
                {
                    U_name = s.Firstname +" "+ s.LastName,
                    U_address = s.address,
                    U_email = s.email,
                    U_username = s.username,
                    U_profileimg = "pro.png",
                    U_phone = s.phone,
                    pharmacyname = "Null",
                    Usertype = "Customer",
                    U_password = s.password
                };
                Project.Systemusers.Add(ss);
                Project.SaveChanges();
                return RedirectToAction("Singinpage");
            }
            return View(s);
        }


         [HttpGet]
        public ActionResult Logout()
        {
            if (Session["Usernmae"] != null)
            {
                Session["Usernmae"] = null;
            }
            return RedirectToAction("Singinpage");
        }

        }
}