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
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns["FoodMenuId"].Visible = false;
            gridView1.Columns["UnitPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["UnitPrice"].DisplayFormat.FormatString = "c2".Trim('$');

        }

        public void loadData()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwFoodMenus.ToList();
             
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
                        var oku = db.Ingredients.Where(x => x.FoodMenuId == row.FoodMenuId).ToList();
                        foreach (var item in oku)
                        {
                            var ProductCode = db.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault().ProductCode;
                            var ProductName = db.Products.Where(x => x.ProductId == item.ProductId).SingleOrDefault().ProductName;
                            double CP = (double)item.CostPrice;
                            double Qty = (double)item.Qty;
                            double IngredientId = item.IngredientId;
                            formAddMenu.dataGridView1.Rows.Add(ProductCode+'-'+IngredientId, ProductName, Qty.ToString("##,##0.00"), CP.ToString("##,##0.00"));
                        }
                        formAddMenu.textEditSP.Text = db.FoodMenus.Where(x => x.FoodMenuId == row.FoodMenuId).SingleOrDefault().UnitPrice.ToString();
                        formAddMenu.textEditTitle.Text = db.FoodMenus.Where(x => x.FoodMenuId == row.FoodMenuId).SingleOrDefault().Title;
                        formAddMenu.lblFoodMenuId.Text = row.FoodMenuId.ToString();
                    }
                }

                formAddMenu.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = db.vwFoodMenus.ToList();
            }
        }
    }
}