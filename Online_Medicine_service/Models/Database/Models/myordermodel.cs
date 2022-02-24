using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Medicine_service.Models.Database.Models
{
    public class myordermodel
    {
        public int Id { get; set; }
        public string Oder_id { get; set; }
        public int User_id { get; set; }
        public string U_username { get; set; }
        public string totale_price { get; set; }
        public string Paymanttype { get; set; }
        public string O_status { get; set; }
        public string totale_iteam { get; set; }
    }
}