using Microsoft.AspNetCore.Mvc;
using SchoolIMgmt.Domain.Entities;
using SchoolIMgmt.Interfaces;
using SchoolIMgmt.Migrations;

namespace SchoolIMgmt.Controllers
{
    public class StudentsController : Controller
    {


        private readonly IStudentService _service;
        public StudentsController(IStudentService service) => _service = service;

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Student student)
        {
            var students = await _service.GetAllAsync();
            return View(students);
        }


        [HttpGet]
        public IActionResult Create()
        {
   
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var student = await _service.GetByIdAsync(id);
        //    if (student == null) return NotFound();
        //    return View(student);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

       
    }
}
