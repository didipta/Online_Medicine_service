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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<addtocart> addtocarts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<deliverinfo> deliverinfoes { get; set; }
        public virtual DbSet<myorder> myorders { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<returndeteli> returndetelis { get; set; }
        public virtual DbSet<Returnproduct> Returnproducts { get; set; }
        public virtual DbSet<Systemuser> Systemusers { get; set; }
    }
}
