using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Medicine_service.Models.Database.Models
{
    public class systemuserordermodel : systemusermodel
    {
        public List<myordermodel> orders { get; set; }

        public systemuserordermodel()
        {
            orders = new List<myordermodel>();
        }
    }
}