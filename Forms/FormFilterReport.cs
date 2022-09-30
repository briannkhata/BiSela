using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Katswiri.Data;
using Katswiri.Enums;
using Katswiri.Reports;
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
    public partial class FormFilterReport : DevExpress.XtraEditors.XtraForm
    {
        BEntities db;
        public FormFilterReport()
        {
            InitializeComponent();
            loadCustomers();
            loadCashiers();
            loadSaleTypes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (db = new BEntities())
            {
                SalesReport salesReport = new SalesReport();
                ReportPrintTool printTool = new ReportPrintTool(salesReport);
                //printTool.ShowPreviewDialog();
                printTool.ShowPreview();
            }
        }

        private void loadCustomers()
        {
            using (db = new BEntities())
            {
                lookUpEditCustomer.Properties.DataSource = db.Users.Where(x=>x.UserType == "Customer").ToList();
                lookUpEditCustomer.Properties.ValueMember = "UserId";
                lookUpEditCustomer.Properties.DisplayMember = "Name";
                lookUpEditCustomer.Properties.NullText = "Customer";
            }
        }

        private void loadCashiers()
        {
            using (db = new BEntities())
            {
                lookUpEditCashier.Properties.DataSource = db.Users.Where(x => x.UserType == "Staff").ToList();
                lookUpEditCashier.Properties.ValueMember = "UserId";
                lookUpEditCashier.Properties.DisplayMember = "Name";
                lookUpEditCashier.Properties.NullText = "Staff";
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
                lookUpEditSaleType.Properties.NullText = "Sale Type";
            }
        }

        private void PaymentTypes()
        {
            using (db = new BEntities())
            {
                lookUpEditPaymentType.Properties.DataSource = db.PaymentTypes.Where(x => x.Deleted == 0).ToList();
                lookUpEditPaymentType.Properties.ValueMember = "Value";
                lookUpEditPaymentType.Properties.DisplayMember = "Value";
                lookUpEditPaymentType.Properties.NullText = "Payment Type";
            }
        }
    }
}