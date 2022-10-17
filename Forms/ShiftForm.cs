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
    public partial class ShiftForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Shift shift = new Shift();
        BEntities db;
        int ShiftId;
        public ShiftForm()
        {
            InitializeComponent();
            loadShifts();
        }

        private void loadShifts()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwShifts.ToList();
                gridView1.Columns["ShiftId"].Visible = false;
                //gridView1.Columns["CloseDate"].Visible = false;
                //gridView1.Columns["OpenDate"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }

        private bool formValid()
        {
            var result = true;
            //if (String.IsNullOrEmpty(textEditClosing.Text))
            //{
            //    result = false;
            //    textEditClosing.ErrorText = "Required";
            //}

            if (String.IsNullOrEmpty(textEditOpening.Text))
            {
                result = false;
                textEditOpening.ErrorText = "Required";
            }
            return result;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    using (db = new BEntities())
                    {
                        shift.OpenBalance = Double.Parse(textEditOpening.Text);
                        shift.ShopId = db.Shops.SingleOrDefault().ShopId;
                        shift.OpenDate = DateTime.Now;
                        shift.CloseDate = DateTime.Now;

                        if (ShiftId > 0)
                        {
                            var update = db.Shifts.Where(x => x.ShiftId == ShiftId).FirstOrDefault();
                            update.CloseDate = DateTime.Now;
                            update.CloseBalance = Double.Parse(textEditClosing.Text);
                            db.Entry(update).State = EntityState.Modified;
                        }
                        else
                        {
                            db.Shifts.Add(shift);
                        }
                        db.SaveChanges();
                        loadShifts();

                    }
                    XtraMessageBox.Show("Shift Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void clearFields()
        {
            textEditClosing.Text = textEditOpening.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            ShiftId = 0;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Are you sure you want to delete this record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (db = new BEntities())
                    {
                        var del = db.Shifts.Where(x => x.ShiftId == ShiftId).FirstOrDefault();
                        del.Deleted = 1;
                        db.Entry(del).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Record Deleted Successfully");
                    loadShifts();
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwShift)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.ShiftId != -1)
                {
                    ShiftId = row.ShiftId;
                    textEditOpening.Text = row.OpenBalance.ToString();
                    textEditClosing.Text = row.CloseBalance.ToString();
                }
            }
            btnSave.Caption = "Close Shift";
            btnDelete.Enabled = true;
        }
    }
}