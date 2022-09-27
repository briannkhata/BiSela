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
        User user;
        Sale sale;
        Pos pos = null;
        public FormCustomer()
        {
            InitializeComponent();
            loadCustomers();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    using (db = new BEntities())
                    {
                        user = new User()
                        {
                            Name = textEditName.Text,
                            Phone = textEditPhone.Text,
                            UserType = "Customer",
                            Gender = "Other",
                            UserName = textEditName.Text,
                            PassWord = textEditName.Text,
                            Email = "shop@yahoo.com",
                            Address = "NAN",
                            ShopId = db.Users.Where(x => x.UserId == LoginInfo.UserId).SingleOrDefault().ShopId,
                        };

                        db.Users.Add(user);
                        db.SaveChanges();
                        int UserId = user.UserId;

                        sale = new Sale()
                        { 
                            Customer = UserId,
                            SoldBy = LoginInfo.UserId,
                            DateSold = DateTime.Now,
                            ShopId = db.Users.Where(x => x.UserId == LoginInfo.UserId).SingleOrDefault().ShopId,
                        };
                        db.Sales.Add(sale);
                        db.SaveChanges();


                    }
                    this.Dispose();
                    this.Close();
                    pos = new Pos();
                    pos.Activate();
                    pos.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void loadCustomers()
        {
            using (db = new BEntities())
            {
                lookUpEditCustomer.Properties.DataSource = db.vwCustomers.Where(x=>x.UserType == "Customer").ToList();
                lookUpEditCustomer.Properties.ValueMember = "UserId";
                lookUpEditCustomer.Properties.DisplayMember = "Name";
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

        private void lookUpEditCustomer_EditValueChanged(object sender, EventArgs e)
        {
            int UserId = (int)lookUpEditCustomer.EditValue;
            //XtraMessageBox.Show(UserId.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
            this.Close();
            pos = new Pos();
            pos.Activate();
            pos.ShowDialog();
        }
    }
}