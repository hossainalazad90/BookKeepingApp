using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Models.ViewModel
{
    public class ReconcilationFormViewModel
    {
        public int Year { get; set; }
        public List<ReconcilationViewModel> IncomeExpenseViews { get; set; }
        public List<ReconcilationViewModel> Reconciliations { get; set; }
    }
}
