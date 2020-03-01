using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;
using BLL.Interfaces;
using Entities.DTOModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentsController: Controller
    {
        private readonly IManager<StudentDTO>_studentManager;
        private readonly IManager<GroupDTO> _groupManager;

        public StudentsController(IManager<StudentDTO> studentManager, IManager<GroupDTO> groupManager)
        {
            _studentManager = studentManager;
            _groupManager = groupManager;
        }
        public ActionResult Index(string searchString)
        {
            var students = new List<StudentViewModel>();
            if (String.IsNullOrEmpty(searchString))
            {
                foreach (var student in _studentManager.GetAll())
                {
                    var group = _groupManager.GetById(student.GroupId).NameOfGroup;
                    var studentViewModel = new StudentViewModel
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Address = student.Address,
                        Phone = student.Phone,
                        DateOfBirth = student.DateOfBirth,
                        Group = group
                    };
                    students.Add(studentViewModel);
                }
            }
            else
            {
                var groupId = _groupManager.GetAll().Where(t => t.NameOfGroup.Equals(searchString)).ToList()
                    .First().Id;
                foreach (var student in _studentManager.GetAll().Where(t => t.GroupId.Equals(groupId)).ToList())
                {
                    var studentViewModel = new StudentViewModel
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Address = student.Address,
                        Phone = student.Phone,
                        DateOfBirth = student.DateOfBirth,
                        Group = _groupManager.GetById(groupId).NameOfGroup
                    };
                    students.Add(studentViewModel);
                }
            }
            return View(students);
        }
        
        public ActionResult Create()
        {
            ViewBag.Groups = _groupManager.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var student = new StudentDTO
                {
                    FirstName = studentViewModel.FirstName,
                    LastName = studentViewModel.LastName,
                    Address = studentViewModel.Address,
                    Phone = studentViewModel.Phone,
                    DateOfBirth = studentViewModel.DateOfBirth,
                    GroupId = _groupManager.GetAll().Where(t => t.NameOfGroup.Equals(studentViewModel.Group)).ToList().First().Id
                };
                _studentManager.Create(student);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var student = _studentManager.GetById(id);
            var studentViewModel = new StudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address = student.Address,
                Phone = student.Phone,
                DateOfBirth = student.DateOfBirth,
                Group = _groupManager.GetById(student.GroupId).NameOfGroup
            };
            ViewBag.Groups = _groupManager.GetAll();
            return View(studentViewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var groupId = _groupManager.GetAll().Where(t => t.NameOfGroup.Equals(studentViewModel.Group)).ToList()
                    .First().Id;
                var student = new StudentDTO
                {
                    Id = studentViewModel.Id,
                    FirstName = studentViewModel.FirstName,
                    LastName = studentViewModel.LastName,
                    Address = studentViewModel.Address,
                    Phone = studentViewModel.Phone,
                    DateOfBirth = studentViewModel.DateOfBirth,
                    GroupId = groupId
                };
                _studentManager.Update(student);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        { 
            var student = _studentManager.GetById(id);
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _studentManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
 
    }
}