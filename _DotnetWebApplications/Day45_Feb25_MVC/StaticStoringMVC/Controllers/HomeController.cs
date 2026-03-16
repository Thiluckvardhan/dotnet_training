using Microsoft.AspNetCore.Mvc;
using StaticStoringMVC.Data;
using StaticStoringMVC.Models;
using System.Diagnostics;

namespace StaticStoringMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("../Students/AddStudent");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StudentData(Student student)
        {
            StudentRepository.Students.Add(student);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
