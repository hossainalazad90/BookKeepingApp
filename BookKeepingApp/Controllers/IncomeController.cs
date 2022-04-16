using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookKeepingApp.Models;
using BookKeepingApp.Models.Enums;
using BookKeepingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookKeepingApp.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeExpenseService _incomeExpenseService;
        private readonly IIncomeExpenseHeadService _incomeExpenseHeadService;

        public IncomeController(IIncomeExpenseService incomeExpenseService,IIncomeExpenseHeadService incomeExpenseHeadService)
        {
            _incomeExpenseService = incomeExpenseService;
            _incomeExpenseHeadService = incomeExpenseHeadService;
        }
        public ActionResult Index()
       {
            var result = _incomeExpenseService.GetAll(HeadEnum.Income);
            return View(result);
        }
       
        public ActionResult Details(int id)
        {
            var result = _incomeExpenseService.Get(id);
            return View(result);
        }
        
        public ActionResult Create()
        {
            ViewBag.IncomeExpenseHeadId = new SelectList(_incomeExpenseHeadService.GetAll(HeadEnum.Income),"Id","HeadName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IncomeExpense model)
        {
            ViewBag.IncomeExpenseHeadId = new SelectList(_incomeExpenseHeadService.GetAll(HeadEnum.Income), "Id", "HeadName",model.IncomeExpenseHeadId);
            try
            {
                _incomeExpenseService.Save(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
        
        public ActionResult Edit(int id)
        {
            
            var result = _incomeExpenseService.Get(id);
            ViewBag.IncomeExpenseHeadId = new SelectList(_incomeExpenseHeadService.GetAll(HeadEnum.Income), "Id", "HeadName",result.IncomeExpenseHeadId);
            return View(result);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IncomeExpense model)
        {
            ViewBag.IncomeExpenseHeadId = new SelectList(_incomeExpenseHeadService.GetAll(HeadEnum.Income), "Id", "HeadName", model.IncomeExpenseHeadId);
            try
            {
                _incomeExpenseService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        
        public ActionResult Delete(int id)
        {
            var result = _incomeExpenseService.Get(id);
            return View(result);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IncomeExpense model)
        {
            try
            {
                _incomeExpenseService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
