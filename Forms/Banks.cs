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
    public partial class Banks : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Bank bank = new Bank();
        int BankId;
        public Banks()
        {
            InitializeComponent();
            clearFields();
            loadBanks();
        }

        private void loadBanks()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.Banks.Where(x => x.Deleted == 0).ToList();
                gridView1.Columns["Deleted"].Visible = false;
                gridView1.Columns["BankId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                //gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }
        private void clearFields()
        {
            textEditBank.Text = string.Empty;
            btnDelete.Enabled = false;
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(textEditBank.Text))
            {
                result = false;
                textEditBank.ErrorText = "Required";
            }

            return result;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    bank.BankName = textEditBank.Text;
                    using (db = new BEntities())
                    {
                        if (BankId > 0)
                            db.Entry(bank).State = EntityState.Modified;
                        else
                        {
                            db.Banks.Add(bank);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadBanks();
                        XtraMessageBox.Show("Bank Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                using (db = new BEntities())
                {
                    bank.Deleted = 1;
                    db.Entry(bank).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadBanks();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((Bank)gridView1.GetRow(selectedRows[0]));
                if (row.BankId != -1)
                {
                    BankId = row.BankId;
                    bank = db.Banks.Where(x => x.BankId == BankId).FirstOrDefault();
                    textEditBank.Text = bank.BankName;
                }
                btnSave.Caption = "Update";
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}