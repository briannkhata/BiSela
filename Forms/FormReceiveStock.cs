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
    public partial class FormReceiveStock : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        ReceivingCart receivingCart = new ReceivingCart();
        ReceivingDetail receivingDetail;
        Receiving receiving;
        Stock stock; 
        public FormReceiveStock()
        {
            InitializeComponent();
            autoCompleteSearch();

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
                textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxSearch.AutoCompleteCustomSource = autoText;
            }
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
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void datedateTimePicker_textchanged(object sender, EventArgs e)
        {
            //datagridview1.currentCell.Value = datetimepicker.text.Tostring();
        }

        public void dateTimePicker_closeup(object sender, EventArgs e)
        {
            //datetimepicker.visible = false;
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                try
                {
                    using (var db = new BEntities())
                    {
                        var product = db.Products.Where(p => p.ProductCode == textBoxSearch.Text).FirstOrDefault();
                        double UnitPrice = (double)db.Stocks?.Where(x => x.ProductId == product.ProductId).FirstOrDefault().SellingPrice;
                        Boolean Found = false;

                        double qty = 0;
                        double toto = 0;
                        double selu = 0;
                        double order = 0;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == product.ProductCode && row.Cells[1].Value.ToString() == product.ProductName.ToString())
                                {
                                    var code = row.Cells[0].Value.ToString();
                                    selu = Convert.ToDouble(row.Cells[4].Value);
                                    qty = Convert.ToDouble(row.Cells[2].Value) + 1;
                                    order = Convert.ToDouble(row.Cells[3].Value);
                                    toto = order * qty;
                                   
                                    row.Cells[2].Value = qty.ToString("##,##0.00");
                                    row.Cells[3].Value = order.ToString("##,##0.00");
                                    row.Cells[4].Value = selu.ToString("##,##0.00");
                                    row.Cells[6].Value = toto.ToString("##,##0.00");
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
                                double SellingPrice = UnitPrice;
                               
                                dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"), Order, SellingPrice.ToString("##,##0.00"), expiry, Total);
                            }
                        }
                        else
                        {
                            string ProductId = product.ProductId.ToString();
                            string ProductCode = product.ProductCode.ToString();
                            string ProductName = product.ProductName.ToString();

                            double Total = 0.00;
                            double Order = 0.00;
                            DateTime expiry = DateTime.Now;

                            double Qty = 1;
                            double SellingPrice = UnitPrice;

                            dataGridView1.Rows.Add(ProductCode, ProductName, Qty.ToString("##,##0.00"), Order, SellingPrice.ToString("##,##0.00"), expiry, Total);
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textBoxSearch.Text = string.Empty;

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
                    DateTime DD = dateEditDD.DateTime;
                    DateTime DR = dateEditRD.DateTime;
                    string Sup = textEditSup.Text;
                    string DN = textEditDN.Text;

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
                        DeliveryDate = DD,
                        DeliveryNote = DN,
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
                            ExpiryDate = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()),
                            TotalPrice = Double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()),
                            UserId = LoginInfo.UserId,
                            ReceivingId = receiving.Id,
                        };
                        db.ReceivingDetails.Add(receivingDetail);
                        db.SaveChanges();


                        bool stores = radioButtonStores.Checked;
                        if (stores)
                        {
                            stock = new Stock()
                            {
                                ProductId = receivingDetail.ProductId,
                                ShopId = db.Shops.SingleOrDefault().ShopId,
                                Stores = receivingDetail.Qty,
                                SellingPrice = receivingDetail.SellingPrice,
                                ExpiryDate = receivingDetail.ExpiryDate,
                                OrderPrice = receivingDetail.OrderPrice
                            };

                        }
                        else
                        {
                            stock = new Stock()
                            {
                                ProductId = receivingDetail.ProductId,
                                ShopId = db.Shops.SingleOrDefault().ShopId,
                                Shop = receivingDetail.Qty,
                                SellingPrice = receivingDetail.SellingPrice,
                                ExpiryDate = receivingDetail.ExpiryDate,
                                OrderPrice = receivingDetail.OrderPrice
                            };
                        }
                        db.Stocks.Add(stock);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        double expiry = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["ExpiryDate"].Value);
                        double toto = order * qty;
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = qty.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = order.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = sp.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = expiry.ToString("##,##0.00");
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = toto.ToString("##,##0.00");
                    }
                }
        }
    }
}