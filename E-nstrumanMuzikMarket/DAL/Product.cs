//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> Category_ID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string ProductCode { get; set; }
        public string BrandName { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
