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
    public partial class IncomeTypes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        IncomeType incomeType = new IncomeType();
        int IncomeTypeId;
        public IncomeTypes()
        {
            InitializeComponent();
            clearFields();
            loadIncomeTypes();
        }

        private void loadIncomeTypes()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwIncomTypes.ToList();
                gridView1.Columns["IncomeTypeId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }
        public void clearFields()
        {
            textEditIncomeType.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            IncomeTypeId = 0;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    using (db = new BEntities())
                    {
                        incomeType.IncomeTypeName = textEditIncomeType.Text;

                        if (IncomeTypeId > 0)
                            db.Entry(incomeType).State = EntityState.Modified;
                        else
                        {
                            db.IncomeTypes.Add(incomeType);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadIncomeTypes();
                    }
                    XtraMessageBox.Show("IncomeType Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(textEditIncomeType.Text))
            {
                result = false;
                textEditIncomeType.ErrorText = "Required";
            }
             return result;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwIncomType)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.IncomeTypeId != -1)
                {
                    IncomeTypeId = row.IncomeTypeId;
                    incomeType = db.IncomeTypes.Where(x => x.IncomeTypeId == IncomeTypeId).FirstOrDefault();
                    textEditIncomeType.Text = incomeType.IncomeTypeName;
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Are you sure you want to delete this record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (db = new BEntities())
                    {
                        var del = db.IncomeTypes.Where(x => x.IncomeTypeId == IncomeTypeId).FirstOrDefault();
                        del.Deleted = 1;
                        db.Entry(del).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Record Deleted Successfully");
                    loadIncomeTypes();
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