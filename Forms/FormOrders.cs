using DevExpress.XtraEditors;
using Katswiri.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katswiri.Forms
{
    public partial class FormOrders : DevExpress.XtraEditors.XtraForm
    {
        BEntities db;
        Pos pos = new Pos();
        public FormOrders()
        {
            InitializeComponent();
            loadOrders();
            loadCustomers();
            gridView1.Columns["SaleId"].Visible = false;
            gridView1.Columns["Customer"].Visible = false;
            gridView1.OptionsBehavior.Editable = false;
        }

        private void loadCustomers()
        {
            using (db = new BEntities())
            {
                lookUpEditCus.Properties.DataSource = db.vwCustomers.Where(x => x.UserType == "Customer").ToList();
                lookUpEditCus.Properties.ValueMember = "UserId";
                lookUpEditCus.Properties.DisplayMember = "Name";
                lookUpEditCus.Properties.NullText = "Select Customer";
            }
        }

        public void loadOrders()
        {
            using (db = new BEntities()) 
            {
                gridControl1.DataSource = db.vwOrderCustomers.ToList();
            }
        }

        private void lookUpEditCus_EditValueChanged(object sender, EventArgs e)
        {
            int customer = (int)lookUpEditCus.EditValue;
            using (db = new BEntities())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = db.vwOrderCustomers.Where(x=>x.Customer == customer).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwOrderCustomers.ToList();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwOrderCustomer)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.SaleId != -1)
                {
                    var oku = db.SaleDetails.Where(x => x.SaleId == row.SaleId).ToList();
                    foreach (var item in oku)
                    {
                        var ProductCode = db.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault().ProductCode;
                        var ProductName = db.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault().ProductName;
                        double SellingPrice = item.SellingPrice;
                        double Qty = item.Qty;
                        double Discount = item.Discount;
                        double Tax = item.TaxValue;
                        double TotalPrice = item.SoldPrice;
                        pos.dataGridView1.Rows.Add(ProductCode, ProductName, SellingPrice.ToString("##,##0.00"), Qty.ToString("##,##0.00"), Discount.ToString("##,##0.00"), Tax.ToString("##,##0.00"), TotalPrice.ToString("##,##0.00"));
                    }

                    pos.dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 12);
                    pos.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic",12, FontStyle.Bold);
                    pos.dataGridView1.RowHeadersVisible = false;
                    pos.dataGridView1.RowHeadersVisible = false;
                    pos.dataGridView1.AllowUserToAddRows = false;
                    pos.dataGridView1.AllowUserToDeleteRows = false;
                    pos.dataGridView1.AllowUserToResizeRows = false;
                    pos.dataGridView1.MultiSelect = false;

                    pos.labelBalance.Text = Convert.ToDouble(db.Sales.Where(x => x.SaleId == row.SaleId).FirstOrDefault().Balance).ToString("##,##0.00");
                    pos.labelBill.Text = Convert.ToDouble(db.Sales.Where(x => x.SaleId == row.SaleId).FirstOrDefault().Bill).ToString("##,##0.00");

                    int cus = (int)db.Sales.Where(x => x.SaleId == row.SaleId).SingleOrDefault().Customer;
                    var saletype = db.Sales.Where(x => x.SaleId == row.SaleId).SingleOrDefault().SaleType;

                    pos.lookUpEditCustomer.Properties.ValueMember = "UserId";
                    pos.lookUpEditCustomer.Properties.DisplayMember = "Name";
                    pos.lookUpEditCustomer.EditValue = cus;
                    pos.lookUpEditSaleType.EditValue = saletype;
                    pos.labelSaleId.Text = row.SaleId.ToString();

                    if(double.Parse(pos.labelBalance.Text) >= 0.5)
                    {
                        pos.textBoxTendered.Enabled = true;
                    }
                    else
                    {
                        pos.textBoxTendered.Enabled = false;
                    }

                    pos.buttonRemove.Enabled = false;
                    pos.buttonVoid.Enabled = false;
                    pos.dateEditDateSold.DateTime = (DateTime)row.DateSold;
                    pos.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}