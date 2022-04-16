using BookKeepingApp.GenericRepository;
using BookKeepingApp.Models;
using BookKeepingApp.Models.Enums;
using BookKeepingApp.Models.ViewModel;
using BookKeepingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Services
{
    public interface IIncomeExpenseService
    {
        List<IncomeExpense> GetAll();
        List<IncomeExpense> GetAll(HeadEnum head);
        IncomeExpense Get(int id);
        void Save(IncomeExpense model);
        void Update(IncomeExpense model);
        void Delete(int id);
        //ReconcilationViewModel MonthWiseData(int yearId, HeadEnum income);
        //ReconcilationViewModel GetAll(int yearId, HeadEnum expense);
        //ReconcilationViewModel MonthWiseCumulativeData(int yearId, HeadEnum income);
    }

    public class IncomeExpenseService : IIncomeExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIncomeExpenseRepository _incomeExpenseRepository;
       

        public IncomeExpenseService(IUnitOfWork unitOfWork,IIncomeExpenseRepository incomeExpenseRepository)
        {
            _unitOfWork = unitOfWork;
            _incomeExpenseRepository = incomeExpenseRepository;
            
        }

        public List<IncomeExpense> GetAll()
        {
            return _incomeExpenseRepository.GetAll().OrderBy(f => f.EntryDate).ToList();
        }
        public List<IncomeExpense> GetAll(HeadEnum head)
        {
            return _incomeExpenseRepository.GetAll().Where(f=>f.IncomeExpenseHead.Head== head).OrderBy(f=>f.EntryDate).ToList();
        }
        public IncomeExpense Get(int id)
        {
            return _incomeExpenseRepository.FirstOrDefault(f => f.Id==id);
        }

        public void Save(IncomeExpense model)
        {
            _incomeExpenseRepository.Add(model);
            _unitOfWork.Commit();
        }

        public void Update(IncomeExpense model)
        {
             _incomeExpenseRepository.Update(model);
            _unitOfWork.Commit();
        }
        public void Delete(int id)
        {
            var result = _incomeExpenseRepository.FirstOrDefault(f => f.Id == id);
            _incomeExpenseRepository.Delete(result);
            _unitOfWork.Commit();
        }        
    }
}
