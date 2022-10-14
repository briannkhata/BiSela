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
        Recipe recipe;
        //Menu menu;
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
                        dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"), CP.ToString("##,##0.00"));                      
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textBoxCode.Text = string.Empty;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (e.RowIndex != -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4))
                {
                    double qty = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value);
                    double CP = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["CostPrice"].Value);
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = qty.ToString("##,##0.00");
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = CP.ToString("##,##0.00");
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (db = new BEntities())
                {
                    double tcost = 0.00;
                    string Title = textEditTitle.Text;
                    double SP = Double.Parse(textEditSP.Text);
                    double CP = Double.Parse(textEditCP.Text);


                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        tcost += Double.Parse((string)dataGridView1.Rows[i].Cells[3].Value);
                    }

                    //receiving = new Receiving()
                    //{
                    //    TotalBill = total,
                    //    SubTotal = torder,
                    //    Supplier = Sup,
                    //    ReceivingDate = DR,
                    //    PurchasingOrder = PO,
                    //    DeliveryDate = DD,
                    //    DeliveryNote = DN,
                    //    UserId = LoginInfo.UserId,
                    //};
                    //db.Receivings.Add(receiving);
                    //db.SaveChanges();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        var code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        recipe = new Recipe()
                        {
                            ProductId = db.Products.Where(x => x.ProductCode == code).FirstOrDefault().ProductId,
                            Qty = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                            CostPrice = Double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                        };
                        db.Recipes.Add(recipe);
                        db.SaveChanges();


                       
                        //    stock = new Stock()
                        //    {
                        //        ProductId = receivingDetail.ProductId,
                        //        ShopId = db.Shops.SingleOrDefault().ShopId,
                        //        Stores = receivingDetail.Qty,
                        //        SellingPrice = receivingDetail.SellingPrice,
                        //        ExpiryDate = receivingDetail.ExpiryDate,
                        //        OrderPrice = receivingDetail.OrderPrice
                        //    };
                      
                        //db.Stocks.Add(stock);
                        //db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}