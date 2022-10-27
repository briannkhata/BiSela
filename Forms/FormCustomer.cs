using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
            loadWaiters();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (textEditName.Text != "" && textEditPhone.Text != "")
                {

                        using (db = new BEntities())
                        {
                            user = new User()
                            {
                                Name = textEditName.Text,
                                Phone = textEditPhone.Text,
                                Gender = "Other",
                                UserName = textEditName.Text,
                                PassWord = textEditName.Text,
                                UserType = "Customer",
                                Email = "shop@yahoo.com",
                                ShopId = db.Shops.SingleOrDefault().ShopId,
                            };
                            db.Users.Add(user);
                            db.SaveChanges();
                            int UserId = user.UserId;

                            sale = new Sale()
                            {
                                Customer = UserId,
                                Waiter = (int?)lookUpEditWaiter.EditValue,
                                SoldBy = LoginInfo.UserId,
                                DateSold = DateTime.Now,
                                ShopId = db.Shops.SingleOrDefault().ShopId,
                            };
                            db.Sales.Add(sale);
                            db.SaveChanges();
                        }
                        setParams2();
                }

                if(lookUpEditCustomer2.EditValue == null)
                {
                    setParams();
                }

                if (lookUpEditCustomer2.EditValue != null)
                {
                    setParams3();
                 
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void loadCustomers()
        {
            using (db = new BEntities())
            {
                lookUpEditCustomer2.Properties.DataSource = db.vwCustomers.Where(x=>x.UserType == "Customer").ToList();
                lookUpEditCustomer2.Properties.ValueMember = "UserId";
                lookUpEditCustomer2.Properties.DisplayMember = "Name";
               //lookUpEditCustomer2.EditValue = db.vwCustomers.Where(x => x.UserType == "Customer" && x.Name == "WalkIn").FirstOrDefault().UserId;
            }
        }

        private void loadWaiters()
        {
            using (db = new BEntities())
            {
                lookUpEditWaiter.Properties.DataSource = db.vwUsers.Where(x => x.UserType == "Waiter").ToList();
                lookUpEditWaiter.Properties.ValueMember = "UserId";
                lookUpEditWaiter.Properties.DisplayMember = "Name";
                lookUpEditWaiter.EditValue = db.vwUsers.Where(x => x.UserType == "Waiter").Max(x => x.UserId);
            }
        }
      

        private void lookUpEditCustomer2_EditValueChanged(object sender, EventArgs e)
        {
                //this.Close();
                //setParams();
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
                pos.labelSaleId.Text = db.Sales.Where(x => x.Customer == customer).Max(x => x.SaleId).ToString();
            }
            pos.Activate();
            pos.ShowDialog();
            this.Dispose();
        }

        public void setParams()
        {
            Pos pos = new Pos();
            using (db = new BEntities())
            {
                int customerId = db.Users.Where(x => x.UserType == "Customer" && x.Name == "WalkIn").FirstOrDefault().UserId;
                sale = new Sale()
                {
                    Customer = customerId,
                    SoldBy = LoginInfo.UserId,
                    DateSold = DateTime.Now,
                    Waiter = (int?)lookUpEditWaiter.EditValue,
                    ShopId = db.Shops.SingleOrDefault().ShopId,
                };
                db.Sales.Add(sale);
                db.SaveChanges();

                pos.lookUpEditCustomer.Properties.DataSource = db.Users.Where(x => x.UserType == "Customer").ToList();
                pos.lookUpEditCustomer.Properties.ValueMember = "UserId";
                pos.lookUpEditCustomer.Properties.DisplayMember = "Name";
                pos.lookUpEditCustomer.EditValue = customerId;
                //pos.lookUpEditCustomer.Properties.NullText = "Customer";
                pos.labelSaleId.Text = db.Sales.Where(x => x.Customer == customerId).Max(x => x.SaleId).ToString();
               
            }
            pos.Activate();
            pos.ShowDialog();
            this.Dispose();
        }


        public void setParams3()
        {
            Pos pos = new Pos();
            using (db = new BEntities())
            {
                int customerId = db.Users.Where(x => x.UserType == "Customer" && x.Name == "WalkIn").FirstOrDefault().UserId;
                pos.lookUpEditCustomer.Properties.DataSource = db.Users.Where(x => x.UserType == "Customer").ToList();
                pos.lookUpEditCustomer.Properties.ValueMember = "UserId";
                pos.lookUpEditCustomer.Properties.DisplayMember = "Name";
                pos.lookUpEditCustomer.EditValue = (int)lookUpEditCustomer2.EditValue;
                //pos.lookUpEditCustomer.Properties.NullText = "Customer";
                pos.labelSaleId.Text = db.Sales.Where(x => x.Customer == (int)lookUpEditCustomer2.EditValue).Max(x => x.SaleId).ToString();
                sale = new Sale()
                {
                    Customer = (int)lookUpEditCustomer2.EditValue,
                    SoldBy = LoginInfo.UserId,
                    DateSold = DateTime.Now,
                    Waiter = (int?)lookUpEditWaiter.EditValue,
                    ShopId = db.Shops.SingleOrDefault().ShopId,
                };
                db.Sales.Add(sale);
                db.SaveChanges();
            }
            pos.Activate();
            pos.ShowDialog();
            this.Dispose();
        }
    }
}