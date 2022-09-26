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
            //if(e.ColumnIndex == 2)
            //{
            //    DateTimePicker dateTimePicker = new DateTimePicker();
            //    gridControl1.Contorls.Add(dateTimePicker);
            //    dateTimePicker.Format = DateTimePickerFormat.Short;
            //    Rectangle rectangle = datagridView1.GetCellDisplayRectangle(e.ColumnIndex,e.RowIndex,true);
            //    dateTimePicker.Size = new Size(rectangle.Width,rectangle.Height);
            //    dateTimePicker.Location = new Point(rectangle.X,rectangle.Y);
            //    dateTimePicker.CloseUp += new EventHandler(dateTimePicker_closeup);
            //    dateTimePicker.TextChanged += new EventHandler(dateTimePicker_textchanged);
            //    dateTimePicker.Visible = true;
            //}

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
                        //double UnitPrice = (double)db.Stocks.Where(x => x.ProductId == product.ProductId).FirstOrDefault().SellingPrice;

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
    }
}