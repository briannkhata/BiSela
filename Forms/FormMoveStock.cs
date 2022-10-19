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
            loadTo();
            loadBranhces();
            autoCompleteSearch();
            loadDestination();

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

        private void loadDestination()
        {
            Dictionary<int, string> store = Enum.GetValues(typeof(Store)).Cast<Store>().ToDictionary(x => (int)x, x => x.ToString());
            textEditDestination.Properties.DataSource = store;
            textEditDestination.Properties.ValueMember = "Value";
            textEditDestination.Properties.DisplayMember = "Value";
            textEditDestination.Properties.NullText = "Move To";
        }
        private void loadTo()
        {
            using (db = new BEntities())
            {
                textEditTo.Properties.DataSource = db.vwBranches.ToList();
                textEditTo.Properties.ValueMember = "BranchId";
                textEditTo.Properties.DisplayMember = "BranchName";
                textEditTo.Properties.NullText = "Receive To";
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
                        //double selu = 0;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == product.ProductCode && row.Cells[1].Value.ToString() == product.ProductName.ToString())
                                {
                                    var code = row.Cells[0].Value.ToString();
                                    qty = Convert.ToDouble(row.Cells[2].Value) + 1;
                                    //selu = Convert.ToDouble(row.Cells[3].Value);

                                    row.Cells[2].Value = qty.ToString("##,##0.00");
                                    //row.Cells[3].Value = selu.ToString("##,##0.00");
                                    //row.Cells[4].Value = DateTime.Now;
                                    Found = true;
                                }
                            }
                            if (!Found)
                            {
                                string ProductId = product.ProductId.ToString();
                                string ProductCode = product.ProductCode.ToString();
                                string ProductName = product.ProductName.ToString();
                               //DateTime expiry = DateTime.Now;
                                double Qty = 1;
                                //double SellingPrice = 0.00;
                                dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"));
                            }
                        }
                        else
                        {
                            string ProductId = product.ProductId.ToString();
                            string ProductCode = product.ProductCode.ToString();
                            string ProductName = product.ProductName.ToString();
                            //DateTime expiry = DateTime.Now;
                            double Qty = 1;
                            //double SellingPrice = 0.00;
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (e.RowIndex != -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4))
                {
                    double qty = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value);
                    ///double sp = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["SellingPrice"].Value);

                    //DateTime expiry = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["ExpiryDate"].Value;
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = qty.ToString("##,##0.00");
                    //dataGridView1.Rows[e.RowIndex].Cells[3].Value = sp.ToString("##,##0.00");
                    //dataGridView1.Rows[e.RowIndex].Cells[4].Value = expiry;
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
                    var from = db.Shops.FirstOrDefault().ShopId;
                    var to = textEditTo.Text;
                    var comment = textEditComment.Text;
                    var destination = textEditDestination.Text;

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

                        if (destination == "Shop")
                        {
                            stock.Shop = oldShop - Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        }

                        if (destination == "Stores")
                        {
                            stock.Stores = oldStores - Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        }

                        if (destination == "Kitchen")
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
    }
}