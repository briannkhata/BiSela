using DevExpress.XtraBars;
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
    public partial class FormAddMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        public FormAddMenu()
        {
            InitializeComponent();
            autoCompleteSearch();
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void autoCompleteSearch()
        {
            using (db = new BEntities())
            {
                AutoCompleteStringCollection autoText = new AutoCompleteStringCollection();
                foreach (Product product in db.Products.ToList())
                {
                    autoText.Add(product.ProductCode);
                }
                textBoxCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxCode.AutoCompleteCustomSource = autoText;
            }
        }

        private void textBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                try
                {
                    using (var db = new BEntities())
                    {
                        var product = db.Products.Where(p => p.ProductCode == textBoxCode.Text).FirstOrDefault();
                        string ProductId = product.ProductId.ToString();
                        string ProductCode = product.ProductCode.ToString();
                        string ProductName = product.ProductName.ToString();
                        double Qty = 1;
                        double CP = 0.00;
                        dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"), CP);                      
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textBoxCode.Text = string.Empty;

        }
    }
}