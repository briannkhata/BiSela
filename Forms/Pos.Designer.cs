
namespace Katswiri.Forms
{
    partial class Pos
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
            this.lookUpEditPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditSaleType = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEditCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.NewCustomer = new System.Windows.Forms.Button();
            this.lblCashier = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textSearchProduct = new System.Windows.Forms.TextBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlOrders = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lookUpEditPaymentType
            // 
            this.lookUpEditPaymentType.Location = new System.Drawing.Point(1067, 13);
            this.lookUpEditPaymentType.Name = "lookUpEditPaymentType";
            this.lookUpEditPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPaymentType.Size = new System.Drawing.Size(223, 30);
            this.lookUpEditPaymentType.TabIndex = 13;
            this.lookUpEditPaymentType.EditValueChanged += new System.EventHandler(this.lookUpEditPaymentType_EditValueChanged);
            // 
            // lookUpEditSaleType
            // 
            this.lookUpEditSaleType.Location = new System.Drawing.Point(1296, 12);
            this.lookUpEditSaleType.Name = "lookUpEditSaleType";
            this.lookUpEditSaleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSaleType.Size = new System.Drawing.Size(226, 30);
            this.lookUpEditSaleType.TabIndex = 11;
            // 
            // panelControl5
            // 
            this.panelControl5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl5.Controls.Add(this.lookUpEditCustomer);
            this.panelControl5.Controls.Add(this.NewCustomer);
            this.panelControl5.Controls.Add(this.lblCashier);
            this.panelControl5.Controls.Add(this.label3);
            this.panelControl5.Controls.Add(this.lookUpEditPaymentType);
            this.panelControl5.Controls.Add(this.lookUpEditSaleType);
            this.panelControl5.Location = new System.Drawing.Point(2, 1);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(1532, 58);
            this.panelControl5.TabIndex = 3;
            // 
            // lookUpEditCustomer
            // 
            this.lookUpEditCustomer.Location = new System.Drawing.Point(838, 13);
            this.lookUpEditCustomer.Name = "lookUpEditCustomer";
            this.lookUpEditCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCustomer.Size = new System.Drawing.Size(223, 30);
            this.lookUpEditCustomer.TabIndex = 29;
            // 
            // NewCustomer
            // 
            this.NewCustomer.Location = new System.Drawing.Point(591, 7);
            this.NewCustomer.Name = "NewCustomer";
            this.NewCustomer.Size = new System.Drawing.Size(231, 42);
            this.NewCustomer.TabIndex = 28;
            this.NewCustomer.Text = "New Customer";
            this.NewCustomer.UseVisualStyleBackColor = true;
            this.NewCustomer.Click += new System.EventHandler(this.NewCustomer_Click);
            // 
            // lblCashier
            // 
            this.lblCashier.BackColor = System.Drawing.Color.Transparent;
            this.lblCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashier.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCashier.Location = new System.Drawing.Point(198, 6);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(218, 47);
            this.lblCashier.TabIndex = 27;
            this.lblCashier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 47);
            this.label3.TabIndex = 26;
            this.label3.Text = "CASHIER : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textSearchProduct
            // 
            this.textSearchProduct.AcceptsReturn = true;
            this.textSearchProduct.AcceptsTab = true;
            this.textSearchProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textSearchProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textSearchProduct.BackColor = System.Drawing.SystemColors.Window;
            this.textSearchProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSearchProduct.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearchProduct.Location = new System.Drawing.Point(20, 81);
            this.textSearchProduct.Name = "textSearchProduct";
            this.textSearchProduct.Size = new System.Drawing.Size(398, 57);
            this.textSearchProduct.TabIndex = 0;
            this.textSearchProduct.WordWrap = false;
            this.textSearchProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSearchProduct_KeyDown);
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.gridControlOrders);
            this.panelControl1.Location = new System.Drawing.Point(904, 116);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(622, 649);
            this.panelControl1.TabIndex = 3;
            // 
            // gridControlOrders
            // 
            this.gridControlOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gridControlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOrders.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlOrders.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControlOrders.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlOrders.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.gridControlOrders.Location = new System.Drawing.Point(2, 2);
            this.gridControlOrders.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.gridControlOrders.MainView = this.gridView2;
            this.gridControlOrders.Name = "gridControlOrders";
            this.gridControlOrders.Size = new System.Drawing.Size(618, 645);
            this.gridControlOrders.TabIndex = 0;
            this.gridControlOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView2.GridControl = this.gridControlOrders;
            this.gridView2.Name = "gridView2";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(905, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(619, 31);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "List of Orders";
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(424, 81);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(400, 57);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = "label1";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 714);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 82);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(223, 714);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 82);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(634, 714);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(195, 82);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControl1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.gridControl1.Location = new System.Drawing.Point(2, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(804, 406);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyUp);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl3
            // 
            this.panelControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl3.Controls.Add(this.gridControl1);
            this.panelControl3.Location = new System.Drawing.Point(20, 150);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(811, 409);
            this.panelControl3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(22, 570);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 133);
            this.panel1.TabIndex = 9;
            // 
            // Pos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1538, 808);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.textSearchProduct);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl3);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.True;
            this.Name = "Pos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop Name - Company";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pos_FormClosing);
            this.Shown += new System.EventHandler(this.Pos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSaleType;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentType;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.TextBox textSearchProduct;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button NewCustomer;
        public System.Windows.Forms.Label lblCustomer;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCustomer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Panel panel1;
    }
}