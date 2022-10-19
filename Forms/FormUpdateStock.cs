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
    public partial class FormUpdateStock : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Stock stock;
        DateTimePicker dateTimePicker = new DateTimePicker();

        public FormUpdateStock()
        {
            InitializeComponent();
            loadstores();
            autoCompleteSearch();
        }

        public void loadstores()
        {
            Dictionary<int, string> store = Enum.GetValues(typeof(Store)).Cast<Store>().ToDictionary(x => (int)x, x => x.ToString());
            textEditLocation.Properties.DataSource = store;
            textEditLocation.Properties.ValueMember = "Value";
            textEditLocation.Properties.DisplayMember = "Value";
            textEditLocation.Properties.NullText = "Update Location";
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
                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = autoText;
            }
        }


        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (db = new BEntities())
                {
                   
                    string Comment = textEditComment.Text;
                    var RCT = textEditLocation.EditValue.ToString();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        var code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        stock = new Stock()
                        {
                            ProductId = db.Products.Where(x => x.ProductCode == code).FirstOrDefault().ProductId,
                            //SellingPrice = Double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()),
                            ExpiryDate = DateTime.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()),
                            Comment = Comment + " - " + LoginInfo.UserName,
                        };
                       

                        if (RCT == "Shop")
                        {
                            stock = new Stock()
                            {
                                Shop = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())
                            };
                        }
                        else if (RCT == "Kitchen")
                        {
                            stock = new Stock()
                            {
                                Kitchen = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())
                            };
                        }
                        else if (RCT == "Stores")
                        {
                            stock = new Stock()
                            {
                                Stores = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())
                            };
                        }
                        //db.Entry(stock).State = EntityState.Modified;
                        db.Stocks.Add(stock);
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Products Updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
                else
                {
                    XtraMessageBox.Show("There are no data to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                using (db = new BEntities())
                {
                    var products = db.Products.Where(x => x.Deleted == 0).ToList();
                    foreach (var item in products)
                    {
                        double Qty = 1;
                        DateTime expiry = DateTime.Now;
                        dataGridView1.Rows.Add(item.ProductCode, item.ProductName, Qty.ToString("##,##0.00"), expiry);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void datedateTimePicker_textchanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dateTimePicker.Text.ToString();
        }

        public void dateTimePicker_closeup(object sender, EventArgs e)
        {
            dateTimePicker.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dataGridView1.Controls.Add(dateTimePicker);
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "dd/MM/yyy";
                Rectangle rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dateTimePicker.Size = new Size(rectangle.Width, rectangle.Height);
                dateTimePicker.Location = new Point(rectangle.X, rectangle.Y);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                try
                {
                    using (var db = new BEntities())
                    {
                        var product = db.Products.Where(p => p.ProductCode == textBox1.Text).FirstOrDefault();
                        Boolean Found = false;

                        double qty = 0;

                        if (dataGridView1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == product.ProductCode && row.Cells[1].Value.ToString() == product.ProductName.ToString())
                                {
                                    var code = row.Cells[0].Value.ToString();
                                    qty = Convert.ToDouble(row.Cells[2].Value) + 1;
                                    row.Cells[2].Value = qty.ToString("##,##0.00");
                                    row.Cells[3].Value = DateTime.Now;
                                    Found = true;
                                }
                            }
                            if (!Found)
                            {
                                string ProductId = product.ProductId.ToString();
                                string ProductCode = product.ProductCode.ToString();
                                string ProductName = product.ProductName.ToString();
                                DateTime expiry = DateTime.Now;
                                double Qty = 1;
                                dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"), expiry);
                            }
                        }
                        else
                        {
                            string ProductId = product.ProductId.ToString();
                            string ProductCode = product.ProductCode.ToString();
                            string ProductName = product.ProductName.ToString();
                            DateTime expiry = DateTime.Now;
                            double Qty = 1;
                            dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"), expiry);
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            textBox1.Text = string.Empty;
        }
    }
}