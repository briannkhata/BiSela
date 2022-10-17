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
    public partial class FormBranches : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Branch formBranches = new Branch();
        int BranchId;
        public FormBranches()
        {
            InitializeComponent();
            loadBranches();
        }

        private void loadBranches()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwBranches.ToList();
                gridView1.Columns["BranchId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }
        public void clearFields()
        {
            textEditBranch.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            BranchId = 0;
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(textEditBranch.Text))
            {
                result = false;
                textEditBranch.ErrorText = "Required";
            }
            return result;
        }


        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    using (db = new BEntities())
                    {
                        formBranches.BranchName = textEditBranch.Text;

                        if (BranchId > 0)
                            db.Entry(formBranches).State = EntityState.Modified;
                        else
                        {
                            db.Branches.Add(formBranches);
                        }
                        db.SaveChanges();

                    }
                    XtraMessageBox.Show("Shop Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    loadBranches();
                    return;
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
                        var del = db.Branches.Where(x => x.BranchId == BranchId).FirstOrDefault();
                        del.Deleted = 1;
                        db.Entry(del).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Record Deleted Successfully");
                    loadBranches();
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
            var row = ((vwBranch)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.BranchId != -1)
                {
                    BranchId = row.BranchId;
                    textEditBranch.Text = row.BranchName;
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }
    }
}