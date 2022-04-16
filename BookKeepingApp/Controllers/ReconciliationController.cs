using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookKeepingApp.Models.Enums;
using BookKeepingApp.Models.ViewModel;
using BookKeepingApp.Models.Views;
using BookKeepingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookKeepingApp.Controllers
{
    public class ReconciliationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReconciliationService _reconcilationService;
        private readonly IIncomeExpenseService _incomeExpenseService;
        private readonly IIncomeExpenseViewService _incomeExpenseViewService;
        private readonly ICumulativeIncomeExpenseViewService _cumulativeIncomeExpenseViewService;
        private readonly IReconciliationViewService _reconcilationViewService;

        public ReconciliationController(IMapper mapper,IReconciliationService reconcilationService,
            IIncomeExpenseService incomeExpenseService,
            IIncomeExpenseViewService incomeExpenseViewService,
            ICumulativeIncomeExpenseViewService cumulativeIncomeExpenseViewService,
            IReconciliationViewService  reconcilationViewService)
        {
            _mapper = mapper;
            _reconcilationService = reconcilationService;
            _incomeExpenseService = incomeExpenseService;
            _incomeExpenseViewService = incomeExpenseViewService;
            _cumulativeIncomeExpenseViewService = cumulativeIncomeExpenseViewService;
            _reconcilationViewService = reconcilationViewService;
        }
        
        public ActionResult Index()
        {
           
            return View();
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }        
        public ActionResult Create()
        {
            ViewBag.Year = new SelectList(YearList().Select(s => new { key = s, value = s }), "key", "value");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReconcilationFormViewModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReconcilationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReconcilationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReconcilationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public List<int> YearList()
        {
            List<int> d = new List<int>();
            for (int i = DateTime.Now.AddYears(-5).Year; i < DateTime.Now.AddYears(5).Year; i++)
            {
                d.Add(i);
            }

            return d;
        }
        public ActionResult LoadReconciliationData(int yearId)
        {
            var data = new ReconcilationFormViewModel();
            #region Income Expanse Portion

            List<ReconcilationViewModel> incomeExpanseDataList = new List<ReconcilationViewModel>();           

            var yearOfIncome =_mapper.Map< ReconcilationViewModel>( _incomeExpenseViewService.GetByYearAndHead(yearId, HeadEnum.Income)?? new IncomeExpenseView { Description="Income" });
            var cumulativeYearOfIncome = _mapper.Map <ReconcilationViewModel>(_cumulativeIncomeExpenseViewService.GetByYearAndHead(yearId, HeadEnum.Income)?? new CumulativeIncomeExpenseView { Description="Cumulative Income" });
            var yearOfExpense = _mapper.Map < ReconcilationViewModel >( _incomeExpenseViewService.GetByYearAndHead(yearId, HeadEnum.Expense)?? new IncomeExpenseView { Description = "Cost" });
            var cumulativeYearOfExpense = _mapper.Map < ReconcilationViewModel > (_cumulativeIncomeExpenseViewService.GetByYearAndHead(yearId, HeadEnum.Expense) ?? new CumulativeIncomeExpenseView { Description = "Cumulative Cost" });
            var result = CalculateResult(yearOfIncome, yearOfExpense);
            incomeExpanseDataList.Add(yearOfIncome);
            incomeExpanseDataList.Add(cumulativeYearOfIncome);
            incomeExpanseDataList.Add(yearOfExpense);
            incomeExpanseDataList.Add(cumulativeYearOfExpense);
            incomeExpanseDataList.Add(result);
            data.IncomeExpenseViews = incomeExpanseDataList;

            #endregion  Income Expanse Portion

            #region Reconcilation Portion
            var reconcilationData = _mapper.Map<List<ReconcilationViewModel>>( _reconcilationViewService.GetAll());

            data.Reconciliations = reconcilationData;

            #endregion Reconcilation Portion


            return PartialView(data);
        }

        private ReconcilationViewModel CalculateResult(ReconcilationViewModel yearOfIncome, ReconcilationViewModel yearOfExpense)
        {
            var result = new ReconcilationViewModel
            {
                Description = "Result",
                Jan = yearOfIncome.Jan - yearOfExpense.Jan,
                Feb = yearOfIncome.Feb - yearOfExpense.Feb,
                Mar = yearOfIncome.Mar - yearOfExpense.Mar,
                Apr = yearOfIncome.Apr - yearOfExpense.Apr,
                May = yearOfIncome.May - yearOfExpense.May,
                Jun = yearOfIncome.Jun - yearOfExpense.Jun,
                Jul = yearOfIncome.Jul - yearOfExpense.Jul,
                Aug = yearOfIncome.Aug - yearOfExpense.Aug,
                Sep = yearOfIncome.Sep - yearOfExpense.Sep,                                        
                Oct = yearOfIncome.Oct - yearOfExpense.Oct,
                Nov = yearOfIncome.Nov - yearOfExpense.Nov,
                Dec = yearOfIncome.Dec - yearOfExpense.Dec,

            };

            return result;

        }
    }
}
