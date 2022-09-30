
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
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.lookUpEditPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpEditSaleType = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lookUpEditCashier = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lookUpEditCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCashier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(28, 89);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(295, 26);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(353, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(354, 89);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(295, 26);
            this.dateTimePickerTo.TabIndex = 2;
            // 
            // lookUpEditPaymentType
            // 
            this.lookUpEditPaymentType.Location = new System.Drawing.Point(27, 161);
            this.lookUpEditPaymentType.Name = "lookUpEditPaymentType";
            this.lookUpEditPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPaymentType.Size = new System.Drawing.Size(621, 26);
            this.lookUpEditPaymentType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Payment Type";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(26, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sale Type";
            // 
            // lookUpEditSaleType
            // 
            this.lookUpEditSaleType.Location = new System.Drawing.Point(28, 227);
            this.lookUpEditSaleType.Name = "lookUpEditSaleType";
            this.lookUpEditSaleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSaleType.Size = new System.Drawing.Size(621, 26);
            this.lookUpEditSaleType.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cashier";
            // 
            // lookUpEditCashier
            // 
            this.lookUpEditCashier.Location = new System.Drawing.Point(26, 295);
            this.lookUpEditCashier.Name = "lookUpEditCashier";
            this.lookUpEditCashier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCashier.Size = new System.Drawing.Size(621, 26);
            this.lookUpEditCashier.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(22, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Customer";
            // 
            // lookUpEditCustomer
            // 
            this.lookUpEditCustomer.Location = new System.Drawing.Point(24, 367);
            this.lookUpEditCustomer.Name = "lookUpEditCustomer";
            this.lookUpEditCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCustomer.Size = new System.Drawing.Size(621, 26);
            this.lookUpEditCustomer.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 49);
            this.button1.TabIndex = 12;
            this.button1.Text = "Filter Report";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormFilterReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(691, 502);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lookUpEditCustomer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lookUpEditCashier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookUpEditSaleType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpEditPaymentType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormFilterReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Sales Report";
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCashier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSaleType;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCashier;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCustomer;
        private System.Windows.Forms.Button button1;
    }
}