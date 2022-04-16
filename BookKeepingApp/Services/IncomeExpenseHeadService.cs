using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models;
using BookKeepingApp.Models.Enums;
using BookKeepingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Services
{
    public interface IIncomeExpenseHeadService
    {
        List<IncomeExpenseHead> GetAll();
        List<IncomeExpenseHead> GetAll(HeadEnum head);
        IncomeExpenseHead Get(int id);
        void Save(IncomeExpenseHead model);
        void Update(IncomeExpenseHead model);
        void Delete(int id);
        bool IsExist(HeadEnum head, string typeName, int id);
    }
    public class IncomeExpenseHeadService: IIncomeExpenseHeadService
    {
        private IUnitOfWork _unitOfWork;
        private IIncomeExpenseHeadRepository _incomeExpenseHeadRepository;

        public IncomeExpenseHeadService(IUnitOfWork unitOfWork, IIncomeExpenseHeadRepository incomeExpenseHeadRepository )
        {
            _unitOfWork = unitOfWork;
            _incomeExpenseHeadRepository = incomeExpenseHeadRepository;
        }
        public List<IncomeExpenseHead> GetAll()
        {
            return _incomeExpenseHeadRepository.GetAll().ToList();
        }

        public List<IncomeExpenseHead> GetAll(HeadEnum head)
        {
            return _incomeExpenseHeadRepository.GetAll().Where(f=>f.Head== head).ToList();
        }

        public IncomeExpenseHead Get(int id)
        {
            return _incomeExpenseHeadRepository.FirstOrDefault(f => f.Id == id);
        }

        public void Save(IncomeExpenseHead model)
        {
            _incomeExpenseHeadRepository.Add(model);
            _unitOfWork.Commit();

        }
        public void Update(IncomeExpenseHead model)
        {
            _incomeExpenseHeadRepository.Update(model);
            _unitOfWork.Commit();

        }

        public void Delete(int id)
        {
            var result = _incomeExpenseHeadRepository.FirstOrDefault(f => f.Id == id);
            _incomeExpenseHeadRepository.Delete(result);
            _unitOfWork.Commit();
        }

        public bool IsExist(HeadEnum head, string headName, int id)
        {
            return _incomeExpenseHeadRepository.IsExist(f => f.Head == head && f.HeadName == headName && f.Id != id);
        }
    }
}
