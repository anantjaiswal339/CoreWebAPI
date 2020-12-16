using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreWebPortal.Models;
using CoreWebAPI.Infrastructure.Interfaces;
using CoreWebAPI.Infrastructure.Models;

namespace CoreWebPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentsRepository _studentsRepository;

        public HomeController(ILogger<HomeController> logger, IStudentsRepository studentsRepository)
        {
            _logger = logger;
            _studentsRepository = studentsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _studentsRepository.InsertStudent(model);
                TempData["ResponseMessage"] = "Record has been inserted successfully!";
                return RedirectToAction("Students");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {            
            var student = await _studentsRepository.GetStudent(id);
            if (student == null)
            {
                return View("_NotFoundPartial");
            }
            var model = new StudentCreateViewModel
            {
                StudentID = student.StudentID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                PhoneNumber = student.PhoneNumber
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.StudentID = id;
                await _studentsRepository.UpdateStudent(model);
                TempData["ResponseMessage"] = "Record has been updated successfully!";
                return RedirectToAction("Students");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            try
            {
                await _studentsRepository.DeleteStudent(studentId);
                return StatusCode(200, "Record has been delete successfully!");
            }
            catch
            {
                return StatusCode(500, "Failed to delete record!");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Students()
        {
            var students = await _studentsRepository.GetAllStudent();
            //The below mpaaing column wil be moved on business layer
            var model = students.Select(x => new StudentCreateViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                StudentID = x.StudentID,
                City = x.City,
                PhoneNumber = x.PhoneNumber
            }).ToList();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
