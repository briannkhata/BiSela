using DevExpress.XtraEditors;
using Katswiri.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katswiri.Forms
{
    public partial class FormCustomer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        User user = new User();
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    using (db = new BEntities())
                    {
                        user.Name = textEditName.Text;
                        user.Phone = textEditPhone.Text;
                        user.UserType = "Customer";
                        user.Gender = "Other";
                        user.UserName = textEditName.Text;
                        user.PassWord = textEditName.Text;
                        user.Email = "shop@yahoo.com";
                        user.Address = "NAN";
                        user.ShopId = db.Users.Where(x => x.UserId == LoginInfo.UserId).SingleOrDefault().ShopId;
                        db.Users.Add(user);
                        db.SaveChanges();

                        //int UserId = user.UserId;
                       
                    }
                    this.Dispose();
                    this.Close();
                    
                    Pos pos = new Pos();
                    pos.Activate();
                    pos.ShowDialog();
                    //XtraMessageBox.Show("IncomeType Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (String.IsNullOrEmpty(textEditName.Text))
            {
                result = false;
                textEditName.ErrorText = "Required";
            }
            if (String.IsNullOrEmpty(textEditPhone.Text))
            {
                result = false;
                textEditPhone.ErrorText = "Required";
            }
 
            return result;
        }
    }
}