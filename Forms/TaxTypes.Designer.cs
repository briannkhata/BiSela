
namespace Katswiri.Forms
{
    partial class TaxTypes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxTypes));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.TaxTypeNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.taxTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TaxTypeValueTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForTaxTypeValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTaxTypeName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTaxTypeStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TaxTypeStatusTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaxTypeNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxTypeValueTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTaxTypeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTaxTypeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTaxTypeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxTypeStatusTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSave,
            this.btnDelete,
            this.btnRefresh});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(719, 232);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 1;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 3;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.Name = "btnRefresh";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Tools";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.TaxTypeNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TaxTypeValueTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TaxTypeStatusTextEdit);
            this.dataLayoutControl1.DataSource = this.taxTypesBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 232);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(719, 198);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // TaxTypeNameTextEdit
            // 
            this.TaxTypeNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxTypesBindingSource, "TaxTypeName", true));
            this.TaxTypeNameTextEdit.Location = new System.Drawing.Point(24, 69);
            this.TaxTypeNameTextEdit.MenuManager = this.ribbon;
            this.TaxTypeNameTextEdit.Name = "TaxTypeNameTextEdit";
            this.TaxTypeNameTextEdit.Size = new System.Drawing.Size(671, 26);
            this.TaxTypeNameTextEdit.StyleController = this.dataLayoutControl1;
            this.TaxTypeNameTextEdit.TabIndex = 4;
            // 
            // taxTypesBindingSource
            // 
            this.taxTypesBindingSource.DataMember = "TaxTypes";
            // 
            // taxTypesDataSet
            // 

            // 
            // TaxTypeValueTextEdit
            // 
            this.TaxTypeValueTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxTypesBindingSource, "TaxTypeValue", true));
            this.TaxTypeValueTextEdit.Location = new System.Drawing.Point(294, 118);
            this.TaxTypeValueTextEdit.MenuManager = this.ribbon;
            this.TaxTypeValueTextEdit.Name = "TaxTypeValueTextEdit";
            this.TaxTypeValueTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.TaxTypeValueTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TaxTypeValueTextEdit.Properties.Mask.EditMask = "F";
            this.TaxTypeValueTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TaxTypeValueTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TaxTypeValueTextEdit.Size = new System.Drawing.Size(401, 26);
            this.TaxTypeValueTextEdit.StyleController = this.dataLayoutControl1;
            this.TaxTypeValueTextEdit.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(719, 198);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(699, 178);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTaxTypeValue,
            this.ItemForTaxTypeName,
            this.ItemForTaxTypeStatus});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(699, 178);
            this.layoutControlGroup2.Text = "Enter Details";
            // 
            // ItemForTaxTypeValue
            // 
            this.ItemForTaxTypeValue.Control = this.TaxTypeValueTextEdit;
            this.ItemForTaxTypeValue.Location = new System.Drawing.Point(270, 49);
            this.ItemForTaxTypeValue.Name = "ItemForTaxTypeValue";
            this.ItemForTaxTypeValue.Size = new System.Drawing.Size(405, 79);
            this.ItemForTaxTypeValue.Text = "Tax Type Value";
            this.ItemForTaxTypeValue.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForTaxTypeValue.TextSize = new System.Drawing.Size(98, 16);
            // 
            // ItemForTaxTypeName
            // 
            this.ItemForTaxTypeName.Control = this.TaxTypeNameTextEdit;
            this.ItemForTaxTypeName.Location = new System.Drawing.Point(0, 0);
            this.ItemForTaxTypeName.Name = "ItemForTaxTypeName";
            this.ItemForTaxTypeName.Size = new System.Drawing.Size(675, 49);
            this.ItemForTaxTypeName.Text = "Tax Type Name";
            this.ItemForTaxTypeName.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForTaxTypeName.TextSize = new System.Drawing.Size(98, 16);
            // 
            // ItemForTaxTypeStatus
            // 
            this.ItemForTaxTypeStatus.Control = this.TaxTypeStatusTextEdit;
            this.ItemForTaxTypeStatus.Location = new System.Drawing.Point(0, 49);
            this.ItemForTaxTypeStatus.Name = "ItemForTaxTypeStatus";
            this.ItemForTaxTypeStatus.Size = new System.Drawing.Size(270, 79);
            this.ItemForTaxTypeStatus.Text = "Tax Type Status";
            this.ItemForTaxTypeStatus.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForTaxTypeStatus.TextSize = new System.Drawing.Size(98, 16);
            // 
            // taxTypesTableAdapter
            // 
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 436);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(719, 282);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // TaxTypeStatusTextEdit
            // 
            this.TaxTypeStatusTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taxTypesBindingSource, "TaxTypeStatus", true));
            this.TaxTypeStatusTextEdit.Location = new System.Drawing.Point(24, 118);
            this.TaxTypeStatusTextEdit.MenuManager = this.ribbon;
            this.TaxTypeStatusTextEdit.Name = "TaxTypeStatusTextEdit";
            this.TaxTypeStatusTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TaxTypeStatusTextEdit.Properties.NullText = "";
            this.TaxTypeStatusTextEdit.Size = new System.Drawing.Size(266, 26);
            this.TaxTypeStatusTextEdit.StyleController = this.dataLayoutControl1;
            this.TaxTypeStatusTextEdit.TabIndex = 6;
            // 
            // TaxTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(719, 718);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TaxTypes";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaxTypes";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaxTypeNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxTypeValueTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTaxTypeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTaxTypeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTaxTypeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxTypeStatusTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.BindingSource taxTypesBindingSource;
        private DevExpress.XtraEditors.TextEdit TaxTypeNameTextEdit;
        private DevExpress.XtraEditors.TextEdit TaxTypeValueTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTaxTypeValue;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTaxTypeName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTaxTypeStatus;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraEditors.LookUpEdit TaxTypeStatusTextEdit;
    }
}