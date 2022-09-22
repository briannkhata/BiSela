
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
            this.textBoxPayReference = new System.Windows.Forms.TextBox();
            this.lookUpEditPayMode = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPayMode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTendered
            // 
            this.textBoxTendered.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTendered.Location = new System.Drawing.Point(11, 133);
            this.textBoxTendered.Name = "textBoxTendered";
            this.textBoxTendered.Size = new System.Drawing.Size(494, 53);
            this.textBoxTendered.TabIndex = 0;
            // 
            // btnFinishSale
            // 
            this.btnFinishSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishSale.Location = new System.Drawing.Point(12, 322);
            this.btnFinishSale.Name = "btnFinishSale";
            this.btnFinishSale.Size = new System.Drawing.Size(494, 73);
            this.btnFinishSale.TabIndex = 3;
            this.btnFinishSale.Text = "FINISH SALE";
            this.btnFinishSale.UseVisualStyleBackColor = true;
            this.btnFinishSale.Click += new System.EventHandler(this.btnFinishSale_Click);
            // 
            // textBoxPayReference
            // 
            this.textBoxPayReference.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPayReference.Location = new System.Drawing.Point(12, 231);
            this.textBoxPayReference.Name = "textBoxPayReference";
            this.textBoxPayReference.Size = new System.Drawing.Size(494, 53);
            this.textBoxPayReference.TabIndex = 4;
            // 
            // lookUpEditPayMode
            // 
            this.lookUpEditPayMode.Location = new System.Drawing.Point(13, 41);
            this.lookUpEditPayMode.Name = "lookUpEditPayMode";
            this.lookUpEditPayMode.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditPayMode.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditPayMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPayMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPayMode.Size = new System.Drawing.Size(492, 48);
            this.lookUpEditPayMode.TabIndex = 9;
            // 
            // Pay
            // 
            this.AcceptButton = this.btnFinishSale;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(518, 490);
            this.Controls.Add(this.lookUpEditPayMode);
            this.Controls.Add(this.textBoxPayReference);
            this.Controls.Add(this.btnFinishSale);
            this.Controls.Add(this.textBoxTendered);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Pay";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.TextBox textBoxPayReference;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPayMode;
    }
}