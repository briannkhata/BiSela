
namespace Katswiri.Forms
{
    partial class Pay
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
            this.textBoxTendered = new System.Windows.Forms.TextBox();
            this.btnFinishSale = new System.Windows.Forms.Button();
            this.lookUpEditPayMode = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBill = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPayMode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTendered
            // 
            this.textBoxTendered.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTendered.Location = new System.Drawing.Point(13, 269);
            this.textBoxTendered.Name = "textBoxTendered";
            this.textBoxTendered.Size = new System.Drawing.Size(494, 81);
            this.textBoxTendered.TabIndex = 0;
            this.textBoxTendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFinishSale
            // 
            this.btnFinishSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishSale.Location = new System.Drawing.Point(12, 553);
            this.btnFinishSale.Name = "btnFinishSale";
            this.btnFinishSale.Size = new System.Drawing.Size(494, 78);
            this.btnFinishSale.TabIndex = 3;
            this.btnFinishSale.Text = "FINISH SALE";
            this.btnFinishSale.UseVisualStyleBackColor = true;
            this.btnFinishSale.Click += new System.EventHandler(this.btnFinishSale_Click);
            // 
            // lookUpEditPayMode
            // 
            this.lookUpEditPayMode.Location = new System.Drawing.Point(13, 44);
            this.lookUpEditPayMode.Name = "lookUpEditPayMode";
            this.lookUpEditPayMode.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditPayMode.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditPayMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPayMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPayMode.Size = new System.Drawing.Size(492, 48);
            this.lookUpEditPayMode.TabIndex = 9;
            // 
            // lblBill
            // 
            this.lblBill.BackColor = System.Drawing.Color.Black;
            this.lblBill.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBill.ForeColor = System.Drawing.Color.White;
            this.lblBill.Location = new System.Drawing.Point(13, 126);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(492, 118);
            this.lblBill.TabIndex = 10;
            this.lblBill.Text = "label1";
            this.lblBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChange
            // 
            this.lblChange.BackColor = System.Drawing.Color.Black;
            this.lblChange.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.White;
            this.lblChange.Location = new System.Drawing.Point(12, 439);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(492, 89);
            this.lblChange.TabIndex = 11;
            this.lblChange.Text = "label1";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 79);
            this.label1.TabIndex = 12;
            this.label1.Text = "CHANGE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pay
            // 
            this.AcceptButton = this.btnFinishSale;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(518, 660);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblBill);
            this.Controls.Add(this.lookUpEditPayMode);
            this.Controls.Add(this.btnFinishSale);
            this.Controls.Add(this.textBoxTendered);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Pay";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pay_FormClosing);
            this.Load += new System.EventHandler(this.Pay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPayMode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTendered;
        private System.Windows.Forms.Button btnFinishSale;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPayMode;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label1;
    }
}