using BookKeepingApp.Context;
using BookKeepingApp.GenericRepository;
using BookKeepingApp.Repositories;
using BookKeepingApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Extension
{
    public static class ServiceExtension
    {

        public static void DependencyResolving(this IServiceCollection services)
        {
            services.AddScoped<DbContext, ApplicationDBContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReconciliationHeadTypeRepository, ReconciliationHeadTypeRepository>();
            services.AddScoped<IReconciliationHeadTypeService, ReconciliationHeadTypeService>();
            services.AddScoped<IIncomeExpenseHeadRepository, IncomeExpenseHeadRepository>();
            services.AddScoped<IIncomeExpenseHeadService, IncomeExpenseHeadService>();
            services.AddScoped<IIncomeExpenseRepository, IncomeExpenseRepository>();
            services.AddScoped<IIncomeExpenseService, IncomeExpenseService>();
            services.AddScoped<IReconciliationRepository, ReconciliationRepository>();
            services.AddScoped<IReconciliationService, ReconciliationService>();

            services.AddScoped<IIncomeExpenseViewRepository, IncomeExpenseViewRepository>();
            services.AddScoped<IIncomeExpenseViewService, IncomeExpenseViewService>();
            services.AddScoped<ICumulativeIncomeExpenseViewRepository, CumulativeIncomeExpenseViewRepository>();
            services.AddScoped<ICumulativeIncomeExpenseViewService, CumulativeIncomeExpenseViewService>();
            services.AddScoped<IReconciliationViewRepository, ReconciliationViewRepository>();
            services.AddScoped<IReconciliationViewService, ReconciliationViewService>();

        }
    }
}
