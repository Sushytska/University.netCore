using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities.DataContext;
using Entities.DTOModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IManager<DepartmentDTO>_departmentManager;
        private readonly IManager<FacultyDTO>_facultyManager;
        private UniversityContext _context;
        public DepartmentsController(IManager<DepartmentDTO> departmentManager, IManager<FacultyDTO> facultyManager)
        {
            _departmentManager = departmentManager;
            _facultyManager = facultyManager;
        }
        public ActionResult Index(string searchString)
        {
            var departments = new List<DepartmentViewModel>();
            if (String.IsNullOrEmpty(searchString))
            {
                foreach (var department in _departmentManager.GetAll())
                {
                    var facullty = _facultyManager.GetById(department.FacultyId).NameOfFaculty;
                    var departmentViewModel = new DepartmentViewModel
                    {
                        Id = department.Id,
                        NameOfDepartment = department.NameOfDepartment,
                        Faculty = facullty
                    };
                    departments.Add(departmentViewModel);
                }
            }
            else
            {
                var facultyId = _facultyManager.GetAll().Where(t => t.NameOfFaculty.Equals(searchString)).ToList()
                                    .First().Id;
                foreach (var department in _departmentManager.GetAll().Where(t => t.FacultyId.Equals(facultyId)).ToList())
                {
                    var departmentViewModel = new DepartmentViewModel
                    {
                        Id = department.Id,
                        NameOfDepartment = department.NameOfDepartment,
                        Faculty = _facultyManager.GetById(facultyId).NameOfFaculty
                    };
                    departments.Add(departmentViewModel);
                }
            }
            return View(departments);
        }
        
        public ActionResult Create()
        {
            ViewBag.Faculties = _facultyManager.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var department = new DepartmentDTO
                {
                    NameOfDepartment = departmentViewModel.NameOfDepartment,
                    FacultyId = _facultyManager.GetAll().Where(t => t.NameOfFaculty.Equals(departmentViewModel.Faculty)).ToList().First().Id
                };
                _departmentManager.Create(department);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var department = _departmentManager.GetById(id);
            var departmentViewModel = new DepartmentViewModel
            {
                Id = department.Id,
                NameOfDepartment = department.NameOfDepartment,
                Faculty = _facultyManager.GetById(department.FacultyId).NameOfFaculty
            };
            ViewBag.Faculties = _facultyManager.GetAll();
            return View(departmentViewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var facultyId = _facultyManager.GetAll().Where(t => t.NameOfFaculty.Equals(departmentViewModel.Faculty)).ToList()
                    .First().Id;
                var department = new DepartmentDTO
                {
                    Id = departmentViewModel.Id,
                    NameOfDepartment = departmentViewModel.NameOfDepartment,
                    FacultyId = facultyId
                };
                _departmentManager.Update(department);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        { 
            var department = _departmentManager.GetById(id);
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _departmentManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}