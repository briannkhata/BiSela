using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Katswiri.Data;
using Katswiri.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Katswiri.Forms
{
    public partial class Pos : DevExpress.XtraEditors.XtraForm
    {
        BEntities db;
        Sale sale;
        SaleDetail saleDetail;
        BillPayment billPayment;
        Stock stock;
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

            initVaribles();

            dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9, FontStyle.Bold);
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

        public void initVaribles()
        {
            using(db = new BEntities())
            {
                lblCashier.Text = db.Users.Where(x => x.UserId == LoginInfo.UserId).SingleOrDefault().Name;
            }

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

                if (change > 0)
                {
                    labelChange.Text = change.ToString("##,##00.00");
                }
                else
                {
                    labelChange.Text = "0.00";
                }

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
                    balance = (double.Parse(labelBill.Text) - tendered);
                }
                labelBalance.Text = balance.ToString("##,##00.00");
            }
            else
            {
                labelChange.Text="00.00";
                textBoxTendered.Clear();
                labelBalance.Text = "00.00";

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
             labelBalance.Text = (total - discount).ToString("##,##0.00");
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
                                    var code = row.Cells[0].Value.ToString(); 
                                    var taxstatus = db.Products.Where(x => x.ProductCode == code).FirstOrDefault().TaxStatus;
                                    selu = Convert.ToDouble(row.Cells[2].Value);
                                    qty = Convert.ToDouble(row.Cells[3].Value) + 1;
                                    disc = Convert.ToDouble(row.Cells[4].Value);
                                    sub = selu * qty;
                                    if (taxstatus == "Inclusive")
                                    {
                                        vat = sub * (taxValue / 100);
                                    }
                                    else if(taxstatus == "Exempted")
                                    {
                                        vat = 0;
                                    }
                                    else if(taxstatus == "Exclusive")
                                    {

                                    }
                                    else 
                                    { 
                                    }
                                    toto = (sub + vat) - disc;
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
                                    var UnitId = db.Products.Where(x => x.ProductId == product.ProductId).SingleOrDefault().UnitId;
                                    double Qte = Double.Parse(db.Units.Where(x => x.UnitId == UnitId).SingleOrDefault().Qty);
                                    string ProductCode = product.ProductCode.ToString();
                                    string ProductName = product.ProductName.ToString();
                                    double Qty = Qte;
                                    double SellingPrice = UnitPrice;
                                    double Discount = 0;
                                    double Tax = 0;
                                    if (taxstatus == "Inclusive")
                                    {
                                        Tax = (UnitPrice * (taxValue / 100));
                                    }
                                    else if (taxstatus == "Exempted")
                                    {
                                        Tax = 0;
                                    }
                                    else if (taxstatus == "Exclusive")
                                    {

                                    }
                                    else
                                    {

                                    }
                                   double TotalPrice = ((UnitPrice * Qty) + Tax) - Discount;
                                   dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty.ToString("##,##0.00"), Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
                                   calculate_money();
                            }
                        }
                        else
                        {
                            var taxstatus = db.Products.Where(x => x.ProductCode == product.ProductCode.ToString()).FirstOrDefault().TaxStatus;
                            string ProductId = product.ProductId.ToString();
                            var UnitId = db.Products.Where(x => x.ProductId == product.ProductId).SingleOrDefault().UnitId;
                            double Qte = Double.Parse(db.Units.Where(x => x.UnitId == UnitId).SingleOrDefault().Qty);
                            string ProductCode = product.ProductCode.ToString();
                            string ProductName = product.ProductName.ToString();
                            double Qty = Qte;
                            double SellingPrice = UnitPrice;
                            double Discount = 0;
                            double Tax = 0;
                            if (taxstatus == "Inclusive")
                            {
                                Tax = (UnitPrice * (taxValue / 100));
                            }
                            else if (taxstatus == "Exempted")
                            {
                                Tax = 0;
                            }
                            else if (taxstatus == "Exclusive")
                            {

                            }
                            else
                            {

                            }
                            double TotalPrice = ((UnitPrice * Qty) + Tax) - Discount;
                            dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty.ToString("##,##0.00"), Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
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
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            endSale();
        }

        public void resetCart()
        {
            labelSubTotal.Text = "00.0";
            labelDiscount.Text = "00.0";
            textBoxTendered.Text = "00.0";
            labelTax.Text = "00.0";
            labelBill.Text = "00.0";
            labelBalance.Text = "00.0";
            dataGridView1.Rows.Clear();
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
            //textBoxTendered.Text = Convert.ToDouble(textBoxTendered.Text).ToString("0:###,###,##0");
            calculate_change();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormPayments formPayments = new FormPayments();
            formPayments.ShowDialog();

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
                if (dataGridView1.Rows.Count > 0)
                {
                    if (e.RowIndex != -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4))
                    {
                        var code = dataGridView1.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString();
                        var taxstatus = db.Products.Where(x => x.ProductCode == code).FirstOrDefault().TaxStatus;
                        double vat = (double)db.Shops.SingleOrDefault().Vat;
                        double qty = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value);
                        double sp = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["SellingPrice"].Value);
                        double sub = qty * sp;
                        double tax = 0;

                        if (taxstatus == "Inclusive")
                        {
                            tax = sub * (vat / 100);
                        }
                        else if (taxstatus == "Exempted")
                        {
                            tax = 0;
                        }
                        else if (taxstatus == "Exclusive")
                        {

                        }
                        else
                        {

                        }
                        double disc = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Discount"].Value);
                        double toto = (sub + tax) - disc;
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = tax.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = toto.ToString("##,##0.00");
                        calculate_money();
                    }
                }
            }
        }

        private void Pos_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) 
            { 
                if (e.KeyCode == Keys.F12)
                {
                   // textBoxTendered.Enabled = true;
                   // textBoxTendered.Focus();
                }
                else
                {

                }
            }
            else
            {
                //textBoxTendered.Enabled = false;

            }
        }

        private void printReceipt(object sender, PrintPageEventArgs ev)
        {
            Font headingFont = new Font("Calibri", 13, FontStyle.Bold);
            Font boldFont = new Font("Calibri", 11, FontStyle.Bold);
            Font normalFont = new Font("Calibri", 11, FontStyle.Regular);

            float topMargin = ev.MarginBounds.Top;
            float leftMargin = ev.MarginBounds.Left;

            DataTable dt = new DataTable();
            dt.Columns.Add("Product");
            dt.Columns.Add("Price");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Discount");
            dt.Columns.Add("Total");

            DataRow row;
            using (db = new BEntities())
            {
                int userId = LoginInfo.UserId;
                int saleId = db.Sales.Where(x=>x.SoldBy == userId).Max(x => x.SaleId);
                var orders = db.SaleDetails.Where(x => x.SaleId == saleId).ToList();
                foreach (var item in orders)
                {
                    row = dt.NewRow();
                    row[0] = db.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault().ProductName;
                    row[1] = item.SellingPrice.ToString("##,##0.00");
                    row[2] = item.Qty;
                    row[3] = item.Discount.ToString("##,##0.00");
                    row[3] = item.SoldPrice.ToString("##,##0.00");
                    dt.Rows.Add(row);
                }

                double total = (double)db.Sales.Where(x => x.SaleId == saleId).FirstOrDefault().Bill;
                double subtotal = (double)db.Sales.Where(x => x.SaleId == saleId).FirstOrDefault().SubTotal;
                double change = (double)db.Sales.Where(x => x.SaleId == saleId).FirstOrDefault().Change;
                double tendered = (double)db.Sales.Where(x => x.SaleId == saleId).FirstOrDefault().Tendered;
                double vat = (double)db.Sales.Where(x => x.SaleId == saleId).FirstOrDefault().TaxAmount;


                string shop = db.Shops.SingleOrDefault().ShopName;
                string address = db.Shops.SingleOrDefault().Address;
                string motto = db.Shops.SingleOrDefault().Motto;
                string phone = db.Shops.SingleOrDefault().Phone;
                string email = db.Shops.SingleOrDefault().Email;


                string orderNo = "0000" + saleId;
                string receipt_date = DateTime.Now.ToString("MM/dd/yyyy");
                string line = "--------------------------------------------------------------------------------";
                float height = 30;


                //Print Company Name
                ev.Graphics.DrawString(shop, headingFont, Brushes.Black, 160, height, new StringFormat());
                height += 30;
                ev.Graphics.DrawString(address, normalFont, Brushes.Black, 100, height, new StringFormat());
                height += 40;
                ev.Graphics.DrawString(orderNo, boldFont, Brushes.Black, 10, height, new StringFormat());
                ev.Graphics.DrawString(receipt_date, boldFont, Brushes.Black, 260, height, new StringFormat());
                height += 40;

                //Print Line
                ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
                height += 20;

                //Printe Table Headings
                ev.Graphics.DrawString("Description", normalFont, Brushes.Black, 10, height, new StringFormat());
                ev.Graphics.DrawString("Price", normalFont, Brushes.Black, 170, height, new StringFormat());
                ev.Graphics.DrawString("Qty", normalFont, Brushes.Black, 220, height, new StringFormat());
                ev.Graphics.DrawString("Discount", normalFont, Brushes.Black, 220, height, new StringFormat());
                ev.Graphics.DrawString("Total", normalFont, Brushes.Black, 320, height, new StringFormat());
                height += 20;

                //Print Line
                ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
                height += 20;

                //Printe Table Rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SizeF qtyWidth = ev.Graphics.MeasureString(dt.Rows[i][1].ToString(), normalFont);
                    SizeF priceWidth = ev.Graphics.MeasureString(dt.Rows[i][2].ToString(), normalFont);
                    SizeF discountWidth = ev.Graphics.MeasureString(dt.Rows[i][3].ToString(), normalFont);
                    SizeF totalWidth = ev.Graphics.MeasureString(dt.Rows[i][3].ToString(), normalFont);
                    //SizeF totalWidth = ev.Graphics.MeasureString(dt.Rows[i][3].ToString(), normalFont);

                    ev.Graphics.DrawString(dt.Rows[i][0].ToString(), normalFont, Brushes.Black, 10, height, new StringFormat());
                    ev.Graphics.DrawString(dt.Rows[i][1].ToString(), normalFont, Brushes.Black, 140 + (50 - qtyWidth.Width), height, new StringFormat());
                    ev.Graphics.DrawString(dt.Rows[i][2].ToString(), normalFont, Brushes.Black, 220 + (50 - priceWidth.Width), height, new StringFormat());
                    ev.Graphics.DrawString(dt.Rows[i][3].ToString(), normalFont, Brushes.Black, 220 + (50 - discountWidth.Width), height, new StringFormat());
                    ev.Graphics.DrawString(dt.Rows[i][4].ToString(), normalFont, Brushes.Black, 320 + (50 - totalWidth.Width), height, new StringFormat());
                    height += 30;
                }

                //Print Line
                ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
                height += 20;

                ev.Graphics.DrawString("Sub Total", normalFont, Brushes.Black, 220, height, new StringFormat());
                SizeF netWidth = ev.Graphics.MeasureString(subtotal.ToString(), normalFont);
                ev.Graphics.DrawString(total.ToString("##,##0.00"), normalFont, Brushes.Black, 320 + (50 - netWidth.Width), height, new StringFormat());
                height += 20;

                ev.Graphics.DrawString("VAT", normalFont, Brushes.Black, 220, height, new StringFormat());
                SizeF netWidth33 = ev.Graphics.MeasureString(total.ToString(), normalFont);
                ev.Graphics.DrawString(vat.ToString("##,##0.00"), normalFont, Brushes.Black, 320 + (50 - netWidth.Width), height, new StringFormat());
                height += 20;

                ev.Graphics.DrawString("Total", normalFont, Brushes.Black, 220, height, new StringFormat());
                SizeF netWidth22 = ev.Graphics.MeasureString(total.ToString(), normalFont);
                ev.Graphics.DrawString(total.ToString("##,##0.00"), normalFont, Brushes.Black, 320 + (50 - netWidth.Width), height, new StringFormat());
                height += 20;

                ev.Graphics.DrawString("Tendered", normalFont, Brushes.Black, 220, height, new StringFormat());
                SizeF netWidth1 = ev.Graphics.MeasureString(total.ToString(), normalFont);
                ev.Graphics.DrawString(tendered.ToString("##,##0.00"), normalFont, Brushes.Black, 320 + (50 - netWidth1.Width), height, new StringFormat());
                height += 20;

                ev.Graphics.DrawString("Change", normalFont, Brushes.Black, 220, height, new StringFormat());
                SizeF netWidth2 = ev.Graphics.MeasureString(total.ToString(), normalFont);
                ev.Graphics.DrawString(change.ToString("##,##0.00"), normalFont, Brushes.Black, 320 + (50 - netWidth2.Width), height, new StringFormat());
                height += 20;


                //Print Line
                ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
                height += 40;

                ev.Graphics.DrawString("!!!"+ motto +"!!!", headingFont, Brushes.Black, 130, height, new StringFormat());
                ev.HasMorePages = false;
            }
        }
        public void finishsale()
        {
            using (db = new BEntities())
            {
                int UserId = LoginInfo.UserId;
                var SaleId = labelSaleId.Text;
                int Customer = (int)lookUpEditCustomer.EditValue;
                var PaymentTypeId = (int)lookUpEditPaymentType.EditValue;
                var SaleType = Convert.ToString(lookUpEditSaleType.EditValue);

                if (SaleType == "Sale")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        var code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        saleDetail = new SaleDetail()
                        {
                            ProductId = db.Products.Where(x => x.ProductCode == code).FirstOrDefault().ProductId,
                            Discount = Double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()),
                            Qty = Double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                            SellingPrice = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                            SoldPrice = Double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()),
                            ShopId = db.Shops.SingleOrDefault().ShopId,
                            UserId = UserId,
                            SaleId = short.Parse(SaleId),
                            TaxValue = Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()),
                            DateSold = dateEditDateSold.DateTime,
                        };
                        db.SaleDetails.Add(saleDetail);
                        db.SaveChanges();

                        var StockId = db.Stocks.Where(x => x.ProductId == saleDetail.ProductId).FirstOrDefault().StockId;
                        double oldQty = (double)db.Stocks.Where(x => x.StockId == StockId).FirstOrDefault().Shop;
                        stock = db.Stocks.Where(x => x.StockId == StockId).FirstOrDefault();
                        stock.Shop = oldQty - saleDetail.Qty;
                        db.Entry(stock).State = EntityState.Modified;
                        db.SaveChanges();
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

                    int seluidi = Convert.ToInt32(SaleId);
                    double paid = (double)db.BillPayments.Where(x => x.SaleId == seluidi).Sum(x => x.Amount);
                    sale = db.Sales.Where(x => x.SaleId == seluidi).FirstOrDefault();
                    sale.SaleId = seluidi;
                    sale.Customer = Customer;
                    sale.SoldBy = UserId;
                    sale.PaymentTypeId = PaymentTypeId;
                    sale.SaleType = SaleType;
                    sale.TaxAmount = Convert.ToDouble(labelTax.Text);
                    sale.Bill = Convert.ToDouble(labelBill.Text);
                    sale.Paid = paid;
                    sale.ShopId = db.Shops.SingleOrDefault().ShopId;
                    sale.Change = Convert.ToDouble(labelChange.Text);
                    sale.Balance = Convert.ToDouble(labelBalance.Text);
                    sale.Tendered = Convert.ToDouble(textBoxTendered.Text);
                    sale.Discount = Convert.ToDouble(labelDiscount.Text);
                    sale.SubTotal = Convert.ToDouble(labelSubTotal.Text);
                    sale.DateSold = DateTime.Now;
                    db.Entry(sale).State = EntityState.Modified;
                    db.SaveChanges();

                }
                else if (SaleType == "Return")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        var code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        saleDetail = new SaleDetail()
                        {
                            ProductId = db.Products.Where(x => x.ProductCode == code).FirstOrDefault().ProductId,
                            Discount = Double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()),
                            Qty = Double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                            SellingPrice = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                            SoldPrice = Double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()),
                            ShopId = db.Shops.SingleOrDefault().ShopId,
                            UserId = UserId,
                            SaleId = short.Parse(SaleId),
                            TaxValue = Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()),
                            DateSold = dateEditDateSold.DateTime,
                        };
                        db.SaleDetails.Add(saleDetail);
                        db.SaveChanges();

                        var StockId = db.Stocks.Where(x => x.ProductId == saleDetail.ProductId).FirstOrDefault().StockId;
                        double oldQty = (double)db.Stocks.Where(x => x.StockId == StockId).FirstOrDefault().Shop;
                        stock = db.Stocks.Where(x => x.StockId == StockId).FirstOrDefault();
                        stock.Shop = oldQty + saleDetail.Qty;
                        db.Entry(stock).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    int seluidi = Convert.ToInt32(SaleId);
                    double paid = (double)db.BillPayments.Where(x => x.SaleId == seluidi).Sum(x => x.Amount);
                    sale = db.Sales.Where(x => x.SaleId == seluidi).FirstOrDefault();
                    sale.SaleId = seluidi;
                    sale.Customer = Customer;
                    sale.SoldBy = UserId;
                    sale.PaymentTypeId = PaymentTypeId;
                    sale.SaleType = SaleType;
                    sale.TaxAmount = Convert.ToDouble(labelTax.Text);
                    sale.Bill = -Convert.ToDouble(labelBill.Text);
                    sale.Paid = -paid;
                    sale.ShopId = db.Shops.SingleOrDefault().ShopId;
                    sale.Change = 0;
                    sale.Balance = 0;
                    sale.Tendered = 0;
                    sale.Discount = 0;
                    sale.SubTotal = 0;
                    sale.DateSold = DateTime.Now;
                    db.Entry(sale).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (SaleType == "Credit")
                {

                }
                else if (SaleType == "Free")
                {

                }
                else if (SaleType == "Damage")
                {

                }
                else
                {

                }

                if (sale.Balance <= 0.5)
                {
                    resetCart();
                    double paid = (double)db.BillPayments.Where(x => x.SaleId == sale.SaleId).Sum(x => x.Amount);
                    sale.Bill = paid + sale.Balance;
                    db.Entry(sale).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    labelBill.Text = Convert.ToDouble(sale.Balance).ToString("##,##00.00");
                    textBoxTendered.Text = "0.00";
                }
            }
        }

        public void endSale()
        {
            finishsale();

            PrintDialog printDialog = new PrintDialog();
            PrintDocument pd = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            pd.PrintPage += new PrintPageEventHandler(this.printReceipt);
            //pd.PrintPage += (k, args) => printOrder(sender, (PrintPageEventArgs)e, 39);

            //pd.Print();// printing without print preview ends here

            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = pd;

            // this is were you take the printersettings from the printDialog
            printPreview.Document.PrinterSettings = printDialog.PrinterSettings;

            //printIssues.DefaultPageSettings.Landscape = true;
            printPreview.ShowDialog();

        }
    }
}