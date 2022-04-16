using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models;
using BookKeepingApp.Models.Enums;
using BookKeepingApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BookKeepingApp.Services
{

    public interface IReconciliationHeadTypeService
    {
        List<ReconcilationHeadType> GetAll();
        ReconcilationHeadType Get(int id);
        void Save(ReconcilationHeadType model);
        void Update(ReconcilationHeadType model);
        void Delete(int id);
        bool IsExist(HeadEnum head, string typeName, int id);
    }
    public class ReconciliationHeadTypeService: IReconciliationHeadTypeService
    {
        private readonly IReconciliationHeadTypeRepository _reconcilationHeadTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReconciliationHeadTypeService(IUnitOfWork unitOfWork,IReconciliationHeadTypeRepository reconcilationHeadTypeRepository)
        {
            _reconcilationHeadTypeRepository = reconcilationHeadTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public List<ReconcilationHeadType> GetAll()
        {
            return _reconcilationHeadTypeRepository.GetAll().ToList();
        }

        public ReconcilationHeadType Get(int id)
        {
            return _reconcilationHeadTypeRepository.FirstOrDefault(f => f.Id == id);
        }

        public void Save(ReconcilationHeadType model)
        {
            _reconcilationHeadTypeRepository.Add(model);
            _unitOfWork.Commit();
            
        }
        public void Update(ReconcilationHeadType model)
        {
            _reconcilationHeadTypeRepository.Update(model);
            _unitOfWork.Commit();

        }

        public void Delete(int id)
        {
            var result = _reconcilationHeadTypeRepository.FirstOrDefault(f => f.Id == id);
            _reconcilationHeadTypeRepository.Delete(result);
            _unitOfWork.Commit();
        }

        public bool IsExist(HeadEnum head, string typeName, int id)
        {
            return _reconcilationHeadTypeRepository.IsExist(f => f.Head == head && f.TypeName == typeName && f.Id != id);
        }
    }


}
