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
    public partial class FormPayments : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        public FormPayments()
        {
            InitializeComponent();
            loadPayments();
        } 

        private void loadPayments()
        {
            //Pos pos = new Pos();
            //var saleId = pos.labelSaleId.Text.ToString();

            //int saleId2 = short.Parse(saleId);
            
            //using (db = new BEntities())
            //{
            //    gridControl1.DataSource = db.vwPayments.Where(x => x.SaleId == saleId2).ToList();
            //    gridView1.OptionsBehavior.Editable = false;
            //    gridView1.OptionsView.ShowIndicator = false;
            //    gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            //}
        }
    }
}