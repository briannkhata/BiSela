using DevExpress.XtraBars;
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
    public partial class FormUpdateStock : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        public FormUpdateStock()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwUpdateStocks.ToList();
                gridView1.Columns["ProductId"].Visible = false;
                gridView1.Columns["ShopId"].Visible = false;
                gridView1.Columns["Description"].Visible = false;
                gridView1.Columns["SellingPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["SellingPrice"].DisplayFormat.FormatString = "c2";
            }
        }
    }
}