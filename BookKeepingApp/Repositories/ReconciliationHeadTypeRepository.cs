using BookKeepingApp.Context;
using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models;
namespace BookKeepingApp.Repositories
{

    public interface IReconciliationHeadTypeRepository:IRepository<ReconcilationHeadType>
    {

    }
    public class ReconciliationHeadTypeRepository:Repository<ReconcilationHeadType>, IReconciliationHeadTypeRepository
    {
        ApplicationDBContext _dbContext;
        public ReconciliationHeadTypeRepository(ApplicationDBContext context):base(context)
        {
            _dbContext = context;
        }
    }
}
