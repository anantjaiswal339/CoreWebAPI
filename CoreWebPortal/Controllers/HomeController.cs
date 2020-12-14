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
