//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        public int RecipeId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<double> Qty { get; set; }
        public Nullable<double> CostPrice { get; set; }
        public Nullable<int> FoodMenuId { get; set; }
    }
}
