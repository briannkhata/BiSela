using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Katswiri.Data;
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
    }
}