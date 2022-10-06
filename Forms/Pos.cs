﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Katswiri.Data;
using Katswiri.Enums;
using Katswiri.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Katswiri.Forms
{
    public partial class Pos : DevExpress.XtraEditors.XtraForm
    {
        BEntities db;
        Cart cart = new Cart();
        int CartId;
        Sale sale;
        SaleDetail saleDetail;
        FormCustomer formCustomer = new FormCustomer();

        GridView gridView1 = new GridView();

        public Pos()
        {
            InitializeComponent();
            autoCompleteSearch();
            loadSaleTypes();
            loadPaymentTypes();
            dateEditDateSold.DateTime = DateTime.Now;
            //this.dataGridView1.Columns["ProductId"].Visible = false;


            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 200;
        }

        public void loadCart()
        {
            using (db = new BEntities())
            {
                int customer = (int)lookUpEditCustomer.EditValue;
                int SaleId = short.Parse(labelSaleId.Text);
                int PaymentTypeId = (int)lookUpEditPaymentType.EditValue;

                //gridControl1.DataSource = cartModel;
                //gridView1.OptionsBehavior.Editable = false;
                //gridView1.Columns["SaleId"].Visible = false;
                //gridView1.Columns["Discount"].Visible = false;
                //gridView1.Columns["ProductId"].Visible = false;
                //gridView1.Columns["Customer"].Visible = false;
                //gridView1.Columns["ProductCode"].Visible = false;
                //gridView1.Columns["CartId"].Visible = false;
                //gridView1.Columns["ShopId"].Visible = false;

                //gridControl1.DataSource = db.vwCarts.Where(x => x.Customer == customer && x.SaleId == SaleId).ToList();

                //string value = gridView1.GetFocusedRowCellValue("ColumnName").ToString();
                //string value = gridView1.GetDataRow(e.FocusedRowHandle)["ColumnName"].ToString();
                //string value = (gridView1.GetFocusedRow() as DataRowView).Row["ColumnName"].ToString();
                //string value = gridView1.GetFocusedDataRow()["ColumnName"].ToString();


                //DataGridViewRow row = (DataGridViewRow)yourDataGridView.Rows[0].Clone();
                //row.Cells[0].Value = "XYZ";
                //row.Cells[1].Value = 50.2;
                //yourDataGridView.Rows.Add(row);

                //gridControlOrders.DataSource = db.vwOrderCustomers.Where(x => x.Customer == customer && x.SaleId == SaleId).ToList();
                //gridView2.OptionsBehavior.Editable = false;
                //gridView2.Columns["Tendered"].Visible = false;
                //gridView2.Columns["Customer"].Visible = false;
                //gridView2.Columns["SaleId"].Visible = false;
                //gridView2.Columns["Name"].Visible = false;
                //gridView2.Columns["Phone"].Visible = false;


                //gridControl1.DataSource = db.vwCarts.Where(x => x.UserId == LoginInfo.UserId).ToList();




                //TotalPrice
                //colModelPrice.DisplayFormat.FormatType = Utils.FormatType.Numeric;
                // gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.ReadOnly = true;
                //gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.AllowEdit = false;

                //gridView1.Columns.ColumnByFieldName("TotalPrice").OptionsColumn.ReadOnly = true;
                //gridView1.Columns.ColumnByFieldName("TotalPrice").OptionsColumn.AllowEdit = false;

                //gridView1.Columns.ColumnByFieldName("TaxValue").OptionsColumn.ReadOnly = false;
                // gridView1.Columns.ColumnByFieldName("TaxValue").OptionsColumn.AllowEdit = false;
                //gridView1.FocusedColumn = gridView1.Columns["Qty"];
                //gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);

                //gridView1.OptionsView.ShowIndicator = false;
                //gridView1.Appearance.Row.Font = new Font("Century Gothic", 18f);


                //gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;

                //var total = db.Carts?.Where(x => x.Customer == (int?)lookUpEditCustomer.EditValue).Sum(x => x.TotalPrice);
                //var tax = db.Carts?.Where(x => x.Customer == (int?)lookUpEditCustomer.EditValue).Sum(x => x.TaxValue);
                //var subTotal = db.Carts?.Where(x => x.Customer == (int?)lookUpEditCustomer.EditValue).Sum(x => x.SellingPrice);
                //var discount = db.Carts?.Where(x => x.Customer == (int?)lookUpEditCustomer.EditValue).Sum(x => x.Discount);


                //if (total != null)
                //{
                //    labelBill.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", total, 2);
                //    labelTax.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", tax, 2);
                //    labelDiscount.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", discount, 2);
                //    labelSubTotal.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", subTotal, 2);
                //}

                //if (sp != null)
                //{
                //    lblSubTotal.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", sp, 2);
                //}
            }
        }
        private void autoCompleteSearch()
        {
            using (db = new BEntities())
            {
                AutoCompleteStringCollection autoText = new AutoCompleteStringCollection();
                //foreach (vwStock vwstock in db.vwStocks.OrderByAscending(x=>x.ExpiryDate) as List<vwStock>)
                foreach (vwStock vwstock in db.vwStocks.Where(x=>x.Shop > 0).OrderBy(x=>x.ExpiryDate).ToList())
                //foreach (vwStock vwstock in db.vwStocks.Where(x => x.Shop > 0 && x.ExpiryDate > DateTime.Today).OrderBy(x => x.ExpiryDate).ToList())
                {
                   autoText.Add(vwstock.ProductCode);
                }
                textSearchProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textSearchProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textSearchProduct.AutoCompleteCustomSource = autoText;
            }
        }

        public void clearmyCart()
        {
            using (var db = new BEntities())
            {
                var list = db.Carts.Where(x => x.SaleId == (int)lookUpEditPaymentType.EditValue).ToList();
                foreach (var rm in list)
                {
                    db.Carts.Remove(rm);
                    db.SaveChanges();
                }
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to clear this ORDER?", "Katswiri", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                clearmyCart();
            }
            loadCart();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            textSearchProduct.Text += button.Text;
        }

        public void calculate_change()
        {
            if (textBoxTendered.Text == "")
            {
                labelChange.Text = "";
                return;
            }
            if (dataGridView1.Rows.Count > 0)
            {
                Double tendered = Convert.ToDouble(textBoxTendered.Text);
                Double change = tendered - Convert.ToDouble(labelBill.Text);
                labelChange.Text = change.ToString("##,##00.00");
                //if (charge >= Convert.ToDouble(txt_totalAmount.Text))
                //{
                //    btn_checkout.Enabled = true;
                //    btn_checkout.BackColor = Color.Green;
                //}
                //else
                //{
                //    btn_checkout.Enabled = false;
                //    btn_checkout.BackColor = Color.Gray;
                //}
;
            }
            else
            {
                labelChange.Text="00.00";
                textBoxTendered.Clear();
            }
        }

        public void calculate_money()
        {
            using (var db = new BEntities())
            {
                double subtotal = 0;
                double total = 0;
                double tax = 0;
                double discount = 0;

                int i;
                for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    tax += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    discount += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                }

                labelSubTotal.Text = (total - tax).ToString("##,##0.00");
                labelTax.Text = tax.ToString("##,##0.00");
                labelBill.Text = total.ToString("##,##0.00");
            }
        }

        public void textSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {

             if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
                {
                try
                {
                    using (var db = new BEntities())
                    {
                        var product = db.Products.Where(p => p.ProductCode == textSearchProduct.Text).FirstOrDefault();
                        double UnitPrice = (double)db.Stocks.Where(x => x.ProductId == product.ProductId).FirstOrDefault().SellingPrice;
                        double taxValue = (double)db.Shops.SingleOrDefault().Vat;
                        Boolean found = false;

                        double qty = 0;
                        double toto = 0;
                        double disc = 0;
                        double selu = 0;
                        double sub = 0;
                        double vat = 0;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {

                                if (row.Cells[0].Value.ToString() == product.ProductCode && row.Cells[1].Value.ToString() == product.ProductName.ToString())
                                {
                                    selu = (double)row.Cells[2].Value;
                                    disc = (double)row.Cells[4].Value;
                                    qty = (double)row.Cells[3].Value + 1;
                                    sub = selu * qty;
                                    vat = sub * (taxValue / 100);
                                    toto = (sub + vat) - disc;
                                    row.Cells[3].Value = qty;
                                    row.Cells[5].Value = toto;
                                    found = true;
                                } 
                            }
                            if(!found)
                                {
                                    string ProductId = product.ProductId.ToString();
                                    string ProductCode = product.ProductCode.ToString();
                                    string ProductName = product.ProductName.ToString();
                                    double Qty = 1;
                                    double SellingPrice = UnitPrice;
                                    double Discount = 0;
                                    double Tax = (UnitPrice * (taxValue / 100));
                                    double TotalPrice = ((UnitPrice * Qty) + Tax) - Discount;
                                    dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty, Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
                                    calculate_money();
                                }
                        }
                        else
                        {

                            string ProductId = product.ProductId.ToString();
                            string ProductCode = product.ProductCode.ToString();
                            string ProductName = product.ProductName.ToString();
                            double Qty = 1;
                            double SellingPrice = UnitPrice;
                            double Discount = 0;
                            double Tax = (UnitPrice * (taxValue / 100));
                            double TotalPrice = ((UnitPrice * Qty) + Tax) - Discount;
                            dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty, Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
                            calculate_money();
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textSearchProduct.Text = string.Empty;
        }
      
        public void refreshCart()
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwCart)gridView1.GetRow(selectedRows[0]));
                using (var db = new BEntities())
                {
                    if (row.CartId != -1)
                    {
                        var taxValue = 16;
                        var taxStatus = db.Products.Where(x => x.ProductId == row.ProductId).SingleOrDefault().TaxStatus;

                        if (taxStatus == "Inclusive")
                        {
                            cart.CartId = row.CartId;
                            cart.Discount = row.Discount;
                            cart.ProductId = row.ProductId;
                            cart.SellingPrice = row.SellingPrice - row.Discount;
                            cart.Qty = row.Qty;
                            cart.TaxValue = (cart.SellingPrice * (taxValue / 100));
                            cart.TotalPrice = (cart.SellingPrice * row.Qty) + row.TaxValue;
                            db.Entry(cart).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {

                        }
                    }
                    loadCart();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            refreshCart();
        }

        private void ShowPayFom()
        {
            Pay pay = null;
            if (pay == null || pay.IsDisposed)
            {
               pay = new Pay();
            }
            pay.Activate();
            pay.ShowDialog();
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.gridView1.IsLastVisibleRow)
                    this.gridView1.MoveNext();
                else
                    this.gridView1.MoveFirst();
            }
            loadCart();
        }

   
        private void loadSaleTypes()
        {
            using (db = new BEntities())
            {
                Dictionary<int, string> saleType = Enum.GetValues(typeof(SaleType)).Cast<SaleType>().ToDictionary(x => (int)x, x => x.ToString());
                lookUpEditSaleType.Properties.DataSource = saleType;
                lookUpEditSaleType.Properties.ValueMember = "Value";
                lookUpEditSaleType.Properties.DisplayMember = "Value";
                lookUpEditSaleType.EditValue = SaleType.Sale;
                lookUpEditSaleType.Properties.NullText = "Sale Type";
            }
        }

        private void loadPaymentTypes()
        {
            using (db = new BEntities())
            {
                lookUpEditPaymentType.Properties.DataSource = db.vwPaymentTypes.ToList();
                lookUpEditPaymentType.Properties.ValueMember = "PaymentTypeId";
                lookUpEditPaymentType.Properties.DisplayMember = "PaymentTypeName";
                lookUpEditPaymentType.EditValue = db.vwPaymentTypes.Where(x => x.PaymentTypeName == "Cash").SingleOrDefault().PaymentTypeId;
                lookUpEditPaymentType.Properties.NullText = "Payment Type";
            }
        }

        // private void TextBox_GotFocus(object sender, EventArgs e)
        //{

        //    System.Diagnostics.Process.Start("osk.exe");
        //}


        //private void textEditTendered_KeyUp(object sender, KeyEventArgs e)
        //{
           
        //    dispalyChange();
        //    //textEditTendered.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", textEditTendered.Text, 2);
        //}

        private void textEditTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!isNumber(e.KeyChar, textEditTendered.Text))
                e.Handled = true;
        }


        private void textEditTendered_MouseEnter(object sender, EventArgs e)
        {
            //Process process = Process.Start(new ProcessStartInfo(((Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\osk.exe"))));
           // textEditTendered.Text = string.Empty;

        }

        private void NewCustomer_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            FormCustomer formCustomer = null;
            if (formCustomer == null || formCustomer.IsDisposed)
            {
                formCustomer = new FormCustomer();
            }
            formCustomer.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowPosFom();
            this.Close();
        }
        private void ShowPosFom()
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            FormCustomer formCustomer = null;
            if (formCustomer == null || formCustomer.IsDisposed)
            {
                formCustomer = new FormCustomer();
            }
            formCustomer.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwCart)gridView1.GetRow(selectedRows[0]));
                using (var db = new BEntities())
                {
                    var cart = db.Carts.Find(row.CartId);
                    db.Carts.Remove(cart);
                    db.SaveChanges();
                }
                loadCart();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using(db = new BEntities())
            {
                if (MessageBox.Show("Do you want to print a receipt?", "Ask", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int UserId = LoginInfo.UserId;
                    //int PaymentTypeId = lookUpEditSaleId
                    int Customer = (int)lookUpEditCustomer.EditValue;
                    int SaleId = (int)lookUpEditPaymentType.EditValue;


                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //saleDetail.ProductId = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.ProductId = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.Discount = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.Qty = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.SellingPrice = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.SoldPrice = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.ShopId = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.UserId = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.TaxValue = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        //saleDetail.DateSold = dateEditDateSold.DateTime;

                    }

                    //clear_all_data();
                    //print a receipt
                    //frm_printReceipt frm_PrintReceipt = new frm_printReceipt();
                    // frm_PrintReceipt.saleId = saleId;
                    // btn_checkout.Enabled = false;
                    // btn_checkout.BackColor = Color.Gray;
                    // frm_PrintReceipt.ShowDialog();
                }

            }
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowFormOrders();
        }

        private void ShowFormOrders()
        {
            FormOrders formOrders = null;
            if (formOrders == null || formOrders.IsDisposed)
            {
                formOrders = new FormOrders();
            }
            formOrders.Activate();
            formOrders.ShowDialog();
        }

        private void Pos_Load(object sender, EventArgs e)
        {
            loadCart();
        }

        private void textBoxTendered_TextChanged(object sender, EventArgs e)
        {
            //textBoxTendered.Text = e.ToString("##,##00.00");
        }
    }
}