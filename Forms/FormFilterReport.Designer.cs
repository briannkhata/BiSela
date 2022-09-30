
namespace Katswiri.Forms
{
    partial class FormFilterReport
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lookUpEditCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lookUpEditCashier = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpEditSaleType = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEditPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCashier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.lookUpEditCustomer);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.lookUpEditCashier);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.lookUpEditSaleType);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.lookUpEditPaymentType);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.dateTimePickerTo);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.dateTimePickerFrom);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(691, 502);
            this.panelControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 49);
            this.button1.TabIndex = 25;
            this.button1.Text = "Filter Report";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(17, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 23);
            this.label6.TabIndex = 24;
            this.label6.Text = "Customer";
            // 
            // lookUpEditCustomer
            // 
            this.lookUpEditCustomer.Location = new System.Drawing.Point(19, 326);
            this.lookUpEditCustomer.Name = "lookUpEditCustomer";
            this.lookUpEditCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCustomer.Size = new System.Drawing.Size(621, 26);
            this.lookUpEditCustomer.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "Cashier";
            // 
            // lookUpEditCashier
            // 
            this.lookUpEditCashier.Location = new System.Drawing.Point(21, 254);
            this.lookUpEditCashier.Name = "lookUpEditCashier";
            this.lookUpEditCashier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCashier.Size = new System.Drawing.Size(621, 26);
            this.lookUpEditCashier.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Sale Type";
            // 
            // lookUpEditSaleType
            // 
            this.lookUpEditSaleType.Location = new System.Drawing.Point(23, 186);
            this.lookUpEditSaleType.Name = "lookUpEditSaleType";
            this.lookUpEditSaleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSaleType.Size = new System.Drawing.Size(621, 26);
            this.lookUpEditSaleType.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Payment Type";
            // 
            // lookUpEditPaymentType
            // 
            this.lookUpEditPaymentType.Location = new System.Drawing.Point(22, 120);
            this.lookUpEditPaymentType.Name = "lookUpEditPaymentType";
            this.lookUpEditPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPaymentType.Size = new System.Drawing.Size(621, 26);
            this.lookUpEditPaymentType.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(348, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "To Date";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(349, 48);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(278, 22);
            this.dateTimePickerTo.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "From Date";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(23, 48);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(278, 22);
            this.dateTimePickerFrom.TabIndex = 13;
            // 
            // FormFilterReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(691, 502);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormFilterReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Sales Report";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCashier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCustomer;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCashier;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSaleType;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
    }
}