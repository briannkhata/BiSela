using DevExpress.XtraEditors;
using Katswiri.Data;
using Katswiri.Enums;
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


        public Pos()
        {
            InitializeComponent();
            clearGrid();
            loadCart();
            autoCompleteSearch();
            loadSaleTypes();
            loadPaymentTypes();

            //clearmyCart();//clear my cart            
            //lblCompany.Text = db.Settings.FirstOrDefault().Name;
            //lblShop.Text = db.Shops.FirstOrDefault().ShopName;

            textEditTendered.Text = String.Format("{0:c}", textEditTendered.Text);
            //textEditTendered.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            using (var db = new BEntities())
            {
                lblCashier.Text = db.Users.Where(x => x.UserId == LoginInfo.UserId).Single().Name;
            }

        }
        public void clearGrid()
        {
            gridControl1.DataSource = null;
            lblTotalBill.Text = "0.00";
        }
        public void resetCartUI()
        {
            lblTotalBill.Text = "00.00";
            //lblChange.Text = "00.00";
            textEditTendered.Text = "00.00";
            clearmyCart();
            loadCart();
        }
        public void loadCart()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = db.vwCarts.Where(x => x.UserId == LoginInfo.UserId).ToList();
                //gridView1.OptionsBehavior.Editable = false;
                gridView1.Columns["UserId"].Visible = false;
                gridView1.Columns["ShopId"].Visible = false;
                gridView1.Columns["ProductId"].Visible = false;
                //gridView1.Columns["DiscountPercent"].Visible = false;
                gridView1.Columns["DiscountAmount"].Visible = false;
                gridView1.Columns["CartId"].Visible = false;

                //TotalPrice
                //colModelPrice.DisplayFormat.FormatType = Utils.FormatType.Numeric;
                gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.ReadOnly = true;
                gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.AllowEdit = false;

                gridView1.Columns.ColumnByFieldName("TotalPrice").OptionsColumn.ReadOnly = true;
                gridView1.Columns.ColumnByFieldName("TotalPrice").OptionsColumn.AllowEdit = false;

                gridView1.Columns.ColumnByFieldName("TaxValue").OptionsColumn.ReadOnly = false;
                gridView1.Columns.ColumnByFieldName("TaxValue").OptionsColumn.AllowEdit = false;
                gridView1.FocusedColumn = gridView1.Columns["Qty"];
                gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);

                gridView1.OptionsView.ShowIndicator = false;
                gridView1.Appearance.Row.Font = new Font("Century Gothic", 18f);


                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;

                var total = db.Carts?.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.TotalPrice);
                var tax = db.Carts?.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.TaxValue);
                var sp = db.Carts?.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.SellingPrice);

                if (total != null)
                {
                    lblTotalBill.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", total, 2);
                    //textEditTendered.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", total, 2);
                    textEditTendered.Text = "0";

                }

                //if (sp != null)
                //{
                //    lblSubTotal.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", sp, 2);
                //}
            }
        }
        public bool isNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }
        private void autoCompleteSearch()
        {
            using (db = new BEntities())
            {
                AutoCompleteStringCollection autoText = new AutoCompleteStringCollection();
                foreach (Product product in db.Products.ToList() as List<Product>)
                {
                    autoText.Add(product.ProductName);
                    //autoText.Add(product.ProductCode);
                    //autoText.Add(product.BarCode);
                }
                textSearchProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textSearchProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textSearchProduct.AutoCompleteCustomSource = autoText;
            }
        }
        private void Pos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to cancel POS UI?", "Katswiri", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        public void clearmyCart()
        {
            using (var db = new BEntities())
            {
                var list = db.Carts.Where(x => x.UserId == LoginInfo.UserId).ToList();
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
                //db.Database.ExecuteSqlCommand("TRUNCATE TABLE Carts");
                clearmyCart();
            }
            //gridControl1.DataSource = null;
            loadCart();
            lblTotalBill.Text = "0.00";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            textSearchProduct.Text += button.Text;
        }

        private void textSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            lblChange.Text = string.Empty;
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
                {
                    using (var db = new BEntities())
                    {
                        //var choice = db.Products.Where(p => p.ProductCode == textSearchProduct.Text | p.BarCode == textSearchProduct.Text).ToList();
                        //var choice = db.Products.Where(p => p.ProductName.Contains(textSearchProduct.Text)).ToList();
                        var product = db.Products.Where(p => p.ProductName == textSearchProduct.Text.ToString()).FirstOrDefault();
                        var taxValue = db.TaxTypes.Where(x => x.TaxTypeId == product.TaxTypeId).SingleOrDefault().TaxTypeValue;
                        var taxStatus = db.TaxTypes.Where(x => x.TaxTypeId == product.TaxTypeId).SingleOrDefault().TaxTypeStatus;
                        var exists = db.Carts.Where(x => x.ProductId == product.ProductId).FirstOrDefault();

                        if (exists != null)
                        {
                            exists.Qty += 1;
                            //exists.TaxValue = (product.SellingPrice * (taxValue / 100));
                            exists.TotalPrice = (exists.SellingPrice * exists.Qty) + cart.TaxValue;
                            db.Entry(exists).State = EntityState.Modified;
                            db.SaveChanges();
                            clearGrid();
                        }

                        if (exists == null)
                        {
                            cart.ProductId = product.ProductId;
                            //cart.SellingPrice = product.SellingPrice;
                            cart.ShopId = db.Users.Where(x => x.UserId == LoginInfo.UserId).Single().ShopId;
                            cart.UserId = LoginInfo.UserId;
                            cart.DiscountAmount = 0;
                            cart.DiscountPercent = 0;
                            cart.Qty = 1;
                            //cart.TaxValue = (product.SellingPrice * (taxValue / 100));
                            cart.TotalPrice = (cart.SellingPrice * cart.Qty) + cart.TaxValue;
                            db.Carts.Add(cart);
                            db.SaveChanges();
                            clearGrid();
                        }
                        loadCart();
                    }
                }
            }
            catch
            {

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
                        var taxTypeId = db.Products.Where(x => x.ProductId == row.ProductId).SingleOrDefault().TaxTypeId;
                        var taxValue = db.TaxTypes.Where(x => x.TaxTypeId == taxTypeId).SingleOrDefault().TaxTypeValue;
                        //var taxStatus = db.TaxTypes.Where(x => x.TaxTypeId == product1.TaxTypeId).SingleOrDefault().TaxTypeStatus;
                        cart.CartId = row.CartId;
                        cart.UserId = row.UserId;
                        cart.ShopId = row.ShopId;
                        cart.DiscountAmount = 0;
                        cart.DiscountPercent = 0;
                        cart.ProductId = row.ProductId;
                        cart.SellingPrice = row.SellingPrice;
                        cart.Qty = row.Qty;
                        //cart.TaxValue = (row.SellingPrice * (taxValue / 100));
                        cart.TotalPrice = (row.SellingPrice * row.Qty) + row.TaxValue;
                        db.Entry(cart).State = EntityState.Modified;
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

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            refreshCart();
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
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

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            //ShowPayFom();


            try
            {

                using (db = new BEntities())
                {

                    //var bill = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.TotalPrice);
                    //var Tendered = Double.Parse(textEditTendered.Text);

                    //if (Tendered < bill || textEditTendered.Text == "")
                    //{

                    sale = new Sale()
                    {
                        DateSold = DateTime.Parse(dateTimePickerSaleDate.Text),
                        SaleTypeId = (int)lookUpEditSaleType.EditValue,
                        PaymentTypeId = (int)lookUpEditPaymentType.EditValue,
                        ShopId = db.Users.Where(x => x.UserId == LoginInfo.UserId).Single().ShopId,
                        SoldBy = LoginInfo.UserId,
                        SoldTo = 1,
                        TaxAmount = (double)db.Carts.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.TaxValue),
                        TotalBill = (double)db.Carts.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.TotalPrice),
                        SubTotal = (double)db.Carts.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.SellingPrice),
                        TotalChange = Double.Parse(textEditTendered.Text) - (double)(db.Carts.Where(x => x.UserId == 1).Sum(x => x.TotalPrice)),
                        TotalTendered = Double.Parse(textEditTendered.Text),
                        DiscountAmount = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.DiscountAmount),
                        DiscountPercent = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.DiscountPercent),
                        txnId = textEditTxnId.Text,
                    };

                    db.Sales.Add(sale);
                    db.SaveChanges();
                    var saleId = sale.SaleId;//get recently inserted id

                    var cart = db.Carts.Where(x => x.UserId == LoginInfo.UserId).ToList();
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
                            DateSold = DateTime.Parse(dateTimePickerSaleDate.Text),
                        };
                        db.SaleDetails.Add(saleDetail);
                        db.SaveChanges();

                        //quantity = new Quantity()
                        //{
                        //    ProductId = item.ProductId,
                        //    ShopQty = quantity.ShopQty - item.Qty,
                        //};
                        //db.Quantities.Add(quantity);
                        //db.SaveChanges();
                    }

                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Please Enter Amount Corresponding to the Bill", "Katswiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    resetCartUI();
                    textSearchProduct.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            }
        }

        private void loadPaymentTypes()
        {
            using (db = new BEntities())
            {
                lookUpEditPaymentType.Properties.DataSource = db.vwPaymentTypes.ToList();
                lookUpEditPaymentType.Properties.ValueMember = "PaymentTypeId";
                lookUpEditPaymentType.Properties.DisplayMember = "PaymentTypeName";
            }
        }

        //    private void TextBox_GotFocus(object sender, EventArgs e)
        //{

        //    System.Diagnostics.Process.Start("osk.exe");
        //}


        //private void printReceipt()
        //{
        //    var heda = db.Shops.FirstOrDefault().ShopName;
        //    var futa = "Thank you for Shopping With Us";

        //    int SaleId = (int)(db.Sales.FirstOrDefault().SaleId);
        //    double Tendered = (double)(db.Sales.FirstOrDefault().TotalTendered);
        //    double Tax = (double)(db.Sales.FirstOrDefault().TaxAmount);
        //    double Change = (double)(db.Sales.FirstOrDefault().TotalChange);
        //    double DiscountAmt = (double)(db.Sales.FirstOrDefault().DiscountAmount);
        //    double DiscountPer = (double)(db.Sales.FirstOrDefault().DiscountPercent);
        //    DateTime SaleDate = (DateTime)(db.Sales.FirstOrDefault().DateSold);



        //    int lineHeight = 20;
        //    int supplementaryLines = 15;

        //    //Bitmap bitm = new Bitmap(heda.Length * 30, (supplementaryLines + dataGridView1.Rows.Count) * lineHeight);
        //    StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
        //    using (Graphics graphic = Graphics.FromImage(bitm))
        //    {
        //        int startX = 0;
        //        int startY = 0;
        //        int offsetY = 0;
        //        Font newfont2 = null;
        //        Font itemFont = null;
        //        SolidBrush black = null;
        //        SolidBrush white = null;

        //        try
        //        {
        //            //Font newfont = new Font("Arial Black", 8);
        //            newfont2 = new Font("Calibri", 11);
        //            itemFont = new Font("Calibri", 11);

        //            black = new SolidBrush(Color.Black);
        //            white = new SolidBrush(Color.White);

        //            //PointF point = new PointF(40f, 2f);

        //            graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
        //            graphic.DrawString("" + InvoiceNo + "رقم الفاتورة ", newfont2, black, startX + 150, startY + offsetY);
        //            offsetY = offsetY + lineHeight;

        //            //PointF pointPrice = new PointF(15f, 45f);
        //            graphic.DrawString("" + InvoiceDate + "", newfont2, black, startX, startY + offsetY);
        //            offsetY = offsetY + lineHeight;
        //            offsetY = offsetY + lineHeight;

        //            graphic.DrawString("إسم المنتج             " + "الكمية      " + "السعر", newfont2, black, startX + 15, startY + offsetY);
        //            offsetY = offsetY + lineHeight;
        //            offsetY = offsetY + lineHeight;
        //            graphic.DrawString("--------------------------------------------------", newfont2, black, startX, startY + offsetY);
        //            //PointF pointPname = new PointF(10f, 65f);
        //            //PointF pointBar = new PointF(10f, 65f);

        //            offsetY = offsetY + lineHeight;
        //            offsetY = offsetY + lineHeight;

        //            for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //            {
        //                int ii = 1;
        //                ii++;

        //                graphic.DrawString(" " + dataGridView1.Rows[i].Cells[3].Value + "  " + dataGridView1.Rows[i].Cells[2].Value + "  " + dataGridView1.Rows[i].Cells[1].Value + "", itemFont,
        //                         black, startX + 15, startY + offsetY);
        //                offsetY = offsetY + lineHeight;
        //            }
        //            offsetY = offsetY + lineHeight;
        //            graphic.DrawString("--------------------------------------------------", newfont2, black, startX, startY + offsetY);
        //            offsetY = offsetY + lineHeight;
        //            graphic.DrawString("الإجمالي :" + gross + "", newfont2, black, startX + 15, startY + offsetY);
        //            offsetY = offsetY + lineHeight;
        //            graphic.DrawString("الخصم :" + discount + "", newfont2, black, startX + 15, startY + offsetY);
        //            offsetY = offsetY + lineHeight;
        //            graphic.DrawString("الصافي :" + net + "", newfont2, black, startX + 15, startY + offsetY);
        //            offsetY = offsetY + lineHeight;
        //            offsetY = offsetY + lineHeight;
        //            graphic.DrawString("--------------------------------------------------", newfont2, black, startX, startY + offsetY);
        //            offsetY = offsetY + lineHeight;
        //            graphic.DrawString("" + welcome + "", newfont2, black, startX, startY + offsetY);
        //            offsetY = offsetY + lineHeight;
        //        }
        //        finally
        //        {
        //            black.Dispose();
        //            white.Dispose();
        //            itemFont.Dispose();
        //            newfont2.Dispose();
        //        }
        //    }

        //    //using (MemoryStream Mmst = new MemoryStream())
        //    //{
        //    //    bitm.Save("ms", ImageFormat.Jpeg);
        //    //    pictureBox1.Image = bitm;
        //    //    pictureBox1.Width = bitm.Width;
        //    //    pictureBox1.Height = bitm.Height;


        //    //}


        //}

        private void Pos_Shown(object sender, EventArgs e)
        {
            using (db = new BEntities())
            {
                //lookUpEditSaleType.EditValue = db.vwSaleTypes.ToList()[0].SaleTypeId;
                //lookUpEditPaymentType.EditValue = db.vwPaymentTypes.ToList()[0].PaymentTypeId;

                Dictionary<int, string> taxTypesStatus = Enum.GetValues(typeof(SaleType)).Cast<SaleType>().ToDictionary(x => (int)x, x => x.ToString());
                lookUpEditSaleType.Properties.DataSource = taxTypesStatus;
                lookUpEditSaleType.Properties.ValueMember = "Value";
                lookUpEditSaleType.Properties.DisplayMember = "Value";
            }
        }

        private void dispalyChange()
        {
            if (textEditTendered.Text != string.Empty)
            {
                lblChange.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", (Convert.ToDouble(textEditTendered.Text.Trim()) - Convert.ToDouble(lblTotalBill.Text)).ToString(), 2);
            }
            else
            {
                lblChange.Text = string.Empty;
            }
        }

        private void textEditTendered_KeyUp(object sender, KeyEventArgs e)
        {
           
            dispalyChange();
            //textEditTendered.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", textEditTendered.Text, 2);
        }

        private void textEditTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, textEditTendered.Text))
                e.Handled = true;
        }

      

        private void lookUpEditPaymentType_EditValueChanged(object sender, EventArgs e)
        {
            if((int)lookUpEditPaymentType.EditValue != 1)
            {
                textEditTxnId.Enabled = false;
                //textEditTxnId.Enabled = true;
            }
        }

        private void textEditTendered_MouseEnter(object sender, EventArgs e)
        {
            //Process process = Process.Start(new ProcessStartInfo(((Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\osk.exe"))));
            textEditTendered.Text = string.Empty;

        }
    }
}