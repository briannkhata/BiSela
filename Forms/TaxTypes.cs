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
    public partial class TaxTypes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        TaxType taxType = new TaxType();
        int TaxTypeId;
        public TaxTypes()
        {
            InitializeComponent();
            clearFields();
            loadTaxTypes();
            loadtaxTypesStatus();
        }

        private void clearFields()
        {
            TaxTypeNameTextEdit.Text = TaxTypeStatusTextEdit.Text = TaxTypeValueTextEdit.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            TaxTypeId = 0;
        }

        private void loadtaxTypesStatus()
        {
            using (db = new BEntities())
            {
                Dictionary<int, string> taxTypesStatus = Enum.GetValues(typeof(TaxTypesStatus)).Cast<TaxTypesStatus>().ToDictionary(x => (int)x, x => x.ToString());
                TaxTypeStatusTextEdit.Properties.DataSource = taxTypesStatus;
                TaxTypeStatusTextEdit.Properties.ValueMember = "Value";
                TaxTypeStatusTextEdit.Properties.DisplayMember = "Value";
            }
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(TaxTypeNameTextEdit.Text))
            {
                result = false;
                TaxTypeNameTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(TaxTypeStatusTextEdit.Text))
            {
                result = false;
                TaxTypeStatusTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(TaxTypeValueTextEdit.Text))
            {
                result = false;
                TaxTypeValueTextEdit.ErrorText = "Required";
            }
            return result;
        }

        private void loadTaxTypes()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwTaxTypes.ToList();
                gridView1.Columns["TaxTypeId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
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
                        taxType.TaxTypeName = TaxTypeNameTextEdit.Text;
                        taxType.TaxTypeValue = Convert.ToDouble(TaxTypeValueTextEdit.Text);
                        taxType.TaxTypeStatus = TaxTypeStatusTextEdit.Text;
                        if (TaxTypeId > 0)
                            db.Entry(taxType).State = EntityState.Modified;
                        else
                        {
                            db.TaxTypes.Add(taxType);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadTaxTypes();
                    }
                    XtraMessageBox.Show("Tax Type Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    taxType.Deleted = 1;
                    db.Entry(taxType).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadTaxTypes();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwTaxType)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.TaxTypeId != -1)
                {
                    TaxTypeId = row.TaxTypeId;
                    taxType = db.TaxTypes.Where(x => x.TaxTypeId == TaxTypeId).FirstOrDefault();
                    TaxTypeNameTextEdit.Text = taxType.TaxTypeName;
                    TaxTypeStatusTextEdit.EditValue = taxType.TaxTypeStatus;
                    TaxTypeValueTextEdit.Text = taxType.TaxTypeValue.ToString();
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }

    }
}