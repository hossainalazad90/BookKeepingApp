using BookKeepingApp.Models.Views;
using BookKeepingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Services
{
    public interface IReconciliationViewService
    {
        List<ReconcilationView> GetAll();
    }
    public class ReconciliationViewService : IReconciliationViewService
    {
        private IReconciliationViewRepository _reconcilationViewRepository;

        public ReconciliationViewService( IReconciliationViewRepository  reconcilationViewRepository)
        {
            _reconcilationViewRepository = reconcilationViewRepository;
        }
        public List<ReconcilationView> GetAll()
        {
            return _reconcilationViewRepository.GetAll().OrderBy(f=>f.Head).ThenBy(f=>f.Description).ToList();
        }
    }
}
