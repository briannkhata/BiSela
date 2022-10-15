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
    public partial class FormAddMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEntities db;
        Ingredient ingredient;
        FoodMenu foodMenu;
        int FoodMenuId;
        public FormAddMenu()
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
                textBoxCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxCode.AutoCompleteCustomSource = autoText;
            }
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
                    int FoodMenuId = short.Parse(lblFoodMenuId.Text);
                    string Title = textEditTitle.Text;
                    double SP = Double.Parse(textEditSP.Text);

                    //if (FoodMenuId == 0)
                    //{
                        foodMenu = new FoodMenu()
                        {
                            Title = Title,
                            UnitPrice = SP,
                            FoodMenuId = FoodMenuId,
                        };

                        if (foodMenu.FoodMenuId > 0)
                        {
                            db.Entry(foodMenu).State = EntityState.Modified;
                        }
                        else
                        {
                            db.FoodMenus.Add(foodMenu);
                        }
                        db.SaveChanges();

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                        var code = "";
                        var code2 = "";
                        int IngId = 0;
                                if (foodMenu.FoodMenuId > 0)
                                {
                                    code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                    code2 = code.Substring(0, code.IndexOf("-"));
                                    IngId = short.Parse(code.Substring(code.IndexOf("-") + 1));
                                }
                                else
                                {
                                    code2 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                    IngId = 0;
                                }

                            ingredient = new Ingredient()
                            {
                                ProductId = db.Products.Where(x => x.ProductCode == code2).FirstOrDefault().ProductId,
                                Qty = Double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                                CostPrice = Double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                                FoodMenuId = foodMenu.FoodMenuId,
                                IngredientId = IngId,

                            };

                            if (ingredient.IngredientId > 0)
                            {
                                db.Entry(ingredient).State = EntityState.Modified;
                            }
                            else
                            {
                                db.Ingredients.Add(ingredient);
                            }
                            db.SaveChanges();
                    }
                    
                    XtraMessageBox.Show("Menu Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (foodMenu.FoodMenuId > 0 || ingredient.IngredientId > 0)
                    {

                    }
                    else
                    {
                        textEditTitle.Text = "";
                        textEditSP.Text = "";
                        textBoxCode.Text = "";
                        dataGridView1.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }


        private void textBoxCode_KeyDown_1(object sender, KeyEventArgs e)
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
    }
}