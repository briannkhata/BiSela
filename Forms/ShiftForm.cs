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
                gridControl1.DataSource = db.Shifts.Where(x=>x.Deleted == 0).ToList();
                gridView1.Columns["ShiftId"].Visible = false;
                gridView1.Columns["Deleted"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            }
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(textEditClosing.Text))
            {
                result = false;
                textEditClosing.ErrorText = "Required";
            }

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
                    shift.OpenBalance = Double.Parse(textEditOpening.Text);
                    shift.CloseBalance = Double.Parse(textEditClosing.Text);
                    shift.CloseDate = DateTime.Now;
                    shift.OpenDate = DateTime.Now;
                    using (db = new BEntities())
                    {
                        shift.ShopId = db.Shops.SingleOrDefault().ShopId;
                        if (ShiftId > 0)
                            db.Entry(shift).State = EntityState.Modified;
                        else
                        {
                            db.Shifts.Add(shift);
                        }
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Shift Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearFields()
        {
            textEditClosing.Text = textEditOpening.Text = string.Empty;
            //btnDelete.Enabled = false;
            //btnSave.Caption = "Save";
            //ProductId = 0;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
                if (XtraMessageBox.Show("Are you sure you want to delete this Record ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (db = new BEntities())
                    {
                        shift.Deleted = 1;
                        db.Entry(shift).State = EntityState.Modified;
                        db.SaveChanges();
                        clearFields();
                        loadShifts();
                    }
                    XtraMessageBox.Show("Record Deleted Successfully");
                }
            
        }
    }
}