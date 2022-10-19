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
    public partial class FormReceiveStock : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        ReceivingDetail receivingDetail;
        Receiving receiving;
        Stock stock;
        DateTimePicker dateTimePicker = new DateTimePicker();
        public FormReceiveStock()
        {
            InitializeComponent();
            autoCompleteSearch();
            loadTo();
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
                textBoxAuto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxAuto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxAuto.AutoCompleteCustomSource = autoText;
            }
        }
        
        

        private void loadTo()
        {

            Dictionary<int, string> store = Enum.GetValues(typeof(Store)).Cast<Store>().ToDictionary(x => (int)x, x => x.ToString());
            textEditTo.Properties.DataSource = store;
            textEditTo.Properties.ValueMember = "Value";
            textEditTo.Properties.DisplayMember = "Value";
            textEditTo.Properties.NullText = "Receive To";
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
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
                    return;
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
        public void clearReceivingCart()
        {
           if(dataGridView1.Rows.Count > 1)
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (db = new BEntities())
                {
                    double total = 0.00;
                    double torder = 0.00;
                    string PO = textEditPO.Text;
                    DateTime DR = dateEditRD.DateTime;
                    string Sup = textEditSup.Text;
                    string Comment = textEditComment.Text;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        torder += Double.Parse((string)dataGridView1.Rows[i].Cells[3].Value);
                        total += Double.Parse((string)dataGridView1.Rows[i].Cells[6].Value);
                    }

                    receiving = new Receiving()
                    {
                        TotalBill = total,
                        SubTotal = torder,
                        Supplier = Sup,
                        ReceivingDate = DR,
                        PurchasingOrder = PO,
                        Comment = Comment,
                        UserId = LoginInfo.UserId,
                    };
                    db.Receivings.Add(receiving);
                    db.SaveChanges();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        var code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        receivingDetail = new ReceivingDetail()
                        {
                            ProductId = db.Products.Where(x => x.ProductCode == code).FirstOrDefault().ProductId,
                            Qty = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                            OrderPrice = Double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                            SellingPrice = Double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()),
                            Vat = Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()),
                            TotalPrice = Double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()),
                            ExpiryDate = DateTime.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()),
                            UserId = LoginInfo.UserId,
                            ReceivingId = receiving.Id,
                        };
                        db.ReceivingDetails.Add(receivingDetail);
                        db.SaveChanges();

                        var RCT = textEditTo.EditValue.ToString();
                        if (RCT == "Shop")
                        {
                            stock = new Stock()
                            {
                                ProductId = receivingDetail.ProductId,
                                ShopId = db.Shops.SingleOrDefault().ShopId,
                                Stores = receivingDetail.Qty,
                                SellingPrice = receivingDetail.SellingPrice,
                                ExpiryDate = receivingDetail.ExpiryDate,
                                OrderPrice = receivingDetail.OrderPrice,
                                Comment = Comment,
                            };
                        }
                        else if (RCT == "Kitchen")
                        {
                            stock = new Stock()
                            {
                                ProductId = receivingDetail.ProductId,
                                ShopId = db.Shops.SingleOrDefault().ShopId,
                                Kitchen = receivingDetail.Qty,
                                SellingPrice = receivingDetail.SellingPrice,
                                ExpiryDate = receivingDetail.ExpiryDate,
                                OrderPrice = receivingDetail.OrderPrice,
                                Comment = Comment,

                            };
                        } 
                        else if (RCT == "Stores")
                        {
                            stock = new Stock()
                            {
                                ProductId = receivingDetail.ProductId,
                                ShopId = db.Shops.SingleOrDefault().ShopId,
                                Stores = receivingDetail.Qty,
                                SellingPrice = receivingDetail.SellingPrice,
                                ExpiryDate = receivingDetail.ExpiryDate,
                                OrderPrice = receivingDetail.OrderPrice,
                                Comment = Comment,
                            };
                        }
                        db.Stocks.Add(stock);
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Products Received successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    
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
            clearReceivingCart();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (e.RowIndex != -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4))
                    {
                        double qty = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value);
                        double sp = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["SellingPrice"].Value);
                        double order = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["OrderPrice"].Value);
                        double vat = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Vat"].Value);

                        DateTime expiry = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["ExpiryDate"].Value;
                        double toto = order * qty;
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = qty.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = order.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = vat.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = sp.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = toto.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = expiry;
                    }
                }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                dataGridView1.Controls.Add(dateTimePicker);
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "dd/MM/yyy";
                Rectangle rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex,e.RowIndex,true);
                dateTimePicker.Size = new Size(rectangle.Width,rectangle.Height);
                dateTimePicker.Location = new Point(rectangle.X,rectangle.Y);
            }
        }


        private void textBoxAuto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                try
                {
                    using (var db = new BEntities())
                    {
                        var product = db.Products.Where(p => p.ProductCode == textBoxAuto.Text).FirstOrDefault();
                        Boolean Found = false;

                        double qty = 0;
                        double toto = 0;
                        double selu = 0;
                        double order = 0;
                        double vat = 0;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == product.ProductCode && row.Cells[1].Value.ToString() == product.ProductName.ToString())
                                {
                                    var code = row.Cells[0].Value.ToString();
                                    qty = Convert.ToDouble(row.Cells[2].Value) + 1;
                                    order = Convert.ToDouble(row.Cells[3].Value);
                                    vat = Convert.ToDouble(row.Cells[4].Value);
                                    selu = Convert.ToDouble(row.Cells[5].Value);

                                    toto = order * qty;
                                    row.Cells[2].Value = qty.ToString("##,##0.00");
                                    row.Cells[3].Value = order.ToString("##,##0.00");
                                    row.Cells[4].Value = vat.ToString("##,##0.00");
                                    row.Cells[5].Value = selu.ToString("##,##0.00");
                                    row.Cells[6].Value = toto.ToString("##,##0.00");
                                    row.Cells[7].Value = DateTime.Now;
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
                                double Order = 0.00;
                                double Total = 0.00;
                                double Vat = 0.00;
                                double SellingPrice = 0.00;
                                dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"), Order.ToString("##,##0.00"), Vat.ToString("##,##0.00"), SellingPrice.ToString("##,##0.00"), Total.ToString("##,##0.00"), expiry);
                            }
                        }
                        else
                        {
                            string ProductId = product.ProductId.ToString();
                            string ProductCode = product.ProductCode.ToString();
                            string ProductName = product.ProductName.ToString();
                            DateTime expiry = DateTime.Now;
                            double Qty = 1;
                            double Order = 0.00;
                            double Total = 0.00;
                            double Vat = 0.00;
                            double SellingPrice = 0.00;
                            dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"), Order.ToString("##,##0.00"), Vat.ToString("##,##0.00"), SellingPrice.ToString("##,##0.00"), Total.ToString("##,##0.00"), expiry);
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            textBoxAuto.Text = string.Empty;
        }
    }
}