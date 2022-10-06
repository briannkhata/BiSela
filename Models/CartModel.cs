using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katswiri.Models
{
    class CartModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double SellingPrice { get; set; }
        public double Qty { get; set; }
        public double Discount { get; set; }
        public double TaxValue { get; set; }
        public double TotalPrice { get; set; }
        public int CartId { get; set; }
        public int ShopId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Customer { get; set; }
        

    }
}
