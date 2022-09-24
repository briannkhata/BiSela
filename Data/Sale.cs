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
    
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
        }
    
        public int SaleId { get; set; }
        public Nullable<double> Tendered { get; set; }
        public Nullable<double> Bill { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> TaxAmount { get; set; }
        public Nullable<int> Customer { get; set; }
        public Nullable<int> SoldBy { get; set; }
        public Nullable<int> ShopId { get; set; }
        public Nullable<System.DateTime> DateSold { get; set; }
        public Nullable<double> Change { get; set; }
        public string SaleType { get; set; }
        public Nullable<int> Deleted { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public Nullable<int> PaymentTypeId { get; set; }
        public Nullable<double> Paid { get; set; }
        public Nullable<double> Balance { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
