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
    public partial class Brands : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Brand brand = new Brand();
        int BrandId;
        public Brands()
        {
            InitializeComponent();
            clearFields();
            loadBrands();
        }

        private void clearFields()
        {
            BrandDescriptionTextEdit.Text = BrandNameTextEdit.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            BrandId = 0;
        }

        private void loadBrands()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwBrands.ToList();
                gridView1.Columns["BrandId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(BrandNameTextEdit.Text))
            {
                result = false;
                BrandNameTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(BrandDescriptionTextEdit.Text))
            {
                result = false;
                BrandDescriptionTextEdit.ErrorText = "Required";
            }
          
            return result;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    brand.BrandName = BrandNameTextEdit.Text;
                    brand.BrandDescription = BrandDescriptionTextEdit.Text;
                    using (db = new BEntities())
                    {
                        if (BrandId > 0)
                            db.Entry(brand).State = EntityState.Modified;
                        else
                        {
                            db.Brands.Add(brand);
                        }
                        db.SaveChanges();
                    }
                    clearFields();
                    loadBrands();
                    XtraMessageBox.Show("Brand Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Are you sure you want to delete this record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (db = new BEntities())
                    {
                        var del = db.Brands.Where(x => x.BrandId == BrandId).FirstOrDefault();
                        del.Deleted = 1;
                        db.Entry(del).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Record Deleted Successfully");
                    loadBrands();
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwBrand)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.BrandId != -1)
                {
                    BrandId = row.BrandId;
                    BrandDescriptionTextEdit.Text = row.BrandDescription;
                    BrandNameTextEdit.Text = row.BrandName;
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }
    }
}