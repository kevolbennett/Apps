//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public long Id { get; set; }
        public string vinNumber { get; set; }
        public long make { get; set; }
        public long model { get; set; }
        public string engineType { get; set; }
        public string source { get; set; }
        public System.DateTime arrivalDate { get; set; }
        public string colour { get; set; }
        public decimal price { get; set; }
        public string year { get; set; }
    
        public virtual Make Make1 { get; set; }
        public virtual Model Model1 { get; set; }
    }
}
