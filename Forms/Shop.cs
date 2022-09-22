﻿using DevExpress.XtraBars;
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
    public partial class Shop : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        int ShopId;
        Shop shop = new Shop();
        public Shop()
        {
            InitializeComponent();
            loadDetails();
        }

        public void loadDetails()
        {
            try
            {
                using (db = new BEntities())
                {
                   var shops = db.Shops.FirstOrDefault();
                    if (shops != null)
                    {
                        ShopId = shops.ShopId;
                        NameTextEdit.Text = shops.ShopName;
                        PhoneTextEdit.Text = shops.Currency;
                        TextEditAddress.Text = shops.Address;
                        PhoneTextEdit.Text = shops.Phone;
                        TextEditAddress.Text = shops.Motto;
                        EmailTextEdit.Text = shops.Email;
                    }
                }
             
               
            } 
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool formValid()
        {
            var result = true;
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

            if (String.IsNullOrEmpty(PhoneTextEdit.Text))
            {
                result = false;
                PhoneTextEdit.ErrorText = "Required";
            }

            if (String.IsNullOrEmpty(textEditMotto.Text))
            {
                result = false;
                textEditMotto.ErrorText = "Required";
            }

            if (String.IsNullOrEmpty(TextEditAddress.Text))
            {
                result = false;
                TextEditAddress.ErrorText = "Required";
            }

            if (String.IsNullOrEmpty(TextEditAddress.Text))
            {
                result = false;
                TextEditAddress.ErrorText = "Required";
            }

            if (String.IsNullOrEmpty(textEditMotto.Text))
            {
                result = false;
                textEditMotto.ErrorText = "Required";
            }

            if (String.IsNullOrEmpty(textEditCurrency.Text))
            {
                result = false;
                textEditCurrency.ErrorText = "Required";
            }
            return result;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //if (formValid())
                //{
                //    shop.sho = NameTextEdit.Text?.ToString();
                //    shop.Address = AddressTextEdit.Text?.ToString();
                //    shop.Phone = PhoneTextEdit.Text?.ToString();
                //    shop.Email = EmailTextEdit.Text?.ToString();
                //    shop.Fee = Convert.ToDouble(TextEditAddress.Text);
                //    shop.Terms = termsTextEdit.Text.ToString();


                //    using (db = new BEntities())
                //    {
                //        if (ShopId > 0)
                //            db.Entry(shop).State = EntityState.Modified;
                //        else
                //        {
                //            db.Shops.Add(shop);
                //        }
                //        db.SaveChanges();
                //        loadDetails();
                //    }
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}