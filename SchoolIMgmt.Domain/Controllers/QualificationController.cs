
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SchoolIMgmt.Domain.Entities;
using SchoolIMgmt.Interfaces;
using SchoolIMgmt.Migrations;
using SchoolIMgmt.Models;

namespace SchoolIMgmt.Controllers
{
    public class QualificationController : Controller
    {

        private readonly IStudentService _Sservice;
        private readonly IQualificationService _service;
        private readonly AppDbContext _context;

        public QualificationController(IStudentService Sservice, IQualificationService service ,AppDbContext context)
        {
            _service = service;
            _Sservice = Sservice;
            _context = context;
        }




        [HttpGet]
        public async Task<IActionResult> Index(Qualification student)
        {
            var students = await _service.GetAllQAsync();
            return View(students);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var students = await _context.Students.ToListAsync();
            ViewBag.Student = new SelectList(students, "Id", "FirstName");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Qualification student)
        {
            await _service.AddQAsync(student);
            return RedirectToAction(nameof(Index));


        }


       

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Student = await _context.Students.ToListAsync();
            var student = await _service.GetByIdQAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Qualification student)
        {

            await _service.UpdateQAsync(student);
            return RedirectToAction(nameof(Index));


        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetByIdQAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Qualification student)
        {

            await _service.DeleteQAsync(student.Id);
            return RedirectToAction(nameof(Index));


        }






       

    }
}
