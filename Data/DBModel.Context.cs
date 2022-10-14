﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Katswiri.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BEntities : DbContext
    {
        public BEntities()
            : base("name=BEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<IncomeType> IncomeTypes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<ReceivingDetail> ReceivingDetails { get; set; }
        public virtual DbSet<Receiving> Receivings { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<StockMovement> StockMovements { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<vwBrand> vwBrands { get; set; }
        public virtual DbSet<vwCart> vwCarts { get; set; }
        public virtual DbSet<vwCategory> vwCategories { get; set; }
        public virtual DbSet<vwCustomer> vwCustomers { get; set; }
        public virtual DbSet<vwExpenseType> vwExpenseTypes { get; set; }
        public virtual DbSet<vwIncomType> vwIncomTypes { get; set; }
        public virtual DbSet<vwOrderCustomer> vwOrderCustomers { get; set; }
        public virtual DbSet<vwPaymentType> vwPaymentTypes { get; set; }
        public virtual DbSet<vwReceivingCart> vwReceivingCarts { get; set; }
        public virtual DbSet<vwReceivingReport> vwReceivingReports { get; set; }
        public virtual DbSet<vwSalesReport> vwSalesReports { get; set; }
        public virtual DbSet<vwShop> vwShops { get; set; }
        public virtual DbSet<vwSReport> vwSReports { get; set; }
        public virtual DbSet<vwStockReport> vwStockReports { get; set; }
        public virtual DbSet<vwStock> vwStocks { get; set; }
        public virtual DbSet<vwUnit> vwUnits { get; set; }
        public virtual DbSet<vwUpdateStock> vwUpdateStocks { get; set; }
        public virtual DbSet<vwUser> vwUsers { get; set; }
        public virtual DbSet<BillPayment> BillPayments { get; set; }
        public virtual DbSet<vwShift> vwShifts { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<vwIncome> vwIncomes { get; set; }
        public virtual DbSet<Expens> Expenses { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<vwExpens> vwExpenses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<vwProduct> vwProducts { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<vwMenu> vwMenus { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
    }
}
