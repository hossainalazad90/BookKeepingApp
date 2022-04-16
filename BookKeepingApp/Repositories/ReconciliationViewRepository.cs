using BookKeepingApp.Context;
using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models.ViewModel;
using BookKeepingApp.Models.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Repositories
{
    public interface IReconciliationViewRepository:IRepository<ReconcilationView>
    {       
        
    }
    public class ReconciliationViewRepository : Repository<ReconcilationView>, IReconciliationViewRepository
    {
        ApplicationDBContext _dbContext;
        public ReconciliationViewRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext = context;
        }

    }
}
