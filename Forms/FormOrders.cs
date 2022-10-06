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
    }
}