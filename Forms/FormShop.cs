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
    public partial class FormShop : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        int ShopId;
        Shop formShop = new Shop();
        public FormShop()
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
                        PhoneTextEdit.Text = shops.Phone;
                        TextEditAddress.Text = shops.Address;
                        PhoneTextEdit.Text = shops.Phone;
                        textEditMotto.Text = shops.Motto;
                        EmailTextEdit.Text = shops.Email;
                        textEditCurrency.Text = shops.Currency;
                        dateEditExpiryAlert.Text = shops.ExpiryAlert.ToString();
                        textEditVat.Text = shops.Vat.ToString();
                        labelShopId.Text = shops.ShopId.ToString();
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

            if (String.IsNullOrEmpty(textEditCurrency.Text))
            {
                result = false;
                textEditCurrency.ErrorText = "Required";
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

            if (String.IsNullOrEmpty(dateEditExpiryAlert.Text))
            {
                result = false;
                dateEditExpiryAlert.ErrorText = "Required";
            }
            return result;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (formValid())
                {
                    using (db = new BEntities())
                    {
                        formShop.ShopId = short.Parse(labelShopId.Text);
                        formShop.ShopName = NameTextEdit.Text.ToString();
                        formShop.Address = TextEditAddress.Text.ToString();
                        formShop.Phone = PhoneTextEdit.Text.ToString();
                        formShop.Email = EmailTextEdit.Text.ToString();
                        formShop.Currency = textEditCurrency.Text.ToString();
                        formShop.Motto = textEditMotto.Text.ToString();
                        formShop.ExpiryAlert = short.Parse(dateEditExpiryAlert.Text);
                        formShop.Vat = double.Parse(textEditVat.Text);
                        db.Entry(formShop).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    loadDetails();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}