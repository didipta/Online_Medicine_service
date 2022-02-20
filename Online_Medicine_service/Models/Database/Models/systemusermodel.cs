using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Medicine_service.Models.Database.Models
{
    public class systemusermodel
    {
        public int Id { get; set; }
        public string U_name { get; set; }
        public string U_phone { get; set; }
        public string U_address { get; set; }
        public string U_username { get; set; }
        public string U_email { get; set; }
        public string U_password { get; set; }
        public string Usertype { get; set; }
        public string U_profileimg { get; set; }
        public string pharmacyname { get; set; }
    }
}