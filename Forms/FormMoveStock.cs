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
    public partial class FormMoveStock : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        public FormMoveStock()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwStocks.ToList();
                gridView1.Columns["UnitId"].Visible = false;
                gridView1.Columns["ProductId"].Visible = false;
                gridView1.Columns["ShopId"].Visible = false;
                gridView1.Columns["BarCode"].Visible = false;

                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                //gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }
    }
}