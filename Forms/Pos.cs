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
        BillPayment billPayment;
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
        public void disableButtons()
        {
            buttonFinishSale.Enabled = false;
            buttonRemove.Enabled = false;
            buttonVoid.Enabled = false;
        }

        public void enableButtons()
        {
            buttonFinishSale.Enabled = true;
            buttonRemove.Enabled = true;
            buttonVoid.Enabled = true;
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
                Double balance = 0;
                labelChange.Text = change.ToString("##,##00.00");
                if (tendered >= Convert.ToDouble(labelBill.Text))
                {
                    buttonFinishSale.Enabled = true;
                    buttonFinishSale.BackColor = Color.Green;
                    balance = (tendered - double.Parse(labelBill.Text)) - change;
                }
                else
                {
                    //buttonFinishSale.Enabled = false;
                    //buttonFinishSale.BackColor = Color.Gray;
                    balance = (double.Parse(labelBill.Text) - tendered) - change;
                }
                labelBalance.Text = balance.ToString("##,##00.00");
            }
            else
            {
                labelChange.Text="00.00";
                textBoxTendered.Clear();
            }
        }

        public void calculate_money()
        {
           
                double total = 0;
                double vat = 0;
                double discount = 0;

                int i;
                for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    vat += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    discount += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }

                labelSubTotal.Text = (total - vat - discount).ToString("##,##0.00");
                labelTax.Text = vat.ToString("##,##0.00");
                labelBill.Text = total.ToString("##,##0.00");
                labelDiscount.Text = discount.ToString("##,##0.00");
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
                        Boolean Found = false;

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
                                    var taxstatus = db.Products.Where(x => x.ProductCode == row.Cells[0].Value.ToString()).FirstOrDefault().TaxStatus;
                                    selu = Convert.ToDouble(row.Cells[2].Value);
                                    qty = Convert.ToDouble(row.Cells[3].Value) + 1;
                                    disc = Convert.ToDouble(row.Cells[4].Value);
                                    sub = selu * qty;
                                    if (taxstatus == "Inclusive")
                                    {
                                        vat = sub * (taxValue / 100);
                                        toto = (sub + vat) - disc;
                                    }else if(taxstatus == "Exempted")
                                    {
                                        vat = 0;
                                        toto = (sub + vat) - disc;
                                    }
                                    else if(taxstatus == "Exclusive")
                                    {

                                    }
                                    else { }

                                    row.Cells[3].Value = qty.ToString("##,##0.00");
                                    row.Cells[4].Value = disc.ToString("##,##0.00");
                                    row.Cells[5].Value = vat.ToString("##,##0.00");
                                    row.Cells[6].Value = toto.ToString("##,##0.00");
                                    Found = true;
                                    calculate_money();
                                }
                            }
                            if(!Found)
                            {
                                    var taxstatus = db.Products.Where(x => x.ProductCode == product.ProductCode.ToString()).FirstOrDefault().TaxStatus;
                                    string ProductId = product.ProductId.ToString();
                                    string ProductCode = product.ProductCode.ToString();
                                    string ProductName = product.ProductName.ToString();
                                    double Qty = 1;
                                    double SellingPrice = UnitPrice;
                                    double Discount = 0;
                                    if (taxstatus == "Inclusive")
                                    {
                                        double Tax = (UnitPrice * (taxValue / 100));
                                        double TotalPrice = ((UnitPrice * Qty) + Tax) - Discount;
                                        dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty.ToString("##,##0.00"), Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
                                    }
                                    else if (taxstatus == "Expemted")
                                    {
                                        double Tax = 0;
                                        double TotalPrice = ((UnitPrice * Qty) + Tax) - Discount;
                                        dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty.ToString("##,##0.00"), Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
                                    }
                                    else if (taxstatus == "Exclusive")
                                    {

                                    }
                                    else
                                    {

                                    }
                                    calculate_money();
                            }
                        }
                        else
                        {
                            var taxstatus = db.Products.Where(x => x.ProductCode == product.ProductCode.ToString()).FirstOrDefault().TaxStatus;
                            string ProductId = product.ProductId.ToString();
                            string ProductCode = product.ProductCode.ToString();
                            string ProductName = product.ProductName.ToString();
                            double Qty = 1;
                            double SellingPrice = UnitPrice;
                            double Discount = 0;
                            if (taxstatus == "Inclusive")
                            {
                                double Tax = (UnitPrice * (taxValue / 100));
                                double TotalPrice = ((UnitPrice * Qty) + Tax) - Discount;
                                dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty.ToString("##,##0.00"), Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
                            }
                            else if (taxstatus == "Expemted")
                            {
                                double Tax = 0;
                                double TotalPrice = ((UnitPrice * Qty) + Tax) - Discount;
                                dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty.ToString("##,##0.00"), Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
                            }
                            else if (taxstatus == "Exclusive")
                            {

                            }
                            else
                            {

                            }
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
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    calculate_money();
                }
                else
                {
                    XtraMessageBox.Show("There are no data to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    var SaleId = labelSaleId.Text;
                    int Customer = (int)lookUpEditCustomer.EditValue;
                    var PaymentTypeId = (int)lookUpEditPaymentType.EditValue;
                    var SaleType = lookUpEditSaleType.EditValue;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        saleDetail.ProductId = db.Products.Where(x=>x.ProductCode == dataGridView1.Rows[i].Cells[0].Value.ToString()).SingleOrDefault().ProductId;
                        saleDetail.Discount = Double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        saleDetail.Qty = Double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        saleDetail.SellingPrice = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        saleDetail.SoldPrice = Double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                        saleDetail.ShopId = db.Shops.SingleOrDefault().ShopId;
                        saleDetail.UserId = UserId;
                        saleDetail.TaxValue = Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        saleDetail.DateSold = dateEditDateSold.DateTime;
                    }

                    billPayment = new BillPayment()
                    {
                        SaleId = short.Parse(SaleId),
                        Amount = double.Parse(textBoxTendered.Text),
                        PaymentTypeId = PaymentTypeId,
                        PaymentDate = dateEditDateSold.DateTime,
                    };
                    db.BillPayments.Add(billPayment);
                    db.SaveChanges();

                    sale = new Sale()
                    {
                        SaleId = short.Parse(SaleId),
                        Customer = Customer,
                        SoldBy = UserId,
                        PaymentTypeId = PaymentTypeId,
                        SaleType = (string)SaleType,
                        TaxAmount = double.Parse(labelTax.Text),
                        Bill = double.Parse(labelBill.Text),
                        Paid = db.BillPayments.Where(x=>x.SaleId == short.Parse(SaleId)).Sum(x=>x.Amount),
                        Balance = double.Parse(labelBill.Text)  - (double.Parse(textBoxTendered.Text) - double.Parse(labelChange.Text)),

                        //Balance = (db.Sales.Where(x => x.SaleId == short.Parse(SaleId)).SingleOrDefault().Bill) - (db.Sales.Where(x => x.SaleId == short.Parse(SaleId)).SingleOrDefault().Paid),
                    };
                    db.Entry(sale).State = EntityState.Modified;
                    db.SaveChanges();


                    //clear_all_data();
                    //print a receipt
                    //frm_printReceipt frm_PrintReceipt = new frm_printReceipt();
                    //frm_PrintReceipt.saleId = saleId;
                    buttonFinishSale.Enabled = false;
                    buttonFinishSale.BackColor = Color.Gray;
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

        private void textBoxTendered_TextChanged(object sender, EventArgs e)
        {
            //textBoxTendered.Text = Double.Parse(textBoxTendered.Text).ToString("##,##00.00");
            calculate_change();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            FormOrders formOrders = new FormOrders();
            formOrders.ShowDialog();
        }


        private void buttonVoid_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Refresh();
            }

        }

        private void textBoxTendered_KeyUp(object sender, KeyEventArgs e)
        {
            //textBoxTendered.Text = Double.Parse(textBoxTendered.Text).ToString("##,##00.00");
            //calculate_change();
        }

        private void textBoxTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textBoxTendered.Text = Double.Parse(textBoxTendered.Text).ToString("##,##00.00");
            //calculate_change();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (db = new BEntities())
            {
                if (e.RowIndex != -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4))
                {
                    var taxstatus = db.Products.Where(x => x.ProductCode == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()).FirstOrDefault().TaxStatus;
                    if (taxstatus == "Inclusive")
                    {
                        double vat = (double)db.Shops.SingleOrDefault().Vat;
                        double qty = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value);
                        double sp = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["SellingPrice"].Value);
                        double sub = qty * sp;
                        double tax = sub * (vat / 100);
                        double disc = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Discount"].Value);
                        double toto = (sub + tax) - disc;
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = tax.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = toto.ToString("##,##0.00");

                    }
                    else if(taxstatus == "Exempted")
                    {
                        double vat = (double)db.Shops.SingleOrDefault().Vat;
                        double qty = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value);
                        double sp = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["SellingPrice"].Value);
                        double sub = qty * sp;
                        double tax = 0;
                        double disc = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Discount"].Value);
                        double toto = (sub + tax) - disc;
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = tax.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = toto.ToString("##,##0.00");
                    }
                    else if(taxstatus == "Exclusive")
                    {

                    }
                    else
                    {

                    }
                    calculate_money();
                }
            }
        }
    }
}