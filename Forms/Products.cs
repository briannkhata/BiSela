using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Katswiri.Data;
using Katswiri.Enums;
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
            loadtaxTypesStatus();
            loadCategories();
            loadUnits();
            loadBrands();
        }

        private void clearFields()
        {
            ProductNameTextEdit.Text = ProductCodeTextEdit.Text = TextEditDescription.Text = textEditOrderLevel.Text = textEditBarcode.Text = string.Empty;
            CategoryIdLookUpEdit.EditValue = UnitIdLookUpEdit.EditValue = BrandLookUpEdit.EditValue = null;
            btnSave.Caption = "Save";
            ProductId = 0;
        }
        private void loadtaxTypesStatus()
        {
            using (db = new BEntities())
            {
                Dictionary<int, string> taxTypesStatus = Enum.GetValues(typeof(TaxTypesStatus)).Cast<TaxTypesStatus>().ToDictionary(x => (int)x, x => x.ToString());
                lookUpEditTaxStatus.Properties.DataSource = taxTypesStatus;
                lookUpEditTaxStatus.Properties.ValueMember = "Value";
                lookUpEditTaxStatus.Properties.DisplayMember = "Value";
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
            if (String.IsNullOrEmpty(lookUpEditTaxStatus.Text))
            {
                result = false;
                lookUpEditTaxStatus.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(TextEditDescription.Text))
            {
                result = false;
                TextEditDescription.ErrorText = "Required";
            }

            if (String.IsNullOrEmpty(BrandLookUpEdit.Text))
            {
                result = false;
                BrandLookUpEdit.ErrorText = "Required";
            }

            if (String.IsNullOrEmpty(textEditOrderLevel.Text))
            {
                result = false;
                textEditOrderLevel.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(textEditBarcode.Text))
            {
                result = false;
                textEditBarcode.ErrorText = "Required";
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
                    product.BrandId = Convert.ToInt32(BrandLookUpEdit.EditValue);
                    product.TaxStatus = (string)lookUpEditTaxStatus.EditValue;
                    product.ProductCode = ProductCodeTextEdit.Text;
                    product.ReOrderLevel = short.Parse(textEditOrderLevel.Text);
                    product.BarCode = textEditBarcode.Text;
                    product.Description = TextEditDescription.Text;

                    using (db = new BEntities())
                    {
                        if (Convert.ToInt32(lblProductId.Text) > 0)
                            db.Entry(product).State = EntityState.Modified;
                        else
                        {
                            db.Products.Add(product);
                        }
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Product Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    clearFields();
                    return;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}