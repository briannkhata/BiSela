﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Katswiri.Data;
using Katswiri.Forms;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katswiri
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        //private Login formLogin;
        Home home = null;
        Main main = null;
        Products productsForm = null;
        Login formLogin = null;
        BEntities db;

        User user;

        Categories categoriesForm = null;
        Units unitsForm = null;

        public Main()
        {
           InitializeComponent();
           this.IsMdiContainer = true;
           versionHi.Caption = $"Version : {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
           logout.Caption = "Logout";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            //showLogin();
        }


        private void showLogin()
        {
            formLogin = new Login();
            ribbon.Enabled = false;
            SplashScreenManager.CloseDefaultSplashScreen();
            if(formLogin.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    InitMainView();
                    ribbon.Enabled = true;
                    logger.Info($"User logged into the system");
                }
                catch (Exception ex)
                {
                    logger.Error(ex, ex.Message);
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void ShowHome()
        {
            if (home == null || home.IsDisposed)
            {
                home = new Home();
            }
            home.MdiParent = this;
            home.Activate();
            home.Show();
            home.BringToFront();
        }

        private void ShowUnitFom()
        {
            if (unitsForm == null || unitsForm.IsDisposed)
            {
                unitsForm = new Units();
            }
            unitsForm.Activate();
            unitsForm.ShowDialog();
        }

        private void ShowCategoryFom()
        {
            if (categoriesForm == null || categoriesForm.IsDisposed)
            {
                categoriesForm = new Categories();
            }
            categoriesForm.Activate();
            categoriesForm.ShowDialog();
        }

        private void ShowProductFom()
        {
            if (productsForm == null || productsForm.IsDisposed)
            {
                productsForm = new Products();
            }
            productsForm.Activate();
            productsForm.ShowDialog();
        }

        //private void ShowCategories()
        //{
        //    if (formCategories == null || formCategories.IsDisposed)
        //    {
        //        formCategories = new Categories();
        //    }
        //    //formCategories.MdiParent = this;
        //    //formCategories.Activate();
        //    formCategories.ShowDialog();
        //    formCategories.Ribbon.BringToFront();
        //}

        //private void ViewStockForm()
        //{
        //    if (viewStock == null || viewStock.IsDisposed)
        //    {
        //        viewStock = new ViewStock();
        //    }
        //    viewStock.MdiParent = this;
        //    viewStock.Activate();
        //    viewStock.Show();
        //    viewStock.Ribbon.BringToFront();
        //}


        private void InitMainView()
        {
            using (var db = new BEntities()) {
                //usernameLabel.Caption = $"{Globals.User.UserName} (<b>{Globals.User.FirstName} {Globals.User.SurName}</b>)";
                userNameDisplay.Caption = $"{LoginInfo.UserName} (<b>{ db.Users.Where(x => x.UserId == LoginInfo.UserId).Single().Name }</b>)";
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            //showLogin();
            //user.Caption = $"{logg.User.UserName} (<b>{Globals.User.FirstName} {Globals.User.SurName}</b>)";
            userNameDisplay.Caption = LoginInfo.UserName;
        }

        private void doSignOut()
        {
            try
            {
                //this.closeAllMdiChildren();
                //Globals.User = null;
                //Globals.AuthenticationHeader = null;
                //usernameLabel.Caption = "";
                showLogin();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                Application.Exit();
            }
        }

        private void closeAllMdiChildren()
        {
            var mdiChildren = main.MdiChildren;
            foreach (var item in mdiChildren)
            {
                item.Close();
            }
        }


        private void ribbon_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e)
        {
            ribbon.SelectPage(e.MergedChild.SelectedPage);

        }

        private void btnHome_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowHome();
        }

       
        private void btnCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowCategoryFom();
        }

        private void btnProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowProductFom();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowUnitFom();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowIncomeTypeFom();
        }

        private void ShowIncomeTypeFom()
        {
            IncomeTypes incomeTypes = null;
            if (incomeTypes == null || incomeTypes.IsDisposed)
            {
                incomeTypes = new IncomeTypes();
            }
            incomeTypes.Activate();
            incomeTypes.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowExpenseTypeFom();
        }

        private void ShowExpenseTypeFom()
        {
            ExpenseTypes expenseTypes = null;
            if (expenseTypes == null || expenseTypes.IsDisposed)
            {
                expenseTypes = new ExpenseTypes();
            }
            expenseTypes.Activate();
            expenseTypes.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowPaymentTypeFom();
        }

        private void ShowPaymentTypeFom()
        {
            PaymentTypes paymentTypes = null;
            if (paymentTypes == null || paymentTypes.IsDisposed)
            {
                paymentTypes = new PaymentTypes();
            }
            paymentTypes.Activate();
            paymentTypes.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowBankFom();
        }

        private void ShowBankFom()
        {
            Banks banks = null;
            if (banks == null || banks.IsDisposed)
            {
                banks = new Banks();
            }
            banks.Activate();
            banks.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowIncomeFom();
        }

        private void ShowIncomeFom()
        {
            Incomes incomes = null;
            if (incomes == null || incomes.IsDisposed)
            {
                incomes = new Incomes();
            }
            incomes.Activate();
            incomes.ShowDialog();
        }

      

        private void ShowPosFom()
        {
            Pos pos = null;
            if (pos == null || pos.IsDisposed)
            {
                pos = new Pos();
            }
            pos.Activate();
            pos.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowExpenseFom();
        }

        private void ShowExpenseFom()
        {
            Expenses expenses = null;
            if (expenses == null || expenses.IsDisposed)
            {
                expenses = new Expenses();
            }
            expenses.Activate();
            expenses.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowShopFom();
        }

        private void ShowShopFom()
        {
            Shops shops = null;
            if (shops == null || shops.IsDisposed)
            {
                shops = new Shops();
            }
            shops.Activate();
            shops.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowSettingFom();
        }

        private void ShowSettingFom()
        {
            Forms.Shop settngs = null;
            if (settngs == null || settngs.IsDisposed)
            {
                settngs = new Forms.Shop();
            }
            settngs.Activate();
            settngs.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowTaxTypeFom();
        }

        private void ShowTaxTypeFom()
        {
            TaxTypes taxTypes = null;
            if (taxTypes == null || taxTypes.IsDisposed)
            {
                taxTypes = new TaxTypes();
            }
            taxTypes.Activate();
            taxTypes.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowBrandFom();
        }

        private void ShowBrandFom()
        {
            Brands brands = null;
            if (brands == null || brands.IsDisposed)
            {
                brands = new Brands();
            }
            brands.Activate();
            brands.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowRoleFom();
        }

        private void ShowRoleFom()
        {
            Roles roles = null;
            if (roles == null || roles.IsDisposed)
            {
                roles = new Roles();
            }
            roles.Activate();
            roles.ShowDialog();
        }

        private void ShowUserFom()
        {
            Users users = null;
            if (users == null || users.IsDisposed)
            {
                users = new Users();
            }
            users.Activate();
            users.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to exit Katswiri?", "Katswiri", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            showLogin();
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowUserFom();
        }

        private void logout_ItemClick(object sender, ItemClickEventArgs e)
        {
            doSignOut();
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowPosFom();
        }

   
    }
}