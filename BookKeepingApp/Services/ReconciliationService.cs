using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models;
using BookKeepingApp.Models.ViewModel;
using BookKeepingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Services
{
    public interface IReconciliationService
    {
        List<ReconcilationViewModel> GetAll(int yearId);
        void SaveOrUpdateList(List<Reconcilation> Models);
    }
    public class ReconciliationService : IReconciliationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReconciliationRepository _reconciliationRepository;
        private readonly IReconciliationHeadTypeRepository _reconciliationHeadTypeRepository;

        public ReconciliationService(IUnitOfWork unitOfWork,IReconciliationRepository reconciliationRepository,IReconciliationHeadTypeRepository reconciliationHeadTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _reconciliationRepository = reconciliationRepository;
            _reconciliationHeadTypeRepository = reconciliationHeadTypeRepository;

        }

        public List<ReconcilationViewModel> GetAll(int yearId)
        {
            var result = (from rht in _reconciliationHeadTypeRepository.GetAll()
                          join r in _reconciliationRepository.GetAll().Where(f=>f.Year==yearId) on rht.Id equals r.ReconcilationHeadTypeId  into headType
                          from m in headType.DefaultIfEmpty()
                          select new ReconcilationViewModel
                          {
                              Id = m !=null? m.Id:0,
                              Head = rht.Head,
                              Description = rht.TypeName,
                              ReconcilationHeadTypeId=rht.Id,
                              Year = yearId,
                              Jan = m != null ? m.Jan:0,
                              Feb = m != null ? m.Feb:0,
                              Mar = m != null ? m.Mar:0,
                              Apr = m != null ? m.Apr:0,
                              May = m != null ? m.May:0,
                              Jun = m != null ? m.Jun:0,
                              Jul = m != null ? m.Jul:0,
                              Aug = m != null ? m.Aug:0,
                              Sep = m != null ? m.Sep:0,
                              Oct = m != null ? m.Oct:0,
                              Nov = m != null ? m.Nov:0,
                              Dec = m != null ? m.Dec:0
                          });
            return result.OrderBy(f=>f.Head).ThenBy(f=>f.Description).ToList();

        }

        public void SaveOrUpdateList(List<Reconcilation> Models)
        {
            foreach (var item in Models)
            {
                if (item.Id>0)
                {
                    _reconciliationRepository.Update(item);
                }
                else
                {
                    _reconciliationRepository.Add(item);
                }                

            }          
            _unitOfWork.Commit();
        }
    }
}
