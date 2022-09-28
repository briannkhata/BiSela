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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
            this.Carts = new HashSet<Cart>();
            this.Stocks = new HashSet<Stock>();
        }
    
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public int UnitId { get; set; }
        public int CategoryId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> TaxTypeId { get; set; }
        public Nullable<double> ReOrderLevel { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Deleted { get; set; }
        public string TaxStatus { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual TaxType TaxType { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
