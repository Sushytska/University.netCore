using BLL.Interfaces;
using Entities.DTOModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class FacultiesController: Controller
    {
        private readonly IManager<FacultyDTO>_facultyManager;

        public FacultiesController(IManager<FacultyDTO> facultyManager)
        {
            _facultyManager = facultyManager;
        }
        public ActionResult Index()
        {
            return View(_facultyManager.GetAll());
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FacultyDTO faculty)
        {
            if (ModelState.IsValid)
            {
                _facultyManager.Create(faculty);
                return RedirectToAction("Index");
            }

            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var faculty = _facultyManager.GetById(id);
            return View(faculty);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, FacultyDTO faculty)
        {
            if (ModelState.IsValid)
            {
                _facultyManager.Update(faculty);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        { 
            var faculty = _facultyManager.GetById(id);
            return View(faculty);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _facultyManager.Delete(id);
            return RedirectToAction("Index");
        }
 
    }
}