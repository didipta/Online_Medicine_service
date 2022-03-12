
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Medicine_service.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class customeraccess :AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var auth = false;
            if (httpContext.Session["Usernmae"] != null)
            {
                auth = true;
            }
            if (auth && httpContext.Session["Usertype"].Equals("Customer"))
            {
                return true;
            }
            return false;
        }

       /* protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/index/Singinpage");
        }*/
    }
}