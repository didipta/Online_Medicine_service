using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Medicine_service.Models.Database.Models
{
    public class productcategorymodel : categorymodel
    {
        public List<productmodel> Products { get; set; }

        public productcategorymodel()
        {
            Products = new List<productmodel>();
        }

    }
}