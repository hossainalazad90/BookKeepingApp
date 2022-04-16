using BookKeepingApp.Context;
using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Repositories
{
    public interface IIncomeExpenseRepository:IRepository<IncomeExpense>
    {

    }
    public class IncomeExpenseRepository:Repository<IncomeExpense>,IIncomeExpenseRepository
    {
        ApplicationDBContext _dbContext;
        public IncomeExpenseRepository(ApplicationDBContext context):base(context)
        {
            _dbContext = context;
        }

    }
}
