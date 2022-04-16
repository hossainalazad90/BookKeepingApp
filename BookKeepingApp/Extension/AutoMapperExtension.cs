using AutoMapper;
using BookKeepingApp.Models.ViewModel;
using BookKeepingApp.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Extension
{
    public class AutoMapperExtension:Profile
    {
        public AutoMapperExtension()
        {
            this.CreateMap<IncomeExpenseView, ReconcilationViewModel>();
            this.CreateMap<CumulativeIncomeExpenseView, ReconcilationViewModel>();
            this.CreateMap<ReconcilationView, ReconcilationViewModel>();
        }
    }
}
