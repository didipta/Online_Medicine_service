
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Project.Models.Entities
{
    public class myordersModel
    {
        public int Id { get; set; }
        public string Order_id { get; set; }
        public int User_id { get; set; }
        public string U_username { get; set; }
        public string totale_price { get; set; }
        public string Paymanttype { get; set; }
        public string O_status { get; set; }
        public string totale_iteam { get; set; }
    }
}

