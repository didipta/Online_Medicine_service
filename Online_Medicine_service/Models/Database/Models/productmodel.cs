using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Medicine_service.Models.Database.Models
{
    public class productmodel
    {
        public int Id { get; set; }
        public string P_name { get; set; }
        public string P_price { get; set; }
        public int P_categorie_id { get; set; }
        public int P_quantity { get; set; }
        public string P_details { get; set; }
        public string P_img { get; set; }

       
    }
}