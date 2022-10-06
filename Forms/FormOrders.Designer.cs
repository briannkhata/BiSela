
namespace Katswiri.Forms
{
    partial class FormOrders
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpEditCus = new DevExpress.XtraEditors.LookUpEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.FormOrderslayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.button1item = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookUpEditCusitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1item = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormOrderslayoutControl1ConvertedLayout)).BeginInit();
            this.FormOrderslayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCusitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1item)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(12, 42);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1255, 550);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 372;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // lookUpEditCus
            // 
            this.lookUpEditCus.Location = new System.Drawing.Point(12, 12);
            this.lookUpEditCus.Name = "lookUpEditCus";
            this.lookUpEditCus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCus.Size = new System.Drawing.Size(974, 26);
            this.lookUpEditCus.StyleController = this.FormOrderslayoutControl1ConvertedLayout;
            this.lookUpEditCus.TabIndex = 1;
            this.lookUpEditCus.EditValueChanged += new System.EventHandler(this.lookUpEditCus_EditValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(990, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(277, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormOrderslayoutControl1ConvertedLayout
            // 
            this.FormOrderslayoutControl1ConvertedLayout.Controls.Add(this.button1);
            this.FormOrderslayoutControl1ConvertedLayout.Controls.Add(this.lookUpEditCus);
            this.FormOrderslayoutControl1ConvertedLayout.Controls.Add(this.gridControl1);
            this.FormOrderslayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormOrderslayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.FormOrderslayoutControl1ConvertedLayout.Name = "FormOrderslayoutControl1ConvertedLayout";
            this.FormOrderslayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.FormOrderslayoutControl1ConvertedLayout.Size = new System.Drawing.Size(1279, 604);
            this.FormOrderslayoutControl1ConvertedLayout.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.button1item,
            this.lookUpEditCusitem,
            this.gridControl1item});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1279, 604);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // button1item
            // 
            this.button1item.Control = this.button1;
            this.button1item.Location = new System.Drawing.Point(978, 0);
            this.button1item.Name = "button1item";
            this.button1item.Size = new System.Drawing.Size(281, 30);
            this.button1item.TextSize = new System.Drawing.Size(0, 0);
            this.button1item.TextVisible = false;
            // 
            // lookUpEditCusitem
            // 
            this.lookUpEditCusitem.Control = this.lookUpEditCus;
            this.lookUpEditCusitem.Location = new System.Drawing.Point(0, 0);
            this.lookUpEditCusitem.Name = "lookUpEditCusitem";
            this.lookUpEditCusitem.Size = new System.Drawing.Size(978, 30);
            this.lookUpEditCusitem.TextSize = new System.Drawing.Size(0, 0);
            this.lookUpEditCusitem.TextVisible = false;
            // 
            // gridControl1item
            // 
            this.gridControl1item.Control = this.gridControl1;
            this.gridControl1item.Location = new System.Drawing.Point(0, 30);
            this.gridControl1item.Name = "gridControl1item";
            this.gridControl1item.Size = new System.Drawing.Size(1259, 554);
            this.gridControl1item.TextSize = new System.Drawing.Size(0, 0);
            this.gridControl1item.TextVisible = false;
            // 
            // FormOrders
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1279, 604);
            this.Controls.Add(this.FormOrderslayoutControl1ConvertedLayout);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Orders";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormOrderslayoutControl1ConvertedLayout)).EndInit();
            this.FormOrderslayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCusitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCus;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraLayout.LayoutControl FormOrderslayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem button1item;
        private DevExpress.XtraLayout.LayoutControlItem lookUpEditCusitem;
        private DevExpress.XtraLayout.LayoutControlItem gridControl1item;
    }
}