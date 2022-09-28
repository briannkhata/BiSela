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
    public partial class FormUpdateStock : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Stock stock;
        public FormUpdateStock()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwUpdateStocks.ToList();
                gridView1.Columns["ProductId"].Visible = false;
                gridView1.Columns["ShopId"].Visible = false;
                gridView1.Columns["Description"].Visible = false;
                gridView1.Columns["Stores"].Visible = false;
                gridView1.Columns["StockId"].Visible = false;
                gridView1.Columns["SellingPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["SellingPrice"].DisplayFormat.FormatString = "c2";

                gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.ReadOnly = true;
                gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.AllowEdit = false;

                gridView1.Columns.ColumnByFieldName("ProductCode").OptionsColumn.ReadOnly = true;
                gridView1.Columns.ColumnByFieldName("ProductCode").OptionsColumn.AllowEdit = false;
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
           refreshData();
        }

        public void refreshData()
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwUpdateStock)gridView1.GetRow(selectedRows[0]));
                using (var db = new BEntities())
                {
                    if (row.StockId != -1)
                    {
                        stock = new Stock()
                        {
                            StockId = row.StockId,
                            Shop = row.Shop,
                            ProductId = row.ProductId,
                            SellingPrice = row.SellingPrice,
                            ExpiryDate = row.ExpiryDate,
                            Comment = textBox1.Text,
                            ShopId = row.ShopId,
                        };
                        db.Entry(stock).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Stock Updating Successfull", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            loadData();
        }
    }
}