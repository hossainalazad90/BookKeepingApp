using BookKeepingApp.Context;
using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Repositories
{
    public interface IIncomeExpenseViewRepository:IRepository<IncomeExpenseView>
    {

    }
    public class IncomeExpenseViewRepository : Repository<IncomeExpenseView>, IIncomeExpenseViewRepository
    {
        ApplicationDBContext _dbContext;
        public IncomeExpenseViewRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
