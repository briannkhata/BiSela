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
    
    public partial class BillPayment
    {
        public int Id { get; set; }
        public Nullable<int> SaleId { get; set; }
        public Nullable<int> PaymentTypeId { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
    }
}
