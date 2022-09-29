using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
        FormCustomer formCustomer = new FormCustomer();

        public Pos()
        {
            InitializeComponent();
            clearGrid();
            autoCompleteSearch();
            loadSaleTypes();
            loadPaymentTypes();
            loadCustomers();
            dateEditDateSold.DateTime = DateTime.Now;

            //clearmyCart();//clear my cart            
            //lblCompany.Text = db.Settings.FirstOrDefault().Name;
            //lblShop.Text = db.Shops.FirstOrDefault().ShopName;

            //textEditTendered.Text = String.Format("{0:c}", textEditTendered.Text);
            //textEditTendered.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            using (var db = new BEntities())
            {
                this.Text = db.Shops.SingleOrDefault().ShopName;
                lblCashier.Text = db.Users.Where(x => x.UserId == LoginInfo.UserId).Single().Name;
            }

        }

        public void clearGrid()
        {
            gridControl1.DataSource = null;
            //lblTotalBill.Text = "0.00";
        }
        public void resetCartUI()
        {
            //lblTotalBill.Text = "00.00";
            //lblChange.Text = "00.00";
            //textEditTendered.Text = "00.00";
            clearmyCart();
            loadCart();
        }
        public void loadCart()
        {
            using (db = new BEntities())
            {
                int customer = (int)lookUpEditCustomer.EditValue;
                int SaleId = (int)lookUpEditSaleId.EditValue;

                gridControl1.DataSource = null;
                gridControl1.DataSource = db.vwCarts.Where(x => x.Customer == customer && x.SaleId == SaleId).ToList();

                gridControlOrders.DataSource = db.vwOrderCustomers.Where(x => x.Customer == customer && x.SaleId == SaleId).ToList();
                gridView2.OptionsBehavior.Editable = false;
                gridView2.Columns["Tendered"].Visible = false;
                gridView2.Columns["Customer"].Visible = false;
                gridView2.Columns["SaleId"].Visible = false;
                gridView2.Columns["Name"].Visible = false;
                gridView2.Columns["Phone"].Visible = false;


                //gridControl1.DataSource = db.vwCarts.Where(x => x.UserId == LoginInfo.UserId).ToList();

                //gridView1.OptionsBehavior.Editable = false;
                gridView1.Columns["SaleId"].Visible = false;
                gridView1.Columns["Discount"].Visible = false;
                gridView1.Columns["ProductId"].Visible = false;
                gridView1.Columns["Customer"].Visible = false;
                gridView1.Columns["TaxValue"].Visible = false;
                gridView1.Columns["CartId"].Visible = false;
                gridView1.Columns["Description"].Visible = false;


                //TotalPrice
                //colModelPrice.DisplayFormat.FormatType = Utils.FormatType.Numeric;
                gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.ReadOnly = true;
                gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.AllowEdit = false;

                gridView1.Columns.ColumnByFieldName("TotalPrice").OptionsColumn.ReadOnly = true;
                gridView1.Columns.ColumnByFieldName("TotalPrice").OptionsColumn.AllowEdit = false;

                //gridView1.Columns.ColumnByFieldName("TaxValue").OptionsColumn.ReadOnly = false;
               // gridView1.Columns.ColumnByFieldName("TaxValue").OptionsColumn.AllowEdit = false;
                gridView1.FocusedColumn = gridView1.Columns["Qty"];
                gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);

                gridView1.OptionsView.ShowIndicator = false;
                gridView1.Appearance.Row.Font = new Font("Century Gothic", 18f);


                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;

                var total = db.Carts?.Where(x => x.Customer == (int?)lookUpEditCustomer.EditValue).Sum(x => x.TotalPrice);
                var tax = db.Carts?.Where(x => x.Customer == (int?)lookUpEditCustomer.EditValue).Sum(x => x.TaxValue);
                var subTotal = db.Carts?.Where(x => x.Customer == (int?)lookUpEditCustomer.EditValue).Sum(x => x.SellingPrice);
                var discount = db.Carts?.Where(x => x.Customer == (int?)lookUpEditCustomer.EditValue).Sum(x => x.Discount);


                if (total != null)
                {
                    labelBill.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", total, 2);
                    labelTax.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", tax, 2);
                    labelDiscount.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", discount, 2);
                    labelSubTotal.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", subTotal, 2);

                }

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
                clearmyCart();
            }
            loadCart();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            textSearchProduct.Text += button.Text;
        }

        public void textSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
                {
                    using (var db = new BEntities())
                    {
                        //sale = new Sale()
                        //{
                        //    Customer = (int?)lookUpEditCustomer.EditValue,
                        //    DateSold = (DateTime)dateEditDateSold.EditValue,
                        //    SaleType = lookUpEditSaleType.EditValue.ToString(),
                        //    SoldBy = LoginInfo.UserId,
                        //    ShopId = db.Shops.SingleOrDefault().ShopId,
                        //};
                        //db.Sales.Add(sale);
                        //db.SaveChanges();
                        //int SaleId = sale.SaleId;
                        int customer = (int)lookUpEditCustomer.EditValue;
                        int SaleId = (int)lookUpEditSaleId.EditValue;

                        var product = db.Products.Where(p => p.ProductCode == textSearchProduct.Text).FirstOrDefault();
                        var taxValue = db.TaxTypes.Where(x => x.TaxTypeId == product.TaxTypeId).SingleOrDefault().TaxTypeValue;
                        var taxStatus = db.Products.Where(x => x.ProductId == product.ProductId).SingleOrDefault().TaxStatus;
                        var exists = db.Carts.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                        double UnitPrice = (double)db.Stocks.Where(x => x.ProductId == product.ProductId).FirstOrDefault().SellingPrice;

                        if (taxStatus == "Inclusive")
                        {
                            if (exists != null)
                            {
                                exists.Qty += 1;
                                exists.TaxValue = (cart.SellingPrice * (taxValue / 100));
                                exists.TotalPrice = (cart.SellingPrice * exists.Qty) + cart.TaxValue;
                                db.Entry(exists).State = EntityState.Modified;
                            }
                            else
                            {
                                cart.SaleId = SaleId;
                                cart.ProductId = product.ProductId;
                                cart.SellingPrice = UnitPrice;
                                cart.ShopId = db.Users.Where(x => x.UserId == LoginInfo.UserId).Single().ShopId;
                                cart.UserId = LoginInfo.UserId;
                                cart.Customer = customer;
                                cart.Discount = 0;
                                cart.Qty = 1;
                                cart.TaxValue = (UnitPrice * (taxValue / 100));
                                cart.TotalPrice = (UnitPrice * cart.Qty) + cart.TaxValue;
                                db.Carts.Add(cart);
                            }
                            db.SaveChanges();

                            //var reduceQty = db.Carts.Where(x => x.SaleId == SaleId && x.Customer == customer).ToList();
                            //foreach(var i in )

                            //Stock stock = new Stock()
                            //{
                                
                            //};

                            //var total = db.Carts?.Where(x => x.Customer == customer && x.SaleId == SaleId).Sum(x => x.TotalPrice);
                            //var tax = db.Carts?.Where(x => x.Customer == customer && x.SaleId == SaleId).Sum(x => x.TaxValue);
                            //var subTotal = db.Carts?.Where(x => x.Customer == customer && x.SaleId == SaleId).Sum(x => x.SellingPrice);
                            //var discount = db.Carts?.Where(x => x.Customer == customer && x.SaleId == SaleId).Sum(x => x.Discount);

                            //var sale2 = db.Sales.Where(x => x.SaleId == sale.SaleId).FirstOrDefault();
                            //sale2.Bill = total;
                            //sale2.Balance = total;
                            //sale2.SubTotal = subTotal;
                            //sale2.TaxAmount = tax;
                            //db.Entry(sale2).State = EntityState.Modified;
                            //db.SaveChanges();
                        }
                        else
                        {

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadCart();
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
                        //DateSold = DateTime.Parse(dateTimePickerSaleDate.Text),
                        SaleType = (string)lookUpEditSaleType.EditValue,
                        //PaymentTypeId = (int)lookUpEditPaymentType.EditValue,
                        ShopId = db.Users.Where(x => x.UserId == LoginInfo.UserId).Single().ShopId,
                        SoldBy = LoginInfo.UserId,
                        Customer = 1,
                        TaxAmount = (double)db.Carts.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.TaxValue),
                        Bill = (double)db.Carts.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.TotalPrice),
                        SubTotal = (double)db.Carts.Where(x => x.UserId == LoginInfo.UserId).Sum(x => x.SellingPrice),
                        //TotalChange = Double.Parse(textEditTendered.Text) - (double)(db.Carts.Where(x => x.UserId == 1).Sum(x => x.TotalPrice)),
                        //TotalTendered = Double.Parse(textEditTendered.Text),
                        Discount = (double)db.Carts.Where(x => x.UserId == 1).Sum(x => x.Discount),
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
                            Discount = (double)item.Discount,
                            TaxValue = (double)item.TaxValue,
                            UserId = (int)item.UserId,
                            //DateSold = DateTime.Parse(dateTimePickerSaleDate.Text),
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

        private void loadCustomers()
        {
            using (db = new BEntities())
            {
                //lookUpEditCustomer.Properties.DataSource = db.Users.Where(x=>x.UserType == "Customer").ToList();
                lookUpEditCustomer.Properties.ValueMember = "UserId";
                lookUpEditCustomer.Properties.DisplayMember = "Name";
                //lookUpEditCustomer.EditValue = db.Users.Where(x=>x.UserType =="Customer").Max(x => x.UserId);
                lookUpEditCustomer.Properties.NullText = "Customer";
            }
        }

        private void loadSales()
        {
            using (db = new BEntities())
            {
                //lookUpEditSaleId.Properties.DataSource = db.Sales.ToList();
                lookUpEditSaleId.Properties.ValueMember = "SaleId";
                lookUpEditSaleId.Properties.DisplayMember = "SaleId";
                //lookUpEditSaleId.EditValue = db.Sales.Where(x=>x.Customer == (int)lookUpEditCustomer.EditValue).Max(x => x.SaleId);
                lookUpEditSaleId.Properties.NullText = "Order Number";

            }
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
                //lookUpEditPaymentType.Properties.DataSource = db.vwPaymentTypes.ToList();
                //lookUpEditPaymentType.Properties.ValueMember = "PaymentTypeId";
                //lookUpEditPaymentType.Properties.DisplayMember = "PaymentTypeName";
                //lookUpEditPaymentType.EditValue = db.PaymentTypes.Where(x => x.PaymentTypeName == "Cash").Single().PaymentTypeName;
                //lookUpEditPaymentType.Properties.NullText = "Payment Type";
            }
        }

        // private void TextBox_GotFocus(object sender, EventArgs e)
        //{

        //    System.Diagnostics.Process.Start("osk.exe");
        //}

        private void Pos_Shown(object sender, EventArgs e)
        {
            using (db = new BEntities())
            {
                loadSales();

                //lookUpEditSaleType.EditValue = db.vwSaleTypes.ToList()[0].SaleTypeId;
                //lookUpEditPaymentType.EditValue = db.vwPaymentTypes.ToList()[0].PaymentTypeId;

                //Dictionary<int, string> taxTypesStatus = Enum.GetValues(typeof(SaleType)).Cast<SaleType>().ToDictionary(x => (int)x, x => x.ToString());
                //lookUpEditSaleType.Properties.DataSource = taxTypesStatus;
                //lookUpEditSaleType.Properties.ValueMember = "Value";
                //lookUpEditSaleType.Properties.DisplayMember = "Value";
            }
        }

        private void dispalyChange()
        {
            //if (textEditTendered.Text != string.Empty)
            //{
            //    lblChange.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", (Convert.ToDouble(textEditTendered.Text.Trim()) - Convert.ToDouble(lblTotalBill.Text)).ToString(), 2);
            //}
            //else
            //{
            //    lblChange.Text = string.Empty;
            //}
        }

        private void textEditTendered_KeyUp(object sender, KeyEventArgs e)
        {
           
            dispalyChange();
            //textEditTendered.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", textEditTendered.Text, 2);
        }

        private void textEditTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!isNumber(e.KeyChar, textEditTendered.Text))
                e.Handled = true;
        }

        //private void lookUpEditPaymentType_EditValueChanged(object sender, EventArgs e)
        //{
        //    if((int)lookUpEditPaymentType.EditValue != 1)
        //    {
        //        //textEditTxnId.Enabled = false;
        //        //textEditTxnId.Enabled = true;
        //    }
        //}

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
            //Pos pos = new Pos();
            //pos.Activate();
            //pos.ShowDialog();

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
            ShowPayFom();
        }

        private void textSearchProduct_TextChanged(object sender, EventArgs e)
        {

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
    }
}