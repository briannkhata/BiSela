using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Katswiri.Data;
using Katswiri.Forms;
using Katswiri.Reports;
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
            using (var db = new BEntities()) 
            {
                userNameDisplay.Caption = $"{LoginInfo.UserName} ({ db.Users.Where(x => x.UserId == LoginInfo.UserId).Single().Name })";
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
                this.closeAllMdiChildren();
                userNameDisplay.Caption = "";
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
            //ShowHome();
            using (db = new BEntities()) 
            {
                UsersReport userReport = new UsersReport();
                //userReport.DataSource = db.Stocks.ToList();
                ReportPrintTool printTool = new ReportPrintTool(userReport);
                printTool.ShowPreviewDialog();

                //XtraReport report = new XtraReport();
                //report.DataSource = db.Stocks.ToList();
                //ReportPrintTool tool = new ReportPrintTool(report);
                //tool.ShowPreview();
            }
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

     

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowFormShopFom();
        }

        private void ShowFormShopFom()
        {
            FormShop FormShop = null;
            if (FormShop == null || FormShop.IsDisposed)
            {
                FormShop = new FormShop();
            }
            FormShop.Activate();
            FormShop.ShowDialog();
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
       
        private void ShowUserFom()
        {
            try
            {
                Users users = null;
                if (users == null || users.IsDisposed)
                {
                    users = new Users();
                }
                users.Activate();
                users.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to exit Biselu?", "Biselu", MessageBoxButtons.YesNo) == DialogResult.No)
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
            FormCustomer formCustomer = new FormCustomer();
            formCustomer.ShowDialog();
            //ShowPosFom();
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowUpdateStockFom();
        }

        private void ShowUpdateStockFom()
        {
            try
            {
                FormUpdateStock formUpdateStock = null;
                if (formUpdateStock == null || formUpdateStock.IsDisposed)
                {
                    formUpdateStock = new FormUpdateStock();
                }
                formUpdateStock.Activate();
                formUpdateStock.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowMoveStockFom();
        }

        private void ShowMoveStockFom()
        {
            try
            {
                FormMoveStock formMoveStock = null;
                if (formMoveStock == null || formMoveStock.IsDisposed)
                {
                    formMoveStock = new FormMoveStock();
                }
                formMoveStock.Activate();
                formMoveStock.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Loading");
            ShowReceiveStockFom();
        }

        private void ShowReceiveStockFom()
        {
            try
            {
                FormReceiveStock formReceiveStock = null;
                if (formReceiveStock == null || formReceiveStock.IsDisposed)
                {
                   formReceiveStock = new FormReceiveStock();
                }
                formReceiveStock.Activate();
                formReceiveStock.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (db = new BEntities())
            {
                StockReport stockReport = new StockReport();
                //userReport.DataSource = db.Stocks.ToList();
                ReportPrintTool printTool = new ReportPrintTool(stockReport);
                //printTool.ShowPreviewDialog();
                printTool.ShowPreview();
            }
        }
    }
}