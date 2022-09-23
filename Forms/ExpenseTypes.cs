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
    public partial class ExpenseTypes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        ExpenseType expenseType = new ExpenseType();
        int ExpenseTypeId;
        public ExpenseTypes()
        {
            InitializeComponent();
            clearFields();
            loadExpenseTypes();
        }

        private void loadExpenseTypes()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwExpenseTypes.ToList();
                gridView1.Columns["ExpenseTypeId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(textEditExpenseType.Text))
            {
                result = false;
                textEditExpenseType.ErrorText = "Required";
            }
            return result;
        }
        public void clearFields()
        {
            textEditExpenseType.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            ExpenseTypeId = 0;
        }
        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to delete this record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                expenseType.Deleted = 1;
                using (db = new BEntities())
                {
                    db.Entry(expenseType).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadExpenseTypes();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    using (db = new BEntities())
                    {
                        expenseType.ExpenseTypeName = textEditExpenseType.Text;

                        if (ExpenseTypeId > 0)
                            db.Entry(expenseType).State = EntityState.Modified;
                        else
                        {
                            db.ExpenseTypes.Add(expenseType);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadExpenseTypes();
                    }
                    XtraMessageBox.Show("ExpenseType Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwExpenseType)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.ExpenseTypeId != -1)
                {
                    ExpenseTypeId = row.ExpenseTypeId;
                    expenseType = db.ExpenseTypes.Where(x => x.ExpenseTypeId == ExpenseTypeId).FirstOrDefault();
                    textEditExpenseType.Text = expenseType.ExpenseTypeName;
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }
    }
}