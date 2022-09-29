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
        //Pos pos = null;
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
                    setParams2();
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
                lookUpEditCustomer2.Properties.DataSource = db.vwCustomers.Where(x=>x.UserType == "Customer").ToList();
                lookUpEditCustomer2.Properties.ValueMember = "UserId";
                lookUpEditCustomer2.Properties.DisplayMember = "Name";
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

        private void lookUpEditCustomer2_EditValueChanged(object sender, EventArgs e)
        {
            
            this.Close();
            setParams();
        }
        public void setParams2()
        {
            Pos pos = new Pos();
            using (db = new BEntities())
            {
                int customer = db.Users.Where(x => x.UserType == "Customer").Max(x => x.UserId);
                pos.lookUpEditCustomer.Properties.DataSource = db.Users.Where(x => x.UserType == "Customer").ToList();
                pos.lookUpEditCustomer.Properties.ValueMember = "UserId";
                pos.lookUpEditCustomer.Properties.DisplayMember = "Name";
                pos.lookUpEditCustomer.EditValue = customer;
                pos.lookUpEditCustomer.Properties.NullText = "Customer";

                pos.lookUpEditSaleId.Properties.DataSource = db.Sales.ToList();
                pos.lookUpEditSaleId.Properties.ValueMember = "SaleId";
                pos.lookUpEditSaleId.Properties.DisplayMember = "SaleId";
                pos.lookUpEditSaleId.EditValue = db.Sales.Where(x => x.Customer == customer).Max(x => x.SaleId);
                pos.lookUpEditSaleId.Properties.NullText = "Order Number";
            }
            pos.Activate();
            pos.ShowDialog();
        }

        public void setParams()
        {
            Pos pos = new Pos();
            using (db = new BEntities())
            {
                pos.lookUpEditCustomer.Properties.DataSource = db.Users.Where(x => x.UserType == "Customer").ToList();
                pos.lookUpEditCustomer.Properties.ValueMember = "UserId";
                pos.lookUpEditCustomer.Properties.DisplayMember = "Name";
                pos.lookUpEditCustomer.EditValue = (int)lookUpEditCustomer2.EditValue;
                pos.lookUpEditCustomer.Properties.NullText = "Customer";

                pos.lookUpEditSaleId.Properties.DataSource = db.Sales.ToList();
                pos.lookUpEditSaleId.Properties.ValueMember = "SaleId";
                pos.lookUpEditSaleId.Properties.DisplayMember = "SaleId";
                pos.lookUpEditSaleId.EditValue = db.Sales.Where(x => x.Customer == (int)lookUpEditCustomer2.EditValue).Max(x => x.SaleId);
                pos.lookUpEditSaleId.Properties.NullText = "Order Number";
            }
            pos.Activate();
            pos.ShowDialog();
        }
    }
}