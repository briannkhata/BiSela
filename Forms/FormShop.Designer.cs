
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace Katswiri.Forms
{
    partial class FormShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShop));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.textEditMotto = new DevExpress.XtraEditors.TextEdit();
            this.textEditCurrency = new DevExpress.XtraEditors.TextEdit();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EmailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TextEditAddress = new DevExpress.XtraEditors.MemoEdit();
            this.textEditVat = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForfee = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelShopId = new System.Windows.Forms.Label();
            this.dateEditExpiryAlert = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMotto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditVat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForfee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpiryAlert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSave});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(509, 232);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 1;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
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
            this.dataLayoutControl1.Controls.Add(this.textEditMotto);
            this.dataLayoutControl1.Controls.Add(this.textEditCurrency);
            this.dataLayoutControl1.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.EmailTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PhoneTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TextEditAddress);
            this.dataLayoutControl1.Controls.Add(this.textEditVat);
            this.dataLayoutControl1.Controls.Add(this.dateEditExpiryAlert);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 232);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(509, 593);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // textEditMotto
            // 
            this.textEditMotto.Location = new System.Drawing.Point(24, 224);
            this.textEditMotto.MenuManager = this.ribbon;
            this.textEditMotto.Name = "textEditMotto";
            this.textEditMotto.Size = new System.Drawing.Size(461, 26);
            this.textEditMotto.StyleController = this.dataLayoutControl1;
            this.textEditMotto.TabIndex = 13;
            // 
            // textEditCurrency
            // 
            this.textEditCurrency.Location = new System.Drawing.Point(24, 175);
            this.textEditCurrency.MenuManager = this.ribbon;
            this.textEditCurrency.Name = "textEditCurrency";
            this.textEditCurrency.Size = new System.Drawing.Size(461, 26);
            this.textEditCurrency.StyleController = this.dataLayoutControl1;
            this.textEditCurrency.TabIndex = 12;
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.Location = new System.Drawing.Point(24, 77);
            this.NameTextEdit.MenuManager = this.ribbon;
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(461, 26);
            this.NameTextEdit.StyleController = this.dataLayoutControl1;
            this.NameTextEdit.TabIndex = 6;
            // 
            // EmailTextEdit
            // 
            this.EmailTextEdit.Location = new System.Drawing.Point(256, 126);
            this.EmailTextEdit.MenuManager = this.ribbon;
            this.EmailTextEdit.Name = "EmailTextEdit";
            this.EmailTextEdit.Size = new System.Drawing.Size(229, 26);
            this.EmailTextEdit.StyleController = this.dataLayoutControl1;
            this.EmailTextEdit.TabIndex = 7;
            // 
            // PhoneTextEdit
            // 
            this.PhoneTextEdit.Location = new System.Drawing.Point(24, 126);
            this.PhoneTextEdit.MenuManager = this.ribbon;
            this.PhoneTextEdit.Name = "PhoneTextEdit";
            this.PhoneTextEdit.Size = new System.Drawing.Size(228, 26);
            this.PhoneTextEdit.StyleController = this.dataLayoutControl1;
            this.PhoneTextEdit.TabIndex = 8;
            // 
            // TextEditAddress
            // 
            this.TextEditAddress.Location = new System.Drawing.Point(24, 371);
            this.TextEditAddress.MenuManager = this.ribbon;
            this.TextEditAddress.Name = "TextEditAddress";
            this.TextEditAddress.Size = new System.Drawing.Size(461, 198);
            this.TextEditAddress.StyleController = this.dataLayoutControl1;
            this.TextEditAddress.TabIndex = 11;
            // 
            // textEditVat
            // 
            this.textEditVat.Location = new System.Drawing.Point(24, 273);
            this.textEditVat.MenuManager = this.ribbon;
            this.textEditVat.Name = "textEditVat";
            this.textEditVat.Size = new System.Drawing.Size(461, 26);
            this.textEditVat.StyleController = this.dataLayoutControl1;
            this.textEditVat.TabIndex = 14;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(509, 593);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(489, 573);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(489, 573);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPhone,
            this.ItemForEmail,
            this.ItemForName,
            this.ItemForfee,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(465, 515);
            this.layoutControlGroup2.Text = "Enter Details";
            // 
            // ItemForPhone
            // 
            this.ItemForPhone.Control = this.PhoneTextEdit;
            this.ItemForPhone.Location = new System.Drawing.Point(0, 49);
            this.ItemForPhone.Name = "ItemForPhone";
            this.ItemForPhone.Size = new System.Drawing.Size(232, 49);
            this.ItemForPhone.Text = "Phone";
            this.ItemForPhone.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForPhone.TextSize = new System.Drawing.Size(102, 16);
            // 
            // ItemForEmail
            // 
            this.ItemForEmail.Control = this.EmailTextEdit;
            this.ItemForEmail.Location = new System.Drawing.Point(232, 49);
            this.ItemForEmail.Name = "ItemForEmail";
            this.ItemForEmail.Size = new System.Drawing.Size(233, 49);
            this.ItemForEmail.Text = "Email";
            this.ItemForEmail.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForEmail.TextSize = new System.Drawing.Size(102, 16);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(465, 49);
            this.ItemForName.Text = "Name";
            this.ItemForName.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForName.TextSize = new System.Drawing.Size(102, 16);
            // 
            // ItemForfee
            // 
            this.ItemForfee.Control = this.TextEditAddress;
            this.ItemForfee.Location = new System.Drawing.Point(0, 294);
            this.ItemForfee.Name = "ItemForfee";
            this.ItemForfee.Size = new System.Drawing.Size(465, 221);
            this.ItemForfee.Text = "Address";
            this.ItemForfee.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForfee.TextSize = new System.Drawing.Size(102, 16);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEditCurrency;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(465, 49);
            this.layoutControlItem1.Text = "Currency";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(102, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEditMotto;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 147);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(465, 49);
            this.layoutControlItem2.Text = "Motto";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(102, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEditVat;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 196);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(465, 49);
            this.layoutControlItem3.Text = "VAT";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(102, 16);
            // 
            // labelShopId
            // 
            this.labelShopId.BackColor = System.Drawing.Color.Gainsboro;
            this.labelShopId.ForeColor = System.Drawing.Color.Transparent;
            this.labelShopId.Location = new System.Drawing.Point(226, 175);
            this.labelShopId.Name = "labelShopId";
            this.labelShopId.Size = new System.Drawing.Size(100, 23);
            this.labelShopId.TabIndex = 4;
            // 
            // dateEditExpiryAlert
            // 
            this.dateEditExpiryAlert.Location = new System.Drawing.Point(24, 322);
            this.dateEditExpiryAlert.MenuManager = this.ribbon;
            this.dateEditExpiryAlert.Name = "dateEditExpiryAlert";
            this.dateEditExpiryAlert.Size = new System.Drawing.Size(461, 26);
            this.dateEditExpiryAlert.StyleController = this.dataLayoutControl1;
            this.dateEditExpiryAlert.TabIndex = 15;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dateEditExpiryAlert;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 245);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(465, 49);
            this.layoutControlItem4.Text = "Expiry Alert Days";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(102, 16);
            // 
            // FormShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(509, 825);
            this.Controls.Add(this.labelShopId);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormShop";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop SetUp";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditMotto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditVat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForfee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpiryAlert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DataLayoutControl dataLayoutControl1;
        private LayoutControlGroup Root;
        private TextEdit NameTextEdit;
        private TextEdit EmailTextEdit;
        private TextEdit PhoneTextEdit;
        private LayoutControlGroup layoutControlGroup1;
        private TextEdit textEditMotto;
        private TextEdit textEditCurrency;
        private MemoEdit TextEditAddress;
        private TextEdit textEditVat;
        private System.Windows.Forms.Label labelShopId;
        private TabbedControlGroup tabbedControlGroup1;
        private LayoutControlGroup layoutControlGroup2;
        private LayoutControlItem ItemForPhone;
        private LayoutControlItem ItemForEmail;
        private LayoutControlItem ItemForName;
        private LayoutControlItem ItemForfee;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private TextEdit dateEditExpiryAlert;
        private LayoutControlItem layoutControlItem4;
    }
}