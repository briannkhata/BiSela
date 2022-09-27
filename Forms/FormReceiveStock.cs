using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Katswiri.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katswiri.Forms
{
    public partial class FormReceiveStock : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        ReceivingCart receivingCart = new ReceivingCart();
        ReceivingDetail receivingDetail;
        Receiving receiving;
        Stock stock; 
        public FormReceiveStock()
        {
            InitializeComponent();
            loadCart();
            autoCompleteSearch();

        }
        public void loadCart()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwReceivingCarts.ToList();
                gridView1.Columns["UserId"].Visible = false;
                gridView1.Columns["Id"].Visible = false;
                gridView1.Columns["ProductId"].Visible = false;
                gridView1.Columns.ColumnByFieldName("Description").OptionsColumn.ReadOnly = true;
                gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.ReadOnly = true;

            }
        }

        private void autoCompleteSearch()
        {
            using (db = new BEntities())
            {
                AutoCompleteStringCollection autoText = new AutoCompleteStringCollection();
                foreach (Product product in db.Products.ToList())
                {
                    autoText.Add(product.ProductCode);
                }
                textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxSearch.AutoCompleteCustomSource = autoText;
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwReceivingCart)gridView1.GetRow(selectedRows[0]));
                using (var db = new BEntities())
                {
                    var receivingCart = db.ReceivingCarts.Find(row.Id);
                    db.ReceivingCarts.Remove(receivingCart);
                    db.SaveChanges();
                }
                loadCart();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void datedateTimePicker_textchanged(object sender, EventArgs e)
        {
            //datagridview1.currentCell.Value = datetimepicker.text.Tostring();
        }

        public void dateTimePicker_closeup(object sender, EventArgs e)
        {
            //datetimepicker.visible = false;
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
                {
                    using (var db = new BEntities())
                    {
                        var product = db.Products.Where(p => p.ProductCode == textBoxSearch.Text).FirstOrDefault();
                        var exists = db.ReceivingCarts.Where(x => x.ProductId == product.ProductId).FirstOrDefault();

                        if (exists != null)
                        {
                            exists.Qty += 1;
                            exists.TotalPrice = (receivingCart.SellingPrice * exists.Qty);
                            db.Entry(exists).State = EntityState.Modified;
                        }
                        else
                        {
                            receivingCart.ProductId = product.ProductId;
                            receivingCart.SellingPrice = 00.00;
                            receivingCart.UserId = LoginInfo.UserId;
                            receivingCart.OrderPrice = 0.00;
                            receivingCart.ExpiryDate = DateTime.Now;
                            receivingCart.Qty = 1;
                            receivingCart.TotalPrice = (receivingCart.SellingPrice * receivingCart.Qty);
                            db.ReceivingCarts.Add(receivingCart);
                        }
                        db.SaveChanges();
                    }
                    loadCart();
                    textBoxSearch.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearReceivingCart()
        {
            using(db = new BEntities())
            {
                //db.Database.ExecuteSqlRaw("TRUNCATE TABLE ReceivingCarts");
                var list = db.ReceivingCarts.ToList();
                foreach (var rm in list)
                {
                    db.ReceivingCarts.Remove(rm);
                    db.SaveChanges();
                }
            }
        }


        public void refreshCart()
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwReceivingCart)gridView1.GetRow(selectedRows[0]));
                using (var db = new BEntities())
                {
                    if (row.Id != -1)
                    {
                        receivingCart.Id = row.Id;
                        receivingCart.ProductId = row.ProductId;
                        receivingCart.SellingPrice = row.SellingPrice;
                        receivingCart.Qty = row.Qty;
                        receivingCart.OrderPrice = row.OrderPrice;
                        receivingCart.TotalPrice = (row.SellingPrice * row.Qty);
                        receivingCart.ExpiryDate = row.ExpiryDate;
                        db.Entry(receivingCart).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    loadCart();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            refreshCart();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using(db = new BEntities())
                {
                    receiving = new Receiving()
                    {
                        ReceivingDate = DateTime.Parse(dateTimePickerReceivingDate.Text),
                        TotalBill = (double)db.ReceivingCarts.Sum(x => x.TotalPrice),
                        SubTotal = (double)db.ReceivingCarts.Sum(x => x.SellingPrice),
                        Supplier = textBoxSupplier.Text,
                        UserId = LoginInfo.UserId,
                        PurchasingOrder = textBoxPurchasingOrder.Text,
                        DeliveryDate = DateTime.Parse(dateTimePickerDeliveryDate.Text),
                        DeliveryNote = textBoxDeliveryNote.Text
                    };
                    int ReceivingId = receiving.Id;

                    var cart = db.ReceivingCarts.ToList();
                    foreach (var item in cart)
                    {
                        receivingDetail = new ReceivingDetail()
                        {
                            ReceivingId = ReceivingId,
                            ProductId = (int)item.ProductId,
                            SellingPrice = (double)item.SellingPrice,
                            OrderPrice = (double)item.OrderPrice,
                            TotalPrice = (double)item.TotalPrice,
                            Qty = (double)item.Qty,
                            UserId = (int)item.UserId,
                            ExpiryDate = item.ExpiryDate
                        };
                        db.ReceivingDetails.Add(receivingDetail);
                        db.SaveChanges();

                        stock = new Stock()
                        {
                            ProductId = item.ProductId,
                            Stores = item.Qty,
                            ExpiryDate = item.ExpiryDate,
                            SellingPrice = item.SellingPrice,
                        };
                        db.Stocks.Add(stock);
                        db.SaveChanges();
                    }
                    clearReceivingCart();
                    loadCart();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            clearReceivingCart();
            loadCart();
        }
    }
}