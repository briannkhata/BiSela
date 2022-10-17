
namespace Katswiri.Forms
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.lookUpEditTaxStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.textEditOrderLevel = new DevExpress.XtraEditors.TextEdit();
            this.ProductCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ProductNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UnitIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.CategoryIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.BrandLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.TextEditDescription = new DevExpress.XtraEditors.TextEdit();
            this.textEditBarcode = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblProductId = new System.Windows.Forms.Label();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCategoryId = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProductName1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProductName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUnitId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProductCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTaxStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOrderLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrandLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUnitId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSave,
            this.barEditItem1,
            this.barEditItem2});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.ribbon.Size = new System.Drawing.Size(1174, 232);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 3;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "Category";
            this.barEditItem1.Edit = this.repositoryItemComboBox1;
            this.barEditItem1.Id = 6;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "Unit";
            this.barEditItem2.Edit = this.repositoryItemComboBox2;
            this.barEditItem2.Id = 7;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Tools";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.lookUpEditTaxStatus);
            this.dataLayoutControl1.Controls.Add(this.textEditOrderLevel);
            this.dataLayoutControl1.Controls.Add(this.ProductCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ProductNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UnitIdLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.CategoryIdLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.BrandLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.TextEditDescription);
            this.dataLayoutControl1.Controls.Add(this.textEditBarcode);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 232);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1174, 389);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // lookUpEditTaxStatus
            // 
            this.lookUpEditTaxStatus.Location = new System.Drawing.Point(589, 224);
            this.lookUpEditTaxStatus.MenuManager = this.ribbon;
            this.lookUpEditTaxStatus.Name = "lookUpEditTaxStatus";
            this.lookUpEditTaxStatus.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUpEditTaxStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lookUpEditTaxStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTaxStatus.Properties.NullText = "";
            this.lookUpEditTaxStatus.Size = new System.Drawing.Size(561, 26);
            this.lookUpEditTaxStatus.StyleController = this.dataLayoutControl1;
            this.lookUpEditTaxStatus.TabIndex = 14;
            // 
            // textEditOrderLevel
            // 
            this.textEditOrderLevel.Location = new System.Drawing.Point(24, 175);
            this.textEditOrderLevel.MenuManager = this.ribbon;
            this.textEditOrderLevel.Name = "textEditOrderLevel";
            this.textEditOrderLevel.Size = new System.Drawing.Size(245, 26);
            this.textEditOrderLevel.StyleController = this.dataLayoutControl1;
            this.textEditOrderLevel.TabIndex = 13;
            // 
            // ProductCodeTextEdit
            // 
            this.ProductCodeTextEdit.Location = new System.Drawing.Point(657, 77);
            this.ProductCodeTextEdit.MenuManager = this.ribbon;
            this.ProductCodeTextEdit.Name = "ProductCodeTextEdit";
            this.ProductCodeTextEdit.Size = new System.Drawing.Size(493, 26);
            this.ProductCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.ProductCodeTextEdit.TabIndex = 4;
            // 
            // ProductNameTextEdit
            // 
            this.ProductNameTextEdit.Location = new System.Drawing.Point(24, 77);
            this.ProductNameTextEdit.MenuManager = this.ribbon;
            this.ProductNameTextEdit.Name = "ProductNameTextEdit";
            this.ProductNameTextEdit.Size = new System.Drawing.Size(629, 26);
            this.ProductNameTextEdit.StyleController = this.dataLayoutControl1;
            this.ProductNameTextEdit.TabIndex = 5;
            // 
            // UnitIdLookUpEdit
            // 
            this.UnitIdLookUpEdit.Location = new System.Drawing.Point(778, 175);
            this.UnitIdLookUpEdit.MenuManager = this.ribbon;
            this.UnitIdLookUpEdit.Name = "UnitIdLookUpEdit";
            this.UnitIdLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.UnitIdLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.UnitIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UnitIdLookUpEdit.Properties.NullText = "";
            this.UnitIdLookUpEdit.Size = new System.Drawing.Size(372, 26);
            this.UnitIdLookUpEdit.StyleController = this.dataLayoutControl1;
            this.UnitIdLookUpEdit.TabIndex = 7;
            // 
            // CategoryIdLookUpEdit
            // 
            this.CategoryIdLookUpEdit.Location = new System.Drawing.Point(24, 224);
            this.CategoryIdLookUpEdit.MenuManager = this.ribbon;
            this.CategoryIdLookUpEdit.Name = "CategoryIdLookUpEdit";
            this.CategoryIdLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.CategoryIdLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CategoryIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CategoryIdLookUpEdit.Properties.NullText = "";
            this.CategoryIdLookUpEdit.Size = new System.Drawing.Size(561, 26);
            this.CategoryIdLookUpEdit.StyleController = this.dataLayoutControl1;
            this.CategoryIdLookUpEdit.TabIndex = 8;
            // 
            // BrandLookUpEdit
            // 
            this.BrandLookUpEdit.Location = new System.Drawing.Point(273, 175);
            this.BrandLookUpEdit.MenuManager = this.ribbon;
            this.BrandLookUpEdit.Name = "BrandLookUpEdit";
            this.BrandLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BrandLookUpEdit.Properties.NullText = "";
            this.BrandLookUpEdit.Size = new System.Drawing.Size(501, 26);
            this.BrandLookUpEdit.StyleController = this.dataLayoutControl1;
            this.BrandLookUpEdit.TabIndex = 12;
            // 
            // TextEditDescription
            // 
            this.TextEditDescription.Location = new System.Drawing.Point(24, 273);
            this.TextEditDescription.Name = "TextEditDescription";
            this.TextEditDescription.Size = new System.Drawing.Size(1126, 26);
            this.TextEditDescription.StyleController = this.dataLayoutControl1;
            this.TextEditDescription.TabIndex = 5;
            // 
            // textEditBarcode
            // 
            this.textEditBarcode.Location = new System.Drawing.Point(24, 126);
            this.textEditBarcode.MenuManager = this.ribbon;
            this.textEditBarcode.Name = "textEditBarcode";
            this.textEditBarcode.Size = new System.Drawing.Size(1126, 26);
            this.textEditBarcode.StyleController = this.dataLayoutControl1;
            this.textEditBarcode.TabIndex = 15;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1174, 389);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1154, 369);
            // 
            // lblProductId
            // 
            this.lblProductId.BackColor = System.Drawing.Color.Gainsboro;
            this.lblProductId.Location = new System.Drawing.Point(472, 140);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(217, 23);
            this.lblProductId.TabIndex = 6;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1154, 369);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCategoryId,
            this.layoutControlItem1,
            this.ItemForProductName1,
            this.ItemForProductName,
            this.layoutControlItem3,
            this.ItemForUnitId,
            this.ItemForProductCode,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1130, 311);
            this.layoutControlGroup2.Text = "Enter Details";
            // 
            // ItemForCategoryId
            // 
            this.ItemForCategoryId.Control = this.CategoryIdLookUpEdit;
            this.ItemForCategoryId.Location = new System.Drawing.Point(0, 147);
            this.ItemForCategoryId.Name = "ItemForCategoryId";
            this.ItemForCategoryId.Size = new System.Drawing.Size(565, 49);
            this.ItemForCategoryId.Text = "Category";
            this.ItemForCategoryId.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForCategoryId.TextSize = new System.Drawing.Size(88, 16);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.BrandLookUpEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(249, 98);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(505, 49);
            this.layoutControlItem1.Text = "Brand";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(88, 16);
            // 
            // ItemForProductName1
            // 
            this.ItemForProductName1.Control = this.TextEditDescription;
            this.ItemForProductName1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForProductName1.CustomizationFormText = "Product Name";
            this.ItemForProductName1.Location = new System.Drawing.Point(0, 196);
            this.ItemForProductName1.Name = "ItemForProductName1";
            this.ItemForProductName1.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ItemForProductName1.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.ItemForProductName1.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ItemForProductName1.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.ItemForProductName1.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ItemForProductName1.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.ItemForProductName1.Size = new System.Drawing.Size(1130, 115);
            this.ItemForProductName1.Text = "Description";
            this.ItemForProductName1.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForProductName1.TextSize = new System.Drawing.Size(88, 16);
            // 
            // ItemForProductName
            // 
            this.ItemForProductName.Control = this.ProductNameTextEdit;
            this.ItemForProductName.Location = new System.Drawing.Point(0, 0);
            this.ItemForProductName.Name = "ItemForProductName";
            this.ItemForProductName.Size = new System.Drawing.Size(633, 49);
            this.ItemForProductName.Text = "Product Name";
            this.ItemForProductName.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForProductName.TextSize = new System.Drawing.Size(88, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookUpEditTaxStatus;
            this.layoutControlItem3.Location = new System.Drawing.Point(565, 147);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(565, 49);
            this.layoutControlItem3.Text = "Tax Status";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 16);
            // 
            // ItemForUnitId
            // 
            this.ItemForUnitId.Control = this.UnitIdLookUpEdit;
            this.ItemForUnitId.Location = new System.Drawing.Point(754, 98);
            this.ItemForUnitId.Name = "ItemForUnitId";
            this.ItemForUnitId.Size = new System.Drawing.Size(376, 49);
            this.ItemForUnitId.Text = "Unit";
            this.ItemForUnitId.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForUnitId.TextSize = new System.Drawing.Size(88, 16);
            // 
            // ItemForProductCode
            // 
            this.ItemForProductCode.Control = this.ProductCodeTextEdit;
            this.ItemForProductCode.Location = new System.Drawing.Point(633, 0);
            this.ItemForProductCode.Name = "ItemForProductCode";
            this.ItemForProductCode.Size = new System.Drawing.Size(497, 49);
            this.ItemForProductCode.Text = "Product Code";
            this.ItemForProductCode.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForProductCode.TextSize = new System.Drawing.Size(88, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEditOrderLevel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(249, 49);
            this.layoutControlItem2.Text = "ReOrder Level";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEditBarcode;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 49);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1130, 49);
            this.layoutControlItem4.Text = "Barcode";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(88, 16);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1174, 647);
            this.Controls.Add(this.lblProductId);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Products";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTaxStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOrderLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrandLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUnitId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        public DevExpress.XtraEditors.TextEdit ProductCodeTextEdit;
        public DevExpress.XtraEditors.TextEdit ProductNameTextEdit;
        public DevExpress.XtraEditors.TextEdit TextEditDescription;
        public DevExpress.XtraEditors.TextEdit textEditBarcode;
        public DevExpress.XtraEditors.LookUpEdit UnitIdLookUpEdit;
        public DevExpress.XtraEditors.LookUpEdit CategoryIdLookUpEdit;
        public DevExpress.XtraEditors.LookUpEdit BrandLookUpEdit;
        public DevExpress.XtraEditors.TextEdit textEditOrderLevel;
        public DevExpress.XtraEditors.LookUpEdit lookUpEditTaxStatus;
        public System.Windows.Forms.Label lblProductId;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCategoryId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductName1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUnitId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}