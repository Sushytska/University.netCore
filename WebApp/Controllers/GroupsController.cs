using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using Entities.DTOModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GroupsController: Controller
    {
        private readonly IManager<GroupDTO>_groupManager;
        private readonly IManager<SpecialityDTO> _specialityManager;

        public GroupsController(IManager<GroupDTO> groupManager, IManager<SpecialityDTO> specialityManager)
        {
            _groupManager = groupManager;
            _specialityManager = specialityManager;
        }
        public ActionResult Index(string searchString)
        {
            var groups = new List<GroupViewModel>();
            if (String.IsNullOrEmpty(searchString))
            {
                foreach (var group in _groupManager.GetAll())
                {
                    var speciality = _specialityManager.GetById(group.SpecialityId).NameOfSpeciality;
                    var groupViewModel = new GroupViewModel
                    {
                        Id = group.Id,
                        NameOfGroup = group.NameOfGroup,
                        Speciality = speciality
                    };
                    groups.Add(groupViewModel);
                }
            }
            else
            {
                var specialityId = _specialityManager.GetAll().Where(t => t.NameOfSpeciality.Equals(searchString)).ToList()
                    .First().Id;
                foreach (var group in _groupManager.GetAll().Where(t => t.SpecialityId.Equals(specialityId)).ToList())
                {
                    var groupViewModel = new GroupViewModel
                    {
                        Id = group.Id,
                        NameOfGroup = group.NameOfGroup,
                        Speciality = _specialityManager.GetById(specialityId).NameOfSpeciality
                    };
                    groups.Add(groupViewModel);
                }
            }
            return View(groups);
        }
        
        public ActionResult Create()
        {
            ViewBag.Specialities = _specialityManager.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                var group = new GroupDTO
                {
                    NameOfGroup = groupViewModel.NameOfGroup,
                    SpecialityId = _specialityManager.GetAll().Where(t => t.NameOfSpeciality.Equals(groupViewModel.Speciality)).ToList().First().Id
                };
                _groupManager.Create(group);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var group = _groupManager.GetById(id);
            var groupViewModel = new GroupViewModel
            {
                Id = group.Id,
                NameOfGroup = group.NameOfGroup,
                Speciality = _specialityManager.GetById(group.SpecialityId).NameOfSpeciality
            };
            ViewBag.Specialities = _specialityManager.GetAll();
            return View(groupViewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                var specialityId = _specialityManager.GetAll().Where(t => t.NameOfSpeciality.Equals(groupViewModel.Speciality)).ToList()
                    .First().Id;
                var group = new GroupDTO
                {
                    Id = groupViewModel.Id,
                    NameOfGroup = groupViewModel.NameOfGroup,
                    SpecialityId = specialityId
                };
                _groupManager.Update(group);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        { 
            var group = _groupManager.GetById(id);
            return View(group);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _groupManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
 
    }
}