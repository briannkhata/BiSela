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
            var row = ((Sale)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.SaleId != -1)
                {
                    //PaymentTypeId = row.PaymentTypeId;
                    //paymentType = db.PaymentTypes.Where(x => x.PaymentTypeId == PaymentTypeId).FirstOrDefault();
                    //textEditPaymentType.Text = paymentType.PaymentTypeName;
                    //textEditDescription.Text = paymentType.Description;
                    pos.dataGridView1.DataSource = db.SaleDetails.Where(x => x.SaleId == row.SaleId).ToList();
                    pos.lookUpEditCustomer.EditValue = row.Customer;
                    pos.lookUpEditSaleType.EditValue = row.SaleType;
                    pos.labelSaleId.Text = row.SaleId.ToString();
                    pos.dateEditDateSold.DateTime = (DateTime)row.DateSold;
                    pos.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}