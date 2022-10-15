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
        public FormMoveStock()
        {
            InitializeComponent();
            loadData();
            loadTo();
            loadFrom();
            gridView1.Columns["ProductId"].Visible = false;
            gridView1.Columns["ShopId"].Visible = false;
            gridView1.Columns["StockId"].Visible = false;
            gridView1.Columns["SellingPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["SellingPrice"].DisplayFormat.FormatString = "c2";

            gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.ReadOnly = true;
            gridView1.Columns.ColumnByFieldName("ProductName").OptionsColumn.AllowEdit = false;

            gridView1.Columns.ColumnByFieldName("ProductCode").OptionsColumn.ReadOnly = true;
            gridView1.Columns.ColumnByFieldName("ProductCode").OptionsColumn.AllowEdit = false;
        }

        public void loadData()
        {
            using (db = new BEntities())
            {
                gridControl1.DataSource = db.vwUpdateStocks.ToList();
            }
        }

        private void loadTo()
        {
          
                Dictionary<int, string> store = Enum.GetValues(typeof(Store)).Cast<Store>().ToDictionary(x => (int)x, x => x.ToString());
                searchLookUpEditTo.Properties.DataSource = store;
                searchLookUpEditTo.Properties.ValueMember = "Value";
                searchLookUpEditTo.Properties.DisplayMember = "Value";
                searchLookUpEditTo.Properties.NullText = "Move To";
        }

        private void loadFrom()
        {

            Dictionary<int, string> store = Enum.GetValues(typeof(Store)).Cast<Store>().ToDictionary(x => (int)x, x => x.ToString());
            searchLookUpEditFrom.Properties.DataSource = store;
            searchLookUpEditFrom.Properties.ValueMember = "Value";
            searchLookUpEditFrom.Properties.DisplayMember = "Value";
            searchLookUpEditFrom.Properties.NullText = "Move From";
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
                            Stores = row.Stores - row.Shop,
                            ProductId = row.ProductId,
                            SellingPrice = row.SellingPrice,
                            ExpiryDate = row.ExpiryDate,
                            Comment = "Moved From " +searchLookUpEditFrom.EditValue + "To" + searchLookUpEditTo.EditValue,
                            ShopId = row.ShopId,
                        };
                        db.Stocks.Add(stock);
                        //db.Entry(stock).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Stock Moving Successfull", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var selectedRows = gridView1.GetSelectedRows();
                var row = ((vwUpdateStock)gridView1.GetRow(selectedRows[0]));
                using (var db = new BEntities())
                {
                    var stock = db.Stocks.Find(row.StockId);
                    db.Stocks.Remove(stock);
                    db.SaveChanges();
                }
                loadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}