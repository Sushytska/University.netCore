using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using Entities.DTOModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SpecialitiesController: Controller
    {
        private readonly IManager<SpecialityDTO>_specialityManager;
        private readonly IManager<DepartmentDTO>_departmentManager;

        public SpecialitiesController(IManager<SpecialityDTO> specialityManager, IManager<DepartmentDTO> departmentManager)
        {
            _specialityManager = specialityManager;
            _departmentManager = departmentManager;
        }
        public ActionResult Index(string searchString)
        {
            var specialities = new List<SpecialityViewModel>();
            if (String.IsNullOrEmpty(searchString))
            {
                foreach (var speciality in _specialityManager.GetAll())
                {
                    var department = _departmentManager.GetById(speciality.DepartmentId).NameOfDepartment;
                    var specialityViewModel = new SpecialityViewModel
                    {
                        Id = speciality.Id,
                        NameOfSpeciality = speciality.NameOfSpeciality,
                        Department = department
                    };
                    specialities.Add(specialityViewModel);
                }
            }
            else
            {
                var departmentId = _departmentManager.GetAll().Where(t => t.NameOfDepartment.Equals(searchString)).ToList()
                    .First().Id;
                foreach (var speciality in _specialityManager.GetAll().Where(t => t.DepartmentId.Equals(departmentId)).ToList())
                {
                    var specialityViewModel = new SpecialityViewModel
                    {
                        Id = speciality.Id,
                        NameOfSpeciality = speciality.NameOfSpeciality,
                        Department = _departmentManager.GetById(departmentId).NameOfDepartment
                    };
                    specialities.Add(specialityViewModel);
                }
            }

            return View(specialities);
        }
        
        public ActionResult Create()
        {
            ViewBag.Departments = _departmentManager.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SpecialityViewModel specialityViewModel)
        {
            if (ModelState.IsValid)
            {
                var speciality = new SpecialityDTO
                {
                    NameOfSpeciality = specialityViewModel.NameOfSpeciality,
                    DepartmentId = _departmentManager.GetAll().Where(t => t.NameOfDepartment.Equals(specialityViewModel.Department)).ToList().First().Id
                };
                _specialityManager.Create(speciality);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var speciality = _specialityManager.GetById(id);
            var specialityViewModel = new SpecialityViewModel
            {
                Id = speciality.Id,
                NameOfSpeciality = speciality.NameOfSpeciality,
                Department = _departmentManager.GetById(speciality.DepartmentId).NameOfDepartment
            };
            ViewBag.Departments = _departmentManager.GetAll();
            return View(specialityViewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, SpecialityViewModel specialityViewModel)
        {
            if (ModelState.IsValid)
            {
                var departmentId = _departmentManager.GetAll().Where(t => t.NameOfDepartment.Equals(specialityViewModel.Department)).ToList()
                    .First().Id;
                var speciality = new SpecialityDTO
                {
                    Id = specialityViewModel.Id,
                    NameOfSpeciality = specialityViewModel.NameOfSpeciality,
                    DepartmentId = departmentId
                };
                _specialityManager.Update(speciality);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        { 
            var speciality = _specialityManager.GetById(id);
            return View(speciality);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _specialityManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
 
    }
}