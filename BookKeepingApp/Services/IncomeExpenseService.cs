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
        ReconcilationViewModel GetCumulativeAmount(HeadEnum income, int yearId);
        
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

        public ReconcilationViewModel GetCumulativeAmount(HeadEnum head, int yearId)
        {

            var  camulativeData = new ReconcilationViewModel 
            {
                Year=yearId,
                Head= head,
                Description=head==HeadEnum.Income?"Cumulative Income": "Cumulative Cost"
            };
            var result = _incomeExpenseRepository.GetAll().Where(f => f.IncomeExpenseHead.Head == head && f.EntryDate.Year == yearId).ToList();
            List<decimal> cumArray = new List<decimal>();
            decimal cumValue= 0;
            for (int i = 1; i <= 12; i++)
            {
                var res = result.FindAll(f => f.EntryDate.Month == i);
                if (res.Count()>0)
                {
                    cumValue += res.Select(s => s.Amount).Sum();
                    cumArray.Add(cumValue);
                    
                }
                else
                {
                    cumArray.Add(cumValue);
                }
            }
            camulativeData.Jan = cumArray[0];
            camulativeData.Feb = cumArray[1];
            camulativeData.Mar = cumArray[2];
            camulativeData.Apr = cumArray[3];
            camulativeData.May = cumArray[4];
            camulativeData.Jun = cumArray[5];
            camulativeData.Jul = cumArray[6];
            camulativeData.Aug = cumArray[7];
            camulativeData.Sep = cumArray[8];
            camulativeData.Oct = cumArray[9];
            camulativeData.Nov = cumArray[10];
            camulativeData.Dec = cumArray[11];

            return camulativeData;
        }
    }
}
