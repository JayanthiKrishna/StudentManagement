using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SchoolIMgmt.Domain.Entities;
using SchoolIMgmt.Interfaces;
using SchoolIMgmt.Migrations;
using SchoolIMgmt.Models;

namespace SchoolIMgmt.Controllers
{
    public class StudentsController : Controller
    {


        private readonly IStudentService _service;
        private readonly IQualificationService _Qservice;

        public StudentsController(IStudentService service, IQualificationService Qservice)
        {
            _service = service;
            _Qservice = Qservice;
        }

       

        [HttpGet]
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
                await _service.AddAsync(student);
                return RedirectToAction(nameof(Index));
            
          
        }

       
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(loginmodel model)
        {
            string p = "Abc@1234";
            if(model.UserName == "Admin")
            {
                if ((model.Password == p))
                {
                    return RedirectToAction("Students", "Create");
                }
            }
            

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            
                await _service.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            
            
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Student student)
        {

            await _service.DeleteAsync(student.Id);
            return RedirectToAction(nameof(Index));


        }






       

    }
}
