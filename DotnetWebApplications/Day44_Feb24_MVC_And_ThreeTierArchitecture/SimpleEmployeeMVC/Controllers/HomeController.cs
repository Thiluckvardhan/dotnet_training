using Microsoft.AspNetCore.Mvc;
using SimpleEmployeeMVC.Models;
using System.Diagnostics;

namespace SimpleEmployeeMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("../EmployeeViews/AddEmployeeView");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
