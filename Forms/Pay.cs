using DevExpress.XtraEditors;
using Katswiri.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katswiri.Forms
{
    public partial class Pay : DevExpress.XtraEditors.XtraForm
    {
        BEntities db;
        Cart cart = new Cart();
        Sale sale;
        SaleDetail saleDetail;
        public Pos pos;

        public Pay()
        {
            InitializeComponent();
            pos = new Pos();
            loadPaymentModes();
        }

        private void loadPaymentModes()
        {
            using (db = new BEntities())
            {
                lookUpEditPayMode.Properties.DataSource = db.vwPaymentTypes.ToList();
                lookUpEditPayMode.Properties.ValueMember = "PaymentTypeId";
                lookUpEditPayMode.Properties.DisplayMember = "PaymentTypeName";
            }
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            using (db = new BEntities())
            {
                var totalBill = db.Carts?.Where(x => x.UserId == 1).Sum(x => x.TotalPrice);
                textBoxTendered.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", totalBill, 2);
            }
        }

        private void btnFinishSale_Click(object sender, EventArgs e)
        {
            try
            {
                using (db = new BEntities())
                {
                    sale = new Sale()
                    {
                        DateSold = DateTime.Now,
                        //SaleTypeId = (int)lookUpEditPayMode.EditValue,
                        ShopId = 1,
                        SoldBy = 1,
                        SoldTo = 1,
                        TaxAmount = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.TaxValue),
                        TotalBill = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.TotalPrice),
                        TotalChange = Double.Parse(textBoxTendered.Text) - (double)(db.Carts.Where(x => x.UserId == 1).Sum(x => x.TotalPrice)),
                        TotalTendered = Double.Parse(textBoxTendered.Text),
                        DiscountAmount = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.DiscountAmount),
                        DiscountPercent = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.DiscountPercent),
                    };

                    db.Sales.Add(sale);
                    db.SaveChanges();
                    var saleId = sale.SaleId;//get recently inserted id

                    var cart = db.Carts.Where(x => x.UserId == 1).ToList();
                    foreach (var item in cart)
                    {
                        saleDetail = new SaleDetail()
                        {
                            SaleId = saleId,
                            ProductId = (int)item.ProductId,
                            SellingPrice = (double)item.SellingPrice,
                            ShopId = (int)item.ShopId,
                            SoldPrice = (double)item.TotalPrice,
                            Qty = (double)item.Qty,
                            DiscountAmount = (double)item.DiscountAmount,
                            DiscountPercent = (double)item.DiscountPercent,
                            TaxValue = (double)item.TaxValue,
                            UserId = (int)item.UserId,
                            DateSold = DateTime.Now
                        };
                        db.SaleDetails.Add(saleDetail);
                        db.SaveChanges();
                    }

                    this.Close();
                    pos.clearmyCart();
                    pos.clearGrid();
                    pos.loadCart();



                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pay_FormClosing(object sender, FormClosingEventArgs e)
        {
            pos.clearmyCart();
            pos.clearGrid();
            pos.loadCart();            
        }
    }
}