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
    public partial class Units : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Unit unit = new Unit();
        int UnitId;
        public Units()
        {
            InitializeComponent();
            clearFields();
            loadUnits();
        }

        private void loadUnits()
        {
            using (db = new BEntities())
            {
                gridControlUnits.DataSource = db.vwUnits.ToList();
                gridView1.Columns["Deleted"].Visible = false;
                gridView1.Columns["UnitId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControlUnits.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }

        public void clearFields()
        {
            textEditUnit.Text = textEditSubUnit.Text = textEditSubUnitNameValue.Text = textEditUnitNameValue.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            UnitId = 0;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if(formValid())
                {
                    unit.UnitName = textEditUnit.Text;
                    unit.SubUnit = textEditSubUnit.Text;
                    unit.SubUnitValue = Convert.ToDouble(textEditSubUnitNameValue.Text);
                    unit.UnitValue = Convert.ToDouble(textEditUnitNameValue.Text);
                    using (db = new BEntities())
                    {
                        if (UnitId > 0)
                            db.Entry(unit).State = EntityState.Modified;
                        else
                        {
                            db.Units.Add(unit);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadUnits();
                    }
                    XtraMessageBox.Show("Unit Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(textEditUnit.Text))
            {
                result = false;
                textEditUnit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(textEditSubUnit.Text))
            {
                result = false;
                textEditSubUnit.ErrorText = "Required";
            }
            return result;
        }

        private void gridControlUnits_DoubleClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwUnit)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.UnitId != -1)
                {
                    UnitId = row.UnitId;
                    unit = db.Units.Where(x => x.UnitId == UnitId).FirstOrDefault();
                    textEditUnit.Text = unit.UnitName;
                    textEditSubUnit.Text = unit.SubUnit;
                    textEditSubUnitNameValue.Text = unit.SubUnitValue.ToString();
                    textEditUnitNameValue.Text = unit.UnitValue.ToString();
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to delete this Record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                unit.Deleted = 1;
                using (db = new BEntities())
                {
                    db.Entry(unit).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadUnits();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }
    }
}