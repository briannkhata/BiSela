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
    
    public partial class Receiving
    {
        public int Id { get; set; }
        public double TotalBill { get; set; }
        public double SubTotal { get; set; }
        public System.DateTime ReceivingDate { get; set; }
        public string Supplier { get; set; }
        public int UserId { get; set; }
        public string PurchasingOrder { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryNote { get; set; }
    }
}
