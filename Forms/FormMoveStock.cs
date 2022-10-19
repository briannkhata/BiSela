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
            loadBranhces();

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
            using (db = new BEntities())
            {
                textEditFrom.Properties.DataSource = db.vwBranches.ToList();
                textEditFrom.Properties.ValueMember = "BranchId";
                textEditFrom.Properties.DisplayMember = "BranchName";
                textEditFrom.Properties.NullText = "Receive From";
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
                            Stores = row.Stores - row.Shop,
                            ProductId = row.ProductId,
                            SellingPrice = row.SellingPrice,
                            ExpiryDate = row.ExpiryDate,
                            Comment = textEditComment.Text,
                            ShopId = row.ShopId,
                        };
                        db.Stocks.Add(stock);
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Stock Moving Successfull", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                return;
            }
        }
    }
}