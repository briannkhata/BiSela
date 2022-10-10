using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katswiri.Models
{
    class ReceiptDetail
    {
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double SellingPrice { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
        public double TotalCost { get; set; }
    }
}
