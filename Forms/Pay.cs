using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Katswiri.Data;
using Katswiri.Reports;
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
        Pos pos = new Pos();

        public Pay()
        {
            InitializeComponent();
            loadPaymentModes();
        }

        private void dispalyChange()
        {
            if (textBoxTendered.Text != string.Empty)
            {
                lblChange.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", (Convert.ToDouble(textBoxTendered.Text.Trim()) - Convert.ToDouble(lblBill.Text)).ToString(), 2);
            }
            else
            {
                lblChange.Text = string.Empty;
            }
        }

        private void loadPaymentModes()
        {
            using (db = new BEntities())
            {
                lookUpEditPayMode.Properties.DataSource = db.vwPaymentTypes.ToList();
                lookUpEditPayMode.Properties.ValueMember = "PaymentTypeId";
                lookUpEditPayMode.Properties.DisplayMember = "PaymentTypeName";
                lookUpEditPayMode.EditValue = db.PaymentTypes.Where(x => x.PaymentTypeName == "Cash").SingleOrDefault().PaymentTypeId;
                lookUpEditPayMode.Properties.NullText = "Payment Method";

            }
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            using (db = new BEntities())
            {
                var totalBill = db.Carts?.Where(x => x.UserId == 1).Sum(x => x.TotalPrice);
                textBoxTendered.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", totalBill, 2);
                lblBill.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", totalBill, 2);
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
                        SaleId = (int)pos.lookUpEditSaleId.EditValue,
                        DateSold = DateTime.Now,
                        SaleType = (string)pos.lookUpEditSaleType.EditValue,
                        PaymentTypeId = (int)lookUpEditPayMode.EditValue,
                        ShopId = db.Shops.SingleOrDefault().ShopId,
                        SoldBy = LoginInfo.UserId,
                        Customer = (int?)pos.lookUpEditCustomer.EditValue,
                        TaxAmount = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.TaxValue),
                        Bill = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.TotalPrice),
                        SubTotal = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.SellingPrice),
                        Change = Double.Parse(textBoxTendered.Text) - (double)(db.Carts.Where(x => x.UserId == 1).Sum(x => x.TotalPrice)),
                        Tendered = Double.Parse(textBoxTendered.Text),
                        Balance = sale.Balance - sale.Tendered, 
                        Paid = sale.Tendered,
                        Discount = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.Discount),
                    };
                    db.Entry(sale).State = EntityState.Modified;
                    db.SaveChanges();

                    var cart = db.Carts.Where(x => x.UserId == 1).ToList();
                    foreach (var item in cart)
                    {
                        saleDetail = new SaleDetail()
                        {
                            SaleId = (int)pos.lookUpEditSaleId.EditValue,
                            ProductId = (int)item.ProductId,
                            SellingPrice = (double)item.SellingPrice,
                            ShopId = (int)item.ShopId,
                            SoldPrice = (double)item.TotalPrice,
                            Qty = (double)item.Qty,
                            Discount = (double)item.Discount,
                            TaxValue = (double)item.TaxValue,
                            UserId = (int)item.UserId,
                            DateSold = DateTime.Now
                        };
                        db.SaleDetails.Add(saleDetail);
                        db.SaveChanges();
                    }

                    this.Close();
                    pos.clearmyCart();
                    pos.loadCart();

                    //Receipt bill = new Receipt();
                    //ReportPrintTool printTool = new ReportPrintTool(bill));
                    //// Invoke the Print dialog.
                    //printTool.PrintDialog();
                    //// Send the report to the default printer.
                    //printTool.Print();
                    //// Send the report to the specified printer.
                    //printTool.Print("myPrinter");

                    this.Close();
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
            pos.loadCart();            
        }

        private void textBoxTendered_KeyUp(object sender, KeyEventArgs e)
        {
            dispalyChange();
        }
    }
}