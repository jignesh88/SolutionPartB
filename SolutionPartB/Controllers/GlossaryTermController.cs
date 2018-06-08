using System;
using SolutionPartB.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using SolutionPartB.Models;
using AutoMapper;
using SolutionPartB.Data.Entity;
using System.Collections.Generic;
namespace SolutionPartB.Controllers
{
    public class GlossaryTermController : Controller
    {
        private readonly IGloassaryTermRepository _repository;
        public GlossaryTermController(IGloassaryTermRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index(){
            var list = _repository.GetAll();
            var model = Mapper.Map<IEnumerable<GlossaryTermViewModel>>(list);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(GlossaryTermViewModel model){
            if(ModelState.IsValid){
                try
                {
                    var entity = Mapper.Map<GlossaryTerm>(model);
                    entity.GlossaryTermId = Guid.NewGuid();
                    entity.CreatedDate = DateTime.Now;
                    _repository.Add(entity);
                    _repository.SaveChanges();
                    return Redirect("Index");
                }
                catch (Exception)
                {
                    return View(model);
                }

            } else{ 
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid glossaryTermId)
        {
            var entity = _repository.GetById(glossaryTermId);
            var model = Mapper.Map<GlossaryTermViewModel>(entity);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(GlossaryTermViewModel model)
        {
            var entity = Mapper.Map<GlossaryTerm>(model);
            _repository.Update(entity);
            _repository.SaveChanges();
            return Redirect("Index");
        }

        [HttpGet]
        public JsonResult Remove(Guid glossaryTermId){
            try
            {
                var entity = _repository.GetById(glossaryTermId);
                _repository.Delete(entity);
                _repository.SaveChanges();
                return new JsonResult(new { success = true, Message = "Record Deleted" });
            }
            catch (Exception)
            {
                return new JsonResult(new { success = false, Message = "Error deleting record" });
            }

        }
    }
}
