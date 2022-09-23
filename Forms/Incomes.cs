using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraEditors.Repository;
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
using DevExpress.XtraEditors.Controls;

namespace Katswiri.Forms
{
    public partial class Incomes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Income income = new Income();
        int IncomeId;
        public Incomes()
        {
            InitializeComponent();
            clearFields();
            loadIncomes();
        }

        private void clearFields()
        {
            AmountTextEdit.Text  = IncomeTypeId.Text = string.Empty;
            IncomeTypeId.Properties.TextEditStyle = TextEditStyles.Standard;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            IncomeId = 0;
        }

        private void loadIncomes()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwIncomes.ToList();
                gridView1.OptionsBehavior.Editable = false;
                //gridView1.Columns["UserId"].Visible = false;
                gridView1.Columns["IncomeId"].Visible = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;

                IncomeTypeId.Properties.DataSource = db.vwIncomTypes.ToList();
                IncomeTypeId.Properties.ValueMember = "IncomeTypeId";
                IncomeTypeId.Properties.DisplayMember = "IncomeType";
                IncomeTypeId.Properties.BestFitMode = BestFitMode.BestFit;
                IncomeTypeId.Properties.SearchMode = SearchMode.AutoComplete;
            }

        }

        public void incomeType()
        {
            using (db = new BEntities())
            {
                IncomeTypeId.Properties.DataSource = db.vwIncomTypes.ToList();
                IncomeTypeId.Properties.ValueMember = "IncomeTypeId";
                IncomeTypeId.Properties.DisplayMember = "IncomeType";
                IncomeTypeId.Properties.BestFitMode = BestFitMode.BestFit;
                IncomeTypeId.Properties.SearchMode = SearchMode.AutoComplete;
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
            if (String.IsNullOrEmpty(IncomeTypeId.Text))
            {
                result = false;
                IncomeTypeId.ErrorText = "Required";
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
                        income.Amount = (double)Decimal.Parse(AmountTextEdit.Text);
                        income.IncomeTypeId = Convert.ToInt16(IncomeTypeId.EditValue);
                        income.UserId = 1;

                        if (IncomeId > 0)
                            db.Entry(income).State = EntityState.Modified;
                        else
                        {
                            db.Incomes.Add(income);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadIncomes();
                    }
                    XtraMessageBox.Show("Income Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                income.Deleted = 1;
                using (db = new BEntities())
                {
                    db.Entry(income).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadIncomes();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwIncome)gridView1.GetRow(selectedRows[0]));
                using (db = new BEntities())
                {
                    if (row.IncomeId != -1)
                    {
                        IncomeId = row.IncomeId;
                        income = db.Incomes.Where(x => x.IncomeId == IncomeId).FirstOrDefault();
                        AmountTextEdit.Text = income.Amount.ToString();
                        IncomeTypeId.EditValue = income.IncomeTypeId;
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
            loadIncomes();
        }
    }
}