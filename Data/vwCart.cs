//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Katswiri.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwCart
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Nullable<double> SellingPrice { get; set; }
        public Nullable<double> Qty { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public int CartId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<double> TaxValue { get; set; }
    }
}
