using BookKeepingApp.Context;
using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Repositories
{
    public interface IReconciliationRepository:IRepository<Reconcilation>
    {

    }
    public class ReconciliationRepository : Repository<Reconcilation>, IReconciliationRepository
    {
        ApplicationDBContext _dbContext;
        public ReconciliationRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
