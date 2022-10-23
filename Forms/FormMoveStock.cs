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
    public partial class FormMoveStock : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Stock stock;
        DateTimePicker dateTimePicker = new DateTimePicker();

        public FormMoveStock()
        {
            InitializeComponent();
            loadFrom();
            loadBranhces();
            autoCompleteSearch();
            loadFrom1();

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

        private void loadFrom1()
        {
            Dictionary<int, string> store = Enum.GetValues(typeof(Store)).Cast<Store>().ToDictionary(x => (int)x, x => x.ToString());
            textEditTo.Properties.DataSource = store;
            textEditTo.Properties.ValueMember = "Value";
            textEditTo.Properties.DisplayMember = "Value";
            textEditTo.Properties.NullText = "";

            textEditFrom.Properties.DataSource = store;
            textEditFrom.Properties.ValueMember = "Value";
            textEditFrom.Properties.DisplayMember = "Value";
            textEditFrom.Properties.NullText = "From";
        }

         private void loadFrom()
        {
            using (db = new BEntities())
            {
                textEditTo1.Properties.DataSource = db.vwBranches.ToList();
                textEditTo1.Properties.ValueMember = "BranchId";
                textEditTo1.Properties.DisplayMember = "BranchName";
                textEditTo1.Properties.NullText = "";
            }
        }

        public void loadBranhces()
        {
            //using (db = new BEntities())
            //{
            //    textEditFrom.Properties.DataSource = db.vwBranches.ToList();
            //    textEditFrom.Properties.ValueMember = "BranchId";
            //    textEditFrom.Properties.DisplayMember = "BranchName";
            //    textEditFrom.Properties.NullText = "Receive From";
            //}
        }

      

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (e.RowIndex != -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4))
                {
                    double qty = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value);
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = qty.ToString("##,##0.00");
                }
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
            if (e.ColumnIndex == 4)
            {
                dataGridView1.Controls.Add(dateTimePicker);
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "dd/MM/yyy";
                Rectangle rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dateTimePicker.Size = new Size(rectangle.Width, rectangle.Height);
                dateTimePicker.Location = new Point(rectangle.X, rectangle.Y);
            }
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (db = new BEntities())
                {
                    //var from = db.Shops.FirstOrDefault().ShopId;
                    var from = textEditFrom.Text;
                    var To = textEditTo.Text;
                    var To1 = textEditTo1.Text;
                    var comment = textEditComment.Text;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        var code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        var ProductId = db.Products.Where(x => x.ProductCode == code).FirstOrDefault().ProductId;

                        stock = new Stock()
                        {
                            ProductId = ProductId,
                            Comment = comment + " : by " + LoginInfo.UserId,
                            ShopId = db.Shops.SingleOrDefault().ShopId,
                        };

                        double oldShop = (double)db.Stocks.Where(x => x.ProductId == ProductId).FirstOrDefault().ProductId;
                        double oldStores = (double)db.Stocks.Where(x => x.ProductId == ProductId).FirstOrDefault().ProductId;
                        double oldKitchen = (double)db.Stocks.Where(x => x.ProductId == ProductId).FirstOrDefault().ProductId;

                        if (To != "")
                        {
                            if (To == "Shop")
                            {
                                stock.Shop = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                            }
                        }
                        else
                        {

                        }

                        if(from == "Stores")
                        {
                            stock.Stores = oldStores - Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        }

                        if (from == "Kitchen")
                        {
                            stock.Kitchen = oldKitchen - Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        }

                        db.Entry(stock).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    XtraMessageBox.Show("Products moved/recived successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                     Found = true;
                                }
                            }
                            if (!Found)
                            {
                                string ProductId = product.ProductId.ToString();
                                string ProductCode = product.ProductCode.ToString();
                                string ProductName = product.ProductName.ToString();
                                double Qty = 1;
                                dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"));
                            }
                        }
                        else
                        {
                            string ProductId = product.ProductId.ToString();
                            string ProductCode = product.ProductCode.ToString();
                            string ProductName = product.ProductName.ToString();
                            double Qty = 1;
                            dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"));
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