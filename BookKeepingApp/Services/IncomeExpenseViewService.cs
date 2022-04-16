using BookKeepingApp.Models.Enums;
using BookKeepingApp.Models.ViewModel;
using BookKeepingApp.Models.Views;
using BookKeepingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeepingApp.Services
{
    public interface IIncomeExpenseViewService
    {
        List<IncomeExpenseView> GetAll();
        List<IncomeExpenseView> GetAll(int year);
        IncomeExpenseView GetByYearAndHead(int year,HeadEnum head);
    }
    public class IncomeExpenseViewService : IIncomeExpenseViewService
    {
        private readonly IIncomeExpenseViewRepository _incomeExpenseViewRepository;
        public IncomeExpenseViewService(IIncomeExpenseViewRepository incomeExpenseViewRepository) 
        {
            _incomeExpenseViewRepository = incomeExpenseViewRepository;
        }        

        public List<IncomeExpenseView> GetAll()
        {
            return _incomeExpenseViewRepository.GetAll().ToList();
        }
        public List<IncomeExpenseView> GetAll(int year)
        {
            return _incomeExpenseViewRepository.GetAll().Where(f=>f.Year==year).ToList();
        }

        public IncomeExpenseView GetByYearAndHead(int year, HeadEnum head)
        {
            
            return _incomeExpenseViewRepository.GetAll().Where(f => f.Year == year && f.Head==head).FirstOrDefault();
        }
    }
}
