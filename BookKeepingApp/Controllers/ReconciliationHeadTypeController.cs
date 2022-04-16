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
    public class ReconciliationHeadTypeController : Controller
    {
        private readonly IReconciliationHeadTypeService _reconcilationHeadTypeService;

       
        public ReconciliationHeadTypeController(IReconciliationHeadTypeService reconcilationHeadTypeService)
        {
            _reconcilationHeadTypeService = reconcilationHeadTypeService;

        }
        public ActionResult Index()
        {
            var list = _reconcilationHeadTypeService.GetAll();
            return View(list);
        }       
        public ActionResult Details(int id)
        {
            var result = _reconcilationHeadTypeService.Get(id);
            return View(result);
        }
        
        public ActionResult Create()
        {
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReconcilationHeadType model)
        {           

            var isExistChecking = _reconcilationHeadTypeService.IsExist(model.Head,model.TypeName,model.Id);
            if (isExistChecking)
            {
                ModelState.AddModelError("TypeName", "Type Name Already Exist.");
                return View(model);
            }
            try
            {
                
                _reconcilationHeadTypeService.Save(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
       
        public ActionResult Edit(int id)
        {
            var model = _reconcilationHeadTypeService.Get(id);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReconcilationHeadType model)
        {
            
            var isExistChecking = _reconcilationHeadTypeService.IsExist(model.Head, model.TypeName, model.Id);
            if (isExistChecking)
            {
                ModelState.AddModelError("TypeName", "Type Name Already Exist.");
                return View(model);
            }
            try
            {
                _reconcilationHeadTypeService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete(int id)
        {
            var model = _reconcilationHeadTypeService.Get(id);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _reconcilationHeadTypeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
