//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_Medicine_service.Models.Database.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orderdetail
    {
        public int Id { get; set; }
        public int Order_id { get; set; }
        public int P_id { get; set; }
        public int P_O_quantity { get; set; }
        public string P_tprice { get; set; }
        public string U_username { get; set; }
        public string P_name { get; set; }
        public string status { get; set; }
        public string p_img { get; set; }
    
        public virtual myorder myorder { get; set; }
        public virtual Product Product { get; set; }
    }
}