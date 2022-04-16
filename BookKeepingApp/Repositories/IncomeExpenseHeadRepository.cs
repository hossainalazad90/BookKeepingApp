using BookKeepingApp.Context;
using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Repositories
{
    public interface IIncomeExpenseHeadRepository:IRepository<IncomeExpenseHead>
    {

    }
    public class IncomeExpenseHeadRepository:Repository<IncomeExpenseHead>, IIncomeExpenseHeadRepository
    {
        ApplicationDBContext _dbContext;
        public IncomeExpenseHeadRepository(ApplicationDBContext context):base(context)
        {
            _dbContext = context;
        }

    }
}
