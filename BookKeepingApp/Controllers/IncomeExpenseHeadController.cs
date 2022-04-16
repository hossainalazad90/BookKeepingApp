using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookKeepingApp.Models;
using BookKeepingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKeepingApp.Controllers
{
    public class IncomeExpenseHeadController : Controller
    {
        private readonly IIncomeExpenseHeadService _incomeExpenseHeadService;

        
        public IncomeExpenseHeadController(IIncomeExpenseHeadService incomeExpenseHeadService)
        {
            _incomeExpenseHeadService = incomeExpenseHeadService;

        }
        public ActionResult Index()
        {
            var list = _incomeExpenseHeadService.GetAll();
            return View(list);
        }
        public ActionResult Details(int id)
        {
            var result = _incomeExpenseHeadService.Get(id);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IncomeExpenseHead model)
        {

            var isExistChecking = _incomeExpenseHeadService.IsExist(model.Head, model.HeadName, model.Id);
            if (isExistChecking)
            {
                ModelState.AddModelError("HeadName", "Head Name Already Exist.");
                return View(model);
            }
            try
            {

                _incomeExpenseHeadService.Save(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var model = _incomeExpenseHeadService.Get(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IncomeExpenseHead model)
        {

            var isExistChecking = _incomeExpenseHeadService.IsExist(model.Head, model.HeadName, model.Id);
            if (isExistChecking)
            {
                ModelState.AddModelError("HeadName", "Head Name Already Exist.");
                return View(model);
            }
            try
            {
                _incomeExpenseHeadService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var model = _incomeExpenseHeadService.Get(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _incomeExpenseHeadService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
