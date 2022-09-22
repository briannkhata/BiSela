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
    public partial class Products : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Product product = new Product();
        int ProductId;
        public Products()
        {
            InitializeComponent();
            clearFields();
            loadProducts();
        }

        private void clearFields()
        {
            ProductNameTextEdit.Text = ProductCodeTextEdit.Text = BarCodeTextEdit.Text = SellingPriceTextEdit.Text = string.Empty;
            CategoryIdLookUpEdit.EditValue = UnitIdLookUpEdit.EditValue = TaxTypeIdLookUpEdit.EditValue = null;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            ProductId = 0;
        }

        private void loadProducts()
        {
            using (db = new BEntities())
            {
                gridControlProducts.DataSource = db.vwProducts.ToList();
                gridView1.Columns["Deleted"].Visible = false;
                gridView1.Columns["ProductId"].Visible = false;
                gridView1.Columns["ShopName"].Visible = false;
                gridView1.Columns["TaxTypeName"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridControlProducts.EmbeddedNavigator.Buttons.Append.Visible = false;
                gridView1.OptionsView.ShowIndicator = false;
                loadTaxTypes();
                loadCategories();
                loadUnits();
                loadBrands();
            }
        }

        private void loadTaxTypes()
        {
            using (db = new BEntities())
            {
                TaxTypeIdLookUpEdit.Properties.DataSource = db.vwTaxTypes.ToList();
                TaxTypeIdLookUpEdit.Properties.ValueMember = "TaxTypeId";
                TaxTypeIdLookUpEdit.Properties.DisplayMember = "TaxTypeName";
            }
        }

        private void loadCategories()
        {
            using (db = new BEntities())
            {
                CategoryIdLookUpEdit.Properties.DataSource = db.vwCategories.ToList();
                CategoryIdLookUpEdit.Properties.ValueMember = "CategoryId";
                CategoryIdLookUpEdit.Properties.DisplayMember = "CategoryName";
            }
        }

        private void loadBrands()
        {
            using (db = new BEntities())
            {
                BrandLookUpEdit.Properties.DataSource = db.vwBrands.ToList();
                BrandLookUpEdit.Properties.ValueMember = "BrandId";
                BrandLookUpEdit.Properties.DisplayMember = "BrandName";
            }
        }

        private void loadUnits()
        {
            using (db = new BEntities())
            {
                UnitIdLookUpEdit.Properties.DataSource = db.vwUnits.ToList();
                UnitIdLookUpEdit.Properties.ValueMember = "UnitId";
                UnitIdLookUpEdit.Properties.DisplayMember = "UnitName";
            }
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(UnitIdLookUpEdit.Text))
            {
                result = false;
                UnitIdLookUpEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(TaxTypeIdLookUpEdit.Text))
            {
                result = false;
                TaxTypeIdLookUpEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(CategoryIdLookUpEdit.Text))
            {
                result = false;
                CategoryIdLookUpEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(ProductNameTextEdit.Text))
            {
                result = false;
                ProductNameTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(ProductCodeTextEdit.Text))
            {
                result = false;
                ProductCodeTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(BarCodeTextEdit.Text))
            {
                result = false;
                BarCodeTextEdit.ErrorText = "Required";
            }
            if (Double.IsNaN(Convert.ToDouble(SellingPriceTextEdit.Text)))
            {
                result = false;
                SellingPriceTextEdit.ErrorText = "Required";
            }

            if (String.IsNullOrEmpty(BrandLookUpEdit.Text))
            {
                result = false;
                BrandLookUpEdit.ErrorText = "Required";
            }
            return result;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    product.ProductName = ProductNameTextEdit.Text;
                    product.UnitId = Convert.ToInt32(UnitIdLookUpEdit.EditValue);
                    product.CategoryId = Convert.ToInt32(CategoryIdLookUpEdit.EditValue);
                    product.TaxTypeId = Convert.ToInt32(TaxTypeIdLookUpEdit.EditValue);
                    product.BrandId = Convert.ToInt32(BrandLookUpEdit.EditValue);
                    product.BarCode = BarCodeTextEdit.Text;
                    product.ProductCode = ProductCodeTextEdit.Text;
                    //product.SellingPrice = Convert.ToDouble(SellingPriceTextEdit.Text);
                    using (db = new BEntities())
                    {
                        if (ProductId > 0)
                            db.Entry(product).State = EntityState.Modified;
                        else
                        {
                            db.Products.Add(product);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadProducts();
                    }
                    XtraMessageBox.Show("Product Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to delete this Record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (db = new BEntities())
                {
                    product.Deleted = 1;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadProducts();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }

        private void gridControlProducts_DoubleClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwProduct)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.ProductId != -1)
                {
                    ProductId = row.ProductId;
                    product = db.Products.Where(x => x.ProductId == ProductId).FirstOrDefault();
                    ProductNameTextEdit.Text = product.ProductName;
                    ProductCodeTextEdit.Text = product.ProductCode;
                    BarCodeTextEdit.Text = product.BarCode;
                    UnitIdLookUpEdit.EditValue = product.UnitId;
                    CategoryIdLookUpEdit.EditValue = product.CategoryId;
                    TaxTypeIdLookUpEdit.EditValue = product.TaxTypeId;
                    BrandLookUpEdit.EditValue = product.BrandId;
                   // SellingPriceTextEdit.Text = product.SellingPrice.ToString();
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }
    }
}