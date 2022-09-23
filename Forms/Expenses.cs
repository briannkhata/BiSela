using DevExpress.XtraBars;
using Katswiri.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;

namespace Katswiri.Forms
{
    public partial class Expenses : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Expens expense = new Expens();
        int ExpenseId;
        public Expenses()
        {
            InitializeComponent();
            clearFields();
            loadExpenses();
        }

        private void clearFields()
        {

            AmountTextEdit.Text = string.Empty;
            gridView1.OptionsView.ShowIndicator = false;
            ExpenseTypeId.Properties.TextEditStyle = TextEditStyles.Standard;

            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
        }

        private void loadExpenses()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwExpenses.ToList();
                gridView1.OptionsBehavior.Editable = false;
                //gridView1.Columns["UserId"].Visible = false;
                gridView1.Columns["ExpenseId"].Visible = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;


                //populate Expense typs
                ExpenseTypeId.Properties.DataSource = db.vwExpenseTypes.ToList();
                ExpenseTypeId.Properties.ValueMember = "ExpenseTypeId";
                ExpenseTypeId.Properties.DisplayMember = "ExpenseTypeName";
                ExpenseTypeId.Properties.BestFitMode = BestFitMode.BestFit;
                ExpenseTypeId.Properties.SearchMode = SearchMode.AutoComplete;
            }
        
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(AmountTextEdit.Text))
            {
                result = false;
                AmountTextEdit.ErrorText = "Required";
            }


            if (String.IsNullOrEmpty(ExpenseTypeId.Text))
            {
                result = false;
                ExpenseTypeId.ErrorText = "Required";
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

                        expense.Amount = Double.Parse(AmountTextEdit.Text);
                        expense.ExpenseTypeId = Convert.ToInt16(ExpenseTypeId.EditValue);
                        expense.UserId = 1;

                        if (ExpenseId > 0)
                            db.Entry(expense).State = EntityState.Modified;
                        else
                        {
                            db.Expenses.Add(expense);
                        }
                        db.SaveChanges();
                    }
                    clearFields();
                    loadExpenses();
                    XtraMessageBox.Show("Expense Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to delete this record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                expense.Deleted = 1;
                using (db = new BEntities())
                {
                    db.Entry(expense).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadExpenses();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwExpens)gridView1.GetRow(selectedRows[0]));
                using (db = new BEntities())
                {
                    if (row.ExpenseId != -1)
                    {
                        ExpenseId = row.ExpenseId;
                        expense = db.Expenses.Where(x => x.ExpenseId == ExpenseId).FirstOrDefault();
                        AmountTextEdit.Text = expense.Amount.ToString();
                        ExpenseTypeId.EditValue = expense.ExpenseTypeId;
                    }
                }
                btnSave.Caption = "Update";
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            clearFields();
            loadExpenses();
        }

        private void Expenses_Load(object sender, EventArgs e)
        {

        }
    }
}