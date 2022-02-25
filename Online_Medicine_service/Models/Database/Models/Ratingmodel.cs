using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Medicine_service.Models.Database.Models
{
    public class Ratingmodel
    {
        public int id { get; set; }
        public int rating1 { get; set; }
        public string Review { get; set; }
        public int Product_id { get; set; }
        public string username { get; set; }
    }
}