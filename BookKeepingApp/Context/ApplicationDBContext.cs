using BookKeepingApp.Models;
using BookKeepingApp.Models.ViewModel;
using BookKeepingApp.Models.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options ):base (options)
        {

        }

       public DbSet<ReconcilationHeadType> ReconcilationHeadTypes { get; set; }
       public DbSet<IncomeExpenseHead> IncomeExpenseHeads { get; set; }
       public DbSet<IncomeExpense> IncomeExpenses { get; set; }
       public DbSet<Reconcilation> Reconcilations { get; set; }


        #region DB View
        public DbSet<IncomeExpenseView> IncomeExpenseViews { get; set; }
        public DbSet<CumulativeIncomeExpenseView> CumulativeIncomeExpenseViews { get; set; }
        public DbSet<ReconcilationView> ReconcilationViews { get; set; }
        
        #endregion DB View


    }
}
