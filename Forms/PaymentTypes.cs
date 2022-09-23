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
    public partial class PaymentTypes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        PaymentType paymentType = new PaymentType();
        int PaymentTypeId;
        public PaymentTypes()
        {
            InitializeComponent();
            clearFields();
            loadPaymentTypes();
        }

        private void clearFields()
        {
            textEditPaymentType.Text = textEditDescription.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            PaymentTypeId = 0;
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(textEditPaymentType.Text))
            {
                result = false;
                textEditPaymentType.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(textEditDescription.Text))
            {
                result = false;
                textEditDescription.ErrorText = "Required";
            }
            return result;
        }

        private void loadPaymentTypes()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwPaymentTypes.ToList();
                gridView1.Columns["PaymentTypeId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to delete this record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (db = new BEntities())
                {
                    paymentType.Deleted = 1;
                    db.Entry(paymentType).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadPaymentTypes();
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
                    paymentType.PaymentTypeName = textEditPaymentType.Text;
                    paymentType.Description = textEditDescription.Text;
                    using (db = new BEntities())
                    {
                        if (PaymentTypeId > 0)
                            db.Entry(paymentType).State = EntityState.Modified;
                        else
                        {
                            db.PaymentTypes.Add(paymentType);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadPaymentTypes();
                    }
                    XtraMessageBox.Show("PaymentType Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var row = ((vwPaymentType)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.PaymentTypeId != -1)
                {
                    PaymentTypeId = row.PaymentTypeId;
                    paymentType = db.PaymentTypes.Where(x => x.PaymentTypeId == PaymentTypeId).FirstOrDefault();
                    textEditPaymentType.Text = paymentType.PaymentTypeName;
                    textEditDescription.Text = paymentType.Description;
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }
    }
}