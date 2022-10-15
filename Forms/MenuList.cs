using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
                gridControl1.DataSource = db.vwFoodMenus.ToList();
                gridView1.Columns["FoodMenuId"].Visible = false;
                gridView1.Columns["UnitPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["UnitPrice"].DisplayFormat.FormatString = "c2".Trim('$');
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            FormAddMenu formAddMenu = new FormAddMenu();
            formAddMenu.ShowDialog();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FormAddMenu formAddMenu = new FormAddMenu();
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwFoodMenu)gridView1.GetRow(selectedRows[0]));
                using (db = new BEntities())
                {
                    if (row.FoodMenuId != -1)
                    {
                        formAddMenu.dataGridView1.DataSource = db.Ingredients.Where(x => x.FoodMenuId == row.FoodMenuId).ToList();
                        //IncomeId = row.IncomeId;
                        //AmountTextEdit.Text = row.Amount.ToString();
                        //IncomeTypeId.EditValue = row.IncomeTypeId.ToString();
                    }
                }
                //btnSave.Caption = "Update";
                //btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}