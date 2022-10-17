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
using System.Data.Entity;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraEditors;

namespace Katswiri.Forms
{
    public partial class Categories : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        int CategoryId;
        Category category = new Category();
        public Categories()
        {
            InitializeComponent();
            clearFields();
            loadCategories();
        }

        private void loadCategories()
        {
            using (db = new BEntities())
            {
                gridControlCategories.DataSource = db.vwCategories.ToList();
                gridView2.Columns["CategoryId"].Visible = false;
                gridView2.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControlCategories.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }
        public void clearFields()
        {
            textEditCategory.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            CategoryId = 0;
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(textEditCategory.Text))
            {
                result = false;
                textEditCategory.ErrorText = "Required";
            }
            return result;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    category.CategoryName = textEditCategory.Text;
                    using (db = new BEntities())
                    {
                        if (CategoryId > 0)
                            db.Entry(category).State = EntityState.Modified;
                        else
                        {
                            db.Categories.Add(category);
                        }
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Category Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    loadCategories();
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        var del = db.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
                        del.Deleted = 1;
                        db.Entry(del).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Record Deleted Successfully");
                    loadCategories();
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridControlCategories_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = gridView2.GetSelectedRows();
                var row = ((vwCategory)gridView2.GetRow(selectedRows[0]));
                using (db = new BEntities())
                {
                    if (row.CategoryId != -1)
                    {
                        CategoryId = row.CategoryId;
                        category = db.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
                        textEditCategory.Text = category.CategoryName;
                    }
                }
                btnSave.Caption = "Update";
                btnDelete.Enabled = true;
            }catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
    }
}