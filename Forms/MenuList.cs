using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
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
    public partial class MenuList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        public MenuList()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwMenus.ToList();
                gridView1.Columns["MenuId"].Visible = false;
                gridView1.Columns["RecipeId"].Visible = false;
                gridView1.Columns["SellingPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["SellingPrice"].DisplayFormat.FormatString = "c2";
                gridView1.Columns["Cost"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["Cost"].DisplayFormat.FormatString = "c2";
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            FormAddMenu formAddMenu = new FormAddMenu();
            formAddMenu.ShowDialog();
        }
    }
}