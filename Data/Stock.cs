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
    
    public partial class Stock
    {
        public int StockId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> ShopId { get; set; }
        public Nullable<double> ShopQty { get; set; }
        public Nullable<double> StoresQty { get; set; }
        public Nullable<double> KitchenQty { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<double> SellingPrice { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string Comment { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
