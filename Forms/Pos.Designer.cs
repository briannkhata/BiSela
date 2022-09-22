
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pos));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dateTimePickerSaleDate = new System.Windows.Forms.DateTimePicker();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.textEditTxnId = new DevExpress.XtraEditors.TextEdit();
            this.textEditTendered = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearCart = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonPay = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonPause = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditSaleType = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCashier = new System.Windows.Forms.Label();
            this.textSearchProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTxnId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTendered.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.dateTimePickerSaleDate);
            this.panelControl2.Controls.Add(this.lblTotalBill);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Location = new System.Drawing.Point(999, 13);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(534, 756);
            this.panelControl2.TabIndex = 1;
            // 
            // dateTimePickerSaleDate
            // 
            this.dateTimePickerSaleDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerSaleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerSaleDate.Location = new System.Drawing.Point(301, 42);
            this.dateTimePickerSaleDate.Name = "dateTimePickerSaleDate";
            this.dateTimePickerSaleDate.Size = new System.Drawing.Size(215, 22);
            this.dateTimePickerSaleDate.TabIndex = 12;
            // 
            // panelControl4
            // 
            this.panelControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl4.Controls.Add(this.label2);
            this.panelControl4.Controls.Add(this.label1);
            this.panelControl4.Controls.Add(this.lblChange);
            this.panelControl4.Controls.Add(this.textEditTxnId);
            this.panelControl4.Controls.Add(this.textEditTendered);
            this.panelControl4.Controls.Add(this.simpleButtonNew);
            this.panelControl4.Controls.Add(this.btnClearCart);
            this.panelControl4.Controls.Add(this.simpleButtonPay);
            this.panelControl4.Controls.Add(this.simpleButtonPause);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(2, 190);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(530, 564);
            this.panelControl4.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(-2, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 43);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tendered";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChange
            // 
            this.lblChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(15, 278);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(498, 82);
            this.lblChange.TabIndex = 23;
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textEditTxnId
            // 
            this.textEditTxnId.Location = new System.Drawing.Point(13, 163);
            this.textEditTxnId.Name = "textEditTxnId";
            this.textEditTxnId.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textEditTxnId.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditTxnId.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textEditTxnId.Properties.Appearance.Options.UseBackColor = true;
            this.textEditTxnId.Properties.Appearance.Options.UseFont = true;
            this.textEditTxnId.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTxnId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTxnId.Size = new System.Drawing.Size(505, 50);
            this.textEditTxnId.TabIndex = 22;
            // 
            // textEditTendered
            // 
            this.textEditTendered.Location = new System.Drawing.Point(12, 81);
            this.textEditTendered.Name = "textEditTendered";
            this.textEditTendered.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textEditTendered.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditTendered.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEditTendered.Properties.Appearance.Options.UseBackColor = true;
            this.textEditTendered.Properties.Appearance.Options.UseFont = true;
            this.textEditTendered.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTendered.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTendered.Size = new System.Drawing.Size(505, 74);
            this.textEditTendered.TabIndex = 18;
            this.textEditTendered.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEditTendered_KeyPress);
            this.textEditTendered.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textEditTendered_KeyUp);
            this.textEditTendered.MouseEnter += new System.EventHandler(this.textEditTendered_MouseEnter);
            // 
            // simpleButtonNew
            // 
            this.simpleButtonNew.Appearance.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonNew.Appearance.Options.UseFont = true;
            this.simpleButtonNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonNew.ImageOptions.SvgImage")));
            this.simpleButtonNew.Location = new System.Drawing.Point(247, 458);
            this.simpleButtonNew.Name = "simpleButtonNew";
            this.simpleButtonNew.Size = new System.Drawing.Size(270, 78);
            this.simpleButtonNew.TabIndex = 17;
            this.simpleButtonNew.Text = "NEW SALE";
            // 
            // btnClearCart
            // 
            this.btnClearCart.Appearance.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCart.Appearance.Options.UseFont = true;
            this.btnClearCart.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClearCart.ImageOptions.SvgImage")));
            this.btnClearCart.Location = new System.Drawing.Point(14, 458);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(227, 78);
            this.btnClearCart.TabIndex = 16;
            this.btnClearCart.Text = "CLEAR CART";
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // simpleButtonPay
            // 
            this.simpleButtonPay.Appearance.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonPay.Appearance.Options.UseFont = true;
            this.simpleButtonPay.Location = new System.Drawing.Point(245, 374);
            this.simpleButtonPay.Name = "simpleButtonPay";
            this.simpleButtonPay.Size = new System.Drawing.Size(272, 78);
            this.simpleButtonPay.TabIndex = 15;
            this.simpleButtonPay.Text = "FINISH SALE";
            this.simpleButtonPay.Click += new System.EventHandler(this.simpleButton16_Click);
            // 
            // simpleButtonPause
            // 
            this.simpleButtonPause.Appearance.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonPause.Appearance.Options.UseFont = true;
            this.simpleButtonPause.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonPause.ImageOptions.SvgImage")));
            this.simpleButtonPause.Location = new System.Drawing.Point(12, 374);
            this.simpleButtonPause.Name = "simpleButtonPause";
            this.simpleButtonPause.Size = new System.Drawing.Size(227, 78);
            this.simpleButtonPause.TabIndex = 14;
            this.simpleButtonPause.Text = "PAUSE SALE";
            // 
            // lookUpEditPaymentType
            // 
            this.lookUpEditPaymentType.Location = new System.Drawing.Point(633, 14);
            this.lookUpEditPaymentType.Name = "lookUpEditPaymentType";
            this.lookUpEditPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPaymentType.Size = new System.Drawing.Size(160, 30);
            this.lookUpEditPaymentType.TabIndex = 13;
            this.lookUpEditPaymentType.EditValueChanged += new System.EventHandler(this.lookUpEditPaymentType_EditValueChanged);
            // 
            // lookUpEditSaleType
            // 
            this.lookUpEditSaleType.Location = new System.Drawing.Point(801, 14);
            this.lookUpEditSaleType.Name = "lookUpEditSaleType";
            this.lookUpEditSaleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSaleType.Size = new System.Drawing.Size(160, 30);
            this.lookUpEditSaleType.TabIndex = 11;
            // 
            // panelControl3
            // 
            this.panelControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl3.Controls.Add(this.gridControl1);
            this.panelControl3.Location = new System.Drawing.Point(18, 171);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(977, 598);
            this.panelControl3.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControl1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(973, 596);
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
            // panelControl5
            // 
            this.panelControl5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl5.Controls.Add(this.lblCashier);
            this.panelControl5.Controls.Add(this.label3);
            this.panelControl5.Controls.Add(this.lookUpEditPaymentType);
            this.panelControl5.Controls.Add(this.lookUpEditSaleType);
            this.panelControl5.Location = new System.Drawing.Point(25, 13);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(966, 58);
            this.panelControl5.TabIndex = 3;
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
            // textSearchProduct
            // 
            this.textSearchProduct.AcceptsReturn = true;
            this.textSearchProduct.AcceptsTab = true;
            this.textSearchProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textSearchProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textSearchProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSearchProduct.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearchProduct.Location = new System.Drawing.Point(20, 81);
            this.textSearchProduct.Name = "textSearchProduct";
            this.textSearchProduct.Size = new System.Drawing.Size(973, 81);
            this.textSearchProduct.TabIndex = 0;
            this.textSearchProduct.WordWrap = false;
            this.textSearchProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSearchProduct_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(4, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 47);
            this.label2.TabIndex = 25;
            this.label2.Text = "Change";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblTotalBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalBill.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.Location = new System.Drawing.Point(15, 75);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(505, 105);
            this.lblTotalBill.TabIndex = 0;
            this.lblTotalBill.Text = "0.00";
            this.lblTotalBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(-1, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 56);
            this.label4.TabIndex = 26;
            this.label4.Text = "Total Bill";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1538, 808);
            this.Controls.Add(this.textSearchProduct);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.True;
            this.Name = "Pos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop Name - Company";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pos_FormClosing);
            this.Shown += new System.EventHandler(this.Pos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditTxnId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTendered.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSaleDate;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSaleType;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNew;
        private DevExpress.XtraEditors.SimpleButton btnClearCart;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPay;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPause;
        private DevExpress.XtraEditors.TextEdit textEditTendered;
        private DevExpress.XtraEditors.TextEdit textEditTxnId;
        private System.Windows.Forms.Label lblChange;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentType;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.TextBox textSearchProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label label4;
    }
}