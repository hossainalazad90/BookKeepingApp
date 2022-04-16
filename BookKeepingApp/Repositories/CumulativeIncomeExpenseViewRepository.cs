using BookKeepingApp.Context;
using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Repositories
{
    public interface ICumulativeIncomeExpenseViewRepository : IRepository<CumulativeIncomeExpenseView>
    {

    }
    public class CumulativeIncomeExpenseViewRepository : Repository<CumulativeIncomeExpenseView>, ICumulativeIncomeExpenseViewRepository
    {
        ApplicationDBContext _dbContext;
        public CumulativeIncomeExpenseViewRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
