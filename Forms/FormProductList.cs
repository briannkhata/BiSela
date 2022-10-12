using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Katswiri.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katswiri.Forms
{
    public partial class FormProductList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Product product = new Product();
        public FormProductList()
        {
            InitializeComponent();
            loadProducts();
            loadBrands();
            loadCategories();
            loadUnits();
            //gridView1.Columns["ProductId"].Visible = false;
            //gridView1.Columns["BrandId"].Visible = false;
            //gridView1.Columns["UnitId"].Visible = false;
            btnDelete.Enabled = false;
        }


        private void loadProducts()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwProducts.ToList();
                //gridView1.Columns["Product Id"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
                //gridView1.OptionsView.ShowIndicator = false;
            
            }
        }

        private void loadCategories()
        {
            using (db = new BEntities())
            {
                searchLookUpEditCategory.Properties.DataSource = db.vwCategories.ToList();
                searchLookUpEditCategory.Properties.ValueMember = "CategoryId";
                searchLookUpEditCategory.Properties.DisplayMember = "CategoryName";
                searchLookUpEditCategory.Properties.NullText = "Product Category";

            }
        }

        private void loadBrands()
        {
            using (db = new BEntities())
            {
                searchLookUpEditBrand.Properties.DataSource = db.vwBrands.ToList();
                searchLookUpEditBrand.Properties.ValueMember = "BrandId";
                searchLookUpEditBrand.Properties.DisplayMember = "BrandName";
                searchLookUpEditBrand.Properties.NullText = "Product Brand";

            }
        }

        private void loadUnits()
        {
            using (db = new BEntities())
            {
                searchLookUpEditUnit.Properties.DataSource = db.vwUnits.ToList();
                searchLookUpEditUnit.Properties.ValueMember = "UnitId";
                searchLookUpEditUnit.Properties.DisplayMember = "UnitName";
                searchLookUpEditUnit.Properties.NullText = "Unit Category";

            }
        }
        private void FormProductList_Load(object sender, EventArgs e)
        {

        }

        private void searchLookUpEditCategory_EditValueChanged(object sender, EventArgs e)
        {
            int categoryId = (int)searchLookUpEditCategory.EditValue;
            using (db = new BEntities())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = db.vwProducts.Where(x=>x.CategoryId == categoryId).ToList();
                //gridView1.Columns["Product Id"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
                //gridView1.OptionsView.ShowIndicator = false;

            }
        }

        private void searchLookUpEditBrand_EditValueChanged(object sender, EventArgs e)
        {
            int brandId = (int)searchLookUpEditBrand.EditValue;
            using (db = new BEntities())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = db.vwProducts.Where(x => x.BrandId == brandId).ToList();
                //gridView1.Columns["Product Id"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
                //gridView1.OptionsView.ShowIndicator = false;

            }
        }

        private void searchLookUpEditUnit_EditValueChanged(object sender, EventArgs e)
        {
            int unitId = (int)searchLookUpEditUnit.EditValue;
            using (db = new BEntities())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = db.vwProducts.Where(x => x.UnitId == unitId).ToList();
                //gridView1.Columns["Product Id"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
                //gridView1.OptionsView.ShowIndicator = false;

            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwProducts.ToList();
                //gridView1.Columns["Product Id"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
                //gridView1.OptionsView.ShowIndicator = false;

            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to delete this Record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (db = new BEntities())
                {
                    product.Deleted = 1;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    loadProducts();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwProduct)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.ProductId != -1)
                {
                    //ProductId = row.ProductId;
                    //product = db.Products.Where(x => x.ProductId == ProductId).FirstOrDefault();
                    //ProductNameTextEdit.Text = product.ProductName;
                    //ProductCodeTextEdit.Text = product.ProductCode;
                    //lookUpEditTaxStatus.EditValue = product.TaxStatus;
                    //UnitIdLookUpEdit.EditValue = product.UnitId;
                    //CategoryIdLookUpEdit.EditValue = product.CategoryId;
                    //BrandLookUpEdit.EditValue = product.BrandId;
                    //textEditOrderLevel.Text = product.ReOrderLevel.ToString();
                }
            }
            btnDelete.Enabled = true;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Products products = new Products();
            products.ShowDialog();
        }
    }
}