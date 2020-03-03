using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityServer3.Core.ViewModels;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }


        //     private IUniversityService _universityService;
        //
        //     public HomeController(IUniversityService serv)
        //     {
        //         _universityService = serv;
        //     }
        //
        //     public ActionResult Index()
        //     {
        //         IEnumerable<FacultyDTO> facultyDtos = _universityService.GetFaculties();
        //         var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FacultyDTO, FacultyViewModel>()).CreateMapper();
        //         var faculties = mapper.Map<IEnumerable<FacultyDTO>, List<FacultyViewModel>>(facultyDtos);
        //         return View(faculties);
        //     }
        //
        //     public ActionResult MakeDepartment(int? id)
        //     {
        //         try
        //         {
        //             FacultyDTO faculty = _universityService.GetFaculty(id);
        //             var department = new DepartmentViewModel { FacultyId = faculty.Id };
        //              
        //             return View(department);
        //         }
        //         catch (ValidationException ex)
        //         {
        //             return Content(ex.Message);
        //         }
        //     }
        //     [HttpPost]
        //     public ActionResult MakeDepartment(DepartmentViewModel departmentViewModel)
        //     {
        //         try
        //         {
        //             var departmentDto = new DepartmentDTO{ FacultyId = departmentViewModel.FacultyId, NameOfDepartment = departmentViewModel.NameOfDepartment};
        //             _universityService.MakeDepartment(departmentDto);
        //             return Content("<h2>Відділ успішно зроблений</h2>");
        //         }
        //         catch (ValidationException ex)
        //         {
        //             ModelState.AddModelError(ex.Property, ex.Message);
        //         }
        //
        //         return View(departmentViewModel);
        //     }
        //     protected override void Dispose(bool disposing)
        //     {
        //         _universityService.Dispose();
        //         base.Dispose(disposing);
        //     }
        // }
    }
}