//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_Medicine_service.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rating
    {
        public int id { get; set; }
        public int rating1 { get; set; }
        public string Review { get; set; }
        public int Product_id { get; set; }
        public string username { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
