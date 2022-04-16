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
    public interface ICumulativeIncomeExpenseViewService
    {
        List<CumulativeIncomeExpenseView> GetAll();
        List<CumulativeIncomeExpenseView> GetAll(int year);
        CumulativeIncomeExpenseView GetByYearAndHead(int year, HeadEnum head);
    }
    public class CumulativeIncomeExpenseViewService : ICumulativeIncomeExpenseViewService
    {
        private readonly ICumulativeIncomeExpenseViewRepository _cumulativeIncomeExpenseViewRepository;
        public CumulativeIncomeExpenseViewService(ICumulativeIncomeExpenseViewRepository cumulativeIncomeExpenseViewRepository) 
        {
            _cumulativeIncomeExpenseViewRepository = cumulativeIncomeExpenseViewRepository;
        }        

        public List<CumulativeIncomeExpenseView> GetAll()
        {
            return _cumulativeIncomeExpenseViewRepository.GetAll().ToList();
        }
        public List<CumulativeIncomeExpenseView> GetAll(int year)
        {
            return _cumulativeIncomeExpenseViewRepository.GetAll().Where(f=>f.Year==year).ToList();
        }
        public CumulativeIncomeExpenseView GetByYearAndHead(int year, HeadEnum head)
        {

            return _cumulativeIncomeExpenseViewRepository.GetAll().Where(f => f.Year == year && f.Head == head).FirstOrDefault();
        }
    }
}
