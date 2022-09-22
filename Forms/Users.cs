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
    public partial class Users : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        User user = new User();
        int UserId;
        public Users()
        {
            InitializeComponent();
            clearFields();
            loadUsers();
        }

        private void loadUsers()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwUsers.ToList();
                gridView1.Columns["Deleted"].Visible = false;
                gridView1.Columns["UserId"].Visible = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.ShowIndicator = false;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
                loadShops();
                loadGender();
            }
        }

        private void loadGender()
        {
            Dictionary<int, string> gender = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToDictionary(x => (int)x, x => x.ToString());
            textEditGender.Properties.DataSource = gender;
            textEditGender.Properties.ValueMember = "Value";
            textEditGender.Properties.DisplayMember = "Value";
        }

        public void loadShops()
        {
            using (db = new BEntities())
            {
                ShopIdLookUpEdit.Properties.DataSource = db.vwShops.ToList();
                ShopIdLookUpEdit.Properties.ValueMember = "ShopId";
                ShopIdLookUpEdit.Properties.DisplayMember = "ShopName";
            }

        }
        private void clearFields()
        {
            NameTextEdit.Text = EmailTextEdit.Text = AltEmailTextEdit.Text = PhoneTextEdit.Text = AltPhoneTextEdit.Text = PhysicalAddressTextEdit.Text = ContactAddressTextEdit.Text = string.Empty;
            textEditGender.EditValue = null;
            ShopIdLookUpEdit.EditValue = null;
            RoleIdLookUpEdit.EditValue = null;
            UserNameTextEdit.Text = string.Empty;
            PassWordTextEdit.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Caption = "Save";
            UserId = 0;
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadUsers();
            clearFields();
        }

        private bool formValid()
        {
            var result = true;
            if (String.IsNullOrEmpty(PassWordTextEdit.Text))
            {
                result = false;
                PassWordTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(UserNameTextEdit.Text))
            {
                result = false;
                UserNameTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(RoleIdLookUpEdit.Text))
            {
                result = false;
                RoleIdLookUpEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(ShopIdLookUpEdit.Text))
            {
                result = false;
                ShopIdLookUpEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(textEditGender.Text))
            {
                result = false;
                textEditGender.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(ContactAddressTextEdit.Text))
            {
                result = false;
                ContactAddressTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(PhysicalAddressTextEdit.Text))
            {
                result = false;
                PhysicalAddressTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(AltPhoneTextEdit.Text))
            {
                result = false;
                AltPhoneTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(PhoneTextEdit.Text))
            {
                result = false;
                PhoneTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(NameTextEdit.Text))
            {
                result = false;
                NameTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(EmailTextEdit.Text))
            {
                result = false;
                EmailTextEdit.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(AltEmailTextEdit.Text))
            {
                result = false;
                AltEmailTextEdit.ErrorText = "Required";
            }
            return result;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    user.Name = NameTextEdit.Text;
                    user.Gender = textEditGender.EditValue.ToString();
                    user.UserName = UserNameTextEdit.Text;
                    user.ShopId =Convert.ToInt32(ShopIdLookUpEdit.EditValue);
                    user.PassWord = PassWordTextEdit.Text;
                    user.Email = EmailTextEdit.Text;
                    user.Phone = PhoneTextEdit.Text;
                    user.Address = PhysicalAddressTextEdit.Text;
                    using (db = new BEntities())
                    {
                        if (UserId > 0)
                            db.Entry(user).State = EntityState.Modified;
                        else
                        {
                            db.Users.Add(user);
                        }
                        db.SaveChanges();
                        clearFields();
                        loadUsers();
                    }
                    XtraMessageBox.Show("User Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    user.Deleted = 1;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    clearFields();
                    loadUsers();
                }
                XtraMessageBox.Show("Record Deleted Successfully");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            var row = ((vwUser)gridView1.GetRow(selectedRows[0]));
            using (db = new BEntities())
            {
                if (row.UserId != -1)
                {
                    UserId = row.UserId;
                    user = db.Users.Where(x => x.UserId == UserId).FirstOrDefault();
                    NameTextEdit.Text = user.Name;
                    textEditGender.EditValue = user.Gender;
                    UserNameTextEdit.Text = user.UserName;
                    ShopIdLookUpEdit.EditValue = user.ShopId;
                    PassWordTextEdit.Text = user.PassWord;
                    EmailTextEdit.Text = user.Email;
                    PhoneTextEdit.Text = user.Phone;
                    PhysicalAddressTextEdit.Text = user.Address;
                }
            }
            btnSave.Caption = "Update";
            btnDelete.Enabled = true;
        }

       
    }
}